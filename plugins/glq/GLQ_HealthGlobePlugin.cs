using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_HealthGlobePlugin : BasePlugin, IInGameWorldPainter
    {

        public WorldDecoratorCollection HealthGlobeDecorator { get; set; }

        public GLQ_HealthGlobePlugin()
	{
            Enabled = true;
	}

        public override void Load(IController hud)
        {
            base.Load(hud);

            HealthGlobeDecorator = new WorldDecoratorCollection(

                 new MapShapeDecorator(Hud)
                 {
                    Brush = Hud.Render.CreateBrush(255, 255, 0, 0, 0),
                    ShapePainter = new CircleShapePainter(Hud),
                    Radius = 4f,
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 0, 0, 0),
                    Radius = 0.7f
                }
                );
        }

	public void PaintWorld(WorldLayer layer)
	{

            var healthGlobes = Hud.Game.Actors.Where(x => x.SnoActor.Kind == ActorKind.HealthGlobe);

            foreach (var actor in healthGlobes)

	    {
                HealthGlobeDecorator.Paint(layer, actor, actor.FloorCoordinate, "");
	    }
        }
    }
}