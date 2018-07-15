using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;
//
// This plugin will show one single icon with the timedown to your best elemtnes on the top of your player.
// If you wearing the Broken Promisses too, it will show another icon while 100% CHC is active.
//
namespace Turbo.Plugins.wq {
    public class ConventionOfElementsAndBrokenPromissesBuffOnCenterPlugin : BasePlugin, IInGameTopPainter {

        public bool HideWhenUiIsHidden { get; set; }
        public BuffPainter BuffPainter { get; set; }
		public float PositionOffset { get; set; }
		public float IconSizeMultiplier{get; set;}

		public const int ConventionElementID = 430674;
		public const int BrokenPromissesID = 402462;
		public const uint BrokenPromissesSnoItemID = 3106202140;

		//CoE means Convention Of Elements
        private BuffRuleCalculator ruleCalculatorCoE;

		//BP means Broken Promisses
		private BuffRuleCalculator ruleCalculatorBP;

        public ConventionOfElementsAndBrokenPromissesBuffOnCenterPlugin() {
            Enabled = true;
			PositionOffset = 0.04f;
			IconSizeMultiplier = 1.0f;
        }

        public override void Load(IController hud) {
            base.Load(hud);

            HideWhenUiIsHidden = false;

            BuffPainter = new BuffPainter(Hud, true)
            {
                Opacity = 1.0f,
                TimeLeftFont = Hud.Render.CreateFont("tahoma", 10, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true),
            };

            ruleCalculatorCoE = new BuffRuleCalculator(Hud);
            ruleCalculatorCoE.SizeMultiplier = IconSizeMultiplier;

            ruleCalculatorCoE.Rules.Add(new BuffRule(ConventionElementID) { IconIndex = 1, MinimumIconCount = 0, DisableName = true }); // Arcane
            ruleCalculatorCoE.Rules.Add(new BuffRule(ConventionElementID) { IconIndex = 2, MinimumIconCount = 0, DisableName = true }); // Cold
            ruleCalculatorCoE.Rules.Add(new BuffRule(ConventionElementID) { IconIndex = 3, MinimumIconCount = 0, DisableName = true }); // Fire
            ruleCalculatorCoE.Rules.Add(new BuffRule(ConventionElementID) { IconIndex = 4, MinimumIconCount = 0, DisableName = true }); // Holy
            ruleCalculatorCoE.Rules.Add(new BuffRule(ConventionElementID) { IconIndex = 5, MinimumIconCount = 0, DisableName = true }); // Lightning
            ruleCalculatorCoE.Rules.Add(new BuffRule(ConventionElementID) { IconIndex = 6, MinimumIconCount = 0, DisableName = true }); // Physical
            ruleCalculatorCoE.Rules.Add(new BuffRule(ConventionElementID) { IconIndex = 7, MinimumIconCount = 0, DisableName = true }); // Poison

			ruleCalculatorBP = new BuffRuleCalculator(Hud);
			ruleCalculatorBP.SizeMultiplier = IconSizeMultiplier;
			ruleCalculatorBP.Rules.Add(new BuffRule(BrokenPromissesID) { IconIndex = 1, MinimumIconCount = 0, DisableName = true});   // Broken Promisses

        }

//-- Main Function to generate the paint list

		private List<BuffPaintInfo> GeneratePaintList() {
            var player = Hud.Game.Me;

			if (!player.HasValidActor) return null;

			var paintInfoList = new List<BuffPaintInfo>();

			//Add Convention Of Elements and caculate timedown
			var elementPaintInfo = GetElementPaintInfo();
			if(elementPaintInfo != null) {
				paintInfoList.Add(elementPaintInfo);
			}

			var bpPaintInfo = GetBrokenPromissesPaintInfo();
			if(bpPaintInfo != null) {
				paintInfoList.Add(bpPaintInfo);
			}

			return paintInfoList;
		}
//-- End of Main function to generate the paint list

//-- Broken Promisses Buff part

		// I cant locate the texture of the buff itself(maybe the blizzard doesn't want to show the buff at all).
		// So I use the legendary item instead. It will locate the cube first if there is no then use the
		// inventory to find the ring on your finger.
		private ISnoItem FindBPRing() {
			ISnoItem item = Hud.Game.Me.CubeSnoItem3;
			if(item != null && BrokenPromissesSnoItemID == item.Sno) return item;
			item = Hud.Inventory.GetSnoItem(BrokenPromissesSnoItemID);
			if(item!=null) return item;
			return null;
		}

