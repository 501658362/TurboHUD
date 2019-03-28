using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_FollowerPlugin : BasePlugin, IInGameWorldPainter
    {
        public WorldDecoratorCollection Decorators { get; set; }
        //4482	Hireling_Enchantress	Enchantress
        //52694	Hireling_Scoundrel	Scoundrel
        //52693	Hireling_Templar	Templars
        public GLQ_FollowerPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            Decorators = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 0, 255, 51, 1),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 6f,
                    ShapePainter = new RotatingTriangleShapePainter(Hud),
                }
            );
        }
        public void PaintWorld(WorldLayer layer)
        {
            foreach (var actor in Hud.Game.Actors)
            {
				if(actor.SnoActor.Sno == ActorSnoEnum._hireling_enchantress || actor.SnoActor.Sno == ActorSnoEnum._hireling_templar || actor.SnoActor.Sno == ActorSnoEnum._hireling_scoundrel)
				{
					Decorators.Paint(layer, actor, actor.FloorCoordinate, "F");
				}
            }
        }
    }
}