using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace YuriyGuts.WinFormsAutoTabOrder
{
    public partial class MainForm : Form
    {
        private IDesignerHost designerHost;

        private IDesignerHost DesignerHost
        {
            get
            {
                return designerHost;
            }
            set
            {
                designerHost = value;
                LoadControlsFromDesigner();
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        public static void Execute(IDesignerHost designerHost)
        {
            using (MainForm form = new MainForm())
            {
                form.DesignerHost = designerHost;
                form.ShowDialog();
            }
        }

        private void LoadControlsFromDesigner()
        {
            containerControlTree.Nodes.Clear();
            affectedControlTree.Nodes.Clear();

            Control rootControl = DesignerHost.RootComponent as Control;
            if (rootControl == null)
            {
                return;
            }

            TreeNode rootNode = containerControlTree.Nodes.Add(GetNodeDisplayText(rootControl));
            rootNode.Tag = rootControl;
            rootNode.StateImageIndex = 0;
            LoadControlsIntoContainerNode(rootControl, rootNode);

            containerControlTree.ExpandAll();
            containerControlTree.SelectedNode = rootNode;
        }

        private void LoadControlsIntoContainerNode(Control container, TreeNode parentNode)
        {
            foreach (Control control in container.Controls)
            {
                if (control.HasChildren && control.Controls[0].Site != null)
                {
                    string nodeDisplayText = GetNodeDisplayText(control);
                    TreeNode node = parentNode.Nodes.Add(nodeDisplayText);
                    node.StateImageIndex = 1;
                    node.Tag = control;
                    LoadControlsIntoContainerNode(control, node);
                }
            }
        }

        private void RefreshAffectedControlTree()
        {
            affectedControlTree.Nodes.Clear();
            Control containerControl = containerControlTree.SelectedNode.Tag as Control;
            if (containerControl != null)
            {
                LoadControlsIntoAffectedNode(containerControl, null);
            }
            affectedControlTree.ExpandAll();
        }

        private void LoadControlsIntoAffectedNode(Control container, TreeNode parentNode)
        {
            foreach (Control control in container.Controls)
            {
                if (control.Site != null)
                {
                    string nodeDisplayText = GetNodeDisplayText(control);
                    TreeNode node = (parentNode != null ? parentNode.Nodes : affectedControlTree.Nodes).Add(nodeDisplayText);
                    if (node.Parent != null)
                    {
                        node.Parent.StateImageIndex = 1;
                    }
                    node.StateImageIndex = 2;
                    node.Tag = control;

                    if (chkApplyToChildContainers.Checked)
                    {
                        LoadControlsIntoAffectedNode(control, node);
                    }
                }
            }
        }

        private static string GetNodeDisplayText(Control control)
        {
            string result;
            if (!string.IsNullOrEmpty(control.Text))
            {
                result = string.Format("{0}   [{1}, \"{2}\"]", control.Name, control.GetType().Name, control.Text);
            }
            else
            {
                result = string.Format("{0}   [{1}]", control.Name, control.GetType().Name);
            }
            return result;
        }

        private void AutoArrangeTabOrder(Control parentControl, int thresholdY, bool applyToChildContainers)
        {
            // Splitting the controls into virtual rows.
            List<List<Control>> rows = new List<List<Control>>();

            foreach (Control control in parentControl.Controls)
            {
                // Determining the index of the virtual row to add the current control to.
                int rowIndex = -1;
                for (int i = 0; i < rows.Count; i++)
                {
                    if (ControlsBelongToSameRow(rows[i][0], control, thresholdY))
                    {
                        rowIndex = i;
                        break;
                    }
                }

                // No appropriate rows are found.
                if (rowIndex < 0)
                {
                    // Determining the index for the new row.
                    int newRowIndex = rowIndex = Math.Max(0, rows.Count);
                    for (int i = 0; i < rows.Count; i++)
                    {
                        if (rows[i][0].Top > control.Top + thresholdY)
                        {
                            rowIndex = newRowIndex = i;
                            break;
                        }
                    }
                    rows.Insert(newRowIndex, new List<Control>());
                }

                int controlIndex = Math.Max(0, rows[rowIndex].Count);
                // Determining the index within the row.
                for (int i = 0; i < rows[rowIndex].Count; i++)
                {
                    if (rows[rowIndex][i].Left > control.Left)
                    {
                        controlIndex = i;
                        break;
                    }
                }

                rows[rowIndex].Insert(controlIndex, control);
            }

            // Assigning the proper TabIndex value to all controls.
            int currentTabIndex = 0;
            foreach (List<Control> row in rows)
            {
                foreach (Control rowItem in row)
                {
                    PropertyDescriptor descriptor = TypeDescriptor.GetProperties(rowItem)["TabIndex"];
                    descriptor.SetValue(rowItem, currentTabIndex++);
                }
            }

            // Recursively processing all children.
            if (applyToChildContainers)
            {
                foreach (Control control in parentControl.Controls)
                {
                    AutoArrangeTabOrder(control, thresholdY, true);
                }
            }
        }

        private bool ControlsBelongToSameRow(Control control1, Control control2, int thresholdY)
        {
            return Math.Abs(control1.Top - control2.Top) <= thresholdY;
        }

        private void Accept()
        {
            DesignerTransaction transaction = DesignerHost.CreateTransaction();
            TreeNode selectedNode = containerControlTree.SelectedNode;
            if (selectedNode != null)
            {
                Control container = selectedNode.Tag as Control;
                if (container != null)
                {
                    AutoArrangeTabOrder(container, (int)thresholdEditor.Value, chkApplyToChildContainers.Checked);
                }
            }
            transaction.Commit();

            CloseForm(DialogResult.OK);
        }

        private void Cancel()
        {
            CloseForm(DialogResult.Cancel);
        }

        private void CloseForm(DialogResult result)
        {
            DialogResult = result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Accept();
        }

        private void chkApplyToChildContainers_CheckedChanged(object sender, EventArgs e)
        {
            RefreshAffectedControlTree();
        }

        private void containerControlTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshAffectedControlTree();
        }
    }
}