		private BuffPaintInfo GetBrokenPromissesPaintInfo() {

			var player = Hud.Game.Me;

			ISnoItem item = FindBPRing();
			if(item == null) return null;

			var buff = player.Powers.GetBuff(ruleCalculatorBP.Rules[0].PowerSno);

			if(buff == null || !buff.Active) return null;

			int index = 2; //I dont know why is 2, but it works on my computer.
			var timeLeft = buff.TimeLeftSeconds[index];

			// Here I only show icon while the 100% CHC is active
			if(timeLeft > 0) {
				ruleCalculatorBP.Rules[0].UseLegendaryItemTexture = item;
				ruleCalculatorBP.CalculatePaintInfo(player);
				if(ruleCalculatorBP.PaintInfoList.Count > 0) {
					var info = ruleCalculatorBP.PaintInfoList[0];
					if(timeLeft > 0) {
						info.TimeLeft = timeLeft;
					}
					return info;
				}
			}
			return null;
		}
//-- End of Broken Promisses Buff part

//-- Convention of Elements Buff part

		// This part copied from the Default plugins. Thanks for the job done.
        private IEnumerable<BuffRule> GetCurrentRules(HeroClass heroClass) {
            for (int i = 1; i <= 7; i++)
            {
                switch (heroClass)
                {
                    case HeroClass.Barbarian: if (i == 1 || i == 4 || i == 7) continue; break;
                    case HeroClass.Crusader: if (i == 1 || i == 2 || i == 7) continue; break;
                    case HeroClass.DemonHunter: if (i == 1 || i == 4 || i == 7) continue; break;
                    case HeroClass.Monk: if (i == 1 || i == 7) continue; break;
                    case HeroClass.Necromancer: if (i == 1 || i == 3 || i == 4 || i == 5) continue; break;
                    case HeroClass.WitchDoctor: if (i == 1 || i == 4 || i == 5) continue; break;
                    case HeroClass.Wizard: if (i == 4 || i == 6 || i == 7) continue; break;
                }
                yield return ruleCalculatorCoE.Rules[i - 1];
            }
        }

		private BuffPaintInfo GetElementPaintInfo() {
			var player = Hud.Game.Me;
			var classSpecificRules = GetCurrentRules(player.HeroClassDefinition.HeroClass);

			ruleCalculatorCoE.CalculatePaintInfo(player, classSpecificRules);

			if (ruleCalculatorCoE.PaintInfoList.Count == 0) return null;
			if (!ruleCalculatorCoE.PaintInfoList.Any(info => info.TimeLeft > 0)) return null;

			var buff = Hud.Game.Me.Powers.GetBuff(ConventionElementID);

			if ((buff == null) || (buff.IconCounts[0] <= 0)) return null;

			var bestElementIndex = LocateBestElement();
			var currentElementIndex = LocateCurrentElement();

			var paintInfo = ruleCalculatorCoE.PaintInfoList[currentElementIndex];

			if (bestElementIndex == currentElementIndex) {
				paintInfo.TimeLeftNumbersOverride = false;
			} else if(bestElementIndex > currentElementIndex) {
				paintInfo.TimeLeft += (bestElementIndex - currentElementIndex - 1) * 4;
			} else {
				paintInfo.TimeLeft += (ruleCalculatorCoE.PaintInfoList.Count - 1 - currentElementIndex + bestElementIndex) * 4;
			}
			return paintInfo;
		}

		private int LocateCurrentElement() {
			for (int index = 0; index < ruleCalculatorCoE.PaintInfoList.Count; index++) {
				if (ruleCalculatorCoE.PaintInfoList[index].TimeLeft > 0) return index;
			}
			return 0;
		}

		private int LocateBestElement() {
			var player = Hud.Game.Me;
			var highestElementalBonus = player.Offense.HighestElementalDamageBonus;
			var list = ruleCalculatorCoE.PaintInfoList;
			for(int index = 0; index < list.Count - 1; index++) {
				var best = false;
				var info = list[index];
				switch (info.Rule.IconIndex) {
					case 1: best = player.Offense.BonusToArcane == highestElementalBonus; break;
					case 2: best = player.Offense.BonusToCold == highestElementalBonus; break;
					case 3: best = player.Offense.BonusToFire == highestElementalBonus; break;
					case 4: best = player.Offense.BonusToHoly == highestElementalBonus; break;
					case 5: best = player.Offense.BonusToLightning == highestElementalBonus; break;
					case 6: best = player.Offense.BonusToPhysical == highestElementalBonus; break;
					case 7: best = player.Offense.BonusToPoison == highestElementalBonus; break;
				}
				if (best) return index;
			}
			return 0;
		}
//-- End of Convention of Elements part

		private void debug(string message) {
			Hud.TextLog.Log("Debug", message);
		}

        public void PaintTopInGame(ClipState clipState) {
            if (clipState != ClipState.BeforeClip) return;
            if (HideWhenUiIsHidden && Hud.Render.UiHidden) return;
			if(!Enabled) return;
			var paintInfoList = GeneratePaintList();
			if (paintInfoList == null || paintInfoList.Count == 0) return;

			var x = 0;
			var y = Hud.Window.Size.Height * 0.25f - Hud.Window.Size.Height * PositionOffset;
            BuffPainter.PaintHorizontalCenter(paintInfoList, x, y, Hud.Window.Size.Width, ruleCalculatorCoE.StandardIconSize, ruleCalculatorCoE.StandardIconSpacing);
        }
    }

}