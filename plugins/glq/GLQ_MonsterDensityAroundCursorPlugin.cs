using Turbo.Plugins.Default;
using System.Globalization;
//by prrovoss
namespace Turbo.Plugins.glq
{

    public class GLQ_MonsterDensityAroundCursorPlugin : BasePlugin, IInGameWorldPainter
    {
        public bool DrawCursorCircle { get; set; }
        public bool DrawCursorLabel { get; set; }
        public bool DrawCursorLine { get; set; }
		public bool OnlyInTown { get; set; }

        public int Distance { get; set; }

        public TopLabelWithTitleDecorator CursorLabelDecorator { get; set; }
        public TopLabelWithTitleDecorator DistanceLabelOnLineDecorator { get; set; }
        public IBrush CursorCircleBrush { get; set; }
        public IBrush LineBrush { get; set; }



        public float DistanceLabelOnLineWRatio { get; set; }
        public float DistanceLabelOnLineHRatio { get; set; }


        public float CursorLabelXOffset { get; set; }
        public float CursorLabelYOffset { get; set; }
        public float CursorLabelWRatio { get; set; }
        public float CursorLabelHRatio { get; set; }

        public GLQ_MonsterDensityAroundCursorPlugin()
        {
            Enabled = true;
			OnlyInTown = true;
        }




        public override void Load(IController hud)
        {
            base.Load(hud);
            CursorCircleBrush = Hud.Render.CreateBrush(200, 255, 255, 255, 4);

            DrawCursorCircle = true;
            DrawCursorLabel = true;
            DrawCursorLine = true;
            Distance = 15;

            CursorLabelDecorator = new TopLabelWithTitleDecorator(Hud)
            {
                TextFont = hud.Render.CreateFont("tahoma", 9, 255, 255, 255, 255, false, false, true),
                BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, -1),
                BackgroundBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
            };
            CursorLabelXOffset = -10f;
            CursorLabelYOffset = 35f;
            CursorLabelWRatio = 0.025f;
            CursorLabelHRatio = 0.015f;

            DistanceLabelOnLineDecorator = new TopLabelWithTitleDecorator(Hud)
            {
                TextFont = hud.Render.CreateFont("tahoma", 9, 255, 255, 255, 255, false, false, true),
                BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, -1),
                BackgroundBrush = Hud.Render.CreateBrush(150, 0, 0, 0, 0),
            };
            DistanceLabelOnLineWRatio = 0.045f;
            DistanceLabelOnLineHRatio = 0.015f;

            LineBrush = Hud.Render.CreateBrush(255, 255, 255, 255, 3.0f);
        }

        public void PaintWorld(WorldLayer layer)
        {
            if (OnlyInTown && Hud.Game.Me.IsInTown) return;
			IScreenCoordinate coord = Hud.Window.CreateScreenCoordinate(Hud.Window.CursorX, Hud.Window.CursorY);
            IWorldCoordinate cursor = coord.ToWorldCoordinate();
			int count = 0;
            float x, y, width, height = 0;
            foreach (IMonster monster in Hud.Game.AliveMonsters)
            {
                if (monster.FloorCoordinate.XYDistanceTo(cursor) < Distance) count++;
            }
            if (DrawCursorCircle)
            {
                CursorCircleBrush.DrawWorldEllipse(Distance, -1, cursor);
            }
            if (DrawCursorLabel)
            {
                width = Hud.Window.Size.Height * CursorLabelWRatio;
                height = Hud.Window.Size.Height * CursorLabelHRatio;
                CursorLabelDecorator.Paint(coord.X + CursorLabelXOffset, coord.Y + CursorLabelYOffset, width, height, count.ToString(), null, "");
            }
            if (DrawCursorLine)
            {
                var player = Hud.Game.Me.ScreenCoordinate;
                LineBrush.DrawLine(player.X, player.Y, coord.X, coord.Y);
                var distance = Hud.Game.Me.FloorCoordinate.XYDistanceTo(cursor);
                var meScreenCoord = Hud.Game.Me.ScreenCoordinate;
                x = (meScreenCoord.X + coord.X) / 2;
                y = (meScreenCoord.Y + coord.Y) / 2;
                width = Hud.Window.Size.Height * DistanceLabelOnLineWRatio;
                height = Hud.Window.Size.Height * DistanceLabelOnLineHRatio;
                DistanceLabelOnLineDecorator.Paint(x - width / 2, y, width, height, distance.ToString("F1", CultureInfo.InvariantCulture) + '码');
            }







        }

    }

}