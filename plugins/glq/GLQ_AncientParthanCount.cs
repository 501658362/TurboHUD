using System;
using System.Linq;
using Turbo.Plugins.Default;
using System.Drawing;
namespace Turbo.Plugins.glq
{
    public class GLQ_AncientParthanCount : BasePlugin, IInGameTopPainter
    {
        public IFont TextFont { get; set; }
        public float XWidth { get; set; }
        public float YHeight { get; set; }
        public int percent { get; set; }
        public TopLabelDecorator AncientParthanDecorator { get; set; }
        private IBrush StackBrush;
 
        public GLQ_AncientParthanCount()
        {
            Enabled = true;
        }
 
        public override void Load(IController hud)
        {
            base.Load(hud);
            TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 170, 90, 90, false, false, true);
            XWidth = 0.3f;
            YHeight = 0.3f;
            percent = 0;
            AncientParthanDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 5, 255, 255, 255, 255, false, false, 250, 0, 0, 0, true),
            };
            StackBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0);
        }
 
        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;
            if (!Hud.Game.Me.Powers.BuffIsActive(Hud.Sno.SnoPowers.AncientParthanDefenders.Sno))
            {
                percent = 0;
                return;
            }
            var count = Hud.Game.AliveMonsters.Count(m => (m.Stunned || m.Frozen) && m.NormalizedXyDistanceToMe <= 25);
            if (count == 0) return;
            SetDamageReductionpercent();
            var dr = 100 * (1 - Math.Pow(1 - percent * 0.01d, count));
            var ui = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.minimap_pve_main");
            var XPos = ui.Rectangle.Left - ui.Rectangle.Width * XWidth;
            var YPos = ui.Rectangle.Bottom + ui.Rectangle.Width * YHeight;
            var w = ui.Rectangle.Height * 0.1f;
            var h = ui.Rectangle.Height * 0.2f;
            var tex = Hud.Texture.GetItemTexture(Hud.Sno.SnoItems.Unique_Bracer_102_x1);
            var bgTex = Hud.Texture.GetTexture(3166997520);
            var rect = new RectangleF(XPos, YPos, w, h);
            if (Hud.Window.CursorInsideRect(rect.X, rect.Y, rect.Width, rect.Height))
            {
                Hud.Render.SetHint("古帕特效\r\n古帕触发数\r\n古帕总减伤");
            }
                StackBrush.DrawRectangle(rect);

            bgTex.Draw(rect.Left, rect.Top, rect.Width, rect.Height);
            tex.Draw(rect.Left, rect.Top, rect.Width, rect.Height);
            AncientParthanDecorator.TextFunc = () => "   " + percent.ToString()+"%" + "\r\n" + "\r\n" + "\r\n" + " " + count.ToString() + "\r\n" + dr.ToString("f2")+"%";
            //AncientParthanDecorator.HintFunc = () => "古帕特效\r\n古帕触发数\r\n古帕总减伤";
            AncientParthanDecorator.Paint(XPos, YPos, w, h, HorizontalAlign.Center);

        }
        private void SetDamageReductionpercent()
        {
            if (Hud.Game.Me.CubeSnoItem2 != null && Hud.Game.Me.CubeSnoItem2.LegendaryPower.Sno == Hud.Sno.SnoPowers.AncientParthanDefenders.Sno)
            {
                percent = 12;
            }
            else
            {
                var parthans = Hud.Game.Items.First(item => item.Location == ItemLocation.Bracers).Perfections.FirstOrDefault(p => p.Attribute.Code == "Item_Power_Passive");
                percent = parthans == null ? 10 : (int)Math.Round(parthans.Cur * 100);
            }
        }
    }
}