using System.Collections.Generic;
using System.Linq;

namespace Turbo.Plugins.Default
{

    public class OtherPlayersPlugin : BasePlugin, IInGameWorldPainter
	{

        public Dictionary<HeroClass, WorldDecoratorCollection> DecoratorByClass { get; set; }
        public float NameOffsetZ { get; set; }

        public OtherPlayersPlugin()
		{
            Enabled = true;
            DecoratorByClass = new Dictionary<HeroClass, WorldDecoratorCollection>();
            NameOffsetZ = 8.0f;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            var grounLabelBackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0);

            DecoratorByClass.Add(HeroClass.Barbarian, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 200, 250, 10, 10, false, false, 128, 0, 0, 0, true),
                    Up = true,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = grounLabelBackgroundBrush,
                    BorderBrush = Hud.Render.CreateBrush(200, 250, 10, 10, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 6f, 200, 250, 10, 10, false, false, 128, 0, 0, 0, true),
                }
                ));

            DecoratorByClass.Add(HeroClass.Crusader, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 240, 0, 200, 250, false, false, 128, 0, 0, 0, true),
                    Up = true,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = grounLabelBackgroundBrush,
                    BorderBrush = Hud.Render.CreateBrush(240, 0, 200, 250, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 6f, 240, 0, 200, 250, false, false, 128, 0, 0, 0, true),
                }
                ));

            DecoratorByClass.Add(HeroClass.DemonHunter, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 0, 0, 200, false, false, 128, 0, 0, 0, true),
                    Up = true,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = grounLabelBackgroundBrush,
                    BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 200, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 6f, 255, 0, 0, 200, false, false, 128, 0, 0, 0, true),
                }
                ));

            DecoratorByClass.Add(HeroClass.Monk, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 245, 120, 0, 200, false, false, 128, 0, 0, 0, true),
                    Up = true,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = grounLabelBackgroundBrush,
                    BorderBrush = Hud.Render.CreateBrush(245, 120, 0, 200, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 6f, 245, 120, 0, 200, false, false, 128, 0, 0, 0, true),
                }
                ));

            DecoratorByClass.Add(HeroClass.Necromancer, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 175, 238, 238, false, false, 128, 0, 0, 0, true),
                    Up = true,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = grounLabelBackgroundBrush,
                    BorderBrush = Hud.Render.CreateBrush(255, 175, 238, 238, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 6f, 255, 175, 238, 238, false, false, 128, 0, 0, 0, true),
                }
                ));

            DecoratorByClass.Add(HeroClass.WitchDoctor, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 155, 0, 155, 125, false, false, 128, 0, 0, 0, true),
                    Up = true,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = grounLabelBackgroundBrush,
                    BorderBrush = Hud.Render.CreateBrush(155, 0, 155, 125, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 6f, 155, 0, 155, 125, false, false, 128, 0, 0, 0, true),
                }
                ));

            DecoratorByClass.Add(HeroClass.Wizard, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 250, 50, 180, false, false, 128, 0, 0, 0, true),
                    Up = true,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = grounLabelBackgroundBrush,
                    BorderBrush = Hud.Render.CreateBrush(255, 250, 50, 180, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 6f, 255, 250, 50, 180, false, false, 128, 0, 0, 0, true),
                }
                ));
        }

        public void PaintWorld(WorldLayer layer)
        {
            var players = Hud.Game.Players.Where(player => !player.IsMe && player.CoordinateKnown && (player.HeadStone == null));
            foreach (var player in players)
            {
                WorldDecoratorCollection decorator;
                if (!DecoratorByClass.TryGetValue(player.HeroClassDefinition.HeroClass, out decorator)) continue;

                decorator.Paint(layer, null, NameOffsetZ != 0 ? player.FloorCoordinate.Offset(0, 0, NameOffsetZ) : player.FloorCoordinate, player.BattleTagAbovePortrait);
            }
        }

    }

}