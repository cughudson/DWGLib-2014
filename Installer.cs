using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using DWGLib.Dialog;
using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Windows.Forms;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;
namespace DWGLib.init
{
    public class PluginInit:IExtensionApplication
    {
        //插件加载的时候会运行下面的代码
        string PluginPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string RootPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\";
        string AppName = "CSCECDECLib";
        string DEFAULTBLOCKPATH = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resource\library\StdBlock";
        string DEFAULTSYSPATH = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resource\library\StdSys";
        Editor ed = AcadApp.DocumentManager.MdiActiveDocument.Editor;
        string ToolbarPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\gui.cuix";
        System.Windows.Forms.Timer Tim = new Timer();
        int Signal = 1;
        string EncryString = Environment.MachineName + "cscecdec";
        void IExtensionApplication.Initialize()
        {
            // bool IsActive = GetIsActiveValue(Url);
            InilizationSetting();
            CreateToolbar();
            ed.WriteMessage("\n中建深装幕墙图库插件加载成功");
            /*
            string Code = GetMd5Hash(MD5.Create(), EncryString);
            if(Properties.Settings.Default.verifycode != Code)
            {
                RegisterSoftware();
            }else
            {
                CreateToolbar();
                ed.WriteMessage("\n中建深装幕墙图库插件加载成功");
            }*/
        }
        /// <summary>
        /// 设置系统运行的时候所必须的参数
        /// </summary>
        private void RegisterSoftware()
        {
            Register RegDialog = new Register();
            if (RegDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("注册成功");
                CreateToolbar();
                ed.WriteMessage("\n中建深装幕墙图库插件加载成功");
                return;
            }
            else
            {
                MessageBox.Show("注册失败");
                ed.WriteMessage("\n中建深装幕墙图库插件加载失败");
                return;
            }
        }
        void InilizationSetting()
        {
           //bool IsActive = GetIsActiveValue(Url);
           // Properties.Settings.Default.verifycode = IsActive;
            Properties.Settings.Default.StdBlockPath = DEFAULTBLOCKPATH;
            Properties.Settings.Default.StdSysPath = DEFAULTSYSPATH;
            Properties.Settings.Default.Save();
        }
        private string GetMd5Hash(MD5 md5Hash, string str)
        {
            byte[] data = md5Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();

        }
        /// <summary>
        /// 获取远程主机上的激活码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool GetIsActiveValue(string url)
        {
            try
            {
                WebRequest Request = WebRequest.Create(url);
                WebResponse Resp = Request.GetResponse();
                Stream s = Resp.GetResponseStream();
                StreamReader sr = new StreamReader(s);

                string ActiveStr = sr.ReadToEnd();
                try
                {
                    return Convert.ToBoolean(ActiveStr);
                }catch
                {
                    return true;
                }

            }catch(System.Exception ex)
            {
                AcadApp.ShowAlertDialog(ex.Message);
                return false;
            }
        }
        private void DocumentManager_DocumentLockModeChanged(object sender, Autodesk.AutoCAD.ApplicationServices.DocumentLockModeChangedEventArgs e)
        {
           if(e.GlobalCommandName.ToUpper() == "SAVE" || e.GlobalCommandName.ToUpper() == "SAVEAS")
            {
                 //Autodesk.AutoCAD.ApplicationServices.Application.Quit();
            }
        }

