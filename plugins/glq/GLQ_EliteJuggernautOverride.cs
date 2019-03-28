using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_DangerousAffixMonsterPlugin : BasePlugin, IInGameWorldPainter
    {
        public WorldDecoratorCollection EliteLeaderDecorator_Special { get; set; }
        public List<MonsterAffix> SpecialAffix { get; set; }
 
        public GLQ_DangerousAffixMonsterPlugin()
        {
            Enabled = true;
            SpecialAffix = new List<MonsterAffix>();
        }
 
        public override void Load(IController hud)
        {
            base.Load(hud);
            EliteLeaderDecorator_Special = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(220, 255, 0, 0, 0),
                    Radius = 12,
                    ShapePainter = new CircleShapePainter(Hud),
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333)
                }
            );
        }
        public void PaintWorld(WorldLayer layer)
        {
            var MonstersList = Hud.Game.AliveMonsters.Where(m => m.Rarity == ActorRarity.Rare || m.Rarity == ActorRarity.Champion || m.Rarity == ActorRarity.Unique);
            foreach (var thisMonster in MonstersList)
            {
                //var thisElite = EliteLeaderDecorator;
                foreach (var searchAffix in SpecialAffix)
                {
                    foreach (var snoMonsterAffix in thisMonster.AffixSnoList)
                    {
                        if (snoMonsterAffix.Affix == searchAffix)
                        {
                            EliteLeaderDecorator_Special.Paint(layer, thisMonster, thisMonster.FloorCoordinate, thisMonster.SnoMonster.NameLocalized);
                        }
                        
                    }

                }
            }
        }
    }
}