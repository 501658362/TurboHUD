using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
	public class GLQ_PoolState : BasePlugin, IInGameTopPainter
	{

		public IFont PortraitInfoFont { get; set; }
        public float OffsetXmultiplier { get; set; }
        public float OffsetYmultiplier { get; set; }

		public bool ShowDeathCounter { get; set; }

		public GLQ_PoolState()
		{
			Enabled = true;
		}

		public override void Load(IController hud)
		{
			base.Load(hud);

			PortraitInfoFont = Hud.Render.CreateFont("tahoma", 7f, 255, 180, 147, 109, false, false, true);
			OffsetXmultiplier = 0.004f;
			OffsetYmultiplier = 0.125f;
		}

		public void PaintTopInGame(ClipState clipState)
		{
			if (clipState != ClipState.BeforeClip) return;


			foreach (IPlayer player in Hud.Game.Players)
			{
				DrawPlayerInfo(player);
			}
		}

		private string GetPlayerInfoText(IPlayer player)
		{
            float pool = 0;
            pool = 10 * ((float)player.BonusPoolRemaining / player.ParagonExpToNextLevel);
            if (pool > 0)
            {
                return "经验池：" + pool.ToString("f2");
            }
            else
                return "";

        }

		private void DrawPlayerInfo(IPlayer player)
		{
			var OffsetX = Hud.Window.Size.Width * OffsetXmultiplier;
			var OffsetY = Hud.Window.Size.Height * OffsetYmultiplier;
			var portraitRect = player.PortraitUiElement.Rectangle;
			var YPos = portraitRect.Y + OffsetY;
			var XPos = portraitRect.X + OffsetX;

			var Layout = PortraitInfoFont.GetTextLayout(GetPlayerInfoText(player));
			PortraitInfoFont.DrawText(Layout, XPos, YPos);
		}

	}
}