using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWGLib.Control
{
    public partial class CSCECDECLib : UserControl
    {
        public string DWGPath = null;
        public ImageList ImageList;
        public CSCECDECLib(string DWGPath)
        {
            this.DWGPath = DWGPath;
            InitializeComponent();
        }

        private void CSCECDECLib_Load(object sender, EventArgs e)
        {
            this.InitTreeView(DWGPath);
        }
        private void InitTreeView(string FolderPath)
        {
            this.FolderTree.ImageList = this.ImageList;
            string RootNodeName = Path.GetFileNameWithoutExtension(FolderPath);
            TreeNode RootNode = new TreeNode(RootNodeName);
            RootNode.ImageIndex = 1;
            string[] DirArr = Directory.GetDirectories(FolderPath);
        }
        private void InitImageList()
        {
            this.ImageList.Images.Add("Root",Properties.Resources.file_pdf);
            this.ImageList.Images.Add("Sub", Properties.Resources.file_pdf);
        }
        private void FolderTree_Click(object sender, EventArgs e)
        {

        }
    }
}
