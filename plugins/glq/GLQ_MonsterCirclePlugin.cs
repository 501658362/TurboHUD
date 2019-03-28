using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_MonsterCirclePlugin : BasePlugin, IInGameWorldPainter
	{

        public WorldDecoratorCollection TrashDecorator { get; set; }
        public WorldDecoratorCollection ChampionDecorator { get; set; }
        public WorldDecoratorCollection RareMinionDecorator { get; set; }
        public WorldDecoratorCollection RareDecorator { get; set; }
        public WorldDecoratorCollection UniqueDecorator { get; set; }
        public WorldDecoratorCollection BossDecorator { get; set; }

        public GLQ_MonsterCirclePlugin()
		{
            Enabled = true;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            var TrashGroundBrush = Hud.Render.CreateBrush(255, 200, 200, 200, 3, SharpDX.Direct2D1.DashStyle.Dash);
            TrashDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = TrashGroundBrush,
                    Radius = -1,
                }
                );

            var EliteChampionGroundBrush = Hud.Render.CreateBrush(255, 64, 128, 255, 3, SharpDX.Direct2D1.DashStyle.Dash);
            ChampionDecorator = new WorldDecoratorCollection(
			    new GroundCircleDecorator(Hud)
                {
                    Brush = EliteChampionGroundBrush,
                    Radius = -1,
                }
                );
            var EliteMinionGroundBrush = Hud.Render.CreateBrush(255, 192, 92, 20, 3, SharpDX.Direct2D1.DashStyle.Dash);
            RareMinionDecorator = new WorldDecoratorCollection(
			    new GroundCircleDecorator(Hud)
                {
                    Brush = EliteMinionGroundBrush,
                    Radius = -1,
                }
                );
            var EliteLeaderGroundBrush = Hud.Render.CreateBrush(255, 255, 148, 20, 3, SharpDX.Direct2D1.DashStyle.Dash);
            RareDecorator = new WorldDecoratorCollection(
			    new GroundCircleDecorator(Hud)
                {
                    Brush = EliteLeaderGroundBrush,
                    Radius = -1,
                }
                );
            var EliteUniqueGroundBrush = Hud.Render.CreateBrush(255, 255, 140, 255, 3, SharpDX.Direct2D1.DashStyle.Dash);
            UniqueDecorator = new WorldDecoratorCollection(
			    new GroundCircleDecorator(Hud)
                {
                    Brush = EliteUniqueGroundBrush,
                    Radius = -1,
                }
                );


            var BossGroundBrush = Hud.Render.CreateBrush(255, 255, 96, 0, 3, SharpDX.Direct2D1.DashStyle.Dash);
            BossDecorator = new WorldDecoratorCollection(
			    new GroundCircleDecorator(Hud)
                {
                    Brush = BossGroundBrush,
                    Radius = -1,
                }
                );
        }

        public void PaintWorld(WorldLayer layer)
        {
            if ((Hud.Game.MapMode == MapMode.WaypointMap) || (Hud.Game.MapMode == MapMode.ActMap) || (Hud.Game.MapMode == MapMode.Map)) return;
            var inRift = Hud.Game.SpecialArea == SpecialArea.Rift || Hud.Game.SpecialArea == SpecialArea.GreaterRift;
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
                // trash
                if (!monster.Invisible && !monster.IsElite && (monster.SnoMonster.Priority != MonsterPriority.goblin) && (monster.SnoMonster.Priority != MonsterPriority.boss) && (monster.SnoMonster.Priority != MonsterPriority.keywarden))
                {
                    TrashDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
                }
                if (monster.Rarity == ActorRarity.Unique)
                {
                    UniqueDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
                }	
                if (monster.SnoMonster.Priority == MonsterPriority.boss)
                {
                    BossDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
                }				
                if (monster.Rarity == ActorRarity.Champion && illusionist == false)
                {
                    ChampionDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
                }
                if (monster.Rarity == ActorRarity.RareMinion && illusionist == false)
                {
                    RareMinionDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
                }
                if (monster.Rarity == ActorRarity.Rare && illusionist == false)
				{
                    RareDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
                }
                if ((monster.Rarity == ActorRarity.Unique) && (monster.SnoMonster.Priority < MonsterPriority.keywarden) && illusionist == false)
                {
                    UniqueDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
                }
                if (monster.SnoMonster.Priority == MonsterPriority.boss && illusionist == false)
                {
                    BossDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
                }
            }
        }

    }

}
		