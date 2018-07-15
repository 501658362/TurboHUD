using System.Collections.Generic;
using System.Globalization;

namespace Turbo.Plugins.Default
{

    public class AttributeLabelListPlugin : BasePlugin, IInGameTopPainter
    {

        public HorizontalTopLabelList LabelList { get; private set; }

        public AttributeLabelListPlugin()
            : base()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
           base.Load(hud);

            var expandedHintFont = Hud.Render.CreateFont("tahoma", 7, 255, 200, 200, 200, false, false, true);

            LabelList = new HorizontalTopLabelList(hud);

            LabelList.LeftFunc = () =>
            {
                var ui = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_window_hud_overlay");
                return ui.Rectangle.Left + ui.Rectangle.Width * 0.267f;
            };
            LabelList.TopFunc = () =>
            {
                var ui = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_window_hud_overlay");
                return ui.Rectangle.Top + ui.Rectangle.Height * 0.318f;
            };
            LabelList.WidthFunc = () =>
            {
                var ui = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_window_hud_overlay");
                return Hud.Window.Size.Height * 0.07f;
            };
            LabelList.HeightFunc = () =>
            {
                var ui = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_window_hud_overlay");
                return Hud.Window.Size.Height * 0.025f;
            };

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                ExpandedHintFont = expandedHintFont,
                BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                BackgroundTextureOpacity2 = 0.70f,
                TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.Defense.EhpMax, ValueFormat.ShortNumber),
                HintFunc = () => "最大坚韧",
                ExpandUpLabels = new List<TopLabelDecorator>()
                {
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => (Hud.Game.Me.Defense.drCombined * 100).ToString("F1", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "总减免",
                    },
                   new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => (Hud.Game.Me.Defense.drArmor * 100).ToString("F1", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "护甲减伤",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => Hud.Game.Me.Defense.Armor.ToString("#,0", CultureInfo.InvariantCulture),
                        HintFunc = () => "护甲",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => (Hud.Game.Me.Defense.drResist * 100).ToString("F1", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "抗性减伤",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => Hud.Game.Me.Defense.ResAverage.ToString("#,0", CultureInfo.InvariantCulture),
                        HintFunc = () => "平均抗性",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => (Hud.Game.Me.Defense.DRElite * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "精英减伤",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => (Hud.Game.Me.Defense.DRMelee * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "近战减伤",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => (Hud.Game.Me.Defense.DRRanged * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "远程减伤",
                    }
                }
            });

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                ExpandedHintFont = expandedHintFont,
                BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
                BackgroundTextureOpacity2 = 0.5f,
                TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.Offense.SheetDps, ValueFormat.ShortNumber),
                HintFunc = () => "面板伤害",
                ExpandUpLabels = new List<TopLabelDecorator>()
                {
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureYellow,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.Offense.MainHandIsActive ? Hud.Game.Me.Offense.WeaponDamageMainHand : Hud.Game.Me.Offense.WeaponDamageSecondHand, ValueFormat.ShortNumber),
                        HintFunc = () => "武器伤害",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureYellow,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Offense.AttackSpeedPets.ToString("F2", CultureInfo.InvariantCulture) + "/秒",
                        HintFunc = () => "宠物攻速",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureYellow,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Offense.AttackSpeed.ToString("F2", CultureInfo.InvariantCulture) + "/秒",
                        HintFunc = () => "攻击速度",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureYellow,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Offense.CriticalHitChance.ToString("F1", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "暴击几率",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureYellow,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Offense.CritDamage.ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "爆击伤害",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureYellow,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => (Hud.Game.Me.Offense.BonusToElites * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "精英伤害",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureYellow,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => (Hud.Game.Me.Offense.HighestElementalDamageBonus * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "最高元素",
                    }
                }
            });

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 120, 255, 255, 255, false, false, true),
                BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
                BackgroundTextureOpacity2 = 0.5f,
                TextFunc = () => Hud.Game.Me.Offense.AttackSpeedPets.ToString("F2", CultureInfo.InvariantCulture) + "/秒",
                HintFunc = () => "宠物攻击速度",
            });

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 200, 128, 255, 255, true, false, true),
                BackgroundTexture1 = Hud.Texture.BuffFrameTexture,
                BackgroundTexture2 = Hud.Texture.Button2TextureGray,
                BackgroundTextureOpacity2 = 1f,
                TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.Damage.CurrentDps, ValueFormat.LongNumber),
                HintFunc = () => "当前秒伤",
            });

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 200, 255, 255, 255, true, false, true),
                BackgroundTexture1 = Hud.Texture.BuffFrameTexture,
                BackgroundTexture2 = Hud.Texture.Button2TextureBrown,
                BackgroundTextureOpacity2 = 1f,
                TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.Damage.RunDps, ValueFormat.LongNumber),
                HintFunc = () => "平均秒伤",
            });

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 200, 255, 255, 128, true, false, true),
                BackgroundTexture1 = Hud.Texture.BuffFrameTexture,
                BackgroundTexture2 = Hud.Texture.Button2TextureGray,
                BackgroundTextureOpacity2 = 1f,
                TextFunc = () => GLQ_BasePluginCN.ValueToString(Hud.Game.Me.Damage.TotalDamage, ValueFormat.LongNumber),
                HintFunc = () => "总伤害",
            });


            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true),
                ExpandedHintFont = expandedHintFont,
                BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity2 = 0.5f,
                TextFunc = () => (Hud.Game.Me.Stats.CooldownReduction * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
                HintFunc = () => "冷却时间效果缩短%",
                ExpandUpLabels = new List<TopLabelDecorator>()
                {
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => (Hud.Game.Me.Stats.ResourceCostReduction * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "能耗降低",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Defense.LifeRegen.ToString("F0", CultureInfo.InvariantCulture) + "/秒",
                        HintFunc = () => "每秒恢复",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Stats.MoveSpeed.ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "移动速度",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Offense.AreaDamageBonus.ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "范围伤害",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => (Hud.Game.Me.Stats.PickupRange - 5).ToString("F0", CultureInfo.InvariantCulture) + "码",
                        HintFunc = () => "拾取距离",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Stats.GoldFind.ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "金币加成",
                    }
                }
            });

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 120, 255, 200, 200, false, false, true),
                BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity2 = 0.75f,
                TextFunc = () => (Hud.Game.Me.Stats.ResourceCostReduction * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
                HintFunc = () => "能量消耗降低%",
            });

            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 120, 255, 200, 200, false, false, true),
                BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity2 = 0.75f,
                TextFunc = () => Hud.Game.Me.Stats.MoveSpeed.ToString("F0", CultureInfo.InvariantCulture) + "%",
                HintFunc = () => "移动速度",
            });
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;

            LabelList.Paint();
        }

    }

}