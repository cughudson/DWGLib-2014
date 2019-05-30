using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.Customization;

namespace DWGLib.UI
{
    class LoadCUIFile {
      
       
        public string cuiPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+ @"\ui.cuix";
        Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
        public LoadCUIFile()
        {
           
           
        }
        public void Load()
        {
            this.LoadFile(cuiPath);
        }
        public bool FindCuiFile(string root)
        {
            if (Directory.Exists(cuiPath))
            {
                ed.WriteMessage("中建深圳装饰图库菜单文件不存在");
                return false;
            }else
            {
                return true;
            }
        }
        public bool LoadFile(string path)
        {
            if (FindCuiFile(path))
            {
                CustomizationSection cus = new CustomizationSection(path, true);
                CustomizationSection c = new CustomizationSection();
                string AcadPath = Application.GetSystemVariable("MENUNAME").ToString() + ".cuix";
                CustomizationSection acadCustomSection = new CustomizationSection(AcadPath);
                PartialCuiFileCollection cusparfile =  acadCustomSection.PartialCuiFiles;

                if(cusparfile.Contains(path)){
                    ed.WriteMessage("程序中已经包含：" + path + " 的文件，同名文件将不再次加载");
                }else
                {
                    this.LoadCusCUI(path);
                }
                return true;
            }else
            {
                System.Windows.Forms.MessageBox.Show("False");
                return false;
            }
        }
        private void LoadCusCUI(string path)
        {
           
            Autodesk.AutoCAD.ApplicationServices.Document doc = Application.DocumentManager.MdiActiveDocument;

            object oldCmdEcho = Application.GetSystemVariable("CMDECHO");
            object oldFileDia = Application.GetSystemVariable("FILEDIA");
            Application.SetSystemVariable("CMDECHO", 1);
            Application.SetSystemVariable("FILEDIA", 0);
            string LoadCUICommand = "cuiload " + path + " filedia 1";
            doc.SendStringToExecute(LoadCUICommand, true,false,true);
        }
    }
}
