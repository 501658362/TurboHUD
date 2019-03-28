using System.Globalization;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{

    public class GLQ_ExperienceOverBarPlugin : BasePlugin, IInGameTopPainter
	{

        public TopLabelDecorator BlueThisLevelValueDecorator { get; set; }
        public TopLabelDecorator OrangeThisLevelValueDecorator { get; set; }
        public TopLabelDecorator BlueNextLevelValueDecorator { get; set; }
        public TopLabelDecorator OrangeNextLevelValueDecorator { get; set; }
        public TopLabelDecorator BlueExpPercentValueDecorator{ get; set; }
        public TopLabelDecorator OrangeExpPercentValueDecorator { get; set; }
        public TopLabelDecorator BonusValueDecorator { get; set; }

		public GLQ_ExperienceOverBarPlugin()
		{
            Enabled = true;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            BlueThisLevelValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 5.5f, 255, 140, 140, 180, false, false, 160, 0, 0, 0, true),
                TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.ParagonExpInThisLevel, ValueFormat.LongNumber),
                HintFunc = () => "当前经验",
            };

            OrangeThisLevelValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 5.5f, 255, 200, 160, 140, false, false, 160, 0, 0, 0, true),
                TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.ParagonExpInThisLevel, ValueFormat.LongNumber),
                HintFunc = () => "当前经验",
            };

            BlueNextLevelValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 5.5f, 255, 140, 140, 180, false, false, 160, 0, 0, 0, true),
                TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.ParagonExpToNextLevel, ValueFormat.LongNumber), 
                HintFunc = () => "升到下一级所需经验",
            };

            OrangeNextLevelValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 5.5f, 255, 200, 160, 140, false, false, 160, 0, 0, 0, true),
                TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.ParagonExpToNextLevel, ValueFormat.LongNumber), 
                HintFunc = () => "升到下一级所需经验",
            };
            BlueExpPercentValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 5.5f, 255, 140, 140, 180, false, false, 160, 0, 0, 0, true),
                TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.ParagonExpInThisLevel, ValueFormat.LongNumber),
                HintFunc = () => "当前经验百分比",
            };

            OrangeExpPercentValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 5.5f, 255, 200, 160, 140, false, false, 160, 0, 0, 0, true),
                TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.ParagonExpInThisLevel, ValueFormat.LongNumber),
                HintFunc = () => "当前经验百分比",
            };

            BonusValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 5.5f, 255, 200, 160, 140, false, false, 160, 0, 0, 0, true),
                TextFunc = () => (10 * ((float)Hud.Game.Me.BonusPoolRemaining / Hud.Game.Me.ParagonExpToNextLevel)).ToString("f2")+"个池 " + GLQ_BasePluginCN.ValueToString(Hud.Game.Me.BonusPoolRemaining * 5, ValueFormat.LongNumber) , 
                HintFunc = () => "经验池数量及消耗剩余经验池所需经验",
            };
		}

        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;

            var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_window_hud_overlay").Rectangle;

            var bonusRemaining = Hud.Game.Me.BonusPoolRemaining;
            BlueExpPercentValueDecorator.TextFunc = () => ((double)Hud.Game.Me.ParagonExpInThisLevel / (double)Hud.Game.Me.ParagonExpToNextLevel * 100).ToString("f2")+"%";
            OrangeExpPercentValueDecorator.TextFunc = () => ((double)Hud.Game.Me.ParagonExpInThisLevel / (double)Hud.Game.Me.ParagonExpToNextLevel * 100).ToString("f2") + "%";
            (bonusRemaining > 0 ? OrangeThisLevelValueDecorator : BlueThisLevelValueDecorator).Paint(uiRect.Left + uiRect.Width * 0.42f, uiRect.Top + uiRect.Height * 0.470f, uiRect.Width * 0.075f, uiRect.Height * 0.07f, HorizontalAlign.Right);
            (bonusRemaining > 0 ? OrangeNextLevelValueDecorator : BlueNextLevelValueDecorator).Paint(uiRect.Left + uiRect.Width * 0.505f, uiRect.Top + uiRect.Height * 0.470f, uiRect.Width * 0.075f, uiRect.Height * 0.07f, HorizontalAlign.Left);
            (bonusRemaining > 0 ? OrangeExpPercentValueDecorator : BlueExpPercentValueDecorator).Paint(uiRect.Left + uiRect.Width * 0.554f, uiRect.Top + uiRect.Height * 0.470f, uiRect.Width * 0.075f, uiRect.Height * 0.07f, HorizontalAlign.Right);

            if (bonusRemaining > 0)
            {
                BonusValueDecorator.Paint(uiRect.Left + uiRect.Width * 0.651f, uiRect.Top + uiRect.Height * 0.470f, uiRect.Width * 0.075f, uiRect.Height * 0.07f, HorizontalAlign.Right);
            }
        }

    }

}