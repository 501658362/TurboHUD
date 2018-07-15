namespace Turbo.Plugins.Default
{

    public class PlayerRightBuffListPlugin : BasePlugin, IInGameTopPainter
    {

        public BuffPainter BuffPainter { get; set; }
        public BuffRuleCalculator RuleCalculator { get; private set; }
        public float PositionOffsetX { get; set; }
        public float PositionOffsetH { get; set; }

        public PlayerRightBuffListPlugin()
        {
            Enabled = true;
            PositionOffsetX = 0.14f;
            PositionOffsetH = 0.875f;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            BuffPainter = new BuffPainter(Hud, true)
            {
                Opacity = 0.75f,
                ShowTimeLeftNumbers = false,
                ShowTooltips = false,
                TimeLeftFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true),
                StackFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true),
            };

            RuleCalculator = new BuffRuleCalculator(Hud);
            RuleCalculator.SizeMultiplier = 0.75f;
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;

            RuleCalculator.CalculatePaintInfo(Hud.Game.Me);
            if (RuleCalculator.PaintInfoList.Count == 0) return;

            var x = Hud.Window.Size.Width * 0.5f + Hud.Window.Size.Height * PositionOffsetX - RuleCalculator.StandardIconSize / 2;
            var h = Hud.Window.Size.Height * PositionOffsetH;
            BuffPainter.PaintVerticalCenter(RuleCalculator.PaintInfoList, x, 0, h, RuleCalculator.StandardIconSize, RuleCalculator.StandardIconSpacing);
        }

    }

}