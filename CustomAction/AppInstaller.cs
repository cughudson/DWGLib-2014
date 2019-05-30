using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace CustomAction
{
    [RunInstaller(true)]
    public partial class AppInstaller : System.Configuration.Install.Installer
    {
        string PluginPath = "";
        string AppName = "CSCECDECLib";
        string DestFolder = @"%PROGRAMFILES%\Autodesk\ApplicationPlugins";
        string AutoCADRootKey = 
        public AppInstaller()
        {
            InitializeComponent();
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            RegeisterPlugin();
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }
        private void RegeisterPlugin()
        {

            RegistryKey AcadPluginKey = GetAcadAppKey(true);
            RegistryKey AcadPluginInspectorKey = AcadPluginKey.CreateSubKey("CSCECDECLib");
            try
            {

                AcadPluginInspectorKey.SetValue("DESCRIPTION", "CSCECDEC DWG Library", Microsoft.Win32.RegistryValueKind.String);
                AcadPluginInspectorKey.SetValue("LOADCTRLS", 2, Microsoft.Win32.RegistryValueKind.DWord);
                AcadPluginInspectorKey.SetValue("LOADER", PluginPath, Microsoft.Win32.RegistryValueKind.String);
                AcadPluginInspectorKey.SetValue("MANAGED", 1, Microsoft.Win32.RegistryValueKind.DWord);
            }
            catch
            {

            }
            AcadPluginKey.Close();
        }
        private RegistryKey GetAcadAppKey(bool forWrite)
        {
            RegistryKey AcadKey = Registry.CurrentUser.OpenSubKey(Autodesk.AutoCAD.DatabaseServices.HostApplicationServices.Current.UserRegistryProductRootKey);
            return AcadKey.OpenSubKey("Application", forWrite);
        }
    }
}
