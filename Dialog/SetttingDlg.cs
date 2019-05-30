using System;
using System.Windows.Forms;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;

namespace DWGLib.Dialog
{
    public partial class SetttingDlg : Form
    {
        private bool IsChange = false;
        public SetttingDlg()
        {
            InitializeComponent();
            try
            {
                this.StdSysPathLabel.Text = Properties.Settings.Default.StdSysPath;
                this.StdBlockPatnLabel.Text = Properties.Settings.Default.StdBlockPath;
            }catch
            {
                this.StdSysPathLabel.Text = "";
                this.StdBlockPatnLabel.Text = "";
            }

        }

        private void SysPathBtn_Click(object sender, EventArgs e)
        {
            if(this.FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                this.StdSysPathLabel.Text = this.FolderBrowser.SelectedPath;
                Properties.Settings.Default.StdSysPath = this.FolderBrowser.SelectedPath;
                IsChange = true;
            }
        }

        private void BlockPathBtn_Click(object sender, EventArgs e)
        {
            if (this.FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                this.StdBlockPatnLabel.Text = this.FolderBrowser.SelectedPath;
                Properties.Settings.Default.StdBlockPath = this.FolderBrowser.SelectedPath;
                IsChange = true;
            }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.IsChange = false;
            Properties.Settings.Default.Save();
            AcadApp.ShowAlertDialog("保存成功");
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (IsChange)
            {
                if (MessageBox.Show("图库加载路径尚未保存,是否关闭对话框", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                    Properties.Settings.Default.Reload();
                    this.DialogResult = DialogResult.OK;
                };
            }else
            {
                this.DialogResult = DialogResult.Cancel;
            }
            //TODO
        }

        private void StdSysPathLabel_MouseHover(object sender, EventArgs e)
        {
            this.toolTip.Show(this.StdSysPathLabel.Text,this.StdSysPathLabel);
        }

        private void StdBlockPatnLabel_MouseHover(object sender, EventArgs e)
        {
            this.toolTip.Show(this.StdBlockPatnLabel.Text, this.StdBlockPatnLabel);
        }

        private void SetttingDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsChange)
            {
                if (MessageBox.Show("图库加载路径尚未保存,是否关闭对话框", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Properties.Settings.Default.Reload();
                     
                };
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
