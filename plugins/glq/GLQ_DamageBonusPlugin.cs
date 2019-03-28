using System;
using System.Globalization;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_DamageBonusPlugin : BasePlugin, IInGameTopPainter
    {

        public bool ShowInTown { get; set; }
        public bool ShowOutOfTown { get; set; }
        public TopLabelDecorator PhysicalDecorator { get; set; }
        public TopLabelDecorator FireDecorator { get; set; }
        public TopLabelDecorator LightningDecorator { get; set; }
        public TopLabelDecorator ColdDecorator { get; set; }
        public TopLabelDecorator PoisonDecorator { get; set; }
        public TopLabelDecorator ArcaneDecorator { get; set; }
        public TopLabelDecorator HolyDecorator { get; set; }
        public TopLabelDecorator EliteDecorator { get; set; }

        public GLQ_DamageBonusPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            ShowInTown = true;
            ShowOutOfTown = false;

            PhysicalDecorator = new TopLabelDecorator(Hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(180, 155, 6, 0, 0),
                BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, -1),
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, true),
                TextFunc = () => Hud.Game.Me.Offense.BonusToPhysical > 0 ? Convert.ToInt32(Hud.Game.Me.Offense.BonusToPhysical * 100).ToString("D", CultureInfo.InvariantCulture) : "",
                HintFunc = () => "物理元素加成%"
            };

            FireDecorator = new TopLabelDecorator(Hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(180, 183, 57, 7, 0),
                BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, -1),
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, true),
                TextFunc = () => Hud.Game.Me.Offense.BonusToFire > 0 ? Convert.ToInt32(Hud.Game.Me.Offense.BonusToFire * 100).ToString("D", CultureInfo.InvariantCulture) : "",
                HintFunc = () => "火焰元素加成%"
            };

            LightningDecorator = new TopLabelDecorator(Hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(180, 0, 38, 119, 0),
                BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, -1),
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, true),
                TextFunc = () => Hud.Game.Me.Offense.BonusToLightning > 0 ? Convert.ToInt32(Hud.Game.Me.Offense.BonusToLightning * 100).ToString("D", CultureInfo.InvariantCulture) : "",
                HintFunc = () => "闪电元素加成%"
            };

            ColdDecorator = new TopLabelDecorator(Hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(180, 77, 102, 155, 0),
                BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, -1),
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, true),
                TextFunc = () => Hud.Game.Me.Offense.BonusToCold > 0 ? Convert.ToInt32(Hud.Game.Me.Offense.BonusToCold * 100).ToString("D", CultureInfo.InvariantCulture) : "",
                HintFunc = () => "冰霜元素加成%"
            };

            PoisonDecorator = new TopLabelDecorator(Hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(180, 50, 106, 21, 0),
                BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, -1),
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, true),
                TextFunc = () => Hud.Game.Me.Offense.BonusToPoison > 0 ? Convert.ToInt32(Hud.Game.Me.Offense.BonusToPoison * 100).ToString("D", CultureInfo.InvariantCulture) : "",
                HintFunc = () => "毒素元素加成%"
            };

            ArcaneDecorator = new TopLabelDecorator(Hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(180, 138, 0, 94, 0),
                BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, -1),
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, true),
                TextFunc = () => Hud.Game.Me.Offense.BonusToArcane > 0 ? Convert.ToInt32(Hud.Game.Me.Offense.BonusToArcane * 100).ToString("D", CultureInfo.InvariantCulture) : "",
                HintFunc = () => "奥术元素加成%"
            };

            HolyDecorator = new TopLabelDecorator(Hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(180, 190, 117, 0, 0),
                BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, -1),
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, true),
                TextFunc = () => Hud.Game.Me.Offense.BonusToHoly > 0 ? Convert.ToInt32(Hud.Game.Me.Offense.BonusToHoly * 100).ToString("D", CultureInfo.InvariantCulture) : "",
                HintFunc = () => "神圣元素加成%"
            };

            EliteDecorator = new TopLabelDecorator(Hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(180, 255, 148, 20, 0),
                BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, -1),
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, true),
                TextFunc = () => Hud.Game.Me.Offense.BonusToElites > 0 ? Convert.ToInt32(Hud.Game.Me.Offense.BonusToElites * 100).ToString("D", CultureInfo.InvariantCulture) : "",
                HintFunc = () => "精英伤害加成%",
            };
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;

            if (!ShowInTown && Hud.Game.IsInTown) return;
            if (!ShowOutOfTown && !Hud.Game.IsInTown) return;

            if (clipState == ClipState.BeforeClip)
            {
                var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_window_hud_overlay").Rectangle;

                var w = Hud.Window.Size.Height * 0.025f;
                var h = Hud.Window.Size.Height * 0.017f;

                var x = uiRect.Left + uiRect.Width * 0.09f;
                var y = uiRect.Bottom - h - (Hud.Window.Size.Height / 600);

                EliteDecorator.Paint(x + w * 0, y, w, h, HorizontalAlign.Center);
                PhysicalDecorator.Paint(x + w * 1, y, w, h, HorizontalAlign.Center);
                FireDecorator.Paint(x + w * 2, y, w, h, HorizontalAlign.Center);
                LightningDecorator.Paint(x + w * 3, y, w, h, HorizontalAlign.Center);
                ColdDecorator.Paint(x + w * 4, y, w, h, HorizontalAlign.Center);
                PoisonDecorator.Paint(x + w * 5, y, w, h, HorizontalAlign.Center);
                ArcaneDecorator.Paint(x + w * 6, y, w, h, HorizontalAlign.Center);
                HolyDecorator.Paint(x + w * 7, y, w, h, HorizontalAlign.Center);
            }
        }

    }

}