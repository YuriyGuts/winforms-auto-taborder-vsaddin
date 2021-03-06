using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;
using Extensibility;
using Microsoft.VisualStudio.CommandBars;

namespace YuriyGuts.WinFormsAutoTabOrder
{
    /// <summary>The object for implementing an Add-in.</summary>
    /// <seealso class='IDTExtensibility2' />
    public class Connect : IDTExtensibility2, IDTCommandTarget
    {
        private DTE2 _applicationObject;
        private AddIn _addInInstance;

        private object[] contextGUIDs;
        private CommandBars commandBars;
        private CommandBar mainMenuBar;
        private Command autoArrangeCommand;

        private const string eventLogSource = "Visual Studio: YuriyGuts.WinFormsAutoTabOrderAddIn";
        private const string commandPrefix = "YuriyGuts.WinFormsAutoTabOrder.Connect.";
        private const string autoArrangeCommandName = "AutoArrangeTabOrder";

        #region IDTExtensibility2 members

        /// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
        /// <param name='application'>Root object of the host application.</param>
        /// <param name='connectMode'>Describes how the Add-in is being loaded.</param>
        /// <param name='addInInst'>Object representing this Add-in.</param>
        /// <param name='custom'>Custom parameters.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            _applicationObject = (DTE2)application;
            _addInInstance = (AddIn)addInInst;

            if (connectMode == ext_ConnectMode.ext_cm_Startup
              || connectMode == ext_ConnectMode.ext_cm_AfterStartup
              || connectMode == ext_ConnectMode.ext_cm_UISetup)
            {
                Initialize();
                CreateAutoArrangeCommand();
                CreateFormatMenuAutoArrangeItem();
                CreateLayoutToolBarAutoArrangeItem();
            }
        }

        /// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
        /// <param name='disconnectMode'>Describes how the Add-in is being unloaded.</param>
        /// <param name='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
        {
            CleanUp();
        }

        /// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
        /// <param name='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />		
        public void OnAddInsUpdate(ref Array custom)
        {
        }

        /// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
        /// <param name='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnStartupComplete(ref Array custom)
        {
        }

        /// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
        /// <param name='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnBeginShutdown(ref Array custom)
        {
        }

        #endregion IDTExtensibility2 members

        #region IDTCommandTarget members

        public void QueryStatus(string CmdName, vsCommandStatusTextWanted NeededText, ref vsCommandStatus StatusOption, ref object CommandText)
        {
            if (NeededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
            {
                if (CmdName == commandPrefix + autoArrangeCommandName)
                {
                    StatusOption = vsCommandStatus.vsCommandStatusSupported;
                    if (IsWinFormsDesignerActive())
                    {
                        StatusOption |= vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        StatusOption |= vsCommandStatus.vsCommandStatusInvisible;
                    }
                    return;
                }
            }
        }

        public void Exec(string CmdName, vsCommandExecOption ExecuteOption, ref object VariantIn, ref object VariantOut, ref bool Handled)
        {
            Handled = false;
            if (ExecuteOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
            {
                if (CmdName == commandPrefix + autoArrangeCommandName)
                {
                    ExecuteAutoArrangeCommand();
                    Handled = true;
                    return;
                }
            }
        }

        #endregion IDTCommandTarget members

        private void Initialize()
        {
            contextGUIDs = new object[] { };
            commandBars = (CommandBars)_applicationObject.CommandBars;
            mainMenuBar = commandBars["MenuBar"];
        }

        private void CreateAutoArrangeCommand()
        {
            Commands2 commands = (Commands2)_applicationObject.Commands;
            autoArrangeCommand = commands.AddNamedCommand2
              (
                _addInInstance,
                autoArrangeCommandName,
                "Auto Arrange Tab Order...",
                "Automatically fills the TabIndex property of every control according to its location",
                true,
                512,
                ref contextGUIDs,
                (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled,
                (int)vsCommandStyle.vsCommandStylePictAndText,
                vsCommandControlType.vsCommandControlTypeButton
              );
        }

        private void CreateFormatMenuAutoArrangeItem()
        {
            try
            {
                string formatMenuName = GetMenuItemName("Format");
                CommandBarPopup formatMenuItem = (CommandBarPopup)mainMenuBar.Controls[formatMenuName];
                if (autoArrangeCommand != null && formatMenuItem != null)
                {
                    autoArrangeCommand.AddControl(formatMenuItem.CommandBar, formatMenuItem.CommandBar.Controls.Count + 1);
                }
            }
            catch (Exception ex)
            {
                LogError("Failed to create the Auto Arrange menu item: ", ex);
            }
        }

        private void CreateLayoutToolBarAutoArrangeItem()
        {
            try
            {
                CommandBar layoutToolBar = commandBars["Layout"];
                autoArrangeCommand.AddControl(layoutToolBar, layoutToolBar.Controls.Count + 1);
            }
            catch (Exception ex)
            {
                LogError("Failed to create the Auto Arrange toolbar item: ", ex);
            }
        }

        private void CleanUp()
        {
            DeleteAutoArrangeCommand();
        }

        private void DeleteAutoArrangeCommand()
        {
            try
            {
                if (autoArrangeCommand != null)
                {
                    autoArrangeCommand.Delete();
                }
            }
            catch (Exception ex)
            {
                LogError("Failed to delete the Auto Arrange command: ", ex);
            }
        }

        private void ExecuteAutoArrangeCommand()
        {
            try
            {
                if (IsWinFormsDesignerActive())
                {
                    MainForm.Execute(GetDesignerHost());
                }
                else
                {
                    throw new InvalidOperationException("Windows Forms Designer is not active.");
                }
            }
            catch (Exception ex)
            {
                LogError("Failed to execute the Auto Arrange command: ", ex);
                MessageBox.Show("Auto arrangement failed: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetMenuItemName(string englishName)
        {
            string menuItemName;
            ResourceManager resourceManager = new ResourceManager("YuriyGuts.WinFormsAutoTabOrder.CommandBar", Assembly.GetExecutingAssembly());
            CultureInfo cultureInfo = new CultureInfo(_applicationObject.LocaleID);

            try
            {
                string resourcePrefix = cultureInfo.TwoLetterISOLanguageName != "zh"
                  ? cultureInfo.TwoLetterISOLanguageName
                  : cultureInfo.Name;

                string resourceName = string.Concat(resourcePrefix, englishName);
                menuItemName = resourceManager.GetString(resourceName);
            }
            catch
            {
                menuItemName = englishName;
            }

            return menuItemName;
        }

        private IDesignerHost GetDesignerHost()
        {
            return _applicationObject.ActiveWindow.Object as IDesignerHost;
        }

        private bool IsWinFormsDesignerActive()
        {
            IDesignerHost designerHost = GetDesignerHost();
            bool isDesignerActive = (designerHost != null && designerHost.RootComponent is Control);
            return isDesignerActive;
        }

        private static void LogError(string message, Exception exception)
        {
            try
            {
                EventLog.WriteEntry(eventLogSource, message + exception, EventLogEntryType.Error);
            }
            catch
            {
                Trace.WriteLine(message + exception);
            }
        }
    }
}