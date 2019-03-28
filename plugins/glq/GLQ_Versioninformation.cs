using System.Globalization;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_VersioninformationPlugin : BasePlugin, IInGameTopPainter
    {

        public TopLabelWithTitleDecorator logo1Decorator { get; set; }
        public TopLabelWithTitleDecorator logo2Decorator { get; set; }
        public TopLabelWithTitleDecorator logo3Decorator { get; set; }
        public GLQ_VersioninformationPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            logo1Decorator = new TopLabelWithTitleDecorator(Hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(160, 255, 255, 255, 0),
                BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, -1),
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 0, 0, 0, true, false, false),
            };

            logo2Decorator = new TopLabelWithTitleDecorator(Hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(160, 255, 100, 0, 0),
                BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, -1),
                TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 0, 0, 0, true, false, false),
            };
            logo3Decorator = new TopLabelWithTitleDecorator(Hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(160, 250, 200, 20, 0),
                BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, -1),
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 0, 0, 0, true, false, false),
            };
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;

            if (clipState == ClipState.BeforeClip)
            {
                var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_window_hud_overlay").Rectangle;

                var w1 = Hud.Window.Size.Height * 0.12f;
                var h1 = Hud.Window.Size.Height * 0.02f;
                var w2 = Hud.Window.Size.Height * 0.08f;
                var h2 = Hud.Window.Size.Height * 0.02f;
                var w3 = Hud.Window.Size.Height * 0.04f;
                var h3 = Hud.Window.Size.Height * 0.02f;

                var x1 = uiRect.Left + uiRect.Width * 0.74f;
                var y1 = uiRect.Bottom - h1 - h2 - (Hud.Window.Size.Height / 600);
                var x2 = uiRect.Left + uiRect.Width * 0.77f;
                var y2 = uiRect.Bottom - h2 - (Hud.Window.Size.Height / 600);
                var x3 = uiRect.Left + uiRect.Width * 0.86f;
                var y3 = uiRect.Bottom - h3 - (Hud.Window.Size.Height / 600);

                logo1Decorator.Paint(x1 + w1 * 1, y1, w1, h1, "TurboHUD中文版");
                logo2Decorator.Paint(x2 + w2 * 1, y2, w2, h2, "插件管理器");
                logo3Decorator.Paint(x3 + w3 * 1, y3, w3, h3, "v3.59");
            }
        }

    }

}