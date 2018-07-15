using System;
using System.Collections.Generic;
using System.Globalization;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{

    public class GLQ_TopExperienceStatistics : BasePlugin, IInGameTopPainter
    {

        public HorizontalTopLabelList LabelList { get; private set; }

        public GLQ_TopExperienceStatistics()
            : base()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            var expandedHintFont = Hud.Render.CreateFont("tahoma", 6, 255, 200, 200, 200, false, false, true);

            LabelList = new HorizontalTopLabelList(hud);

            LabelList.LeftFunc = () =>
            {
                return Hud.Window.Size.Width / 2 - Hud.Window.Size.Height * 0.14f;
            };
            LabelList.TopFunc = () =>
            {
                return Hud.Window.Size.Height * 0.001f;
            };
            LabelList.WidthFunc = () =>
            {
                return Hud.Window.Size.Height * 0.14f;
            };
            LabelList.HeightFunc = () =>
            {
                return Hud.Window.Size.Height * 0.018f;
            };

            var currentLevelDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 57, 137, 205, true, false, true),
                BackgroundTexture1 = Hud.Texture.Button2TextureOrange,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity1 = 1.0f,
                BackgroundTextureOpacity2 = 0.5f,
                TextFunc = () => (Hud.Game.Me.CurrentLevelNormal < Hud.Game.Me.CurrentLevelNormalCap) ? Hud.Game.Me.CurrentLevelNormal.ToString("0") : Hud.Game.Me.CurrentLevelParagonFloat.ToString("0.##", CultureInfo.InvariantCulture) + "级",
                ExpandDownLabels = new List<TopLabelDecorator>(),
            };

            foreach (var levelIncrement in new uint[] { 1, 2, 5, 10, 20, 50, 100, 250, 500, 1000 })
            {
                currentLevelDecorator.ExpandDownLabels.Add(
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 6, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = 2,
                        BackgroundTexture1 = Hud.Texture.Button2TextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity1 = 1.0f,
                        BackgroundTextureOpacity2 = 0.5f,
                        HideBackgroundWhenTextIsEmpty = true,
                        TextFunc = () => Hud.Game.Me.CurrentLevelNormal >= Hud.Game.Me.CurrentLevelNormalCap ? ((Hud.Game.Me.CurrentLevelParagon + levelIncrement).ToString("D", CultureInfo.InvariantCulture) + "级") : null,
                        HintFunc = () => ExpToParagonLevel(Hud.Game.Me.CurrentLevelParagon + levelIncrement) + " = " + TimeToParagonLevel(Hud.Game.Me.CurrentLevelParagon + levelIncrement, false),
                    });
            }

            LabelList.LabelDecorators.Add(currentLevelDecorator);

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 57, 137, 205, true, false, true),
                BackgroundTexture1 = Hud.Texture.Button2TextureOrange,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity1 = 1.0f,
                BackgroundTextureOpacity2 = 0.5f,
                TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.CurrentHeroToday.GainedExperiencePerHourPlay, ValueFormat.ShortNumber) + " 经验/小时",
            });

        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;

            LabelList.Paint();
        }

        public string ExpToParagonLevel(uint paragonLevel)
        {
            if (paragonLevel > Hud.Game.Me.CurrentLevelParagon)
            {
                var xpRequired = Hud.Sno.TotalParagonExperienceRequired(paragonLevel);
                var xpRemaining = xpRequired - Hud.Game.Me.ParagonTotalExp;
                return GLQ_BasePluginCN.ValueToString(xpRemaining, ValueFormat.LongNumber);
            }
            return null;
        }

        public string TimeToParagonLevel(uint paragonLevel, bool includetext)
        {
            var tracker = Hud.Game.CurrentHeroToday;
            if (tracker != null)
            {
                if (paragonLevel > Hud.Game.Me.CurrentLevelParagon)
                {
                    var text = includetext ? (paragonLevel.ToString("D", CultureInfo.InvariantCulture) + "级") + ": " : "";
                    var xph = tracker.GainedExperiencePerHourPlay;
                    if (xph > 0)
                    {
                        var xpRequired = Hud.Sno.TotalParagonExperienceRequired(paragonLevel);
                        var xpRemaining = xpRequired - Hud.Game.Me.ParagonTotalExp;
                        var hours = xpRemaining / xph;
                        var ticks = Convert.ToInt64(Math.Ceiling(hours * 60.0d * 60.0d * 1000.0d * TimeSpan.TicksPerMillisecond));
                        text += GLQ_BasePluginCN.ValueToString(ticks, ValueFormat.LongTimeNoSeconds);
                    }
                    else text += "-";
                    return text;
                }
            }
            return null;
        }

    }

}