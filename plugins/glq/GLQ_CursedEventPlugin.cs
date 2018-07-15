using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{

    public class GLQ_CursedEventPlugin : BasePlugin, IInGameWorldPainter
	{

        public WorldDecoratorCollection Decorator { get; set; }

        public GLQ_CursedEventPlugin()
		{
            Enabled = true;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);
            var offsetH = Hud.Window.Size.Height * 0.025f;
            Decorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 8f, 230, 255, 0, 0, false, false, 100, 255, 255, 255, true),
                    Up = true,
		    RadiusOffset = - offsetH
                },
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 64, 64, 2),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 8.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 64, 64, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 255, 255, 255, false, false, false),
                }
                );
        }

        public void PaintWorld(WorldLayer layer)
		{
            var actors = Hud.Game.Actors.Where(x => x.SnoActor.Kind == ActorKind.CursedEvent);
            foreach (var actor in actors)
			{
                Decorator.ToggleDecorators<GroundLabelDecorator>(!actor.IsOnScreen);

                Decorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
			}
        }

    }

}