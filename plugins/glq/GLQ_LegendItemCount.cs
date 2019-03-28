using System.Linq;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_LegendItemCount : BasePlugin, IInGameTopPainter
    {
        public IFont TotaltextFont { get; set; }
        public IFont NormaltextFont { get; set; }
        public IFont AncienttextFont { get; set; }
        public IFont PrimaltextFont { get; set; }
        public bool OnlyUnidentified { get; set; }

        public GLQ_LegendItemCount()
        {
            Enabled = true;
            OnlyUnidentified = false;
        }
        public override void Load(IController hud)
        {
            base.Load(hud);
            TotaltextFont = Hud.Render.CreateFont("tahoma", 7.5f, 230, 0, 255, 255, true, false, true);
            NormaltextFont = Hud.Render.CreateFont("tahoma", 7.5f, 230, 128, 64, 64, true, false, true);
            AncienttextFont = Hud.Render.CreateFont("tahoma", 7.5f, 230, 255, 128, 64, true, false, true);
            PrimaltextFont = Hud.Render.CreateFont("tahoma", 7.5f, 230, 255, 0, 0, true, false, true);


        }
        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;
            var items = Hud.Game.Items.Where(item => item.Location == ItemLocation.Floor && !OnlyUnidentified && item.IsLegendary || item.Location == ItemLocation.Floor && OnlyUnidentified && item.Unidentified && item.IsLegendary);
            int Total = items.Count();
            if (Total == 0) return;
            int Normal = 0;
            int Ancient = 0;
            int Primal = 0;
            foreach (var item in items)
            {
                if (item.AncientRank == 0) Normal++;
                if (item.AncientRank == 1) Ancient++;
                if (item.AncientRank == 2) Primal++;
            }
            var TotaltextLayout = "地面传奇物品统计\n总数：" + Total;
            var NormaltextLayout = "普通：" + Normal;
            var AncienttextLayout = "远古：" + Ancient;
            var PrimaltextLayout = "太古：" + Primal;
            var x = Hud.Window.Size.Width / 1.18f;
            var y = Hud.Window.Size.Height / 1.15f;
            var h = Hud.Window.Size.Height * 0.018f;
            TotaltextFont.DrawText(TotaltextLayout, x, y);
            y = y + h;
            if (Normal != 0)
            {
                y = y + h;
                NormaltextFont.DrawText(NormaltextLayout, x, y);
            }
            if (Ancient != 0)
            {
                y = y + h;
                AncienttextFont.DrawText(AncienttextLayout, x, y);
            }
            if (Primal != 0)
            {
                y = y + h;
                PrimaltextFont.DrawText(PrimaltextLayout, x, y);
            }
        }
    }
}