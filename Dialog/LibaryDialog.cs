using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWGLib.Dialog
{
    using DWGLib.Control;
    public enum LibType{BlockLib,SysLib};
    public partial class LibaryDialog : Form
    {
        public string Root = "";
        public TabPage PreviousPage;
        List<DwgThumnail> DwgThumanilCollect = new List<DwgThumnail>();
        public ClassifyBtn PreviousClickBtn = null;
        public ClassifyBtn CurrentClickBtn = null;
        public LibType Type = 0;
        private string _RootPath = "";
        public LibaryDialog(string RootPath,string title, LibType _Type)
        {
            InitializeComponent();

            this.CreateClassifyBtn(RootPath);
            ClassifyBtn Btn = this.TableLayout.Controls[0] as ClassifyBtn;
            Btn.TriggerClick();
            Type = _Type;
            this._RootPath = RootPath;
            this.Text = title;
           
        }
        //每个实例只运行一次
        //创建左侧按钮
        public void CreateClassifyBtn(string RootPath)
        {
            List<string> SubDirs = Directory.GetDirectories(RootPath).ToList();
            List<ClassifyBtn> ClassifyBtns = new List<ClassifyBtn>();
            if (SubDirs.Count > 20)
            {
                MessageBox.Show("图库的子文件夹不能超过15个");
                SubDirs = SubDirs.Take(15).ToList();
            }

            SubDirs.ForEach(item =>
            {
                string FolderName = item.Split('\\').Last();
                if (!Regex.IsMatch(FolderName, "^_"))
                {

                    ClassifyBtn ClassBtn = new ClassifyBtn(FolderName,item);
                    ClassBtn.Dock = DockStyle.Top;
                    ClassifyBtns.Add(ClassBtn);
                }
            });

            this.TableLayout.RowCount = ClassifyBtns.Count;
            this.TableLayout.SuspendLayout();
            //下面两句代码需要配套使用
            this.TableLayout.RowCount = ClassifyBtns.Count;
            this.TableLayout.Controls.AddRange(ClassifyBtns.ToArray());
            //end
            this.TableLayout.ResumeLayout();
        }
        private void ToggleClassilyBtn()
        {
            this.PreviousClickBtn.ToNomalStyle();
            this.CurrentClickBtn.ToActiveStyle();
        }
        //右边的SelectedIndex改变的时候
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl TabControl = sender as TabControl;

            TabPage page = TabControl.SelectedTab;
            if(PreviousPage != null)
                ClearTabPageChild(this.PreviousPage);
            if (page == null) return;
            string path = page.Tag as string;
            this.OpenFolder.Tag = path;
            if (Directory.Exists(path))
            {
                List<DwgThumnail> DwgThumnailList = this.CreateDwgThumnails(path);

                if(DwgThumnailList.Count == 0)
                {
                    Label lb = new Label();
                    lb.Text = "该路径下不包含任何DWG文件";
                    lb.AutoSize = true;
                    FlowLayoutPanel Panel = this.ConstructFlowPanel(new System.Windows.Forms.Control[] { lb });
                    Panel.Padding = new Padding(30);
                    page.Controls.Add(Panel);
                    return;
                }
               
                page.Controls.Add(this.ConstructFlowPanel(DwgThumnailList.ToArray()));
                this.PreviousPage = page;
            }
            else
            {
                MessageBox.Show(string.Format("路径{0}不存在",path));
                return;
            }
        }
        private FlowLayoutPanel ConstructFlowPanel(System.Windows.Forms.Control[] Controls)
        {
            FlowLayoutPanel FlowPanel = new FlowLayoutPanel();
            FlowPanel.Dock = DockStyle.Fill;
            FlowPanel.AutoScroll = true;
            FlowPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;

            FlowPanel.SuspendLayout();
            FlowPanel.Controls.AddRange(Controls);
            FlowPanel.ResumeLayout();

            return FlowPanel;
        }
        private void ClearTabPageChild(TabPage Page)
        {
            Page.Controls.Clear();
            /*
            System.Windows.Forms.Control.ControlCollection Collect = Page.Controls[0].Controls;

            if(Collect.Count != 0)
            {
                Page.SuspendLayout();
                while(Collect.Count != 0)
                {
                    DwgThumnail item = Collect[0] as DwgThumnail;
                    if(item != null)
                    {
                        Collect.Remove(item);
                        item.Dispose();
                    }
                }
                Page.ResumeLayout();
            }*/
        }
        /// <summary>
        /// create DWG thumnails from an folder with dwg file and dwg file thumanil below it
        /// the number of dwg file and dwg file thumanil must be the same
        /// </summary>
        /// <param name="Path">The path of an folder</param>
        /// <returns></returns>
        private List<DwgThumnail> CreateDwgThumnails(string Path)
        {
            List<DwgThumnail> DwgThumnailList = new List<DwgThumnail>();
            List<string> Files = Directory.GetFiles(Path, "*.dwg", SearchOption.AllDirectories).ToList();
            int type = 0;
          
            if (Regex.Match(Path, @"StdBlock").Success)
            {
                type = 0;
            }else
            {
                type = 1;
            }
            //使用并行的方法来创建DwgThumnail
            if (Files.Count == 0) return DwgThumnailList; 
            Parallel.ForEach(Files, File =>
            {
                DwgThumnail DwgItem = new DwgThumnail(File,type);
                DwgThumnailList.Add(DwgItem);
            });
            return DwgThumnailList;
        }
        /// <summary>
        /// Get DWG file path from it thumnail path, thumanil name is the same with dwg file
        /// </summary>
        /// <param name="PathName">is the thumanil path of the dwg file</param>
        /// <returns></returns>
        private string ComputeDWGFilePath(string PathName)
        {
            string Dir = Path.GetDirectoryName(PathName);
            string FileName = Path.GetFileNameWithoutExtension(PathName);
            return Dir + "/" + FileName + ".dwg";
        }

        private void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            PreviousPage = e.TabPage;
        }
        private void LibaryDialog_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel; 
            }
        }

        private void LibaryDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void OpenCurrentFolder(object sender, EventArgs e)
        {
            string Path = this.TabControl.SelectedTab.Tag as string;
            try
            {
                System.Diagnostics.Process.Start(Path);
            }catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //修改border 的默认值
    }
}
