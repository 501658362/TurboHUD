using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_PlayersCirclePlugin : BasePlugin, IInGameWorldPainter
    {
        public WorldDecoratorCollection MeDecorator { get; set; }
        public Dictionary<HeroClass, WorldDecoratorCollection> HeroClassDecorators { get; private set; }

        public GLQ_PlayersCirclePlugin()
        {
            Enabled = true;
            HeroClassDecorators = new Dictionary<HeroClass, WorldDecoratorCollection>();
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            MeDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 0, 0, 3),
                    Radius = -1,
                }
            );

            HeroClassDecorators.Add(HeroClass.Wizard, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 0, 255, 3),
                    Radius = -1,
                }
            ));
            HeroClassDecorators.Add(HeroClass.WitchDoctor, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 0, 128, 64, 3),
                    Radius = -1,
                }
            ));
            HeroClassDecorators.Add(HeroClass.Barbarian, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 128, 64, 3),
                    Radius = -1,
                }
            ));
            HeroClassDecorators.Add(HeroClass.DemonHunter, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 36, 4, 187, 3),
                    Radius = -1,
                }
            ));
            HeroClassDecorators.Add(HeroClass.Crusader, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 240, 240, 240, 3),
                    Radius = -1,
                }
            ));
            HeroClassDecorators.Add(HeroClass.Monk, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 255, 0, 3),
                    Radius = -1,
                }
            ));
            HeroClassDecorators.Add(HeroClass.Necromancer, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 0, 128, 128, 3),
                    Radius = -1,
                }
            ));
        }

        public void PaintWorld(WorldLayer layer)
        {
            if ((Hud.Game.MapMode == MapMode.WaypointMap) || (Hud.Game.MapMode == MapMode.ActMap) || (Hud.Game.MapMode == MapMode.Map)) return;
            var players = Hud.Game.Players.Where(player => player.CoordinateKnown && (player.HeadStone == null));
            foreach (var player in players)
            {
                if (player.IsMe)
                {
                    MeDecorator.Paint(layer, player, player.FloorCoordinate, null);
                }
                else
                {
                    WorldDecoratorCollection decorator;
                    if (!HeroClassDecorators.TryGetValue(player.HeroClassDefinition.HeroClass, out decorator)) return;

                    decorator.Paint(layer, player, player.FloorCoordinate, null);
                }
            }
        }

    }

}