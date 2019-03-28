using System.Linq;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_MonsterDensityPlugin : BasePlugin, IInGameWorldPainter
    {
        public bool ShowLabel { get; set; }
        public bool ShowCircle { get; set; }
        public bool ShowProgression { get; set; }
        public bool ShowMark { get; set; }
        public int Distance { get; set; }
        public int MaxRadius { get; set; }
        public int ping { get; set; }
        public int DisplayLimit { get; set; }
        public WorldDecoratorCollection LabelDecorator { get; set; }
        public WorldDecoratorCollection CircleDecorator { get; set; }
		public WorldDecoratorCollection MarkDecorator { get; set; }
        IWorldCoordinate MCoordinate { get; set; }
        int Mcount { get; set; }
        public GLQ_MonsterDensityPlugin()
        {
            Enabled = true;
        }
 
        public override void Load(IController hud)
        {
            base.Load(hud);
            DisplayLimit = 1;
            ShowLabel = true;
            ShowCircle = true; 
			ShowMark = true;
            ShowProgression = true;
            Distance = 10;
            MaxRadius = 15;
            ping = 333;
            LabelDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud) {
                    BackgroundBrush = Hud.Render.CreateBrush(80, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 255, 255, true, false, 160, 0, 0, 0, true),
                }
                );
			MarkDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 0, 255, 255, 0),
                    Radius = 1f,
                }
                );

        }

        public void PaintWorld(WorldLayer layer)
        {
            if ((Hud.Game.MapMode == MapMode.WaypointMap) || (Hud.Game.MapMode == MapMode.ActMap) || (Hud.Game.MapMode == MapMode.Map)) return;
            var inRift = Hud.Game.SpecialArea == SpecialArea.Rift || Hud.Game.SpecialArea == SpecialArea.GreaterRift;
            double MRiftProgression = 0;
            int density = 0;
            var monsters = Hud.Game.AliveMonsters.Where(x => x.IsOnScreen);
            CircleDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 0, 255, 255, 1.5f),
                    Radius = MaxRadius,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, ping),
                }
                );
            foreach (var monster in monsters)
            {
                double MonsterRiftProgression = 0;
                if (monster.IsOnScreen)
                {
                    int count = Hud.Game.AliveMonsters.Count(m => (monster.FloorCoordinate.XYZDistanceTo(m.FloorCoordinate) - m.RadiusBottom) <= Distance);
                    var monsters2 = Hud.Game.AliveMonsters.Where(mm => (monster.FloorCoordinate.XYZDistanceTo(mm.FloorCoordinate) - mm.RadiusBottom) <= MaxRadius && mm.SummonerAcdDynamicId == 0 && mm.IsElite || (monster.FloorCoordinate.XYZDistanceTo(mm.FloorCoordinate) - mm.RadiusBottom) <= MaxRadius && !mm.IsElite);
                    if (inRift)
                    {
                        foreach (var monster2 in monsters2)
                        {
                            MonsterRiftProgression += monster2.SnoMonster.RiftProgression * 100.0d / this.Hud.Game.MaxQuestProgress;

                        }
                    }
                    if (count >= density && MonsterRiftProgression >= MRiftProgression)
                    {
                        MCoordinate = monster.FloorCoordinate;
                        Mcount = count;
                        density = count;
                        MRiftProgression = MonsterRiftProgression;
                    }
                } 
            }
            foreach (var monster in monsters)
            {
                if (monster.IsOnScreen && Mcount >= DisplayLimit)
                {
                    if (ShowLabel)
                    {
                        
                        if(!inRift)
                        {
                            LabelDecorator.Paint(layer, monster, MCoordinate, Distance + "码密度：" + Mcount);
                        }
                        else
                        {
                            if(ShowProgression)
                            {
                                LabelDecorator.Paint(layer, monster, MCoordinate, Distance + "码密度：" + Mcount + "（" + MaxRadius + "码进度：" + MRiftProgression.ToString("f2") + "）");
                            }
                            else
                            {
                                LabelDecorator.Paint(layer, monster, MCoordinate, Distance + "码密度：" + Mcount);
                            }
                            
                        }     
                    }
                    if (ShowCircle)
                    {
                        CircleDecorator.Paint(layer, monster, MCoordinate, null);
                    }
					if (ShowMark)
					{
						MarkDecorator.Paint(layer, monster, MCoordinate, null);
					}
                }
                return;
            }

        }
    }
}