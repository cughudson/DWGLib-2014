using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoCAD;
using System.IO;

namespace ThumnailPreProcess
{
   
    public partial class ThumnailPreProcess : Form
    {
        public AutoCAD.AcadApplication App = null;
        public uint BgColor = 0x000000;
        public string RootPathStr;
        public List<string> ProcessFilesList = new List<string>();
        private StreamWriter Writer;
        private bool IsProcess = false;
        private string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "output.log";
        public ThumnailPreProcess()
        {
            InitializeComponent();
        }
        private bool OpenDwgAndProcessFile(string FilePath)
        {
            if(App != null){
                string FileName = "#"+Path.GetFileName(FilePath);
                string FileSavePath = Path.GetDirectoryName(FilePath) + @"\" + FileName;
                AutoCAD.AcadDocument Doc = this.App.Documents.Open(FilePath);
                App.ZoomExtents();
                App.ZoomScaled(0.5, AcZoomScaleType.acZoomScaledRelative);
                Doc.PurgeAll();
                App.Update();
                Doc.Save();
// Doc.SaveAs(FileSavePath, "ac2010_dwg");
                Doc.Close();

                return true;
            }
            else
            {
                MessageBox.Show("请先点击截面上的AutoCAD启动按钮再使用该软件");
                return false;
            }
        }
        private void SelectProcessFolder(object sender, EventArgs e)
        {
            if(this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.StartProcessBtn.Enabled = true;
                string SelectPath = folderBrowserDialog.SelectedPath;
                this.RootPath.Text = SelectPath.Length > 58?SelectPath.Substring(0,58)+"...":SelectPath;
                this.RootPathStr = SelectPath;
                this.ProcessFilesList = Directory.GetFiles(this.RootPathStr, "*.dwg", SearchOption.AllDirectories).ToList();
            }
        }

        private void BlockRadio_Click(object sender, EventArgs e)
        {
            this.BgColor = 0x000000;
        }

        private void WhiteRadio_Click(object sender, EventArgs e)
        {
            this.BgColor = 0xffffff;
        }

        private void ProcessComplelte(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBar.Value = 100;
            this.Percent.Text = "100%";
            this.Writer.Close();
            this.Writer.Dispose();
            this.IsProcess = false;
            this.StartProcessBtn.Enabled = true;
            MessageBox.Show("处理完成, 处理结果请查看文件：" + this.filePath);
        }

        private void ProcessChanged(object sender, ProgressChangedEventArgs e)
        {
            int HasComplete = Convert.ToInt32(100*(e.ProgressPercentage) / this.ProcessFilesList.Count);
            this.progressBar.Value = HasComplete;
            this.CurrentFile.Text = Path.GetFileName(this.ProcessFilesList[e.ProgressPercentage]);
            this.Percent.Text = string.Format("{0}%",HasComplete);
        }

        private void ProcessDWGFile(object sender, DoWorkEventArgs e)
        {
            for(int Index = 0; Index < this.ProcessFilesList.Count; Index++)
            {
                string FileStr = this.ProcessFilesList[Index];
                if (this.OpenDwgAndProcessFile(FileStr) == true)
                {
                    this.Writer.WriteLine(FileStr + "  处理成功");
                }else
                {
                    this.Writer.WriteLine(FileStr + "  处理失败");
                }
                this.Writer.Flush();
                this.backgroundWorker.ReportProgress(Index);
                System.Threading.Thread.Sleep(500);
            }
        }

        private void ThumnailPreProcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsProcess)
            {
                if(MessageBox.Show("文件正在处理当中，确定关闭?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.Yes){
                    this.backgroundWorker.CancelAsync();
                    this.Close();
                }
            }
        }

        private void StartProcess(object sender, EventArgs e)
        {
            if (this.ProcessFilesList.Count == 0)
            {
                MessageBox.Show("请选择需要处理的文件");
                return;
            }
            this.IsProcess = true;
            this.backgroundWorker.RunWorkerAsync();
            this.Create_LogFile(filePath);
        }
        private void Create_LogFile(string path)
        {
            if (File.Exists(path)) File.Delete(path);
            try
            {
                this.Writer = File.CreateText(path);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void StartUpAutoCAD(object sender, EventArgs e)
        {
            try
            {
                App = new AutoCAD.AcadApplication();
                App.WindowState = AcWindowState.acMax;
                App.Preferences.Display.GraphicsWinModelBackgrndColor = this.BgColor;
                App.Visible = true;
                this.StartCAD.Enabled = false;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                this.StartCAD.Enabled = true;
            }
          
        }
    }
    
}
