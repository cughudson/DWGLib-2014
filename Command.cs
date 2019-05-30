
using Autodesk.AutoCAD.Runtime;
//using Microsoft.WindowsAPICodePack.Shell;

using DWGLib.Dialog;
using System;
using System.IO;
using System.Security.Cryptography;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;

namespace DWGLib.Command
{
    public class LibCommand
    {
        string EncryString = Environment.MachineName + "cscecdec";
        string HelpFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resource\help\Help.pdf";
        /// <summary>
        /// d打开帮助文件夹
        /// </summary>
        [CommandMethod("libhelp")]
        public void openHelpFolder()
        {
            try
            {
                System.Diagnostics.Process.Start(HelpFile);
            }catch(System.Exception ex)
            {
                AcadApp.ShowAlertDialog(ex.Message);
            }
            
        }
        [CommandMethod("libabout")]
        public void ShowAboutDialog()
        {
            AboutDlg _AboutDlg = new AboutDlg();
            AcadApp.ShowModalDialog(AcadApp.MainWindow.Handle,_AboutDlg);
        }
        // <summary>
        /// 用于缩略图处理
        /// </summary>
        [CommandMethod("thumnailprocess")]
        public void ShowProcessingDialog()
        {

            ThumnailProcessDlg thumnailProcessDlg = new ThumnailProcessDlg(0, false, "");
            thumnailProcessDlg.RootPath.Text = "这里显示CAD文件夹路径";
            AcadApp.ShowModalDialog(AcadApp.MainWindow.Handle,thumnailProcessDlg);

        }
        /// <summary>
        /// 用于设置
        /// </summary>
       // [CommandMethod("libsetting")]
        public void ShowlibsettingDialog()
        {

            SetttingDlg _SettingDlg = new SetttingDlg();
            AcadApp.ShowModalDialog(AcadApp.MainWindow.Handle,_SettingDlg);

        }
        /// <summary>
        /// 打开标准系统图库
        /// </summary>
        [CommandMethod("stdsys")]
        public void DwgStdSystem()
        {
            string _Path = Properties.Settings.Default.StdSysPath;
            /*
            string Code = GetMd5Hash(MD5.Create(), EncryString);
            if (Properties.Settings.Default.verifycode != Code)
            {
                AcadApp.DocumentManager.MdiActiveDocument.Editor.WriteMessage("未注册软件，请注册后使用");
                return;
            }
            */
            if (Directory.Exists(_Path))
            {
                LibaryDialog Diag = new LibaryDialog(_Path, "中建深装-标准节点图库", LibType.SysLib);
                AcadApp.ShowModelessDialog(Diag);

            }
            else
            {
                AcadApp.ShowAlertDialog(string.Format("路径:{0}不存在,请先设置正确的图库加载路径",_Path));
            }

        }
        /// <summary>
        /// 打开标准图块图库
        /// </summary>
        [CommandMethod("stdblock")]
        public void DwgStdBlock()
        {
            string _Path = Properties.Settings.Default.StdBlockPath;
            //string Code = GetMd5Hash(MD5.Create(), EncryString);
            /*
            if (Properties.Settings.Default.verifycode != Code)
            {
                AcadApp.DocumentManager.MdiActiveDocument.Editor.WriteMessage("未注册软件,请注册后再使用");
                return;
            }*/

            if (Directory.Exists(_Path))
            {
                LibaryDialog Diag = new LibaryDialog(_Path, "中建深装-标准图块图库", LibType.BlockLib);
                AcadApp.ShowModalDialog(Diag);
            }
            else
            {
                AcadApp.ShowAlertDialog(string.Format("路径:{0}不存在,请先设置正确的图库加载路径", _Path));
            }

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
    }
}



