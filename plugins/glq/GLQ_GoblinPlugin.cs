using System.Linq;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_GoblinPlugin : BasePlugin, IInGameWorldPainter
	{

        public WorldDecoratorCollection PortalDecorator { get; set; }

        public WorldDecoratorCollection MalevolentDecorator { get; set; }
        public WorldDecoratorCollection BloodDecorator { get; set; }
        public WorldDecoratorCollection OdiousDecorator { get; set; }
        public WorldDecoratorCollection GemDecorator { get; set; }
        public WorldDecoratorCollection GelatinousDecorator { get; set; }
        public WorldDecoratorCollection GildedDecorator { get; set; }
        public WorldDecoratorCollection InsufferableDecorator { get; set; }
        public WorldDecoratorCollection MenageristDecorator { get; set; }
        public WorldDecoratorCollection TreasureDecorator { get; set; }
        public WorldDecoratorCollection RainbowDecorator { get; set; }
        public WorldDecoratorCollection FiendDecorator { get; set; }
        public bool EnableSpeak { get; set; }
        public string MalevolentSpeak { get; set; }
        public string BloodSpeak { get; set; }
        public string OdiousSpeak { get; set; }	
        public string GemSpeak { get; set; }
        public string GelatinousSpeak { get; set; }
        public string GildedSpeak { get; set; }
        public string InsufferableSpeak { get; set; }
        public string MenageristSpeak { get; set; }
        public string TreasureSpeak { get; set; }
        public string RainbowSpeak { get; set; }
        public string FiendSpeak { get; set; }
	
		
        public GLQ_GoblinPlugin() {
            Enabled = true;
            EnableSpeak = true;
        }

        public override void Load(IController hud) {
            base.Load(hud);
			MalevolentSpeak = "默认";
			BloodSpeak = "默认";
			OdiousSpeak = "默认";
			GemSpeak = "默认";
			GelatinousSpeak = "默认";
			GildedSpeak = "默认";
			InsufferableSpeak = "默认";
			MenageristSpeak = "默认";
			TreasureSpeak = "默认";
			RainbowSpeak = "默认";
			FiendSpeak = "默认";

            var offsetH = Hud.Window.Size.Height * 0.005f;

            PortalDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud) {
                    Brush = Hud.Render.CreateBrush(180, 255, 255, 255, 0),
                    Radius = 8.0f
                },
                new MapShapeDecorator(Hud) {
                    Brush = Hud.Render.CreateBrush(180, 120, 0, 0, 0),
                    Radius = 2.5f
                }
            );

            MalevolentDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud) {
                    BackgroundBrush = Hud.Render.CreateBrush(180, 183, 91, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 10, 255, 0, 0, 0, true, false, false)
                },
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 183, 91, 0, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = offsetH,
                }
            );

            BloodDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud) {
                    BackgroundBrush = Hud.Render.CreateBrush(180, 255, 0, 128, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 10, 255, 255, 255, 255, true, false, false)
                },
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 255, 0, 128, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = offsetH,
                }
            );

            OdiousDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud) {
                    BackgroundBrush = Hud.Render.CreateBrush(180, 0, 255, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 10, 255, 0, 0, 0, true, false, false)
                },
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 0, 255, 0, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = offsetH,
                }
            );

            GemDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud) {
                    BackgroundBrush = Hud.Render.CreateBrush(180, 220, 220, 220, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 10, 255, 0, 0, 0, true, false, false)
                },
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 220, 220, 220, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = offsetH,
                }
            );

            GelatinousDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud) {
                    BackgroundBrush = Hud.Render.CreateBrush(200, 50, 50, 200, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 10, 255, 255, 255, 255, true, false, false)
                },

                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 62, 158, 255, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = offsetH,
                }
            );

            GildedDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud) {
                    BackgroundBrush = Hud.Render.CreateBrush(180, 255, 255, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 10, 255, 0, 0, 0, true, false, false)
                },
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 255, 255, 0, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = offsetH,
                }
            );

            InsufferableDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud) {
                    BackgroundBrush = Hud.Render.CreateBrush(180, 64, 128, 128, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 10, 255, 0, 0, 0, true, false, false)
                },
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 64, 128, 128, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = offsetH,
                }
            );

             MenageristDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud) {
                    BackgroundBrush = Hud.Render.CreateBrush(180, 56, 1, 185, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 10, 255, 255, 255, 255, true, false, false)
                },
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 8f, 200, 25, 1, 185, true, false, 128, 255, 255, 255, true),
                    RadiusOffset = offsetH,
                }
            );

            TreasureDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud) {
                    BackgroundBrush = Hud.Render.CreateBrush(200, 255, 255, 128, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 10, 255, 0, 0, 0, true, false, false)
                },
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 255, 255, 128, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = offsetH,
                }
            );

            RainbowDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud) {
                    BackgroundBrush = Hud.Render.CreateBrush(160, 196, 107, 255, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 10, 255, 0, 0, 0, true, false, false)
                },
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 196, 107, 255, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = offsetH,
                }
            );

            FiendDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud) {
                    BackgroundBrush = Hud.Render.CreateBrush(160, 255, 163, 15, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 10, 255, 0, 0, 0, true, false, false)
                },
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 255, 163, 15, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = offsetH,
                }
            );

        }


        public void PaintWorld(WorldLayer layer) {

            var portals = Hud.Game.Actors.Where(x => x.SnoActor.Sno == 410460);

            foreach (var actor in portals) {
                PortalDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
            }


            var monsters = Hud.Game.AliveMonsters;
            foreach (var monster in monsters) {
                var name = monster.SnoMonster.NameEnglish;
                switch (name) {
                    case "Malevolent Tormentor":
                        MalevolentDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
						if (EnableSpeak && (monster.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && MalevolentSpeak != "")
						{
							if(MalevolentSpeak == "默认")
							{
								Hud.Sound.Speak(monster.SnoMonster.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(MalevolentSpeak);
							}
						monster.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;
                    case "Blood Thief":
                        BloodDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
						if (EnableSpeak && (monster.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && BloodSpeak != "")
						{
							if(BloodSpeak == "默认")
							{
								Hud.Sound.Speak(monster.SnoMonster.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(BloodSpeak);
							}
						monster.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;
                    case "Odious Collector":
                        OdiousDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
						if (EnableSpeak && (monster.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && OdiousSpeak != "")
						{
							if(OdiousSpeak == "默认")
							{
								Hud.Sound.Speak(monster.SnoMonster.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(OdiousSpeak);
							}
						monster.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;
                    case "Gem Hoarder":
                        GemDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
						if (EnableSpeak && (monster.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && GemSpeak != "")
						{
							if(GemSpeak == "默认")
							{
								Hud.Sound.Speak(monster.SnoMonster.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(GemSpeak);
							}
						monster.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;
                    case "Gelatinous Sire":
                        GelatinousDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
						if (EnableSpeak && (monster.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && GelatinousSpeak != "")
						{
							if(GelatinousSpeak == "默认")
							{
								Hud.Sound.Speak(monster.SnoMonster.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(GelatinousSpeak);
							}
						monster.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;
                    case "Gelatinous Spawn":
                        GelatinousDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
                        break;
                    case "Gilded Baron":
                        GildedDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
						if (EnableSpeak && (monster.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && GildedSpeak != "")
						{
							if(GildedSpeak == "默认")
							{
								Hud.Sound.Speak(monster.SnoMonster.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(GildedSpeak);
							}
						monster.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;
                    case "Insufferable Miscreant":
                        InsufferableDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
						if (EnableSpeak && (monster.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && InsufferableSpeak != "")
						{
							if(InsufferableSpeak == "默认")
							{
								Hud.Sound.Speak(monster.SnoMonster.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(InsufferableSpeak);
							}
						monster.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;
                    case "Menagerist Goblin":
                        MenageristDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
						if (EnableSpeak && (monster.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && MenageristSpeak != "")
						{
							if(MenageristSpeak == "默认")
							{
								Hud.Sound.Speak(monster.SnoMonster.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(MenageristSpeak);
							}
						monster.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;
                    case "Treasure Goblin":
                        TreasureDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
						if (EnableSpeak && (monster.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && TreasureSpeak != "")
						{
							if(TreasureSpeak == "默认")
							{
								Hud.Sound.Speak(monster.SnoMonster.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(TreasureSpeak);
							}
						monster.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;
                    case "Rainbow Goblin":
                        RainbowDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
						if (EnableSpeak && (monster.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && RainbowSpeak != "")
						{
							if(RainbowSpeak == "默认")
							{
								Hud.Sound.Speak(monster.SnoMonster.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(RainbowSpeak);
							}
						monster.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;
                    case "Treasure Fiend":
                        FiendDecorator.Paint(layer, monster, monster.FloorCoordinate, monster.SnoMonster.NameLocalized);
						if (EnableSpeak && (monster.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000) && FiendSpeak != "")
						{
							if(FiendSpeak == "默认")
							{
								Hud.Sound.Speak(monster.SnoMonster.NameLocalized);
							}
							else
							{
								Hud.Sound.Speak(FiendSpeak);
							}
						monster.LastSpeak = Hud.Time.CreateAndStartWatch();

						}
                        break;
                }

            }
            }
        }
    }