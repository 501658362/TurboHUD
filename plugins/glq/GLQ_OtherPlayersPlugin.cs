using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_OtherPlayersPlugin : BasePlugin, IInGameWorldPainter
	{
        
        public Dictionary<HeroClass, WorldDecoratorCollection> DecoratorscreenByClass { get; set; }
        public Dictionary<HeroClass, WorldDecoratorCollection> DecoratorminimapByClass { get; set; }
        public float NameOffsetZ { get; set; }
        public bool screen { get; set; }
        public bool minimap { get; set; }

        public GLQ_OtherPlayersPlugin()
		{
            Enabled = true;
            DecoratorscreenByClass = new Dictionary<HeroClass, WorldDecoratorCollection>();
            DecoratorminimapByClass = new Dictionary<HeroClass, WorldDecoratorCollection>();
            NameOffsetZ = 3.5f;
            screen = true;
            minimap = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            DecoratorscreenByClass.Add(HeroClass.Barbarian, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 128, 64, 0),
                    BorderBrush = Hud.Render.CreateBrush(250, 0, 0, 0, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                }
                ));

            DecoratorscreenByClass.Add(HeroClass.Crusader, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 240, 240, 240, 0),
                    BorderBrush = Hud.Render.CreateBrush(240, 0, 0, 0, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                }
                ));

            DecoratorscreenByClass.Add(HeroClass.DemonHunter, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 255, 255, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                }
                ));

            DecoratorscreenByClass.Add(HeroClass.Monk, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 255, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(240, 0, 0, 0, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                }
                ));

            DecoratorscreenByClass.Add(HeroClass.WitchDoctor, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 255, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(250, 0, 0, 0, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                }
                ));

            DecoratorscreenByClass.Add(HeroClass.Wizard, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 0, 255, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                }
                ));
            DecoratorscreenByClass.Add(HeroClass.Necromancer, new WorldDecoratorCollection(
                 new GroundLabelDecorator(Hud)
                 {
                     BackgroundBrush = Hud.Render.CreateBrush(255, 0, 190, 190, 0),
                     BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 1),
                     TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                 }
                 ));


            DecoratorminimapByClass.Add(HeroClass.Barbarian, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 250, 255, 128, 64, false, false, 128, 0, 0, 0, true),
                    Up = true,
                }
                ));

            DecoratorminimapByClass.Add(HeroClass.Crusader, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 240, 240, 240, 240, false, false, 128, 0, 0, 0, true),
                    Up = true,
                }
                ));

            DecoratorminimapByClass.Add(HeroClass.DemonHunter, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 255, 0, 200, 255, false, false, 128, 0, 0, 0, true),
                    Up = true,
                }
                ));

            DecoratorminimapByClass.Add(HeroClass.Monk, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 245, 255, 255, 0, false, false, 128, 0, 0, 0, true),
                    Up = true,
                }
                ));

            DecoratorminimapByClass.Add(HeroClass.WitchDoctor, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 255, 0, 255, 0, false, false, 128, 0, 0, 0, true),
                    Up = true,
                }
                ));

            DecoratorminimapByClass.Add(HeroClass.Wizard, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 255, 255, 0, 255, false, false, 128, 0, 0, 0, true),
                    Up = true,
                }
                ));
            DecoratorminimapByClass.Add(HeroClass.Necromancer, new WorldDecoratorCollection(
                 new MapLabelDecorator(Hud)
                 {
                     LabelFont = Hud.Render.CreateFont("tahoma", 7f, 230, 0, 190, 190, false, false, 128, 0, 0, 0, true),
                     Up = true,
                 }
                 ));
        }

        public void PaintWorld(WorldLayer layer)
        {
            //if (!screen && !minimap) return;
            var players = Hud.Game.Players.Where(player => !player.IsMe && player.CoordinateKnown && (player.HeadStone == null));
            foreach (var player in players)
            {
                WorldDecoratorCollection decoratorscreen;
                WorldDecoratorCollection decoratorminimap;
                if (!DecoratorscreenByClass.TryGetValue(player.HeroClassDefinition.HeroClass, out decoratorscreen)) continue;
                if (!DecoratorminimapByClass.TryGetValue(player.HeroClassDefinition.HeroClass, out decoratorminimap)) continue;
                if (screen && Hud.Game.MapMode != MapMode.WaypointMap && Hud.Game.MapMode != MapMode.ActMap && Hud.Game.MapMode != MapMode.Map)
                {
                    decoratorscreen.Paint(layer, null, NameOffsetZ != 0 ? player.FloorCoordinate.Offset(0, 0, NameOffsetZ) : player.FloorCoordinate, player.BattleTagAbovePortrait);
                }
                
                if(minimap)
                {
                    decoratorminimap.Paint(layer, null, NameOffsetZ != 0 ? player.FloorCoordinate.Offset(0, 0, NameOffsetZ) : player.FloorCoordinate, player.BattleTagAbovePortrait);
                }

                    

            }
        }

    }

}