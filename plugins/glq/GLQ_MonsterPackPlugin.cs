using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    // original idea from: http://turbohud.freeforums.net/user/13025 and http://turbohud.freeforums.net/user/12966
    public class GLQ_MonsterPackPlugin : BasePlugin, IInGameWorldPainter
    {

        //
        // this plugin is work-in-progress and will be finished in a later release
        //
        // todo: add sidebar
        //

        public IBrush ChampionPackLineBrush { get; set; }
        public IFont ChampionPackNameFont { get; set; }
        public IBrush RarePackLineBrush { get; set; }
        public IFont RarePackNameFont { get; set; }

        public float MiddleHealthBarHeight { get; set; }
        public float MiddleHealthBarWidth { get; set; }
        public IBrush HealthBorder { get; set; }
        public IBrush HealthBackgroundMax { get; set; }
        public IBrush HealthBackgroundChampionRemaining { get; set; }
        public IBrush HealthBackgroundRareRemaining { get; set; }
        public IBrush HealthBackgroundRareMinionRemaining { get; set; }

        public GroundLabelDecorator WeakDecorator { get; set; }
        public Dictionary<MonsterAffix, GroundLabelDecorator> AffixDecorators { get; set; }
        public Dictionary<MonsterAffix, string> CustomAffixNames { get; set; }

        public Dictionary<MonsterAffix, int> Priorities { get; private set; }
		public bool HideOnIllusions { get; set; }
        public int transparency { get; set; }
        public int fontsize { get; set; }

        public GLQ_MonsterPackPlugin()
        {
            Enabled = false;
			HideOnIllusions = true;
            Order = 20000;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            transparency = 150;
            fontsize = 10;
            Priorities = new Dictionary<MonsterAffix, int>() {
                { MonsterAffix.Juggernaut, 20 },
                { MonsterAffix.Arcane, 10 },
                { MonsterAffix.Desecrator, 10 },
                { MonsterAffix.Frozen, 10 },
                { MonsterAffix.Molten, 9 },
                { MonsterAffix.FrozenPulse, 8 },
                { MonsterAffix.Thunderstorm, 8 },
                { MonsterAffix.Reflect, 7 },
                { MonsterAffix.Electrified, 5 },
                { MonsterAffix.Jailer, 5 },
                { MonsterAffix.Mortar, 5 },
                { MonsterAffix.Orbiter, 5 },
                { MonsterAffix.Plagued, 6 },
                { MonsterAffix.Poison, 5 },
                { MonsterAffix.Waller, 3 },
                { MonsterAffix.FireChains, 1 },
                { MonsterAffix.Shielding, 1 },
                { MonsterAffix.Avenger, 0 },
                { MonsterAffix.ExtraHealth, 0 },
                { MonsterAffix.Fast, 0 },
                { MonsterAffix.HealthLink, 0 },
                { MonsterAffix.Horde, 0 },
                { MonsterAffix.Illusionist, 0 },
                { MonsterAffix.Knockback, 0 },
                { MonsterAffix.MissileDampening, 0 },
                { MonsterAffix.Nightmarish, 0 },
                { MonsterAffix.Teleporter, 0 },
                { MonsterAffix.Vampiric, 0 },
                { MonsterAffix.Vortex, 0 },
                { MonsterAffix.Wormhole, 0 } };


            ChampionPackLineBrush = Hud.Render.CreateBrush(255, 125, 175, 240, -1.5f);
            ChampionPackNameFont = Hud.Render.CreateFont("tahoma", 9.0f, 255, 125, 175, 240, true, false, 255, 0, 0, 0, true);
            RarePackLineBrush = Hud.Render.CreateBrush(255, 240, 175, 125, -1.5f);
            RarePackNameFont = Hud.Render.CreateFont("tahoma", 9.0f, 255, 240, 175, 125, true, false, 255, 0, 0, 0, true);

            MiddleHealthBarWidth = 0.05f;
            MiddleHealthBarHeight = 0.007f;

            HealthBorder = Hud.Render.CreateBrush(255, 0, 0, 0, 1);
            HealthBackgroundMax = Hud.Render.CreateBrush(255, 0, 0, 0, 0);
            HealthBackgroundChampionRemaining = Hud.Render.CreateBrush(200, 0, 128, 255, 0);
            HealthBackgroundRareRemaining = Hud.Render.CreateBrush(200, 255, 128, 0, 0);
            HealthBackgroundRareMinionRemaining = Hud.Render.CreateBrush(200, 180, 180, 180, 0);

            var BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2);
            CustomAffixNames = new Dictionary<MonsterAffix, string>();
            AffixDecorators = new Dictionary<MonsterAffix, GroundLabelDecorator>();
            AffixDecorators.Add(MonsterAffix.Arcane, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 120, 0, 120, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Desecrator, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 170, 50, 0, 0),
                    ForceOnScreen = true,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Electrified, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 40, 40, 240, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Frozen, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 0, 0, 120, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.FrozenPulse, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 0, 0, 170, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Jailer, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 144, 0, 255, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Juggernaut, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 150, 0, 0, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Molten, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 130, 13, 0, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Mortar, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 170, 50, 0, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Orbiter, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 15, 15, 220, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Plagued, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 0, 180, 0, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Poison, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 0, 120, 0, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Reflect, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 120, 50, 0, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Thunderstorm, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 40, 40, 240, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Waller, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 50, 50, 50, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.HealthLink, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 128, 128, 255, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Fast, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 0, 136, 255, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );		
            AffixDecorators.Add(MonsterAffix.FireChains, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 255, 0, 0, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Knockback, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 128, 128, 128, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Nightmarish, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 0, 128, 128, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
            AffixDecorators.Add(MonsterAffix.Illusionist, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 166, 166, 255, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );	
            AffixDecorators.Add(MonsterAffix.Shielding, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 150, 180, 150, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );		
            AffixDecorators.Add(MonsterAffix.Teleporter, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 185, 185, 185, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );		
            AffixDecorators.Add(MonsterAffix.Vortex, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 255, 255, 255, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );		
            AffixDecorators.Add(MonsterAffix.Wormhole, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 255, 0, 255, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );		
            AffixDecorators.Add(MonsterAffix.Avenger, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 192, 192, 192, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );		
            AffixDecorators.Add(MonsterAffix.Horde, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 128, 128, 0, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );		
            AffixDecorators.Add(MonsterAffix.MissileDampening, 
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 0, 96, 192, 0),
                    ForceOnScreen = false,
                    CenterBaseLine = false,
                }
                );
        }

         public void PaintWorld(WorldLayer layer)
        {
            if (layer != WorldLayer.Ground) return;
            if ((Hud.Game.MapMode == MapMode.WaypointMap) || (Hud.Game.MapMode == MapMode.ActMap) || (Hud.Game.MapMode == MapMode.Map)) return;
            var packs = Hud.Game.MonsterPacks;
            if (!packs.Any()) return;

            var padding = 6.0f * Hud.Window.Size.Height / 1200f;

            var maxHealth = packs.Max(pack => pack.MonstersAlive.Any() ? pack.MonstersAlive.Max(monster => monster.MaxHealth) : 0);
            var middleBarHeight = Hud.Window.Size.Height * MiddleHealthBarHeight;
            var middleBarWidth = Hud.Window.Size.Width * MiddleHealthBarWidth;

            foreach (var pack in packs)
            {
                var alive = !HideOnIllusions ? pack.MonstersAlive.ToList() : pack.MonstersAlive.Where(x => (x.SummonerAcdDynamicId == 0) || (x.Rarity != ActorRarity.RareMinion)).ToList();
                if (alive.Count == 0) continue;

                alive.Sort((a, b) =>
                {
                    var r = a.Rarity.CompareTo(b.Rarity);
                    if (r == 0) r = -a.MaxHealth.CompareTo(b.MaxHealth);
                    return r;
                });

                var center = Hud.Window.CreateWorldCoordinate(0, 0, 0);

                var n = 0;
                if (alive.Any(x => x.FloorCoordinate.IsOnScreen()))
                {
                    foreach (var monster in alive.Where(x => x.FloorCoordinate.IsOnScreen()))
                    {
                        center.Add(monster.FloorCoordinate);
                        n++;
                    }
                }
                else
                {
                    foreach (var monster in alive)
                    {
                        center.Add(monster.FloorCoordinate);
                        n++;
                    }
                }
                center.Set(center.X / n, center.Y / n, center.Z / n);

                var centerScreenCoordinate = center.ToScreenCoordinate(false);

                var y = centerScreenCoordinate.Y;

                if (pack.IsFullChampionPack)
                {
                    if (ChampionPackLineBrush != null && (alive.Count > 1))
                    {
                        PaintFloorLines(alive, ChampionPackLineBrush);
                    }
                    if (ChampionPackNameFont != null)
                    {
                        var layout = ChampionPackNameFont.GetTextLayout(pack.LeadSnoMonster.NameLocalized);
                        ChampionPackNameFont.DrawText(layout, centerScreenCoordinate.X - layout.Metrics.Width / 2, y);
                        y += layout.Metrics.Height + padding;
                    }
                }
                else
                {
                    if (RarePackLineBrush != null && (alive.Count > 1))
                    {
                        PaintFloorLines(alive, RarePackLineBrush);
                    }
                    if (RarePackNameFont != null)
                    {
                        var layout = RarePackNameFont.GetTextLayout(pack.LeadSnoMonster.NameLocalized);
                        RarePackNameFont.DrawText(layout, centerScreenCoordinate.X - layout.Metrics.Width / 2, y);
                        y += layout.Metrics.Height + padding;
                    }
                }

                var decoHeight = 0.0f;

                var snoMonsterAffixList = pack.AffixSnoList.ToList();
                snoMonsterAffixList.Sort((a, b) => -Priorities[a.Affix].CompareTo(Priorities[b.Affix]));

                foreach (var snoMonsterAffix in snoMonsterAffixList)
                {
                    GroundLabelDecorator decorator;
                    if (!AffixDecorators.TryGetValue(snoMonsterAffix.Affix, out decorator)) continue;

                    string affixName = null;
                    if (CustomAffixNames.ContainsKey(snoMonsterAffix.Affix))
                    {
                        affixName = CustomAffixNames[snoMonsterAffix.Affix];
                    }
                    else affixName = snoMonsterAffix.NameLocalized;

                    if (decoHeight == 0.0f)
                    {
                        decoHeight = decorator.TextFont.GetTextLayout(affixName).Metrics.Height * 1.2f;
                    }

                    decorator.OffsetY = y - centerScreenCoordinate.Y;

                    decorator.Paint(null, center, affixName);
                }

                y += decoHeight + padding / 2;

                foreach (var monster in alive)
                {
                    var curW = (float)(middleBarWidth / maxHealth * monster.CurHealth);
                    var maxW = (float)(middleBarWidth / maxHealth * monster.MaxHealth);

                    HealthBackgroundMax.DrawRectangleGridFit(centerScreenCoordinate.X - maxW / 2, y, maxW, middleBarHeight);
                    switch (monster.Rarity)
                    {
                        case ActorRarity.Champion:
                            HealthBackgroundChampionRemaining.DrawRectangleGridFit(centerScreenCoordinate.X - maxW / 2, y, curW, middleBarHeight);
                            break;
                        case ActorRarity.Rare:
                            HealthBackgroundRareRemaining.DrawRectangleGridFit(centerScreenCoordinate.X - maxW / 2, y, curW, middleBarHeight);
                            break;
                        case ActorRarity.RareMinion:
                            HealthBackgroundRareMinionRemaining.DrawRectangleGridFit(centerScreenCoordinate.X - maxW / 2, y, curW, middleBarHeight);
                            break;
                    }

                    HealthBorder.DrawRectangleGridFit(centerScreenCoordinate.X - maxW / 2, y, maxW, middleBarHeight);

                    y += middleBarHeight;
                }
            }
        }

        private void PaintFloorLines(IEnumerable<IMonster> monsters, IBrush brush)
        {
            var lastCenter = Hud.Game.Me.FloorCoordinate;
            var list = new List<IMonster>(monsters);
            IMonster nearest = null;
            foreach (var monster in list)
            {
                if (nearest == null || monster.CentralXyDistanceToMe < nearest.CentralXyDistanceToMe) nearest = monster;
            }
            list.Remove(nearest);
            while (list.Count > 0)
            {
                IMonster nextNearest = null;
                foreach (var monster in list)
                {
                    if (nextNearest == null || monster.FloorCoordinate.XYDistanceTo(nearest.FloorCoordinate) < nextNearest.FloorCoordinate.XYDistanceTo(nearest.FloorCoordinate)) nextNearest = monster;
                }

                brush.DrawLineWorld(nearest.FloorCoordinate, nextNearest.FloorCoordinate);
                nearest = nextNearest;
                list.Remove(nextNearest);
            }
        }

    }

}