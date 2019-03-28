using System.Linq;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_ShrineNamePlugin : BasePlugin, IInGameWorldPainter
	{

        public WorldDecoratorCollection BlessedShrineDecorator { get; set; }
        public WorldDecoratorCollection EnlightenedShrineDecorator { get; set; }
        public WorldDecoratorCollection FortuneShrineDecorator { get; set; }
        public WorldDecoratorCollection FrenziedShrineDecorator { get; set; }
        public WorldDecoratorCollection FleetingShrineDecorator { get; set; }
        public WorldDecoratorCollection EmpoweredShrineDecorator { get; set; }
        public WorldDecoratorCollection BanditShrineDecorator { get; set; }
        public WorldDecoratorCollection PowerPylonDecorator { get; set; }
        public WorldDecoratorCollection ConduitPylonDecorator { get; set; }
        public WorldDecoratorCollection ChannelingPylonDecorator { get; set; }
        public WorldDecoratorCollection ShieldPylonDecorator { get; set; }
        public WorldDecoratorCollection SpeedPylonDecorator { get; set; }
        public WorldDecoratorCollection HealingWellDecorator { get; set; }
        public WorldDecoratorCollection PoolOfReflectionDecorator { get; set; }
        public WorldDecoratorCollection PossibleRiftPylonDecorator { get; set; }
        public bool EnableSpeak { get; set; }
        public string BlessedSpeak { get; set; }
        public string EnlightenedSpeak { get; set; }
		public string FortuneSpeak { get; set; }
		public string FrenziedSpeak { get; set; }
		public string FleetingSpeak { get; set; }
		public string EmpoweredSpeak { get; set; }
		public string BanditSpeak { get; set; }
		public string PowerSpeak { get; set; }
		public string ConduitSpeak { get; set; }
		public string ChannelingSpeak { get; set; }
		public string ShieldSpeak { get; set; }
		public string SpeedSpeak { get; set; }
		public string HealingSpeak { get; set; }
		public string PoolSpeak { get; set; }
		public string PossibleRiftPylonSpeak { get; set; }

		
        public GLQ_ShrineNamePlugin()
		{
            Enabled = true;
            EnableSpeak = true;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);
            BlessedSpeak = "默认";
            EnlightenedSpeak = "默认";
            FortuneSpeak = "默认";
            FrenziedSpeak = "默认";
            FleetingSpeak = "默认";
            EmpoweredSpeak = "默认";
            BanditSpeak = "默认";
            PowerSpeak = "默认";
            ConduitSpeak = "默认";
            ChannelingSpeak = "默认";
            ShieldSpeak = "默认";
            SpeedSpeak = "默认";
            HealingSpeak = "默认";
            PoolSpeak = "经验池";
            PossibleRiftPylonSpeak = "发现刷塔位置";

            var shadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1);
            var importantBorderBrush = Hud.Render.CreateBrush(100, 0, 0, 0, 2);
            var importantBorderroundBrush = Hud.Render.CreateBrush(100, 0, 0, 0, 0);
            var importantLabelFont = Hud.Render.CreateFont("楷体", 11f, 230, 255, 255, 255, false, false, 150, 0, 0, 0, true);
            var offsetH = Hud.Window.Size.Height * 0.005f;

            BlessedShrineDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 230, 255, 255, 255, false, false, 100, 0, 0, 0, true),
                    Up = true,
		    RadiusOffset = -offsetH*5
                },
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    BackgroundBrush = importantBorderroundBrush,
                    TextFont = importantLabelFont,
                }
                );

            EnlightenedShrineDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 230, 255, 255, 255, false, false, 100, 0, 0, 0, true),
                    Up = true,
		    RadiusOffset = -offsetH*5
                },
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    BackgroundBrush = importantBorderroundBrush,
                    TextFont = importantLabelFont,
                }
                );

            FortuneShrineDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 230, 255, 255, 255, false, false, 100, 0, 0, 0, true),
                    Up = true,
		    RadiusOffset = -offsetH*5
                },
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    BackgroundBrush = importantBorderroundBrush,
                    TextFont = importantLabelFont,
                }
                );

            FrenziedShrineDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 230, 255, 255, 255, false, false, 100, 0, 0, 0, true),
                    Up = true,
		    RadiusOffset = -offsetH*5
                },
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    BackgroundBrush = importantBorderroundBrush,
                    TextFont = importantLabelFont,
                }
                );

            FleetingShrineDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 230, 255, 255, 255, false, false, 100, 0, 0, 0, true),
                    Up = true,
		    RadiusOffset = -offsetH*5
                },
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    BackgroundBrush = importantBorderroundBrush,
                    TextFont = importantLabelFont,
                }
                );

            EmpoweredShrineDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 230, 255, 255, 255, false, false, 100, 0, 0, 0, true),
                    Up = true,
		    RadiusOffset = -offsetH*5
                },
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    BackgroundBrush = importantBorderroundBrush,
                    TextFont = importantLabelFont,
                }
                );

            BanditShrineDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 9f, 230, 255, 0, 0, false, false, 100, 70, 22, 0, true),
                    Up = true,
		    RadiusOffset = -offsetH*5
                },
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    BackgroundBrush = importantBorderroundBrush,
                    TextFont = importantLabelFont,
                }
                );

            PowerPylonDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 9f, 230, 255, 0, 0, false, false, 100, 70, 22, 0, true),
                    Up = true,
		    RadiusOffset = -offsetH*7
                },
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    BackgroundBrush = importantBorderroundBrush,
                    TextFont = importantLabelFont,
                }
                );

            ConduitPylonDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 9f, 255, 255, 255, 0, false, false, 100, 111, 111, 0, true),
                    Up = true,
		    RadiusOffset = -offsetH*7
                },
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    BackgroundBrush = importantBorderroundBrush,
                    TextFont = importantLabelFont,
                }
                );

            ChannelingPylonDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 9f, 230, 0, 255, 128, false, false, 100, 0, 0, 0, true),
                    Up = true,
		    RadiusOffset = -offsetH*7
                },
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    BackgroundBrush = importantBorderroundBrush,
                    TextFont = importantLabelFont,
                }
                );

            ShieldPylonDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 9f, 255, 255, 255, 185, false, false, 100, 0, 0, 0, true),
                    Up = true,
		    RadiusOffset = -offsetH*7
                },
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    BackgroundBrush = importantBorderroundBrush,
                    TextFont = importantLabelFont,
                }
                );

            SpeedPylonDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 9f, 230, 0, 200, 255, false, false, 100, 0, 0, 0, true),
                    Up = true,
		    RadiusOffset = -offsetH*7
                },
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    BackgroundBrush = importantBorderroundBrush,
                    TextFont = importantLabelFont,
                }
                );
            HealingWellDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 230, 255, 90, 90, false, false, 100, 0, 0, 0, true),
                    Up = true,
		    RadiusOffset = -offsetH*5
                },
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    BackgroundBrush = importantBorderroundBrush,
                    TextFont = Hud.Render.CreateFont("楷体", 11f, 230, 255, 90, 90, false, false, 150, 0, 0, 0, true),
                }
                );

            PoolOfReflectionDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 230, 255, 255, 0, false, false, 100, 0, 0, 0, true),
                    Up = true,
		    RadiusOffset = -offsetH*5
                },
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    BackgroundBrush = importantBorderroundBrush,
                    TextFont = Hud.Render.CreateFont("楷体", 11f, 230, 255, 255, 0, false, false, 150, 0, 0, 0, true),
                }
                );

            PossibleRiftPylonDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 255, 255, 55, 3),
                    ShadowBrush = shadowBrush,
                    Radius = 5.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                },
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = +offsetH,
                }
                );
        }


        public void PaintWorld(WorldLayer layer)
        {

       	    var shrines = Hud.Game.Shrines.Where(x => !x.IsDisabled && !x.IsOperated && x.DisplayOnOverlay && (x.Type != ShrineType.HealingWell) && (x.Type != ShrineType.PoolOfReflection));
            foreach (var actor in shrines)
            {        
                switch (actor.SnoActor.Sno)
                {
                    case (ActorSnoEnum)225025:
                    case (ActorSnoEnum)176074:
                	BlessedShrineDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && BlessedSpeak != "")
						{
							if(BlessedSpeak == "默认")
							{
								Hud.Sound.Speak(actor.SnoActor.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(BlessedSpeak);
							}
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;
                    case (ActorSnoEnum)225262:
                    case (ActorSnoEnum)176075:
                	EnlightenedShrineDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && EnlightenedSpeak != "")
						{
							if(EnlightenedSpeak == "默认")
							{
								Hud.Sound.Speak(actor.SnoActor.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(EnlightenedSpeak);
							}
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;

                    case (ActorSnoEnum)225263:
                    case (ActorSnoEnum)176076:
                	FortuneShrineDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && FortuneSpeak != "")
						{
							if(FortuneSpeak == "默认")
							{
								Hud.Sound.Speak(actor.SnoActor.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(FortuneSpeak);
							}
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;

                    case (ActorSnoEnum)225266:
                    case (ActorSnoEnum)176077:
                	FrenziedShrineDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && FrenziedSpeak != "")
						{
							if(FrenziedSpeak == "默认")
							{
								Hud.Sound.Speak(actor.SnoActor.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(FrenziedSpeak);
							}
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;

                    case (ActorSnoEnum)260342:
                    case (ActorSnoEnum)260346:
                	FleetingShrineDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && FleetingSpeak != "")
						{
							if(FleetingSpeak == "默认")
							{
								Hud.Sound.Speak(actor.SnoActor.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(FleetingSpeak);
							}
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;

                    case (ActorSnoEnum)260343:
                    case (ActorSnoEnum)260347:
                	EmpoweredShrineDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && EmpoweredSpeak != "")
						{
							if(EmpoweredSpeak == "默认")
							{
								Hud.Sound.Speak(actor.SnoActor.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(EmpoweredSpeak);
							}
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;

                    case (ActorSnoEnum)434409:
                    case (ActorSnoEnum)269349:
                	BanditShrineDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && BanditSpeak != "")
						{
							if(BanditSpeak == "默认")
							{
								Hud.Sound.Speak(actor.SnoActor.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(BanditSpeak);
							}
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;

                    case (ActorSnoEnum)330695:
                	PowerPylonDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && PowerSpeak != "")
						{
							if(PowerSpeak == "默认")
							{
								Hud.Sound.Speak(actor.SnoActor.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(PowerSpeak);
							}
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;

                    case (ActorSnoEnum)330696:
                    case (ActorSnoEnum)398654:
                	ConduitPylonDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && ConduitSpeak != "")
						{
							if(ConduitSpeak == "默认")
							{
								Hud.Sound.Speak(actor.SnoActor.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(ConduitSpeak);
							}
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;

                    case (ActorSnoEnum)330697:
                	ChannelingPylonDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && ChannelingSpeak != "")
						{
							if(ChannelingSpeak == "默认")
							{
								Hud.Sound.Speak(actor.SnoActor.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(ChannelingSpeak);
							}
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;

                    case (ActorSnoEnum)330698:
                	ShieldPylonDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && ShieldSpeak != "")
						{
							if(ShieldSpeak == "默认")
							{
								Hud.Sound.Speak(actor.SnoActor.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(ShieldSpeak);
							}
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;

                    case (ActorSnoEnum)330699:
                	SpeedPylonDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && SpeedSpeak != "")
						{
							if(SpeedSpeak == "默认")
							{
								Hud.Sound.Speak(actor.SnoActor.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(SpeedSpeak);
							}
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;
                }
            }


            var healingWells = Hud.Game.Shrines.Where(x => !x.IsDisabled && !x.IsOperated && x.DisplayOnOverlay && (x.Type == ShrineType.HealingWell));
            foreach (var actor in healingWells)
            {
                HealingWellDecorator.ToggleDecorators<GroundLabelDecorator>(!actor.IsOnScreen); // do not display ground labels when the actor is on the screen
                HealingWellDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && HealingSpeak != "")
						{
							if(HealingSpeak == "默认")
							{
								Hud.Sound.Speak(actor.SnoActor.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(HealingSpeak);
							}
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
            }

            var poolOfReflections = Hud.Game.Shrines.Where(x => !x.IsDisabled && !x.IsOperated && x.DisplayOnOverlay && (x.Type == ShrineType.PoolOfReflection));
            foreach (var actor in poolOfReflections)
            {
                PoolOfReflectionDecorator.ToggleDecorators<GroundLabelDecorator>(!actor.IsOnScreen); // do not display ground labels when the actor is on the screen
                PoolOfReflectionDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && PoolSpeak != "")
						{
							if(PoolSpeak == "默认")
							{
								Hud.Sound.Speak(actor.SnoActor.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(PoolSpeak);
							}
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
            }

            var riftPylonSpawnPoints = Hud.Game.Actors.Where(x => x.SnoActor.Sno == ActorSnoEnum._markerlocation_tieredriftpylon);
            foreach (var actor in riftPylonSpawnPoints)
            {
                PossibleRiftPylonDecorator.Paint(layer, actor, actor.FloorCoordinate, "？？塔");
						if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && PossibleRiftPylonSpeak != "")
						{
						Hud.Sound.Speak(PossibleRiftPylonSpeak);
						actor.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
            }

        }
    }

}