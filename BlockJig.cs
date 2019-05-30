using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;

namespace DWGLib
{
    public class BlockJig:EntityJig
    {
        public ObjectId _blockId = ObjectId.Null;
        public Point3d _basePt;

        public BlockJig(Entity entity) : base(entity)
        {
            
        }

        // Shows the block until the user clicks a point.
        // The 1st parameter is the Id of the block definition.
        // The 2nd is the clicked point.
        //---------------------------------------------------------------
        // Need to override this method.
        // Updating the current position of the block.
        //--------------------------------------------------------------
        //单击屏幕的时候会运行一下
        protected override SamplerStatus Sampler(JigPrompts prompts)
        {

            JigPromptPointOptions JipOpts = new JigPromptPointOptions("\n拾取放置位置:");
            PromptPointResult prResult1 = prompts.AcquirePoint(JipOpts);

            if (prResult1.Status == PromptStatus.Cancel) return SamplerStatus.Cancel;

            if (prResult1.Value.Equals(_basePt))
            {
                return SamplerStatus.NoChange;
            }else
            {
                _basePt = prResult1.Value;
                return SamplerStatus.OK;
            }
        }
        //更新频率未知，50ms？
        //更新图块的位置
        protected override bool Update()
        {
            BlockReference _Block = Entity as BlockReference;
            if((Entity as BlockReference) != null)
            {
                (Entity as BlockReference).Position = _basePt;
                return true; 
            }
            return false;
        }
        //没单击一次就会运行一次
        public bool RunBlockJig(BlockReference ent)
        {
            try
            {
                Editor ed = AcadApp.DocumentManager.MdiActiveDocument.Editor;
                BlockJig BlockJig = new BlockJig(ent);
                PromptResult pr;
                //这个函数是终点；
                pr = ed.Drag(BlockJig);
                if (pr.Status == PromptStatus.Cancel|| pr.Status == PromptStatus.Error)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }catch
            {
                return false;
            }
        }
    }
}
