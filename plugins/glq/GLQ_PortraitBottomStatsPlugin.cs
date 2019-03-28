using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_PortraitBottomStatsPlugin : BasePlugin, IInGameTopPainter
	{

        public TopLabelDecorator MonsterHpDecreaseDecorator { get; set; }

		public GLQ_PortraitBottomStatsPlugin()
		{
            Enabled = true;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            MonsterHpDecreaseDecorator = new TopLabelDecorator(Hud)
            {
                BackgroundTexture1 = Hud.Texture.BackgroundTextureOrange,
                BackgroundTextureOpacity1 = 1.0f,
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 200, 180, 100, true, false, 255, 0, 0, 0, true),
                TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Stat.MonsterHitpointDecreasePerfCounter.LastValue, ValueFormat.LongNumber),
                HintFunc = () => "队伍每秒伤害",
            };
        }
		
        public void PaintTopInGame(ClipState clipState)
		{
            if (Hud.Render.UiHidden) return;
            if (Hud.Game.NumberOfPlayersInGame <= 1) return;
            if (clipState != ClipState.BeforeClip) return;

            var uiRect = Hud.Render.GetUiElement("*portrait-bottom").Rectangle;

            MonsterHpDecreaseDecorator.Paint(uiRect.Left + uiRect.Width * 0.14f, uiRect.Top + uiRect.Height * 1.03f, uiRect.Width * 0.72f, uiRect.Height * 0.1f, HorizontalAlign.Center);
        }

    }

}