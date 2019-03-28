using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_DetectMonsterRange : BasePlugin, IInGameWorldPainter
	{
        public WorldDecoratorCollection Decorator { get; set; }

		public GLQ_DetectMonsterRange()
		{
            Enabled = true;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            Decorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(10, 255, 255, 255, 0),
                    ShapePainter = new CircleShapePainter(Hud),
                    Radius = 120,
                }
            );
        }

        public void PaintWorld(WorldLayer layer)
        {
            if (Hud.Game.IsInTown) return;
            Decorator.Paint(layer, null, Hud.Game.Me.FloorCoordinate, null);
        }

    }

}