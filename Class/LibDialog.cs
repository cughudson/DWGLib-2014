using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Windows;
using System.Diagnostics;

using DWGLib;
using DWGLib.Controls;
using DWGLib.Dialog;

namespace DWGLib.Class
{

    class LibDialog
    {
        public PaletteSet StdSysPalette, StdBlockPalette;
        string StdSyslibPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resource\library\StdSys";
        string StdBlockSysPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resource\library\StdBlock";
        public LibDialog()
        {
            //初始化标准系统组件
            this.CreateStdBlockPalette();
            this.CreateStdSysPalette();
        }
        private void CreateStdSysPalette()
        {
            this.StdSysPalette = new PaletteSet("中建深圳装饰-幕墙标准系统", Guid.NewGuid());

            this.StdSysPalette.Size = new Size(600, 600);
            this.StdSysPalette.MinimumSize = new Size(260, 400);
            this.StdBlockPalette.Style = PaletteSetStyles.ShowAutoHideButton;
            this.StdSysPalette.Icon = DWGLib.Properties.Resources.logo;
            this.InitLibrary(this.StdSysPalette, StdSyslibPath);

        }
        private void CreateStdBlockPalette()
        {
            this.StdBlockPalette = new PaletteSet("中建深圳装饰-幕墙标准图块", Guid.NewGuid());

            this.StdBlockPalette.Size = new Size(600, 600);
            this.StdBlockPalette.MinimumSize = new Size(260, 400);
            this.StdBlockPalette.Style = PaletteSetStyles.ShowAutoHideButton;
            this.StdBlockPalette.Icon = DWGLib.Properties.Resources.logo;
            this.InitLibrary(this.StdBlockPalette, StdBlockSysPath);

        }
        private void InitLibrary(PaletteSet MyPaletteSet, string DWGLibPath)
        {

        }
    }
}
