using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_GlobePlugin : BasePlugin, IInGameWorldPainter
	{

        public WorldDecoratorCollection PowerGlobeDecorator { get; set; }
        public WorldDecoratorCollection RiftOrbDecorator { get; set; }
        public bool EnableSpeak { get; set; }
		
        public GLQ_GlobePlugin()
		{
            Enabled = true;
            EnableSpeak = true;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            PowerGlobeDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 240, 240, 120, 0),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 4.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 240, 240, 120, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 6.5f, 255, 0, 0, 0, false, false, false),
                }
                );

            RiftOrbDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 240, 120, 240, 0),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 6.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 240, 120, 240, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 6.5f, 255, 0, 0, 0, false, false, false),
                }
                );
        }

		public void PaintWorld(WorldLayer layer)
		{
            var actors = Hud.Game.Actors.Where(x => x.SnoActor.Kind == ActorKind.PowerGlobe);
            foreach (var actor in actors)
			{
                PowerGlobeDecorator.ToggleDecorators<GroundLabelDecorator>(!actor.IsOnScreen); // do not display ground labels when the actor is on the screen
                PowerGlobeDecorator.Paint(layer, actor, actor.FloorCoordinate, "荣耀球");
			}

            actors = Hud.Game.Actors.Where(x => x.SnoActor.Kind == ActorKind.RiftOrb);
            foreach (var actor in actors)
            {
                RiftOrbDecorator.ToggleDecorators<GroundLabelDecorator>(!actor.IsOnScreen); // do not display ground labels when the actor is on the screen
                RiftOrbDecorator.Paint(layer, actor, actor.FloorCoordinate, "进度球");
				if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && !actor.IsOnScreen && Hud.Game.SpecialArea == SpecialArea.GreaterRift)
				{
				Hud.Sound.Speak("进度球");
				actor.LastSpeak = Hud.Time.CreateAndStartWatch();
				}
            }
        }

    }

}