using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_MeCirclePlugin : BasePlugin, IInGameWorldPainter
    {
        public WorldDecoratorCollection MeDecorator { get; set; } // public propertiy to be editable 
        private float circleRadius; // private backing field 
        public float CircleRadius // public property with getter and setter 
        {
            get { return circleRadius; }
            set
            {
                MeDecorator.GetDecorators<IWorldDecoratorWithRadius>().ForEach(d => d.Radius = value); // this iterate all decorators with radius in collection and change radius 

                circleRadius = value;
            }
        }
        public GLQ_MeCirclePlugin()
        {
            Enabled = true;
            circleRadius = 5; // default value 
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            MeDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 0, 0, 3),
                    Radius = circleRadius, //default value 
                }
            );
        }
        public void PaintWorld(WorldLayer layer)
        {
            if ((Hud.Game.MapMode == MapMode.WaypointMap) || (Hud.Game.MapMode == MapMode.ActMap) || (Hud.Game.MapMode == MapMode.Map)) return;
            var me = Hud.Game.Me;
            MeDecorator.Paint(layer, me, me.FloorCoordinate, null);
        }
    }
}