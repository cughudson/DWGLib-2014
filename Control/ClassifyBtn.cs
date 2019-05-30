using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;

namespace DWGLib.Control
{
    using DWGLib.Dialog;
    public delegate void ToggleClassifyBtnEventHander(object sender, ToggleClassifyBtnEventArgs e);
    public partial class ClassifyBtn : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TagStr">Tag string bingding to ClassifyBtn</param>
        public ClassifyBtn(string Name,string Path)
        {
            InitializeComponent();
            this.ArrowImage.Tag = Path;
            this.ClasslifyName.Text = Name;
            this.Dock = DockStyle.Top;
        }
        public void ToNomalStyle()
        {
            this.BackColor = System.Drawing.SystemColors.Control; 
            this.ArrowImage.Image = Properties.Resources.rightarrow_black;
            this.ClasslifyName.ForeColor = System.Drawing.SystemColors.MenuText;
        }
        public void ToActiveStyle()
        {
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ArrowImage.Image = Properties.Resources.rightarrow_white;
            this.ClasslifyName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
        }
        public void TriggerClick()
        {
            this.ClasslifyPicture_Click(this.ArrowImage, new EventArgs());
            this.ToActiveStyle();
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            this.ClasslifyPicture_Click(this.ArrowImage, new EventArgs());
        }
        private void ClasslifyName_Click(object sender, EventArgs e)
        {
            this.ClasslifyPicture_Click(this.ArrowImage, new EventArgs());
        }
        private void ClasslifyPicture_Click(object sender, EventArgs e)
        {
            ClearLibraryDialogTab();
            PictureBox Btn = sender as PictureBox;
            string PathStr = Btn.Tag as string;
            //改变Classify Buttom的颜色
            this.ToggleClasslifyBtn();

            if (Directory.Exists(PathStr))
            {
                LibaryDialog ParentForm = this.FindForm() as LibaryDialog;
                if (ParentForm == null) return;
                this.CreateTabCollection(PathStr, ParentForm.TabControl);
                //获取当前的tab
                TabPage page = ParentForm.TabControl.SelectedTab; 
                bool IsSuccess = this.CreateDWGThumnailCollection(ref page);
                //这个是在知道的情况下才可以这样做因为Controls[0]是FlowPanelControl
            }
            else
            {
                MessageBox.Show(string.Format("路径{0}不存在", PathStr));
            }
        }
        //change all the libarydialog tablelayout control to nomal style;
        //and change the current classifybtn to active style
        private void ToggleClasslifyBtn()
        {
            LibaryDialog ParentForm = this.FindForm() as LibaryDialog;
            if (ParentForm == null) return;
            TableLayoutPanel TbLayoutControl = ParentForm.TableLayout;
            List<ClassifyBtn> Collect = TbLayoutControl.Controls.Cast<ClassifyBtn>().ToList();
            Collect.ForEach(item => { item.ToNomalStyle(); });
            this.ToActiveStyle();
        }
        //create the tab all in tab control
        //只建立Tab不建立任何的DwgThumnail
        private void CreateTabCollection(string Path,TabControl TabContrl)
        {
            
            List<string> SubPaths = Directory.GetDirectories(Path).ToList();
            //if：如果下面还有子文件夹
            //else：如果下面只有文件，不存在子文件夹
            if(SubPaths.Count > 20)
            {
                MessageBox.Show("图库的子文件夹不能超过20个,如果超过20个，则只加载前20个");
                SubPaths = SubPaths.Take(20).ToList();
            }
            if(SubPaths.Count != 0)
            {
                foreach(var item  in SubPaths)
                {
                    if (!Directory.Exists(item)) break;
                    TabPage Page = new TabPage(item.Split('\\').Last());
                    Page.Tag = item;
                    TabContrl.TabPages.Add(Page);
                };
            }else
            {
                TabPage Page = new TabPage(Path.Split('\\').Last());
                Page.Tag = Path;
                TabContrl.TabPages.Add(Page);
            }
        }
        //create an tabpage
        private bool CreateDWGThumnailCollection(ref TabPage Page)
        {
            string PathStr = Page.Tag as string;
            FlowLayoutPanel FlowPanel = new FlowLayoutPanel();
            if (Directory.Exists(PathStr))
            {
                List<string> DwgFiles = Directory.GetFiles(PathStr, "*.dwg", SearchOption.AllDirectories).ToList();
                BlockingCollection<DwgThumnail> DwgItemList = new BlockingCollection<DwgThumnail>();

                FlowPanel.Dock = DockStyle.Fill;
                FlowPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                FlowPanel.AutoScroll = true;
                int type = 0;

                if (Regex.Match(PathStr, @"StdBlock").Success)
                {
                    type = 0;
                }
                else
                {
                    type = 1;
                }
                Parallel.ForEach(DwgFiles, item =>
                {
                    DwgThumnail DwgItem = new DwgThumnail(item,type);
                    DwgItemList.Add(DwgItem);
                });
                if(DwgItemList.Count == 0)
                {
                    Label lb = new Label();
                    lb.Text = "该路径下不包含任何DWG文件";
                    lb.Dock = DockStyle.Top;
                    lb.AutoSize = true;

                    FlowPanel.Padding = new Padding(30);
                    FlowPanel.Controls.Add(lb);
                    Page.Controls.Add(FlowPanel);
                    return false;
                }
                else
                {
                    FlowPanel.SuspendLayout();
                    List<DwgThumnail> DwgList = DwgItemList.ToList();
                    DwgList.Sort();
                    FlowPanel.Controls.AddRange(DwgList.ToArray());
                    FlowPanel.ResumeLayout();
                    Page.Controls.Add(FlowPanel);
                    return true;
                }
            }else
            {
                AcadApp.ShowAlertDialog(string.Format("路径:{0} 不存在",PathStr));
                return false;
            }
        }
        private void ClearLibraryDialogTab()
        {
            LibaryDialog ParentForm = this.FindForm() as LibaryDialog;
            ParentForm.TabControl.Controls.Clear();
           
        }
    }
    public class ToggleClassifyBtnEventArgs : EventArgs
    {
        public string Sign { get; set; }
    }
}
