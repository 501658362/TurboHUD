using System;
using System.Linq;
using System.Collections.Generic;
using SharpDX.DirectInput;
using System.Globalization;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.gjuz
{
    public class PlayerInTown : BasePlugin, IInGameTopPainter, IAfterCollectHandler, INewAreaHandler, IKeyEventHandler
    {
        private Dictionary<int, IWatch> TownWatch { get; set; }
        private int PlayerCount { get; set; }
        private bool Show { get; set; }

        public bool AlwaysStopTime { get; set; }
        public bool OnlyShowOnBountyTable { get; set; }
        public IKeyEvent ToggleKeyEvent { get; set; }
        public string isInTown { get; set; }
        public string notInTown { get; set; }

        public IFont PortraitInfoFont { get; set; }
        public float OffsetXmultiplier { get; set; }
        public float OffsetYmultiplier { get; set; }

        public PlayerInTown()
        {
            Enabled = true;

            Show = false;
            AlwaysStopTime = false;
            OnlyShowOnBountyTable = false;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            ToggleKeyEvent = Hud.Input.CreateKeyEvent(true, Key.F6, false, false, false);

            TownWatch = new Dictionary<int, IWatch>();
            for (int i = 0; i < 4; i++)
                TownWatch.Add(i,Hud.Time.CreateWatch());

            PortraitInfoFont = Hud.Render.CreateFont("tahoma", 7f, 255, 180, 147, 109, false, false, true);
            OffsetXmultiplier = 1.05f;      //relative to portraitRect.Height
            OffsetYmultiplier = 0.95f;      //relative to portraitRect.Width

            isInTown = "in Town";
            notInTown = "TownTime";
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;
            if (!Show) return;

            foreach (IPlayer player in Hud.Game.Players)
                DrawPlayerInfo(player);
        }

        private void DrawPlayerInfo(IPlayer player)
        {
            var portraitRect = player.PortraitUiElement.Rectangle;
            var OffsetX = portraitRect.Width * OffsetXmultiplier;
            var OffsetY = portraitRect.Height * OffsetYmultiplier;
            var YPos = portraitRect.Y + OffsetY;
            var XPos = portraitRect.X + OffsetX;

            string text = String.Format("{0}: {1:mm\\:ss}",
                            (player.IsInTown ? isInTown : notInTown),
                            TimeSpan.FromMilliseconds( TownWatch[player.Index].ElapsedMilliseconds ));

            var Layout = PortraitInfoFont.GetTextLayout(text);
            PortraitInfoFont.DrawText(Layout, XPos, YPos);
        }

        public void AfterCollect()
        {
            //set watches
            TownWatches();

            //resets not used stopwatches
            if (PlayerCount != Hud.Game.Players.Count())
            {
                List<int> l = new List<int> {0,1,2,3};
                foreach (var player in Hud.Game.Players)
                    l.Remove(player.Index);

                foreach (int i in l)
                    ResetTownWatch(i);

                PlayerCount = Hud.Game.Players.Count();
            }
        }

        private void TownWatches()
        {
            if (!AlwaysStopTime && !Show) return;   //if AlwaysStopTime = false: only stops time if bounty table was shown once (F6 key)

            foreach (var player in Hud.Game.Players)
            {
                IWatch playerWatch = TownWatch[player.Index];
                if (player.IsInTown && !playerWatch.IsRunning)
                {
                    playerWatch.Start();
                }
                else if (!player.IsInTown && playerWatch.IsRunning)
                {
                    playerWatch.Stop();
                }
            }
        }

        public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (newGame)
            {
                Show = false;

                PlayerCount = Hud.Game.Players.Count();

                //reset
                ResetTownWatch();
            }
        }

        private void ResetTownWatch()
        {
            // reset states if needed
            foreach (IWatch watch in TownWatch.Values)
            {
                if (watch.IsRunning || watch.ElapsedMilliseconds > 0)
                {
                    watch.Reset();
                }
            }
        }

        private void ResetTownWatch(int playerIndex)
        {
            // reset states if needed
            IWatch watch = TownWatch[playerIndex];
            if (watch.IsRunning || watch.ElapsedMilliseconds > 0)
            {
                watch.Reset();
            }
        }

        public void OnKeyEvent(IKeyEvent keyEvent)
        {
            if (keyEvent.IsPressed && ToggleKeyEvent.Matches(keyEvent))
            {
                if (!Show)          //toggle on if pressed F6
                    Show = !Show;   //no off switch !!
                else if(Show && OnlyShowOnBountyTable)
                    Show = !Show;
            }
        }
    }
}