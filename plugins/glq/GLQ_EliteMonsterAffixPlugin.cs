using System.Collections.Generic;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_EliteMonsterAffixPlugin : BasePlugin, IInGameWorldPainter
	{

        public WorldDecoratorCollection MinionDecorator { get; set; }
        public Dictionary<MonsterAffix, WorldDecoratorCollection> AffixDecorators { get; set; }
        public Dictionary<MonsterAffix, string> CustomAffixNames { get; set; }
        public int transparency { get; set; }
        public int fontsize { get; set; }
        public int MinionType { get; set; }

        public GLQ_EliteMonsterAffixPlugin()
		{
            Enabled = true;
            Order = 20000;
            MinionType = 0;

        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            transparency = 150;
            fontsize = 10;
			CustomAffixNames = new Dictionary<MonsterAffix, string>();
            var BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2);
            MinionDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 255, 128, 64, 0),
                }
                );
            AffixDecorators = new Dictionary<MonsterAffix, WorldDecoratorCollection>();
            AffixDecorators.Add(MonsterAffix.Arcane, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 120, 0, 120, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Desecrator, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 170, 50, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Electrified, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 40, 40, 240, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Frozen, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 0, 0, 120, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.FrozenPulse, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 0, 0, 170, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Jailer, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 144, 0, 255, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Juggernaut, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 150, 0, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Molten, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 130, 13, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Mortar, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 170, 50, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Orbiter, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 15, 15, 220, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Plagued, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 0, 180, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Poison, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 0, 120, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Reflect, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 120, 50, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Thunderstorm, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 40, 40, 240, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Waller, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 50, 50, 50, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.HealthLink, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 128, 128, 255, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Fast, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 0, 136, 255, 0),
                }
                ));		
            AffixDecorators.Add(MonsterAffix.FireChains, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 255, 0, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Knockback, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 128, 128, 128, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Nightmarish, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 0, 128, 128, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Illusionist, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 166, 166, 255, 0),
                }
                ));	
            AffixDecorators.Add(MonsterAffix.Shielding, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 150, 180, 150, 0),
                }
                ));		
            AffixDecorators.Add(MonsterAffix.Teleporter, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 185, 185, 185, 0),
                }
                ));		
            AffixDecorators.Add(MonsterAffix.Vortex, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 255, 255, 255, 0),
                }
                ));		
            AffixDecorators.Add(MonsterAffix.Wormhole, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 255, 0, 255, 0),
                }
                ));		
            AffixDecorators.Add(MonsterAffix.Avenger, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 0, 0, 0, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 192, 192, 192, 0),
                }
                ));		
            AffixDecorators.Add(MonsterAffix.Horde, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 128, 128, 0, 0),
                }
                ));		
            AffixDecorators.Add(MonsterAffix.MissileDampening, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = BorderBrush,
                    TextFont = Hud.Render.CreateFont("tahoma", fontsize, 255, 255, 255, 255, true, false, false),
                    BackgroundBrush = Hud.Render.CreateBrush(transparency, 0, 96, 192, 0),
                }
                ));
        }
        public void PaintWorld(WorldLayer layer)
        {
            if ((Hud.Game.MapMode == MapMode.WaypointMap) || (Hud.Game.MapMode == MapMode.ActMap) || (Hud.Game.MapMode == MapMode.Map)) return;
            var monsters = Hud.Game.AliveMonsters;
            foreach (var monster in monsters)
            {
				bool illusionist = false;
				if(monster.SummonerAcdDynamicId == 0)
				{
					illusionist = false;
				}
				else
				{
					illusionist = true;
				}
				if (monster.Rarity == ActorRarity.Normal || monster.Rarity == ActorRarity.Unique || monster.Rarity == ActorRarity.Boss) {
                foreach (var snoMonsterAffix in monster.AffixSnoList)
                {
                    WorldDecoratorCollection decorator;
                    if (!AffixDecorators.TryGetValue(snoMonsterAffix.Affix, out decorator)) continue;

                    string affixName = null;
                    if (CustomAffixNames.ContainsKey(snoMonsterAffix.Affix))
                    {
                        affixName = CustomAffixNames[snoMonsterAffix.Affix];
                    }
                    else affixName = snoMonsterAffix.NameLocalized;

                    decorator.Paint(layer, monster, monster.FloorCoordinate, affixName);
                }
				}
				
                if (monster.Rarity == ActorRarity.Champion)
				{
					if (illusionist == false)
					{
                	foreach (var snoMonsterAffix in monster.AffixSnoList)
                	{
                    	WorldDecoratorCollection decorator;
                    	if (!AffixDecorators.TryGetValue(snoMonsterAffix.Affix, out decorator)) continue;

                    	string affixName = null;
                    	if (CustomAffixNames.ContainsKey(snoMonsterAffix.Affix))
                    	{
                        	affixName = CustomAffixNames[snoMonsterAffix.Affix];
                    	}
                    	else affixName = snoMonsterAffix.NameLocalized;

                    	decorator.Paint(layer, monster, monster.FloorCoordinate, affixName);
                	}
					}
				}
				if (monster.Rarity == ActorRarity.Rare)
				{
					if (illusionist == false)
					{
                	foreach (var snoMonsterAffix in monster.AffixSnoList)
                	{
                    	WorldDecoratorCollection decorator;
                    	if (!AffixDecorators.TryGetValue(snoMonsterAffix.Affix, out decorator)) continue;

                    	string affixName = null;
                    	if (CustomAffixNames.ContainsKey(snoMonsterAffix.Affix))
                    	{
                        	affixName = CustomAffixNames[snoMonsterAffix.Affix];
                    	}
                    	else affixName = snoMonsterAffix.NameLocalized;

                    	decorator.Paint(layer, monster, monster.FloorCoordinate, affixName);
                	}
					}
				}
                if (monster.Rarity == ActorRarity.RareMinion)
                {
                    if (illusionist == false)
                    {
                        if (MinionType == 0) continue;
                        if (MinionType == 1)
                        {
                            string affixName = "爪牙";
                            MinionDecorator.Paint(layer, monster, monster.FloorCoordinate, affixName);
                        }
                        if (MinionType == 2)
                        {
                            foreach (var snoMonsterAffix in monster.AffixSnoList)
                            {
                                WorldDecoratorCollection decorator;
                                if (!AffixDecorators.TryGetValue(snoMonsterAffix.Affix, out decorator)) continue;

                                string affixName = null;
                                if (CustomAffixNames.ContainsKey(snoMonsterAffix.Affix))
                                {
                                    affixName = CustomAffixNames[snoMonsterAffix.Affix];
                                }
                                else affixName = snoMonsterAffix.NameLocalized;

                                decorator.Paint(layer, monster, monster.FloorCoordinate, affixName);
                            }
                        }
                    }
                }
            }
        }

    }

}