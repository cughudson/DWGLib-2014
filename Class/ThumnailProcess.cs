using Autodesk.AutoCAD.DatabaseServices;
//using Microsoft.WindowsAPICodePack.Shell;

using DWGLib.Dialog;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DWGLib.Class
{
    public class ThumnailProcess
    {
        public ThumnailProcessDlg thumnailProcessDlg;
        List<string> Files = new List<string>();
        public string root = "";
        public ThumnailProcess() { }
        public int Processing(string file)
        {
            if (!Directory.Exists(file))
            {
                if (Path.GetExtension(file).ToLower() == ".dwg")
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    if (GernateDwgThumnail(file)) return 1;
                    else return 0;
                }else
                {
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("DWG 路径不存在", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return -1;
            }
        }
        public bool GernateDwgThumnail(string path)
        {

            string fileName = Path.GetFileNameWithoutExtension(path);
            string dir = Path.GetDirectoryName(path);
            Database db = new Database(false, true);
            try
            {
                db.ReadDwgFile(path, FileOpenMode.OpenForReadAndReadShare, true, "");
                db.UpdateThumbnail = 1;
                db.CloseInput(true);
                
                //Transaction tra = db.TransactionManager.StartOpenCloseTransaction();
                Transaction tra = db.TransactionManager.StartTransaction();
                try
                {
                    BlockTableRecord mSpaceRecord = tra.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(db), OpenMode.ForRead) as BlockTableRecord;
                    if (mSpaceRecord != null)
                    {
                        
                        Layout msLayout = tra.GetObject(mSpaceRecord.LayoutId, OpenMode.ForRead) as Layout;
                        if (msLayout != null)
                        {
                            Bitmap thumnail = db.ThumbnailBitmap;
                            if (thumnail != null)
                            {
                                Bitmap newThumnail = ResizeTo(thumnail, new Size(thumnail.Width * 2, thumnail.Height * 2));
                                try
                                {
                                    newThumnail.Save(dir + "/" + fileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                    tra.Commit();
                                    return true;
                                }
                                catch(System.Exception ex)
                                {
                                    tra.Commit();
                                    MessageBox.Show(ex.Message);
                                    return false;
                                }
                            }
                            else
                            {
                                tra.Commit();
                                return false;
                            }
                        }
                        else
                        {
                            tra.Commit();
                            return false;
                        }
                    }
                    else
                    {
                        tra.Commit();
                        return false;
                    }
                }
                catch (Autodesk.AutoCAD.Runtime.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    tra.Abort();
                    db.Dispose();
                    return false;
                }
            }
            catch (Autodesk.AutoCAD.Runtime.Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.Dispose(); 
                return false;
            }
        }
        private static Bitmap ResizeTo(Bitmap bitmap, Size size)
        {
            
            Bitmap newImage = new Bitmap(size.Width, size.Height);
            Graphics graphic = Graphics.FromImage((System.Drawing.Image)newImage);
            graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphic.DrawImage(bitmap, 0, 0, newImage.Width, newImage.Height);
            return newImage;
        }
    }
}
