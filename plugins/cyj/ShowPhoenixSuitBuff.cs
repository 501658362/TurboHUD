//using System;
//using System.Linq;
//using System.Globalization;
//using System.Collections.Generic;
//using Turbo.Plugins.Default;
//using Turbo.Plugins.glq;
//namespace Turbo.Plugins.cyj
//{
//
//    public class ShowPhoenixSuitBuff : BasePlugin, INewAreaHandler, IInGameTopPainter
//    {
//        public bool HideWhenUiIsHidden { get; set; }
//        public float IconSizeMultiplier{get; set;}
//        public BuffPainter BuffPainter { get; set; }
//        public BuffRuleCalculator RuleCalculatorMe { get; private set;}
//        public Dictionary<HeroClass, BuffRuleCalculator> RuleCalculators { get; private set; }
//		public bool MePortraitPaint { get; set; }
//		public bool MeScreenPaint { get; set; }
//		public bool OtherPortraitPaint { get; set; }
//		public bool OtherScreenPaint { get; set; }
//		public bool Tooltips { get; set; }
//        private float SizeMultiplier { get; set; }
//        public float Opacity { get; set; }
//        public float PositionOffset { get; set; }
//        public float MePositionOffset { get; set; }
//        private BuffRuleFactory buffRuleFactory;
//		//CoE means Convention Of Elements
//        private BuffRuleCalculator ruleCalculatorCoE;
//
//        public ShowPhoenixSuitBuff()
//        {
//            Enabled = true;
//			MeScreenPaint = true;
//			MePortraitPaint = true;
//			OtherScreenPaint = true;
//			OtherPortraitPaint = true;
//			Tooltips = true;
//        }
//
//         public override void Load(IController hud)
//         {
//             base.Load(hud);
//             buffRuleFactory = new BuffRuleFactory(hud);
//             SizeMultiplier = 0.85f;
//             PositionOffset = 0.085f;
//             MePositionOffset = 0.04f;
//             Opacity = 0.85f;
//             RuleCalculatorMe = new BuffRuleCalculator(Hud);
//             RuleCalculatorMe.SizeMultiplier = SizeMultiplier;
//             RuleCalculators = new Dictionary<HeroClass, BuffRuleCalculator>();
//             foreach(HeroClass h in Enum.GetValues(typeof(HeroClass))){
//                 RuleCalculators.Add(h, new BuffRuleCalculator(Hud));
//                 RuleCalculators[h].SizeMultiplier = SizeMultiplier;
//             }
//
//            ruleCalculatorCoE = new BuffRuleCalculator(Hud);
//            ruleCalculatorCoE.SizeMultiplier = IconSizeMultiplier;
//
//            ruleCalculatorCoE.Rules.Add(new BuffRule(445814) { IconIndex = 7, MinimumIconCount = 0, DisableName = true });
//
//
//             BuffPainter = new BuffPainter(Hud, true)
//             {
//                 Opacity = Opacity,
//                 ShowTimeLeftNumbers = true,
//                 ShowTooltips = Tooltips,
//                 TimeLeftFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true),
//                 StackFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true),
//             };
//
// 		}
//
//         public void PaintWorld(WorldLayer layer)
//         {
//             var players = Hud.Game.Players;
//             foreach(var p in players){
// 				var portraitRect = p.PortraitUiElement.Rectangle;
//                 if (p.IsMe){
//                     RuleCalculatorMe.CalculatePaintInfo(p);
//                     if (RuleCalculatorMe.PaintInfoList.Count != 0)
// 						if (MeScreenPaint)
// 						{
// 						    BuffPainter.PaintHorizontalCenter(
//                             RuleCalculatorMe.PaintInfoList,
//                             0,
//                             Hud.Window.Size.Height * 0.5f + Hud.Window.Size.Height * MePositionOffset,
//                             Hud.Window.Size.Width,
//                             RuleCalculatorMe.StandardIconSize,
//                             RuleCalculatorMe.StandardIconSpacing
//                         );
// 						}
//
//                 }
//             }
// 		}
//
//         private bool BuffRuleExsitsForPlayer(IPlayer p, IBuff b){
//             BuffRuleCalculator r = (p.IsMe) ? RuleCalculatorMe : RuleCalculators[p.HeroClassDefinition.HeroClass];
//             foreach(BuffRule t in r.Rules)
//                 if (t.PowerSno == b.SnoPower.Sno)
//                     return true;
//             return false;
//         }
//
//         private string DataOnBuff(IBuff b){
//             string res = "";
//             res += b.SnoPower.Sno.ToString() + " \t";
//             res += "["+string.Join(",", b.IconCounts)+"]" + "\t";
//             res += b.Active.ToString() + " \t";
//             res += b.SnoPower.NameLocalized + " \t";
//             res += b.SnoPower.Code + " \t";
//             //res += t.SnoPower.DescriptionEnglish;
//             return res;
//         }
//
//         public void DisplayOnAll(params uint[] pwrs){
//             foreach(HeroClass h in Enum.GetValues(typeof(HeroClass)))
//                 AddPower(RuleCalculators[h], pwrs);
//             AddPower(RuleCalculatorMe, pwrs);
//         }
//
//         public void DisplayOnMe(params uint[] pwrs){
//             AddPower(RuleCalculatorMe, pwrs);
//         }
//
//         public void DisplayOnAllClassesExceptMe(params uint[] pwrs){
//             foreach(HeroClass h in Enum.GetValues(typeof(HeroClass)))
//                 AddPower(RuleCalculators[h], pwrs);
//         }
//
//         public void DisplayOnClassExceptMe(HeroClass h, params uint[] pwrs){
//             AddPower(RuleCalculators[h], pwrs);
//         }
//
//         private void AddPower(BuffRuleCalculator bf, params uint[] pwrs){
//             if (pwrs == null) return;
//             foreach(uint p in pwrs)
//                 AddPower(bf, p);
//         }
//
//         private void AddPower(BuffRuleCalculator bf, uint pwr){
//             var buffRules = buffRuleFactory.CreateBuffRules(pwr);       //ty jack!
//             if (buffRules != null){
//                 bf.Rules.AddRange(buffRules);
//             }
//         }
//
//
//        public void OnNewArea(bool newGame, ISnoArea area)
//        {
//            if (!newGame) return;
//
//        }
//
//
//		private List<BuffPaintInfo> GeneratePaintList() {
//            var player = Hud.Game.Me;
//
//			if (!player.HasValidActor) return null;
//
//			var paintInfoList = new List<BuffPaintInfo>();
//
//			//Add Convention Of Elements and caculate timedown
//			var elementPaintInfo = GetElementPaintInfo();
//			if(elementPaintInfo != null) {
//				paintInfoList.Add(elementPaintInfo);
//			}
//
//
//			return paintInfoList;
//		}
//
//		// This part copied from the Default plugins. Thanks for the job done.
//        private IEnumerable<BuffRule> GetCurrentRules(HeroClass heroClass) {
//            for (int i = 1; i <= 7; i++)
//            {
//                switch (heroClass)
//                {
//                    case HeroClass.Barbarian: if (i == 1 || i == 4 || i == 7) continue; break;
//                    case HeroClass.Crusader: if (i == 1 || i == 2 || i == 7) continue; break;
//                    case HeroClass.DemonHunter: if (i == 1 || i == 4 || i == 7) continue; break;
//                    case HeroClass.Monk: if (i == 1 || i == 7) continue; break;
//                    case HeroClass.Necromancer: if (i == 1 || i == 3 || i == 4 || i == 5) continue; break;
//                    case HeroClass.WitchDoctor: if (i == 1 || i == 4 || i == 5) continue; break;
//                    case HeroClass.Wizard: if (i == 4 || i == 6 || i == 7) continue; break;
//                }
//                yield return ruleCalculatorCoE.Rules[i - 1];
//            }
//        }
//
//        private BuffPaintInfo GetElementPaintInfo() {
//        	var player = Hud.Game.Me;
//        	var classSpecificRules = GetCurrentRules(player.HeroClassDefinition.HeroClass);
//
//        	var paintInfo = new BuffRule(445814) { IconIndex = 7, MinimumIconCount = 0, DisableName = true }.PaintInfoList;
//
//        	return paintInfo;
//        }
//
//        public void PaintTopInGame(ClipState clipState) {
//            if (clipState != ClipState.BeforeClip) return;
//			if(!Enabled) return;
//
//			var buff = Hud.Game.Me.Powers.GetBuff(445814);
//            if ((buff == null) || (buff.IconCounts[0] <= 0)) return;
//
//        	var paintInfo = GeneratePaintList();
//
//			var x = 0;
//			var y = Hud.Window.Size.Height * 0.25f - Hud.Window.Size.Height * PositionOffset;
//            BuffPainter.PaintHorizontalCenter(paintInfo, x, y, Hud.Window.Size.Width, ruleCalculatorCoE.StandardIconSize, ruleCalculatorCoE.StandardIconSpacing);
//        }
//
//    }
//}