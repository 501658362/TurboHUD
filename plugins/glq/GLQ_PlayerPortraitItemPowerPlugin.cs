using System.Drawing;
using Turbo.Plugins;
using Turbo.Plugins.Default;
//by JackCeparou
namespace Turbo.Plugins.glq
{
    public class GLQ_PlayerPortraitItemPowerPlugin : BasePlugin, IInGameTopPainter
    {
        private IBrush bgBrush;

        public GLQ_PlayerPortraitItemPowerPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            bgBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0);
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;

            foreach (var player in Hud.Game.Players)
            {
                if (!player.Powers.BuffIsActive(Hud.Sno.SnoPowers.NemesisBracers.Sno)) continue;

                var item = Hud.Sno.SnoItems.Unique_Bracer_106_x1;
                var tex = Hud.Texture.GetItemTexture(item);
                var bgTex = Hud.Texture.GetTexture(3166997520);

                var portrait = player.PortraitUiElement.Rectangle;
                var width = portrait.Left*1.2f;
                var rect = new RectangleF(width / 2, portrait.Top + portrait.Height/2 - width, width, width * 2);//var rect = new RectangleF(width/2, portrait.Height/2.5f, width, width * 2);

                bgBrush.DrawRectangle(rect);
                bgTex.Draw(rect.Left, rect.Top, rect.Width, rect.Height);
                tex.Draw(rect.Left, rect.Top, rect.Width, rect.Height);
            }
        }
    }
}