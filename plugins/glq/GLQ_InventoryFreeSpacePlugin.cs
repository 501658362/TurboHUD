using System.Globalization;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_InventoryFreeSpacePlugin : BasePlugin, IInGameTopPainter
	{

        public TopLabelDecorator RedDecorator { get; set; }
        public TopLabelDecorator YellowDecorator { get; set; }
        public TopLabelDecorator GreenDecorator { get; set; }

		public GLQ_InventoryFreeSpacePlugin()
		{
            Enabled = true;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            RedDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 100, 100, true, false, 255, 0, 0, 0, true),
                BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
                BackgroundTextureOpacity1 = 1.0f,
                BackgroundTextureOpacity2 = 1.0f,
                TextFunc = () => (Hud.Game.Me.InventorySpaceTotal - Hud.Game.InventorySpaceUsed).ToString("D", CultureInfo.InvariantCulture),
                HintFunc = () => "物品栏剩余空间",
            };

            YellowDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 200, 205, 50, true, false, false),
                BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
                BackgroundTextureOpacity1 = 1.0f,
                BackgroundTextureOpacity2 = 1.0f,
                TextFunc = () => (Hud.Game.Me.InventorySpaceTotal - Hud.Game.InventorySpaceUsed).ToString("D", CultureInfo.InvariantCulture),
                HintFunc = () => "物品栏剩余空间",
            };

            GreenDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 100, 130, 100, false, false, false),
                BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
                BackgroundTextureOpacity1 = 1.0f,
                BackgroundTextureOpacity2 = 1.0f,
                TextFunc = () => (Hud.Game.Me.InventorySpaceTotal - Hud.Game.InventorySpaceUsed).ToString("D", CultureInfo.InvariantCulture),
                HintFunc = () => "物品栏剩余空间",
            };
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;

            var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_window_hud_overlay").Rectangle;

            var freeSpace = Hud.Game.Me.InventorySpaceTotal - Hud.Game.InventorySpaceUsed;

            var decorator = freeSpace < 2 ? RedDecorator : freeSpace < 20 ? YellowDecorator : GreenDecorator;
            decorator.Paint(uiRect.Left + uiRect.Width * 0.645f, uiRect.Top + uiRect.Height * 0.88f, uiRect.Width * 0.019f, uiRect.Height * 0.12f, HorizontalAlign.Center);
        }

    }

}