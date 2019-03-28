using System.Linq;
using Turbo.Plugins.Default;
 
namespace Turbo.Plugins.glq
{
    public class GLQ_NecDeadBodyPlugin : BasePlugin, IInGameTopPainter, IInGameWorldPainter
    {
        public IFont TextFont { get; set; }
        public int yard { get; set; }
        public bool DeadBodyCircle { get; set; }
        public bool DeadBodyCount { get; set; }
        public TopLabelDecorator DeadBodyCountDecorator { get; set; }
        public WorldDecoratorCollection DeadBodyCircleDecorator { get; set; }
        public float XWidth { get; set; }
        public float YHeight { get; set; }    

        public GLQ_NecDeadBodyPlugin()
        {
            Enabled = true;
        }
 
        public override void Load(IController hud)
        {
            base.Load(hud);
            DeadBodyCircle = true;
            DeadBodyCount = true;


            DeadBodyCountDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 175, 238, 238, true, false, false), //this configures the size of the numbers ("7") and the color in RGB ("255, 175, 238, 238")
                BackgroundTexture1 = hud.Texture.ButtonTextureBlue,
                BackgroundTexture2 = hud.Texture.BackgroundTextureGreen,
                BackgroundTextureOpacity2 = 0.6f,
            };

            DeadBodyCircleDecorator = new WorldDecoratorCollection(
                 new GroundShapeDecorator(Hud)
                 {
                     Brush = Hud.Render.CreateBrush(192, 255, 0, 0, -3),
                     ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                     ShapePainter = WorldStarShapePainter.NewCross(Hud),
                     Radius = 1f,
                     RadiusTransformator = new StandardPingRadiusTransformator(Hud, 400, 0.8f, 1.0f),
                     RotationTransformator = new CircularRotationTransformator(Hud, 30),
                 },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 0, 0, 2f),
                    Radius = 1f
                }
                );
        }

        public void PaintWorld(WorldLayer layer)
        {
            if ((Hud.Game.MapMode == MapMode.WaypointMap) || (Hud.Game.MapMode == MapMode.ActMap) || (Hud.Game.MapMode == MapMode.Map)) return;
            var skill = Hud.Game.Me.Powers.UsedSkills.Where(x => x.SnoPower.Sno == 454174 || x.SnoPower.Sno == 461650 || x.SnoPower.Sno == 460757 || x.SnoPower.Sno == 462239).FirstOrDefault();
            if (skill != null)
            {
                var DeadBody = Hud.Game.Actors.Where(x => x.SnoActor.Sno == ActorSnoEnum._p6_necro_corpse_flesh);
                if (DeadBodyCircle == true)
                    foreach (var actor in DeadBody)
                    {
                        DeadBodyCircleDecorator.Paint(layer, actor, actor.FloorCoordinate, "");
                    }
            }
                
        }
        public void PaintTopInGame(ClipState clipState)
        {
			if (clipState != ClipState.BeforeClip) return;
            var skill = Hud.Game.Me.Powers.UsedSkills.Where(x => x.SnoPower.Sno == 454174 || x.SnoPower.Sno == 461650 || x.SnoPower.Sno == 460757 || x.SnoPower.Sno == 462239).FirstOrDefault();
            if (skill != null)
            {
                var DeadBody = Hud.Game.Actors.Where(d => d.SnoActor.Sno == ActorSnoEnum._p6_necro_corpse_flesh && d.IsOnScreen);
                int Count = 0;
                var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_progressBar_manaBall").Rectangle;
                var w = uiRect.Width / 3f;
                var h = uiRect.Height * 0.15f;
                var x = uiRect.Left + w;
                var y = uiRect.Top - uiRect.Height * 0.17f;
                if (DeadBodyCount == true)
                {
                    foreach (var actor in DeadBody)
                    {
                        Count++;
                    }
                    if (Count > 0)
                    {
                        if (Count < 10)
                        {
                            DeadBodyCountDecorator.TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 175, 238, 238, true, false, false);
                        }
                        if (Count >= 10 && Count < 16)
                        {
                            DeadBodyCountDecorator.TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, false);
                        }
                        if (Count >= 16)
                        {
                            DeadBodyCountDecorator.TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 0, 0, true, false, false);
                        }
                        DeadBodyCountDecorator.TextFunc = () => Count.ToString();
                        DeadBodyCountDecorator.HintFunc = () => "尸体数量";
                        DeadBodyCountDecorator.Paint(x, y, w, h, HorizontalAlign.Center);
                    }

                }

            }
        }
    }

}
