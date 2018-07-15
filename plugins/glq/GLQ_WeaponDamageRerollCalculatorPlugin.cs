using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class GLQ_WeaponDamageRerollCalculatorPlugin : BasePlugin, IInGameTopPainter
    {
        public IFont ActiveFont { get; set; }
        public IFont InactiveFont { get; set; }
        public IFont RerollMaxedFont { get; set; }

        public string RerollLabel { get; set; }
        public string DpsLabel { get; set; }
        public string RangeLabel { get; set; }
        public string DamagePercentLabel { get; set; }
        public string AttackSpeedLabel { get; set; }
        public string PerfectLabel { get; set; }
        public string LineFormat { get; set; }
        public string DpsFormat { get; set; }

        public IFormatProvider NumberFormat { get; set; }

        public Func<float> LeftFunc { get; set; }
        public Func<float> TopFunc { get; set; }

        private readonly WeaponDamageInfo weaponInfo;

        public GLQ_WeaponDamageRerollCalculatorPlugin()
        {
            Enabled = true;
            weaponInfo = new WeaponDamageInfo();
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            RerollLabel = "词缀";
            DpsLabel = "\t大白字秒伤";
            RangeLabel = "满白字时";
            DamagePercentLabel = "有10%伤害时";
            AttackSpeedLabel = "有7%攻速时";
            PerfectLabel = "全完美最高白字";
            LineFormat = "{0}\t{1}";
            DpsFormat = "N1";

            NumberFormat = NumberFormatInfo.InvariantInfo;

            ActiveFont = Hud.Render.CreateFont("tahoma", 7, 255, 154, 105, 24, true, false, 128, 0, 0, 0, true);
            InactiveFont = Hud.Render.CreateFont("tahoma", 7, 128, 154, 105, 24, true, false, 128, 0, 0, 0, true);
            RerollMaxedFont = Hud.Render.CreateFont("tahoma", 7, 255, 24, 192, 24, true, false, 128, 0, 0, 0, true);

            LeftFunc = () =>
            {
                var uicMain = Hud.Inventory.GetHoveredItemMainUiElement();
                return uicMain.Rectangle.X + uicMain.Rectangle.Width * 0.57f;
            };
            TopFunc = () =>
            {
                var uicTop = Hud.Inventory.GetHoveredItemTopUiElement();
                return uicTop.Rectangle.Bottom + (100f / 1180.0f * Hud.Window.Size.Height);
            };
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;

            var item = Hud.Inventory.HoveredItem;
            if (item == null) return;
            if (!item.IsLegendary) return;
            if (!item.SnoItem.HasGroupCode("weapons")) return;

            var baseMin = item.StatList.WeaponDamageBaseMin();
            var baseMax = item.StatList.WeaponDamageBaseMax();
            var weaponDamageDefinition = weaponInfo.Weapons.FirstOrDefault(w => w.BaseMin == baseMin && w.BaseMax == baseMax);
            if (weaponDamageDefinition == null) return;

            var bonusMinMax = item.AncientRank > 0 ? weaponDamageDefinition.BonusAncientMinMax : weaponDamageDefinition.BonusMinMax;
            var bonusMaxMax = item.AncientRank > 0 ? weaponDamageDefinition.BonusAncientMaxMax : weaponDamageDefinition.BonusMaxMax;

            var baseAps = weaponDamageDefinition.Aps;
            var bonusMin = item.StatList.WeaponDamageBonusMin();
            var bonusMax = item.StatList.WeaponDamageBonusMax();
            var bonusDamage = 1 + item.StatList.WeaponDamageBonusDamagePercent();
            var bonusAttackSpeed = 1 + item.StatList.WeaponDamageBonusAttackSpeedPercent();

            var userBase = (baseMin + bonusMin + baseMax + bonusMax) / 2f;
            var userRollBaseDamageRange = (baseMin + bonusMinMax + baseMax + bonusMaxMax) / 2f * baseAps * bonusDamage * bonusAttackSpeed;
            var userRollDamagePercent = userBase * baseAps * 1.1 * bonusAttackSpeed;
            var userRollAttackSpeedPercent = userBase * baseAps * bonusDamage * 1.07;
            var userPerfect = (baseMin + bonusMinMax + baseMax + bonusMaxMax) / 2f * baseAps * 1.1 * 1.07;

            var x = LeftFunc();
            var y = TopFunc();

            y += DrawTextLine(item, x, y, RerollLabel, DpsLabel, true);
            y += DrawTextLine(item, x, y, RangeLabel, userRollBaseDamageRange.ToString(DpsFormat), WeaponDamageInfo.BaseDamageRangeAffixIds.Contains(item.EnchantedAffixNew));
            y += DrawTextLine(item, x, y, DamagePercentLabel, userRollDamagePercent.ToString(DpsFormat), item.EnchantedAffixNew == WeaponDamageInfo.DamageBonusPercentId, bonusDamage == 1.1f);
            y += DrawTextLine(item, x, y, AttackSpeedLabel, userRollAttackSpeedPercent.ToString(DpsFormat), item.EnchantedAffixNew == WeaponDamageInfo.AttackSpeedBonusPercentId, bonusAttackSpeed == 1.07f);
            y += DrawTextLine(item, x, y, PerfectLabel, userPerfect.ToString(DpsFormat), false);
        }

        private float DrawTextLine(IItem item, float x, float y, string label, string value, bool active, bool maxed = false)
        {
            IFont font;
            var text = string.Format(NumberFormat, LineFormat, label, value);
            if (active)
            {
                font = maxed && item.EnchantedAffixCounter > 0 ? RerollMaxedFont : ActiveFont;
            }
            else
            {
                font = InactiveFont;
            }
            var layout = font.GetTextLayout(text);
            font.DrawText(layout, x, y);

            return layout.Metrics.Height;
        }
    }
}

