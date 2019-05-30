using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
//AutoCAD Custom

using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
/*
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Windows;*/
using DWGLib.Class;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;
namespace DWGLib.Control
{
    public partial class DwgThumnail : UserControl,IDisposable,IComparable
    {
        ///
        public string FilePath = "";
       /// <summary>
       /// 
       /// </summary>
       /// <param name="Path">The Path is used to reference to the dwg thumnail file,aka, jpeg file</param>
        ThumnailProcess Thumnail = new ThumnailProcess();
        //
        // 0 is sys dwg file
        // 1 is block dwg file
        //
        public int _type = 0;
        string NotFoundImage = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"Resource\icon\404image.png";
        public DwgThumnail(string PathStr,int type)
        {
            InitializeComponent();
            this.BlockName.Text = System.IO.Path.GetFileNameWithoutExtension(PathStr);
            this.FilePath = PathStr;
            this._type = type;
            try
            {
                this.BlockImage.Image = Bitmap.FromFile(ComputeDWGThumnailFilePath(PathStr));
            }catch(System.Exception ex)
            {
                this.BlockImage.Image = null;
                AcadApp.DocumentManager.MdiActiveDocument.Editor.WriteMessage(ex.Message);
            }
        }
        private string ComputeDWGThumnailFilePath(string PathName)
        {
            string Dir = Path.GetDirectoryName(PathName);
            string FileName = Path.GetFileNameWithoutExtension(PathName);
            string ImagePath = Dir + "/" + FileName + ".jpg";
            if (!File.Exists(ImagePath))
            {
                return NotFoundImage;
            }else
            {
                return ImagePath;
            }
        }
        private void BlockImage_MouseHover(object sender, EventArgs e)
        {

            PictureBox pictureBox = sender as PictureBox;
            this.DwgTooltip.ToolTipIcon = ToolTipIcon.None;
            this.DwgTooltip.Show(this.BlockName.Text, pictureBox, 1000);
            this.DwgThumnail_MouseEnter();

        }
        public new void Dispose(bool disposing)
        {
            this.BlockImage.Dispose();
            this.BlockName.Dispose();
            base.Dispose(disposing);
        }

        private void DwgThumnail_MouseEnter()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void DwgThumnail_MouseLeave()
        {
            this.BorderStyle = BorderStyle.None;
        }

        private void BlockImage_MouseLeave(object sender, EventArgs e)
        {
            this.DwgThumnail_MouseLeave();
        }
        private ErrorStatus GetInsertDwgFile(ref Database DB)
        {
            try
            {
                DB.ReadDwgFile(this.FilePath, FileShare.ReadWrite, true, null);
                return ErrorStatus.OK;
            }
            catch (System.NotImplementedException)
            {
                return ErrorStatus.InvalidDwgVersion;
            }
            catch
            {
                return ErrorStatus.CantOpenFile;
            }
        }

        private void ViewDWG_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo(this.FilePath);
           // System.Diagnostics.Process.Start(Info);
        }

        private void BlockImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
               // ContextMenu.Show(this.BlockImage,new Point(e.X,e.Y));
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            DwgThumnail _dwgThumnail = obj as DwgThumnail;
            if (_dwgThumnail == null) return 1;

