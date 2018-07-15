using System.Linq;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_PlayerResurrectionTimer : BasePlugin, IInGameTopPainter, INewAreaHandler
    {
        private bool[] FalseDead;
        private bool[] _FalseDead;
        private int[] FalseDeadTime;
        private bool[] Dead;
        private int[] DeadTimes;
        private double[] DeadTime;
        private double[] CurrentTime;
        private double[] GhostTime;
        private double[] CurrentGhostTime;
       
        public string DeathSymbol { get; set; }
        public IFont TextFontDeath { get; set; }
        public IFont TextFontDeathTime { get; set; }
        public IFont TextFontGhostTime { get; set; }
        public IBrush DeadTimeBorderBrush { get; set; }
        public IBrush DeadBorderBrush { get; set; }
        public IBrush GhostBorderBrush { get; set; }
        public double delay { get; set; }
        public GLQ_PlayerResurrectionTimer()
        {
            Enabled = true;
            delay = 3d;
        }
       
        public override void Load(IController hud)
        {
            base.Load(hud);
            FalseDead = new bool[4];
            _FalseDead = new bool[4];
            FalseDeadTime = new int[4];
            Dead = new bool[4];
            DeadTimes = new int[4];
            DeadTime = new double[4];
            CurrentTime = new double[4];
            GhostTime = new double[4];
            CurrentGhostTime = new double[4];
           
            DeathSymbol = "\u271F"; //✟
            TextFontDeath = Hud.Render.CreateFont("tahoma", 35, 200, 255, 255, 255, true, false, true);
            TextFontDeathTime = Hud.Render.CreateFont("tahoma", 12, 200, 255, 0, 0, true, false, true);
            TextFontGhostTime = Hud.Render.CreateFont("tahoma", 12, 200, 128, 255, 255, true, false, true);
            DeadTimeBorderBrush = Hud.Render.CreateBrush(200, 255, 0, 0, -2);
            DeadBorderBrush = Hud.Render.CreateBrush(200, 255, 255, 255, -2);
            GhostBorderBrush = Hud.Render.CreateBrush(200, 128, 255, 255, -2);
        }
       
        public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (newGame)
            {
                for (int i = 0; i < 4; i++)
                {
                    DeadTimes[i] = 0;
                    GhostTime[i] = 0;
                    Dead[i] =false;

                }
            }
        }
       
        private IQuest riftQuest
        {
            get
            {
                return Hud.Game.Quests.FirstOrDefault(q => q.SnoQuest.Sno == 337492) ?? // rift
                       Hud.Game.Quests.FirstOrDefault(q => q.SnoQuest.Sno == 382695);   // gr
            }
        }
       
        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;
            var secondsLeft = (Hud.Game.CurrentTimedEventEndTick - (double)Hud.Game.CurrentGameTick) / 60.0d;
           
            if (riftQuest == null || (riftQuest != null && riftQuest.State == QuestState.none))
            {
                for (int i = 0; i < 4; i++)
                {
                    DeadTimes[i] = 0;
                    GhostTime[i] = 0;
                }
            }
           
            foreach (var player in Hud.Game.Players)
            {
                DrawPlayerDeadTimer(player, player.InGreaterRift, secondsLeft);
            }
        }
       
        private void DrawPlayerDeadTimer(IPlayer player, bool inGR, double secondsLeft)
        {
            var portrait = player.PortraitUiElement.Rectangle;
            var x = portrait.Left + portrait.Width * 1.1f;
            var y = portrait.Top + portrait.Height / 4;
            var layout = TextFontDeath.GetTextLayout(DeathSymbol);
           
            if(player.IsDead)
            {
                if (_FalseDead[player.Index] == false) FalseDeadTime[player.Index] = Hud.Game.CurrentGameTick + (int)(delay * 60);
                if (player.IsDead && Hud.Game.CurrentGameTick > FalseDeadTime[player.Index])
                {
                    FalseDead[player.Index] = true;
                }
                else
                {
                    _FalseDead[player.Index] = true;
                }

            }
            else
            {
                _FalseDead[player.Index] = false;
                FalseDead[player.Index] = false;
            }
            if (FalseDead[player.Index])
            {
                if (Dead[player.Index] == false)
                {
                    DeadTime[player.Index] = Hud.Game.CurrentGameTick;
                    if (inGR) DeadTimes[player.Index]++;
                    Dead[player.Index] = true;
                }
                CurrentTime[player.Index] = GetDeadCountdown(DeadTimes[player.Index], secondsLeft, inGR) - (Hud.Game.CurrentGameTick - DeadTime[player.Index]) / 60.0d;
               
                if (CurrentTime[player.Index] <= 0.5)
                {
                    y = portrait.Top + portrait.Height / 4;
                    layout = TextFontDeath.GetTextLayout(DeathSymbol);
                    DeadBorderBrush.DrawRectangle(portrait.Left, portrait.Top, portrait.Width, portrait.Height);
                    TextFontDeath.DrawText(layout, x, y);
                    CurrentTime[player.Index] = 0;
                }
                else
                {
                    y = portrait.Top + portrait.Height / 3.5f;
                    layout = TextFontDeathTime.GetTextLayout("死亡等待：" + CurrentTime[player.Index].ToString("f0") + "秒");
                    DeadTimeBorderBrush.DrawRectangle(portrait.Left, portrait.Top, portrait.Width, portrait.Height);
                    TextFontDeathTime.DrawText(layout, x, y);
                }
            }
            else
            {
                if (Dead[player.Index])
                {
                    GhostTime[player.Index] = Hud.Game.CurrentGameTick + 3 * 60;
                    Dead[player.Index] = false;
                }
                CurrentGhostTime[player.Index] = (GhostTime[player.Index] - Hud.Game.CurrentGameTick) / 60.0d;
               
                if (CurrentGhostTime[player.Index] > 0)
                {
                    y = portrait.Top + portrait.Height / 3.5f;
                    layout = TextFontGhostTime.GetTextLayout("灵魂状态：" + CurrentGhostTime[player.Index].ToString("f0") + "秒");
                    if (CurrentGhostTime[player.Index] < 1) layout = TextFontGhostTime.GetTextLayout("灵魂状态：" + CurrentGhostTime[player.Index].ToString("f1") + "秒");
                    TextFontGhostTime.DrawText(layout, x, y);
                    GhostBorderBrush.DrawRectangle(portrait.Left, portrait.Top, portrait.Width, portrait.Height);
                }
                else
                {
                    CurrentGhostTime[player.Index] = 0;
                }
            }
        }
       
        private double GetDeadCountdown(int DeadTimes,double secondsLeft ,bool inGR)
        {
            double Times = 0;
            if(!inGR) return 0 + 3.5 - delay;
            if (DeadTimes == 1) Times = 0 + 3.5 - delay;
            if (DeadTimes == 2) Times = 5 + 3.5 - delay;
            if (DeadTimes == 3) Times = 10 + 3.5 - delay;
            if (DeadTimes == 4) Times = 15 + 3.5 - delay;
            if (DeadTimes == 5) Times = 20 + 3.5 - delay;
            if (DeadTimes == 6) Times = 25 + 3.5 - delay;
            if (DeadTimes >= 7) Times = 30 + 3.5 - delay;
            if(secondsLeft<=0)
            {
                Times = 0 + 3.5 - delay;
            }
            return Times;
        }
    }
}