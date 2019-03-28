using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{

    public class GLQ_BannerPlugin : BasePlugin, IInGameWorldPainter
    {

        public WorldDecoratorCollection Decorator { get; set; }
        public bool EnableSpeak { get; set; }
        private HashSet<ActorSnoEnum> _actorSnoList = new HashSet<ActorSnoEnum>();
        public GLQ_BannerPlugin()
		{
            Enabled = true;
            EnableSpeak = true;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            Decorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 200, 0, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(192, 255, 255, 255, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 255, 255, 255, true, false, false),
                }
                );
            _actorSnoList.Add(ActorSnoEnum._emotebanner_player_1); //EmoteBanner_Player_1
			_actorSnoList.Add(ActorSnoEnum._emotebanner_player_2); //EmoteBanner_Player_2
			_actorSnoList.Add(ActorSnoEnum._emotebanner_player_3); //EmoteBanner_Player_3
			_actorSnoList.Add(ActorSnoEnum._emotebanner_player_4); //EmoteBanner_Player_4
			_actorSnoList.Add(ActorSnoEnum._emotebanner_player_5); //EmoteBanner_Player_5
			_actorSnoList.Add(ActorSnoEnum._emotebanner_player_6); //EmoteBanner_Player_6
			_actorSnoList.Add(ActorSnoEnum._emotebanner_player_7); //EmoteBanner_Player_7
			_actorSnoList.Add(ActorSnoEnum._emotebanner_player_8); //EmoteBanner_Player_8
			
        }

        public void PaintWorld(WorldLayer layer)
        {
            var banners = Hud.Game.Banners;
            foreach (var banner in banners)
            {
                Decorator.Paint(layer, null, banner.FloorCoordinate, "注意队友旗子");
            }
            var actors = Hud.Game.Actors.Where(actor => actor.DisplayOnOverlay && _actorSnoList.Contains(actor.SnoActor.Sno));
            foreach (var actor in actors)
            {
				if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000))
				{
				Hud.Sound.Speak("注意队友旗子");
				actor.LastSpeak = Hud.Time.CreateAndStartWatch();
				}
            }

        }

    }

}