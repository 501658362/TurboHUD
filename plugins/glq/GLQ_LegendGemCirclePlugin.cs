using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_LegendGemCirclePlugin : BasePlugin, IInGameWorldPainter
    {
		public GroundCircleDecorator ZeiDecorator { get; set; }
		public GroundCircleDecorator PainDecorator { get; set; }
		public GroundCircleDecorator BaneoftheTrappedDecorator { get; set; }	
        public GLQ_LegendGemCirclePlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
			
            ZeiDecorator = new GroundCircleDecorator(Hud)
            {
                Brush = Hud.Render.CreateBrush(255,192,96,0, 1.5f),
                Radius = 50f
            };
			
            PainDecorator = new GroundCircleDecorator(Hud)
            {
                Brush = Hud.Render.CreateBrush(255,128,0,0, 1.5f),
                Radius = 20f
            };
			
            BaneoftheTrappedDecorator = new GroundCircleDecorator(Hud)
            {
                Brush = Hud.Render.CreateBrush(255,0,150,70, 1.5f),
                Radius = 15f
            };

        }

        public void PaintWorld(WorldLayer layer)
        {
            var me = Hud.Game.Me;
            if (me.Powers.BuffIsActive(403468, 0))
                    ZeiDecorator.Paint(me, me.FloorCoordinate, null);
            if (me.Powers.BuffIsActive(403600, 0))
                    PainDecorator.Paint(me, me.FloorCoordinate, null);
            if (me.Powers.BuffIsActive(403457, 0))
                    BaneoftheTrappedDecorator.Paint(me, me.FloorCoordinate, null);

        }

    }

}