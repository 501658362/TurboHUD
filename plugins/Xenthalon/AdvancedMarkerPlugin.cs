using Turbo.Plugins.Default;

namespace Turbo.Plugins.Xenthalon
{

    public class AdvancedMarkerPlugin : BasePlugin, IInGameWorldPainter, ICustomizer
	{
        public WorldDecoratorCollection QuestDecorator { get; set; }
        public WorldDecoratorCollection KeywardenDecorator { get; set; }
        public WorldDecoratorCollection BossDecorator { get; set; }

        public AdvancedMarkerPlugin()
		{
            Enabled = true;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            QuestDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 255, 255, 55, -1),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 10.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                },
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 200, 255, 255, 0, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 10,
                    Up = true,
                },
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 255, 255, 55, -1),
                    ShapePainter = new LineFromMeShapePainter(Hud)
                }
            );

            KeywardenDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 238, 130, 238, -1),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 10.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                },
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 200, 255, 20, 255, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 10,
                    Up = true,
                },
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 238, 130, 238, -1),
                    ShapePainter = new LineFromMeShapePainter(Hud)
                }
            );

            BossDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 180, 0, 0, -1),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 10.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                },
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 200, 255, 0, 0, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 10,
                    Up = true,
                },
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 180, 0, 0, -1),
                    ShapePainter = new LineFromMeShapePainter(Hud)
                }
            );
        }

		public void PaintWorld(WorldLayer layer)
		{
            var markers = Hud.Game.Markers;

            foreach (var marker in markers)
			{
                QuestDecorator.ToggleDecorators<GroundLabelDecorator>(!marker.FloorCoordinate.IsOnScreen()); // do not display ground labels when the marker is on the screen
                KeywardenDecorator.ToggleDecorators<GroundLabelDecorator>(!marker.FloorCoordinate.IsOnScreen());
                BossDecorator.ToggleDecorators<GroundLabelDecorator>(!marker.FloorCoordinate.IsOnScreen());

                if (marker.SnoQuest != null)
                {
                    QuestDecorator.Paint(layer, null, marker.FloorCoordinate, marker.Name);
                }
                else if (marker.SnoActor != null)
                {
                    if (marker.SnoActor.Code.Contains("_Boss_"))
                    {
                        BossDecorator.Paint(layer, null, marker.FloorCoordinate, marker.Name);
                    }
                    else
                    {
                        KeywardenDecorator.Paint(layer, null, marker.FloorCoordinate, marker.Name);
                    }
                }
			}
        }

        public void Customize()
        {
            Hud.TogglePlugin<MarkerPlugin>(false);	// disable default MarkerPlugin
        }

    }
}