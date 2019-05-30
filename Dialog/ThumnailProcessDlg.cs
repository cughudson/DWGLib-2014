using DWGLib.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DWGLib.Dialog
{
    public partial class ThumnailProcessDlg : Form
    {
        public int ProcessPercent;
        public bool isProcessed;
        public string CurrentProcess;
        ThumnailProcess thumnailProcess;
        private string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "output.log";
        private StreamWriter StreamWriter;
        List<string> fileList;
        public ThumnailProcessDlg(int ProcessPercent,bool isProcess,string CurrentProcess)
        {
            InitializeComponent();
            this.thumnailProcess = new ThumnailProcess();
            this.startProcess.Enabled = false;
        }
        private void Folder_Browser(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            if (folderDlg.ShowDialog() == DialogResult.OK)
            {
                string SelectPath = folderDlg.SelectedPath;
                this.RootPath.Text = SelectPath.Length > 120?SelectPath.Substring(120):SelectPath;
            }
        }
        private void Start_Process(object sender, EventArgs e)
        {
            this.startProcess.Enabled = false;
            this.isProcessed = true;
            this.bgWorker.RunWorkerAsync();
            this.Create_LogFile(this.filePath);
        }
        private void Create_LogFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            this.StreamWriter = File.CreateText(path);
        }
        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int hasComplete = Convert.ToInt32(100 * Convert.ToDouble(e.ProgressPercentage) / fileList.Count);
            this.progressBar.Value = hasComplete;
            this.CurrentProcessLabel.Text = Path.GetFileName(fileList[e.ProgressPercentage]);
            this._processPer.Text = String.Format("{0} %", hasComplete);
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            fileList = Directory.GetFiles(this.RootPath.Text, "*.dwg", SearchOption.AllDirectories).ToList();
            int fileTotal = fileList.Count;
            for(int i = 0; i < fileTotal; i++)
            {
                this.CurrentProcess = fileList[i];
                if (thumnailProcess.Processing(fileList[i]) == 1){
                    this.StreamWriter.WriteLine(fileList[i] + ": 处理成功");
                }else if(thumnailProcess.Processing(fileList[i]) == 0) {
                    
                    this.StreamWriter.WriteLine(fileList[i] + ": 处理失败," + "无法获取缩略图");
                }
                else
                {
                    this.StreamWriter.WriteLine(fileList[i] + ": 处理失败," + "当前目录下无DWG文件");
                }
                this.StreamWriter.Flush();
                this.bgWorker.ReportProgress(i);
                System.Threading.Thread.Sleep(500);
            }
        }
        private void BgWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            this._processPer.Text = "100%";
            this.progressBar.Value = 100;
            this.CurrentProcessLabel.Text = "处理完成";
            this.startProcess.Enabled = false;
            this.StreamWriter.Close();
            this.StreamWriter.Dispose();
            this.isProcessed = false;

            MessageBox.Show("处理完成");
            System.Diagnostics.Process.Start(this.filePath);
        }

        private void RootPath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(this.RootPath.Text))
            {
                this.startProcess.Enabled = true;
            }else
            {
                this.startProcess.Enabled = false;
            }
        }

        private void Dialog_Closing(object sender, FormClosingEventArgs e)
        {
            if (isProcessed)
            {
                MessageBox.Show("文件正在处理当中，无法关闭");
                e.Cancel = true;
            }
        }
    }
}
