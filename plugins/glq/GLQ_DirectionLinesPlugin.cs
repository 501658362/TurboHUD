using System;
using System.Linq;
using Turbo.Plugins.Default;
using System.Collections.Generic;
//BY RuneB
namespace Turbo.Plugins.glq
{
    public class GLQ_DirectionLinesPlugin : BasePlugin, IInGameTopPainter
    {
        public int TextDistanceAway { get; set; }
        public IFont TextFont { get; set; }
        public IBrush GreyBrush { get; set; }
        public float StrokeWidth { get; set; }
        public float CloseEnoughRange { get; set; }
        public bool ShowText { get; set; }
        public Dictionary<ActorRarity, IBrush> MonsterBrushes { get; set; }

        private IScreenCoordinate center { get { return Hud.Game.Me.ScreenCoordinate; } }

        public GLQ_DirectionLinesPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            CloseEnoughRange = 15;
            ShowText = true;
            StrokeWidth = 3;
            TextFont = Hud.Render.CreateFont("tahoma", 8, 120, 255, 255, 255, true, false, true);
            MonsterBrushes = new Dictionary<ActorRarity, IBrush>();
            MonsterBrushes.Add(ActorRarity.Rare, Hud.Render.CreateBrush(100, 255, 128, 0, 0));
            MonsterBrushes.Add(ActorRarity.Champion, Hud.Render.CreateBrush(100, 0, 128, 255, 0));
            MonsterBrushes.Add(ActorRarity.Boss, Hud.Render.CreateBrush(100, 255, 208, 0, 0));
            MonsterBrushes.Add(ActorRarity.Unique, Hud.Render.CreateBrush(100, 200, 0, 150, 0));
            TextDistanceAway = 160;
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;
            var textDistanceAway = TextDistanceAway;

            var monsters = Hud.Game.AliveMonsters.Where(monster => MonsterBrushes.ContainsKey(monster.Rarity) && monster.SummonerAcdDynamicId == 0 && monster.NormalizedXyDistanceToMe > CloseEnoughRange);
            foreach (var monster in monsters)
            {
                var monsterScreenCoordinate = monster.FloorCoordinate.ToScreenCoordinate();

                //Draw line to monster
                var start = PointOnLine(center.X, center.Y, monsterScreenCoordinate.X, monsterScreenCoordinate.Y, 60);
                var end = PointOnLine(monsterScreenCoordinate.X, monsterScreenCoordinate.Y-30, center.X, center.Y, 20);

                if (!monster.IsOnScreen)
                {
                    MonsterBrushes[monster.Rarity].DrawLine(start.X, start.Y, end.X, end.Y, StrokeWidth);
                    if (ShowText) //Draw text
                    {
                        var layout = TextFont.GetTextLayout(string.Format("{0:N0}", monster.NormalizedXyDistanceToMe) + "码");
                        var p = PointOnLine(center.X, center.Y, monsterScreenCoordinate.X, monsterScreenCoordinate.Y, textDistanceAway);
                        TextFont.DrawText(layout, p.X, p.Y);
                        textDistanceAway += 30; // avoid text overlap
                    }
                }


            }
        }

        public IScreenCoordinate PointOnLine(float x1, float y1, float x2, float y2, float offset)
        {
            //Returns a coordinate at offset distance away from x1,y1 towards x2,y2
            var distance = (float)Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            var ratio = offset / distance;

            var x3 = ratio * x2 + (1 - ratio) * x1;
            var y3 = ratio * y2 + (1 - ratio) * y1;
            return Hud.Window.CreateScreenCoordinate(x3, y3);
        }
    }
}