//foreach (IItemStat stat in item.StatList)
//{
//    if (stat != null && stat.Id.Contains("Damage_Weapon_Bonus"))
//    {
//        Jack.Says.Debug("{0,50} {1}", stat.Id, stat.Value);
//        //Hud.Debug(string.Format("{0,50} {1}", stat.Id, stat.Value));
//    }
//}

//var currDps = userBase * baseAps * bonusDamage * bonusAttackSpeed;
//Says.Debug(userBase, currDps, baseMin, baseMax, "|", bonusMin, bonusMax, bonusDamage, bonusAttackSpeed, "|", userRollBaseDamageRange.ToString(DpsFormat), userRollDamagePercent.ToString(DpsFormat), userRollAttackSpeedPercent.ToString(DpsFormat), userPerfect.ToString(DpsFormat));
//Says.Debug(item.EnchantedAffixOriginal, item.EnchantedAffixNew, item.EnchantedAffixCounter, item.ItemUniqueId);

//var currDps = userBase * aps * bonusDam * bonusAps;
//Says.Debug(userBase, currDps, "|", bonusMin, bonusMax, bonusDam, bonusAps, "|", userRollBase.ToString(DpsFormat), userRollPercent.ToString(DpsFormat), userRollAtk.ToString(DpsFormat), userPerfect.ToString(DpsFormat));
//Says.Debug(item.EnchantedAffixOriginal, item.EnchantedAffixNew, item.EnchantedAffixCounter, item.ItemUniqueId);

//Says.Debug(bonusDam, bonusAps);
//Says.Debug(userRollPercent, userRollAtk);
//Says.Debug(item.EnchantedAffixCounter);

//foreach (var stat in item.StatList)
//{
//    if (stat == null || stat.Attribute == null) continue;
//    if (stat.Modifier != item.EnchantedAffixNew) continue;

//    Says.Debug(123, stat.Id, stat.Modifier, stat.Attribute.Index, stat.Attribute.Code);
//}

//Says.Debug(bonusMin, bonusMax, bonusDam, bonusAps, userBase);
//Says.Debug(currDps,
//    Math.Round(userRollBase),
//    Math.Round(userRollAtk),
//    Math.Round(userRollPercent),
//    Math.Round(userPerfect));

//Says.Debug(item.SnoItem.GroupCodes);
//Jack.Says.Debug("======= hovered ========");
////Hud.Debug("======= hovered ========");

//foreach (IItemStat stat in item.StatList)
//{
//    if (stat != null)
//    {
//        Jack.Says.Debug("{0,50} {1}", stat.Id, stat.Value);
//        //Hud.Debug(string.Format("{0,50} {1}", stat.Id, stat.Value));
//    }
//}