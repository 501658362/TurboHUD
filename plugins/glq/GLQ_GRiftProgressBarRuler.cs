using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_GRiftProgressBarRuler : BasePlugin, IInGameTopPainter
    {
        public IBrush ProgressionLineBrush { get; set; }
        public GLQ_GRiftProgressBarRuler()
        {
            Enabled = true;
        }
        public override void Load(IController hud)
        {
            base.Load(hud);
            ProgressionLineBrush = Hud.Render.CreateBrush(255, 125, 175, 240, 1f);
        }
        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;
            if (Hud.Game.SpecialArea != SpecialArea.GreaterRift) return;
            var ui = Hud.Render.GreaterRiftBarUiElement;
            if(!ui.Visible) return;
            var uiRect = ui.Rectangle;
            var x = (float)(uiRect.Width / 5);
            var y1 = uiRect.Top;
            var y2 = uiRect.Top + uiRect.Height / 3;
            for (int a = 1; a <= 4; a = a + 1)
            {
                ProgressionLineBrush.DrawLine(uiRect.Left + x * a, y1, uiRect.Left + x * a, y2, 0);
            }
            x = (float)(uiRect.Width / 20);
            y2 = uiRect.Top + uiRect.Height / 10;
            for (int a = 1; a <= 19; a = a + 1)
            {
                ProgressionLineBrush.DrawLine(uiRect.Left + x * a, y1, uiRect.Left + x * a, y2, 0);
            }
        }
    }
}