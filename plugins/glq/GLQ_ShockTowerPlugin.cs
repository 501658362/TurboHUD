using System.Linq;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_ShockTowerPlugin : BasePlugin, IInGameWorldPainter
	{
        public WorldDecoratorCollection ShockTowerDecorator { get; set; }
        public GLQ_ShockTowerPlugin()
		{
            Enabled = true;
		}
        public override void Load(IController hud)
        {
            base.Load(hud);          
            ShockTowerDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 255, 220, 0),
                    Radius = 6.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 255, 220, 5, SharpDX.Direct2D1.DashStyle.Dash),
                    Radius = 26,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(160, 255, 255, 220, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 0, 0, 255, true, false, false),                    
                }
                );
        }

		public void PaintWorld(WorldLayer layer)
		{
            if ((Hud.Game.MapMode == MapMode.WaypointMap) || (Hud.Game.MapMode == MapMode.ActMap) || (Hud.Game.MapMode == MapMode.Map)) return;
            var shocktower = Hud.Game.Actors.Where(x => x.SnoActor.Sno == ActorSnoEnum._x1_pand_ext_ordnance_tower_shock_a);
            foreach (var actor in shocktower)
            {
                ShockTowerDecorator.Paint(layer, actor, actor.FloorCoordinate, "电塔");
            }
        }
    }
}