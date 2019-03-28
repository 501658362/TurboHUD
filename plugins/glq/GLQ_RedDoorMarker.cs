using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_RedDoorMarker : BasePlugin, IInGameWorldPainter, INewAreaHandler, IInGameTopPainter
    {
        public WorldDecoratorCollection MarkerDecorator { get; set; }
        public TopLabelWithTitleDecorator FinishedDecorator { get; set; }
        public TopLabelWithTitleDecorator TimesDecorator { get; set; }

        private bool redDoor0;
        private bool redDoor1;
        private bool redDoor2;
        private bool redDoor3;
        private bool finished;
        private int times;
        private HashSet<ActorSnoEnum> _actorSnoList = new HashSet<ActorSnoEnum>();

        public GLQ_RedDoorMarker()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            MarkerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 0, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(192, 255, 255, 255, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 10f, 255, 255, 255, 255, true, false, false),
                }
            );

            FinishedDecorator = new TopLabelWithTitleDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 0, 0, true, false, true),
            };

            TimesDecorator = new TopLabelWithTitleDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 239, 220, 129, false, false, true),
            };

            _actorSnoList.Add(ActorSnoEnum._uber_portalspot0); //Uber_PortalSpot0
            _actorSnoList.Add(ActorSnoEnum._uber_portalspot1); //Uber_PortalSpot1
            _actorSnoList.Add(ActorSnoEnum._uber_portalspot2); //Uber_PortalSpot2
            _actorSnoList.Add(ActorSnoEnum._uber_portalspot3); //Uber_PortalSpot3
        }

        public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (newGame)
            {
                redDoor0 = false;
                redDoor1 = false;
                redDoor2 = false;
                redDoor3 = false;
                finished = false;
            }
            else
            {
                if (area.Sno == 256767)
                {
                   redDoor0 = true;
                }
                if (area.Sno == 256106)
                {
                    redDoor1 = true;
                }
                if (area.Sno == 256742)
                {
                    redDoor2 = true;
                }
                if (area.Sno == 374239)
                {
                    redDoor3 = true;
                }
                if (redDoor0 && redDoor1 && redDoor2 && redDoor3 && !finished)
                {
                    times++;
                    finished = true;
                }
            }
        }

        public void PaintWorld(WorldLayer layer)
        {
            if (layer != WorldLayer.Ground)
            {
                return;
            }
            var actors = Hud.Game.Actors.Where(actor => actor.DisplayOnOverlay && _actorSnoList.Contains(actor.SnoActor.Sno));
            foreach (var actor in actors)
            {
                if (redDoor0 && actor.SnoActor.Sno == ActorSnoEnum._uber_portalspot0)
                {
                    MarkerDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 6f), "A1装置已进入过");
                }
                if (redDoor1 && actor.SnoActor.Sno == ActorSnoEnum._uber_portalspot1)
                {
                    MarkerDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 6f), "A2装置已进入过");
                }
                if (redDoor2 && actor.SnoActor.Sno == ActorSnoEnum._uber_portalspot2)
                {
                    MarkerDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 6f), "A3装置已进入过");
                }
                if (redDoor3 && actor.SnoActor.Sno == ActorSnoEnum._uber_portalspot3)
                {
                    MarkerDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 6f), "A4装置已进入过");
                }
                
            }
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;
            var ui = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.BoostWrapper.BoostsDifficultyStackPanel.clock");
            var ui2 = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.minimap_pve_main");
            var w = 0;
            var h = ui.Rectangle.Height;
            var X1 = ui2.Rectangle.Left - ui2.Rectangle.Width / 3.5f;
            var X2 = ui2.Rectangle.Left + ui2.Rectangle.Width / 3.5f;
            var Y = ui.Rectangle.Top;

            if (finished)
            {
                FinishedDecorator.Paint(X1, Y - h, w, h, "当前房间所有红门已进入过");
            }

            if (times != 0)
            {
                TimesDecorator.Paint(X2, Y - h, w, h, "地狱火护符任务已完成：" + times);
            }
        }
    }
}