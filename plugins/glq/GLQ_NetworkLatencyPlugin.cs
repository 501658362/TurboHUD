using System.Globalization;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_NetworkLatencyPlugin : BasePlugin, IInGameTopPainter
	{

        public TopLabelDecorator AverageDecoratorNormal { get; set; }
        public TopLabelDecorator CurrentDecoratorNormal { get; set; }
        public TopLabelDecorator AverageDecoratorHigh { get; set; }
        public TopLabelDecorator CurrentDecoratorHigh { get; set; }
        public int HighLimit { get; set; }

		public GLQ_NetworkLatencyPlugin()
		{
            Enabled = true;
            HighLimit = 50;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            AverageDecoratorNormal = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 6, 160, 150, 200, 150, false, false, false),
                TextFunc = () => Hud.Game.AverageLatency.ToString("F0", CultureInfo.InvariantCulture),
                HintFunc = () => "平均延迟"
            };

            CurrentDecoratorNormal = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 6, 160, 150, 200, 150, false, false, false),
                TextFunc = () => Hud.Game.CurrentLatency.ToString("F0", CultureInfo.InvariantCulture),
                HintFunc = () => "当前延迟"
            };

            AverageDecoratorHigh = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 200, 175, 150, false, false, false),
                TextFunc = () => Hud.Game.AverageLatency.ToString("F0", CultureInfo.InvariantCulture),
                HintFunc = () => "平均延迟"
            };

            CurrentDecoratorHigh = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 200, 175, 150, false, false, false),
                TextFunc = () => Hud.Game.CurrentLatency.ToString("F0", CultureInfo.InvariantCulture),
                HintFunc = () => "当前延迟"
            };
		}

        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;

            var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.latency_meter").Rectangle;

            var avg = Hud.Game.AverageLatency;
            var cur = Hud.Game.CurrentLatency;

            (avg >= HighLimit ? AverageDecoratorHigh : AverageDecoratorNormal).Paint(uiRect.Left + uiRect.Width * 0.5f, uiRect.Top + uiRect.Height * 0.62f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Left);
            (cur >= HighLimit ? CurrentDecoratorHigh : CurrentDecoratorNormal).Paint(uiRect.Left + uiRect.Width * 0.5f, uiRect.Top + uiRect.Height * 0.80f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Left);
        }

    }

}