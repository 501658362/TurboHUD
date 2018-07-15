//by JackCeparou
namespace Turbo.Plugins.glq
{
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;

    // 装备掉落提示
    public class GLQ_ItemDropSoundAlertPlugin : BasePlugin, ILootGeneratedHandler, IAfterCollectHandler, IInGameWorldPainter
    {
        public bool Legendary { get; set; }
        public bool AncientLegendary { get; set; }
        public bool PrimalAncientLegendary { get; set; }
        public bool Set { get; set; }
        public bool AncientSet { get; set; }
        public bool PrimalAncientSet { get; set; }
        public bool BountyCache { get; set; }

        public HashSet<uint> ItemSnos { get; set; }

        public GLQ_ItemDropSoundAlertPlugin()
        {
            Enabled = true;
            Legendary = true;
            AncientLegendary = true;
            PrimalAncientLegendary = true;
            Set = true;
            AncientSet = true;
            PrimalAncientSet = true;
            BountyCache = true;
            ItemSnos = new HashSet<uint>();
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        public void AfterCollect()
        {
            var item = Hud.Game.Items.FirstOrDefault(x => x.Location == ItemLocation.Floor && x.LastSpeak != null && x.LastSpeak.IsRunning);
            if (item == null || !Hud.Sound.LastSpeak.TimerTest(2000)) return;
            //Says.Debug(Hud.Sound.LastSpeak.ElapsedMilliseconds, item.SnoItem.NameLocalized);
            item.LastSpeak.Stop();
            Hud.Sound.Speak(item.SnoItem.NameLocalized);
        }

        public void OnLootGenerated(IItem item, bool gambled)
        {
            if (item.LastSpeak != null) return;

            //Says.Debug(item.SnoItem.Sno, item.SnoItem.NameEnglish);

            if (item.SetSno != uint.MaxValue)
            {
                switch (item.AncientRank)
                {
                    case 1:
                        if (AncientSet) MarkSoundAlert(item);
                        break;

                    case 2:
                        if (PrimalAncientSet) MarkSoundAlert(item);
                        break;

                    default:
                        if (Set) MarkSoundAlert(item);
                        break;
                }
            }
            else if (item.IsLegendary)
            {
                switch (item.AncientRank)
                {
                    case 1:
                        if (AncientLegendary) MarkSoundAlert(item);
                        break;

                    case 2:
                        if (PrimalAncientLegendary) MarkSoundAlert(item);
                        break;

                    default:
                        if (Legendary) MarkSoundAlert(item);
                        break;
                }
            }

            if (ItemSnos.Contains(item.SnoItem.Sno)) MarkSoundAlert(item);
        }
        public void PaintWorld(WorldLayer layer)
        {
            if(BountyCache)
            {
                var items = Hud.Game.Items.Where(item => item.Location == ItemLocation.Floor && item.SnoActor.Sno == 360183);

                foreach (var item in items)
                {
                    var text = item.FullNameLocalized;
                    if ((item.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000))
                    {
                        Hud.Sound.Speak(text);
                        //item.LastSpeak = Hud.Time.CreateAndStartWatch();
                    }
                }
            }
            
        }

        private void MarkSoundAlert(IItem item)
        {
            if (item.LastSpeak != null) return;

            item.LastSpeak = Hud.Time.CreateAndStartWatch();
        }
    }
}