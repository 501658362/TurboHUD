using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
 
    public class UberRealmMarker : BasePlugin, IInGameWorldPainter, INewAreaHandler, IInGameTopPainter
    {
 
        public WorldDecoratorCollection MarkerDecorator { get; set; }
        public TopLabelWithTitleDecorator FinishedDecorator { get; set; }
        public TopLabelWithTitleDecorator TimesDecorator { get; set; }
        bool RedDoor0 { get; set; }
        bool RedDoor1 { get; set; }
        bool RedDoor2 { get; set; }
        bool RedDoor3 { get; set; }
        bool Finished { get; set; }
        int Times { get; set; }
        private HashSet<ActorSnoEnum> _actorSnoList = new HashSet<ActorSnoEnum>();
        public UberRealmMarker()
        {
            Enabled = false;
        }
 
        public override void Load(IController hud)
        {
            base.Load(hud);
            RedDoor0 = false;
            RedDoor1 = false;
            RedDoor2 = false;
            RedDoor3 = false;
            Finished = false;
            Times = 0;
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
                RedDoor0 = false;
                RedDoor1 = false;
                RedDoor2 = false;
                RedDoor3 = false;
                Finished = false;
            }
        }
        public void PaintWorld(WorldLayer layer)
        {
            var MapSno = Hud.Game.Me.SnoArea.Sno.ToString();
            var actors = Hud.Game.Actors.Where(actor => actor.DisplayOnOverlay && _actorSnoList.Contains(actor.SnoActor.Sno));
            if (MapSno == "256767") RedDoor0 = true;
            if (MapSno == "256106") RedDoor1 = true;
            if (MapSno == "256742") RedDoor2 = true;
            if (MapSno == "374239") RedDoor3 = true;
            if (RedDoor0 && RedDoor1 && RedDoor2 && RedDoor3 && Finished == false)
            {
                Times++;
                Finished = true;
            }
            foreach (var actor in actors)
            {
                if (RedDoor0 && actor.SnoActor.Sno == ActorSnoEnum._uber_portalspot0) MarkerDecorator.Paint(layer, null, actor.FloorCoordinate.Offset(0, 0, 6f), "A1Key Entered");
                if (RedDoor1 && actor.SnoActor.Sno == ActorSnoEnum._uber_portalspot1) MarkerDecorator.Paint(layer, null, actor.FloorCoordinate.Offset(0, 0, 6f), "A2Key Entered");
                if (RedDoor2 && actor.SnoActor.Sno == ActorSnoEnum._uber_portalspot2) MarkerDecorator.Paint(layer, null, actor.FloorCoordinate.Offset(0, 0, 6f), "A3Key Entered");
                if (RedDoor3 && actor.SnoActor.Sno == ActorSnoEnum._uber_portalspot3) MarkerDecorator.Paint(layer, null, actor.FloorCoordinate.Offset(0, 0, 6f), "A4Key Entered");
            }
        }
        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;
            var ui = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.BoostWrapper.BoostsDifficultyStackPanel.clock");
			var ui2 = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.minimap_pve_main");
            var w = 0;
            var h = ui.Rectangle.Height;
            float XPos = ui2.Rectangle.Left + ui2.Rectangle.Width / 3.5f;
            float YPos = ui.Rectangle.Top;
            if (Finished) FinishedDecorator.Paint(XPos, YPos - h, w, h, "All UberRealm Entered");
            if (Times != 0)
            {
                TimesDecorator.Paint(XPos, YPos, w, h, "HellfireAmulet mission: " + Times);
            }
        }
 
    }
 
}