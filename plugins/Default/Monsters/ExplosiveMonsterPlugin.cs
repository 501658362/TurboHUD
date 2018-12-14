using System.Linq;

namespace Turbo.Plugins.Default
{
    public class ExplosiveMonsterPlugin : BasePlugin, IInGameWorldPainter
    {
        public WorldDecoratorCollection FastMummyDecorator { get; set; }
        public WorldDecoratorCollection GrotesqueDecorator { get; set; }

        public ExplosiveMonsterPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            FastMummyDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(128, 255, 50, 50, 3, SharpDX.Direct2D1.DashStyle.Dash),
                    Radius = 5,
                }
                );

            // timers does not work for grotesque because it has no death actor with creation ticks and the original monster's creation tick is not the same as the time he died
            GrotesqueDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 3, SharpDX.Direct2D1.DashStyle.Dash),
                    Radius = 20f,
                }
                );
        }

        public void PaintWorld(WorldLayer layer)
        {
            var deadMonsters = Hud.Game.Monsters.Where(x => !x.IsAlive);
            foreach (var monster in deadMonsters)
            {
                switch (monster.SnoActor.Sno)
                {
                    case 4104:
                    case 4105:
                    case 4106:
                        FastMummyDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
                        break;
                    case 3847:
                    case 218307:
                    case 218308:
                    case 365450:
                    case 3848:
                    case 218405:
                    case 3849:
                    case 113994:
                    case 3850:
                    case 195639:
                    case 365465:
                    case 191592:
                        GrotesqueDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
                        break;
                }
            }
        }
    }
}