            string Str1 = this.BlockName.Text; 
            string Str2 = _dwgThumnail.BlockName.Text;
            return Str1.CompareTo(Str2);
        }
        //something plobrem
        //文件的名称必须和块的名称一致
        //不一致将会发生错误
        //将图块写入到当前文档中
        private bool WBlockBetweenDataBase(string BlockName)
        {
            Database SourceDB = new Database(false,true);
            ErrorStatus Stats = this.GetInsertDwgFile(ref SourceDB);
            Document Doc = AcadApp.DocumentManager.MdiActiveDocument;
            Database TargetDB = Doc.Database;
            ObjectIdCollection SourceIds = new ObjectIdCollection();
            using (Transaction Tr = SourceDB.TransactionManager.StartTransaction())
            {
                using (Transaction Tr2 = TargetDB.TransactionManager.StartTransaction())
                {
                    BlockTable SourceBt = (BlockTable)Tr.GetObject(SourceDB.BlockTableId, OpenMode.ForRead);
                    if (SourceBt.Has(BlockName))
                    {
                        SourceIds.Add(SourceBt[BlockName]);
                    }
                    Tr.Commit();
                }

            }
            if(SourceIds.Count != 0)
            {
                IdMapping IdMap = new IdMapping();
                TargetDB.WblockCloneObjects(SourceIds,TargetDB.BlockTableId , IdMap, DuplicateRecordCloning.Ignore, false);
                SourceDB.Dispose();
                return true;
            }else
            {
                SourceDB.Dispose();
                return false;
            }
        }

        /**
            对话框隐藏后无法对焦点的问题通过设置dialog的parent可以解决
            这里是重点
            找到父窗口
        **/ 
        private void BlockImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //string Prefix = "_";
            if (e.Button == MouseButtons.Right) return;
            Form Parent = this.FindForm();
            Editor ed = AcadApp.DocumentManager.MdiActiveDocument.Editor;
            DWGLib.Dialog.LibaryDialog Dialog = Parent as DWGLib.Dialog.LibaryDialog;
            Document Doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            ed.WriteMessage("\n", true, true, false);
            if (this._type == 1)
            {
                Dialog.Hide();
                if (File.Exists(this.FilePath))
                {
                    Document _Doc = AcadApp.DocumentManager.Open(this.FilePath,false);
                }else
                {
                    AcadApp.ShowAlertDialog("文件不存在");
                }
                Dialog.Close();
                return;
            }
            if (Dialog != null)
            {
                ObjectId BlockId = default(ObjectId);
                Dialog.Hide();
                /*
                Database SourceDB = new Database();
                ErrorStatus Stats = this.GetInsertDwgFile(ref SourceDB);
                */
                Database TargetDB = HostApplicationServices.WorkingDatabase;
                DocumentLock DocLock = Doc.LockDocument();
                string BlockName = Path.GetFileNameWithoutExtension(this.FilePath);
                WBlockBetweenDataBase(BlockName);
                using (Transaction Tr = TargetDB.TransactionManager.StartTransaction())
                {
                   
                    BlockTable Btr = Tr.GetObject(TargetDB.BlockTableId, OpenMode.ForWrite) as BlockTable;
                    BlockTableRecord ModelSpace = (BlockTableRecord)SymbolUtilityServices.GetBlockModelSpaceId(TargetDB).GetObject(OpenMode.ForWrite);
                    try
                    {
                        BlockId = Btr[BlockName];
                    }catch
                    {
                        AcadApp.ShowAlertDialog("插入图块失败");
                        DocLock.Dispose();
                        TargetDB.Dispose();
                        return;
                    }
                   
                    ////<summary>
                    /*****
                    if (Stats == ErrorStatus.OK)
                    {
                        BlockId = Btr[BlockName];
                    }
                        /****
                        try
                        {
                            if (Btr.Has(BlockName))
                            {
                                BlockId = Btr[BlockName];
                            }else
                            {
                                BlockId = TargetDB.Insert(BlockName, SourceDB, true);
                                
                            }
                        }catch(Autodesk.AutoCAD.Runtime.Exception ex)
                        {
                            AcadApp.ShowAlertDialog("插入图块失败");

                            Tr.Commit();
                            DocLock.Dispose();
                            TargetDB.Dispose();
                            SourceDB.Dispose();
                            return;
                        }
                    }
                    else
                    {
                        AcadApp.ShowAlertDialog("打开文件失败");
                        Dialog.Close();

                        Tr.Commit();
                        DocLock.Dispose();
                        TargetDB.Dispose();
                        SourceDB.Dispose();
                        return;
                    }
                    ****/
                    BlockReference Block = new BlockReference(new Autodesk.AutoCAD.Geometry.Point3d(0,0,0),BlockId);
                    Block.Highlight();
                    BlockJig _BlockJig = new BlockJig(Block);
                    bool IsOK = _BlockJig.RunBlockJig(Block);
                    //这里的运行情况是这样的，do......while，不会按照计算机的时钟频率运行，而是点击了屏幕之后才会运行，每点击一次运行一次
                    //这个AutoCAD运行的特殊的地方。
                    #region
                    #endregion
                    
                    if (!IsOK)
                    {
                        AcadApp.UpdateScreen();
                        Dialog.Show();
                        ed.WriteMessage("取消插入\n", true, true, false);
                        Tr.Commit();
                        DocLock.Dispose();
                        TargetDB.Dispose();
                    }
                    else
                    {
                        Dialog.Close();
                        ed.WriteMessage("\n插入成功\n", true, true, false);
                        DBObjectCollection Objs = new DBObjectCollection();
                        ModelSpace.AppendEntity(Block);
                        Tr.AddNewlyCreatedDBObject(Block, true);
                       // Block.ExplodeToOwnerSpace();
                        Tr.Commit();
                        DocLock.Dispose();
                        TargetDB.Dispose();
                    }
                    //if is not OK
                }
            }
        }
        public bool EraseBlock(Database TargetDB,string BlockName)
        {

            return false;
        }
    }
}
