using System;
using System.Linq;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_StoryModeTimer : BasePlugin, INewAreaHandler, IInGameTopPainter, IAfterCollectHandler
    {
        public IFont TotalTimerFont { get; set; }
        public IFont A1TimerFont { get; set; }
        public IFont A2TimerFont { get; set; }
        public IFont A3TimerFont { get; set; }
        public IFont A4TimerFont { get; set; }
        public IFont A5TimerFont { get; set; }
        private IWatch TotalTimeWatch;
        private IWatch A1TimeWatch;
        private IWatch A2TimeWatch;
        private IWatch A3TimeWatch;
        private IWatch A4TimeWatch;
        private IWatch A5TimeWatch;
        private bool _IsStoryMode;
        public GLQ_StoryModeTimer()
        {
            Enabled = true;
        }
        public override void Load(IController hud)
        {
            base.Load(hud);
            TotalTimerFont = Hud.Render.CreateFont("tahoma", 7.5f, 230, 0, 255, 255, true, false, true);
            A1TimerFont = Hud.Render.CreateFont("tahoma", 7.5f, 230, 128, 64, 64, true, false, true);
            A2TimerFont = Hud.Render.CreateFont("tahoma", 7.5f, 230, 255, 128, 64, true, false, true);
            A3TimerFont = Hud.Render.CreateFont("tahoma", 7.5f, 230, 128, 128, 192, true, false, true);
            A4TimerFont = Hud.Render.CreateFont("tahoma", 7.5f, 230, 0, 128, 192, true, false, true);
            A5TimerFont = Hud.Render.CreateFont("tahoma", 7.5f, 230, 170, 215, 255, true, false, true);
            TotalTimeWatch = Hud.Time.CreateWatch();
            A1TimeWatch = Hud.Time.CreateWatch();
            A2TimeWatch = Hud.Time.CreateWatch();
            A3TimeWatch = Hud.Time.CreateWatch();
            A4TimeWatch = Hud.Time.CreateWatch();
            A5TimeWatch = Hud.Time.CreateWatch();
        }
        public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (newGame)
            {
                _IsStoryMode = Hud.Game.SpecialArea == SpecialArea.None && !Hud.Game.Bounties.Any();
                TotalTimeWatch.Reset();
                A1TimeWatch.Reset();
                A2TimeWatch.Reset();
                A3TimeWatch.Reset();
                A4TimeWatch.Reset();
                A5TimeWatch.Reset();
            }
        }
        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;
            if(!_IsStoryMode) return;
            var TotaltextLayout = "总耗时 ："+ GLQ_BasePluginCN.ValueToString((long)TotalTimeWatch.ElapsedMilliseconds * 10000, ValueFormat.LongTime); 
            var A1textLayout = "A1耗时：" + GLQ_BasePluginCN.ValueToString((long)A1TimeWatch.ElapsedMilliseconds * 10000, ValueFormat.LongTime);
            var A2textLayout = "A2耗时：" + GLQ_BasePluginCN.ValueToString((long)A2TimeWatch.ElapsedMilliseconds * 10000, ValueFormat.LongTime);
            var A3textLayout = "A3耗时：" + GLQ_BasePluginCN.ValueToString((long)A3TimeWatch.ElapsedMilliseconds * 10000, ValueFormat.LongTime);
            var A4textLayout = "A4耗时：" + GLQ_BasePluginCN.ValueToString((long)A4TimeWatch.ElapsedMilliseconds * 10000, ValueFormat.LongTime);
            var A5textLayout = "A5耗时：" + GLQ_BasePluginCN.ValueToString((long)A5TimeWatch.ElapsedMilliseconds * 10000, ValueFormat.LongTime);
            var x = Hud.Window.Size.Width / 1.18f;
            var y = Hud.Window.Size.Height / 1.15f;
            var h = Hud.Window.Size.Height * 0.018f;
            TotalTimerFont.DrawText(TotaltextLayout, x, y);
            A1TimerFont.DrawText(A1textLayout, x, y + h);
            A2TimerFont.DrawText(A2textLayout, x, y + h * 2);
            A3TimerFont.DrawText(A3textLayout, x, y + h * 3);
            A4TimerFont.DrawText(A4textLayout, x, y + h * 4);
            A5TimerFont.DrawText(A5textLayout, x, y + h * 5);
        }
        public void AfterCollect()
        {
            if (!_IsStoryMode) return;
            if (Hud.Game.IsPaused || (Hud.Game.NumberOfPlayersInGame == 1 && Hud.Game.IsLoading))
            {
                if (TotalTimeWatch.IsRunning)
                {
                    TotalTimeWatch.Stop();
                }
                if (A1TimeWatch.IsRunning)
                {
                    A1TimeWatch.Stop();
                }
                if (A2TimeWatch.IsRunning)
                {
                    A2TimeWatch.Stop();
                }
                if (A3TimeWatch.IsRunning)
                {
                    A3TimeWatch.Stop();
                }
                if (A4TimeWatch.IsRunning)
                {
                    A4TimeWatch.Stop();
                }
                if (A5TimeWatch.IsRunning)
                {
                    A5TimeWatch.Stop();
                }
                return;
            }
            if (!TotalTimeWatch.IsRunning) TotalTimeWatch.Start();
            int CurrentAct = Hud.Game.CurrentAct;
            if (CurrentAct == 1 && !A1TimeWatch.IsRunning)
            {
                A1TimeWatch.Start();
                A2TimeWatch.Stop();
                A3TimeWatch.Stop();
                A4TimeWatch.Stop();
                A5TimeWatch.Stop();
            }
            if (CurrentAct == 2 && !A2TimeWatch.IsRunning)
            {
                A1TimeWatch.Stop();
                A2TimeWatch.Start();
                A3TimeWatch.Stop();
                A4TimeWatch.Stop();
                A5TimeWatch.Stop();
            }
            if (CurrentAct == 3 && !A3TimeWatch.IsRunning)
            {
                A1TimeWatch.Stop();
                A2TimeWatch.Stop();
                A3TimeWatch.Start();
                A4TimeWatch.Stop();
                A5TimeWatch.Stop();
            }
            if (CurrentAct == 4 && !A4TimeWatch.IsRunning)
            {
                A1TimeWatch.Stop();
                A2TimeWatch.Stop();
                A3TimeWatch.Stop();
                A4TimeWatch.Start();
                A5TimeWatch.Stop();
            }
            if (CurrentAct == 5 && !A5TimeWatch.IsRunning)
            {
                A1TimeWatch.Stop();
                A2TimeWatch.Stop();
                A3TimeWatch.Stop();
                A4TimeWatch.Stop();
                A5TimeWatch.Start();
            }
        }
    }
}