        private void Tim_Tick(object sender, EventArgs e)
        {
            if(Signal % 1836 == 0)
            {
                Tim.Stop();
                Autodesk.AutoCAD.ApplicationServices.Application.Quit();
            }
            Signal++;
            
        }
        [CommandMethod("regplugin")]
        public void Register()
        {
            try
            {
                System.Version Ver = Autodesk.AutoCAD.ApplicationServices.Application.Version;
                //版本低于2007的软件
                if (Ver.Major < 17)
                {
                    AcadApp.ShowAlertDialog("插件不适合当前CAD版本，请安装2008及以上版本的AutoCAD软件");
                }
                else
                {
                    this.RegeisterPlugin();
                }
            }
            catch (Autodesk.AutoCAD.Runtime.Exception Ex)
            {
                AcadApp.DocumentManager.MdiActiveDocument.Editor.WriteMessage("注册失败:" + Ex.Message);
            }
        }
        [CommandMethod("unregplugin")]
        public void UnRegister()
        {
            try
            {
                this.UnRegisterPlugin(AppName);
            }catch(Autodesk.AutoCAD.Runtime.Exception ex)
            {
                AcadApp.DocumentManager.MdiActiveDocument.Editor.WriteMessage("卸载失败" + ex.Message);
            }
        }
        private void RegeisterPlugin()
        {

            Microsoft.Win32.RegistryKey AcadPluginKey = this.GetAcadAppKey(true);
            if (AcadPluginKey != null)
            {
                Microsoft.Win32.RegistryKey AcadPluginInspectorKey = AcadPluginKey.CreateSubKey(AppName);
                AcadPluginInspectorKey.SetValue("DESCRIPTION", "CSCECDEC DWG Library", Microsoft.Win32.RegistryValueKind.String);
                AcadPluginInspectorKey.SetValue("LOADCTRLS", 2, Microsoft.Win32.RegistryValueKind.DWord);
                AcadPluginInspectorKey.SetValue("LOADER", PluginPath, Microsoft.Win32.RegistryValueKind.String);
                AcadPluginInspectorKey.SetValue("MANAGED", 1, Microsoft.Win32.RegistryValueKind.DWord);

                AcadPluginKey.Close();
                AcadApp.ShowAlertDialog("写入注册表成功，之后插件将在CAD每次重启时自动加载");
            }
            else
            {
                AcadApp.ShowAlertDialog("写入注册表失败");
                AcadPluginKey.Close();
            }
        }
        private void UnRegisterPlugin(string dname)
        {
           	Microsoft.Win32.RegistryKey AcadPluginKey = GetAcadAppKey(true);
            if(AcadPluginKey != null)
            {
                AcadPluginKey.DeleteSubKey(AppName);
                AcadPluginKey.Close();
                AcadApp.ShowAlertDialog("注册表删除成功");
            }
            else
            {
                AcadApp.ShowAlertDialog("注册表删除失败");
            }
           
        }
        private void DeleteDirectory(string Path)
        {
            if (!Directory.Exists(Path)) return;

        }
        private Microsoft.Win32.RegistryKey GetAcadAppKey(bool forWrite)
        {
            string User = Environment.UserDomainName + "\\" + Environment.UserName;
            string RootKey = Autodesk.AutoCAD.DatabaseServices.HostApplicationServices.Current.UserRegistryProductRootKey;
            Microsoft.Win32.RegistryKey AcadKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RootKey);
            RegistryAccessRule Role = new RegistryAccessRule(User, RegistryRights.WriteKey | RegistryRights.Delete | RegistryRights.ReadKey, AccessControlType.Allow);
            RegistrySecurity Rs = new RegistrySecurity();
            Rs.AddAccessRule(Role);
            Microsoft.Win32.RegistryKey AppKey = AcadKey.OpenSubKey("Applications", forWrite);
            if(AppKey == null)
            {
                try
                {
                    Microsoft.Win32.RegistryKey Key = AcadKey.CreateSubKey("Applications", RegistryKeyPermissionCheck.ReadWriteSubTree, Rs);
                    return Key;
                } catch(System.Exception Ex)
                {
                    AcadApp.ShowAlertDialog(Ex.Message + "注册失败。详情请查看软件的帮助文档");
                    return AppKey;
                }
            }else
            {
                return AppKey;
            }
        }
        public void CreateToolbar()
        {
            //动态的增加Toolbar
            string MainCUI = Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("MENUNAME") + ".cuix";

            Autodesk.AutoCAD.Customization.CustomizationSection cs = new Autodesk.AutoCAD.Customization.CustomizationSection(MainCUI);

            Autodesk.AutoCAD.Customization.PartialCuiFileCollection Pcfc = cs.PartialCuiFiles;
            if (Pcfc.Contains(ToolbarPath))
            {
                Autodesk.AutoCAD.ApplicationServices.Application.UnloadPartialMenu(ToolbarPath);
            }
            Autodesk.AutoCAD.ApplicationServices.Application.LoadPartialMenu(ToolbarPath);
        }

        void IExtensionApplication.Terminate()
        {
        }
    }

}
