namespace YuriyGuts.WinFormsAutoTabOrder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlBottomPanel = new System.Windows.Forms.Panel();
            this.pnlThresholdEditorContainer = new System.Windows.Forms.Panel();
            this.thresholdEditor = new System.Windows.Forms.NumericUpDown();
            this.lblThresholdHint = new System.Windows.Forms.Label();
            this.chkApplyToChildContainers = new System.Windows.Forms.CheckBox();
            this.pnlOKButtonContainer = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnlButtonSpacer = new System.Windows.Forms.Panel();
            this.pnlCancelButtonContainer = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.containerControlTree = new System.Windows.Forms.TreeView();
            this.treeImageList = new System.Windows.Forms.ImageList(this.components);
            this.lblHint = new System.Windows.Forms.Label();
            this.affectedControlTree = new System.Windows.Forms.TreeView();
            this.lblAffectedControlsHint = new System.Windows.Forms.Label();
            this.pnlBottonButtonSpacer = new System.Windows.Forms.Panel();
            this.pnlBottomPanel.SuspendLayout();
            this.pnlThresholdEditorContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdEditor)).BeginInit();
            this.pnlOKButtonContainer.SuspendLayout();
            this.pnlCancelButtonContainer.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottomPanel
            // 
            this.pnlBottomPanel.Controls.Add(this.pnlThresholdEditorContainer);
            this.pnlBottomPanel.Controls.Add(this.lblThresholdHint);
            this.pnlBottomPanel.Controls.Add(this.chkApplyToChildContainers);
            this.pnlBottomPanel.Controls.Add(this.pnlOKButtonContainer);
            this.pnlBottomPanel.Controls.Add(this.pnlButtonSpacer);
            this.pnlBottomPanel.Controls.Add(this.pnlCancelButtonContainer);
            this.pnlBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomPanel.Location = new System.Drawing.Point(10, 377);
            this.pnlBottomPanel.Name = "pnlBottomPanel";
            this.pnlBottomPanel.Size = new System.Drawing.Size(714, 25);
            this.pnlBottomPanel.TabIndex = 0;
            // 
            // pnlThresholdEditorContainer
            // 
            this.pnlThresholdEditorContainer.Controls.Add(this.thresholdEditor);
            this.pnlThresholdEditorContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlThresholdEditorContainer.Location = new System.Drawing.Point(437, 0);
            this.pnlThresholdEditorContainer.Name = "pnlThresholdEditorContainer";
            this.pnlThresholdEditorContainer.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlThresholdEditorContainer.Size = new System.Drawing.Size(48, 25);
            this.pnlThresholdEditorContainer.TabIndex = 2;
            // 
            // thresholdEditor
            // 
            this.thresholdEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thresholdEditor.Location = new System.Drawing.Point(0, 3);
            this.thresholdEditor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.thresholdEditor.Name = "thresholdEditor";
            this.thresholdEditor.Size = new System.Drawing.Size(48, 21);
            this.thresholdEditor.TabIndex = 0;
            this.thresholdEditor.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblThresholdHint
            // 
            this.lblThresholdHint.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblThresholdHint.Location = new System.Drawing.Point(285, 0);
            this.lblThresholdHint.Name = "lblThresholdHint";
            this.lblThresholdHint.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lblThresholdHint.Size = new System.Drawing.Size(152, 25);
            this.lblThresholdHint.TabIndex = 1;
            this.lblThresholdHint.Text = "Y misalignment threshold (px):";
            this.lblThresholdHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkApplyToChildContainers
            // 
            this.chkApplyToChildContainers.Checked = true;
            this.chkApplyToChildContainers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApplyToChildContainers.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkApplyToChildContainers.Location = new System.Drawing.Point(0, 0);
            this.chkApplyToChildContainers.Name = "chkApplyToChildContainers";
            this.chkApplyToChildContainers.Size = new System.Drawing.Size(285, 25);
            this.chkApplyToChildContainers.TabIndex = 0;
            this.chkApplyToChildContainers.Text = "Auto-arrange controls in child containers as well";
            this.chkApplyToChildContainers.UseVisualStyleBackColor = true;
            this.chkApplyToChildContainers.CheckedChanged += new System.EventHandler(this.chkApplyToChildContainers_CheckedChanged);
            // 
            // pnlOKButtonContainer
            // 
            this.pnlOKButtonContainer.Controls.Add(this.btnOK);
            this.pnlOKButtonContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlOKButtonContainer.Location = new System.Drawing.Point(556, 0);
            this.pnlOKButtonContainer.Name = "pnlOKButtonContainer";
            this.pnlOKButtonContainer.Size = new System.Drawing.Size(75, 25);
            this.pnlOKButtonContainer.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Location = new System.Drawing.Point(0, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlButtonSpacer
            // 
            this.pnlButtonSpacer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtonSpacer.Location = new System.Drawing.Point(631, 0);
            this.pnlButtonSpacer.Name = "pnlButtonSpacer";
            this.pnlButtonSpacer.Size = new System.Drawing.Size(8, 25);
            this.pnlButtonSpacer.TabIndex = 6;
            // 
            // pnlCancelButtonContainer
            // 
            this.pnlCancelButtonContainer.Controls.Add(this.btnCancel);
            this.pnlCancelButtonContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCancelButtonContainer.Location = new System.Drawing.Point(639, 0);
            this.pnlCancelButtonContainer.Name = "pnlCancelButtonContainer";
            this.pnlCancelButtonContainer.Size = new System.Drawing.Size(75, 25);
            this.pnlCancelButtonContainer.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.splitContainer1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(10, 10);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(714, 359);
            this.pnlContent.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.containerControlTree);
            this.splitContainer1.Panel1.Controls.Add(this.lblHint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.affectedControlTree);
            this.splitContainer1.Panel2.Controls.Add(this.lblAffectedControlsHint);
            this.splitContainer1.Size = new System.Drawing.Size(714, 359);
            this.splitContainer1.SplitterDistance = 426;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 2;
            // 
            // containerControlTree
            // 
            this.containerControlTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerControlTree.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.containerControlTree.HideSelection = false;
            this.containerControlTree.Indent = 20;
            this.containerControlTree.ItemHeight = 19;
            this.containerControlTree.Location = new System.Drawing.Point(0, 23);
            this.containerControlTree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.containerControlTree.Name = "containerControlTree";
            this.containerControlTree.Size = new System.Drawing.Size(426, 336);
            this.containerControlTree.StateImageList = this.treeImageList;
            this.containerControlTree.TabIndex = 1;
            this.containerControlTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.containerControlTree_AfterSelect);
            // 
            // treeImageList
            // 
            this.treeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImageList.ImageStream")));
            this.treeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImageList.Images.SetKeyName(0, "RootControl.png");
            this.treeImageList.Images.SetKeyName(1, "ParentControl.png");
            this.treeImageList.Images.SetKeyName(2, "ChildControl.png");
            // 
            // lblHint
            // 
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHint.Location = new System.Drawing.Point(0, 0);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(426, 23);
            this.lblHint.TabIndex = 0;
            this.lblHint.Text = "Select a container:";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // affectedControlTree
            // 
            this.affectedControlTree.BackColor = System.Drawing.SystemColors.Control;
            this.affectedControlTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.affectedControlTree.Indent = 20;
            this.affectedControlTree.Location = new System.Drawing.Point(0, 23);
            this.affectedControlTree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.affectedControlTree.Name = "affectedControlTree";
            this.affectedControlTree.Size = new System.Drawing.Size(280, 336);
            this.affectedControlTree.StateImageList = this.treeImageList;
            this.affectedControlTree.TabIndex = 1;
            // 
            // lblAffectedControlsHint
            // 
            this.lblAffectedControlsHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAffectedControlsHint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAffectedControlsHint.Location = new System.Drawing.Point(0, 0);
            this.lblAffectedControlsHint.Name = "lblAffectedControlsHint";
            this.lblAffectedControlsHint.Size = new System.Drawing.Size(280, 23);
            this.lblAffectedControlsHint.TabIndex = 0;
            this.lblAffectedControlsHint.Text = "Controls that will be affected:";
            this.lblAffectedControlsHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBottonButtonSpacer
            // 
            this.pnlBottonButtonSpacer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottonButtonSpacer.Location = new System.Drawing.Point(10, 369);
            this.pnlBottonButtonSpacer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBottonButtonSpacer.Name = "pnlBottonButtonSpacer";
            this.pnlBottonButtonSpacer.Size = new System.Drawing.Size(714, 8);
            this.pnlBottonButtonSpacer.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(734, 412);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlBottonButtonSpacer);
            this.Controls.Add(this.pnlBottomPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 350);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Auto Arrange Tab Order";
            this.pnlBottomPanel.ResumeLayout(false);
            this.pnlThresholdEditorContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.thresholdEditor)).EndInit();
            this.pnlOKButtonContainer.ResumeLayout(false);
            this.pnlCancelButtonContainer.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottomPanel;
        private System.Windows.Forms.Panel pnlOKButtonContainer;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel pnlButtonSpacer;
        private System.Windows.Forms.Panel pnlCancelButtonContainer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlBottonButtonSpacer;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.TreeView containerControlTree;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chkApplyToChildContainers;
        private System.Windows.Forms.Label lblAffectedControlsHint;
        private System.Windows.Forms.TreeView affectedControlTree;
        private System.Windows.Forms.Label lblThresholdHint;
        private System.Windows.Forms.NumericUpDown thresholdEditor;
        private System.Windows.Forms.Panel pnlThresholdEditorContainer;
        private System.Windows.Forms.ImageList treeImageList;

    }
}