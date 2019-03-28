using System.Linq;
using Turbo.Plugins.Default;
 
namespace Turbo.Plugins.glq
{
    public class GLQ_TalRashaPlugin : BasePlugin, IInGameTopPainter
    {
        public bool ShowRashaElements { get; set; }
        public IBrush FireBackgroundBrush { get; set; }
        public IBrush ArcaneBackgroundBrush { get; set; }
		public IBrush LightningBackgroundBrush { get; set; }
		public IBrush ColdBackgroundBrush { get; set; }
        public IBrush FireBrush { get; set; }
        public IBrush ArcaneBrush { get; set; }
        public IBrush LightningBrush { get; set; }
        public IBrush ColdBrush { get; set; }
        public IBrush GreyBrush { get; set; }
 
        private float hudWidth { get { return Hud.Window.Size.Width; } }
        private float hudHeight { get { return Hud.Window.Size.Height; } }
        private float _lRashaSize, _lRashaYpos, _lRashaSizeMod;

 
        public GLQ_TalRashaPlugin()
        {
            Enabled = true;
            ShowRashaElements = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

			
            FireBackgroundBrush = Hud.Render.CreateBrush(255, 255, 0, 0, 0);
            ArcaneBackgroundBrush = Hud.Render.CreateBrush(255, 180, 80, 180, 0);
			LightningBackgroundBrush = Hud.Render.CreateBrush(255, 0, 65, 145, 0);
			ColdBackgroundBrush = Hud.Render.CreateBrush(255, 80, 130, 180, 0);
            GreyBrush = Hud.Render.CreateBrush(10, 50, 50, 50, 0);
            FireBrush = Hud.Render.CreateBrush(30, 255, 0, 0, 0);
            ArcaneBrush = Hud.Render.CreateBrush(30, 180, 80, 180, 0);
            LightningBrush = Hud.Render.CreateBrush(30, 0, 65, 145, 0);
            ColdBrush = Hud.Render.CreateBrush(30, 80, 130, 180, 0);

            // Private vars
            _lRashaSize = 24f;
            _lRashaYpos = 0.585f;
            _lRashaSizeMod = 0.9f;
        }
 
        public void PaintTopInGame(ClipState clipState)
        {
            if ((Hud.Game.MapMode == MapMode.WaypointMap) || (Hud.Game.MapMode == MapMode.ActMap) || (Hud.Game.MapMode == MapMode.Map)) return;
            if (Hud.Game.IsInGame && Hud.Game.Me.HeroClassDefinition.HeroClass == HeroClass.Wizard && ShowRashaElements)
            {
                var me = Hud.Game.Me;
                if ((me.Powers.BuffIsActive(429855, 0)))
                    TalRashaElements(me);
 

            }
        }

 
        private void TalRashaElements(IPlayer me)
        {
            GreyBrush.DrawRectangle((hudWidth * 0.5f - _lRashaSize * .5f) - _lRashaSize * 1.6f, hudHeight * _lRashaYpos - _lRashaSize * 0.1f, _lRashaSize * 4.1f, _lRashaSize * 1.1f);
 
            if (me.Powers.BuffIsActive(429855, 1)) ArcaneBrush.DrawRectangle((hudWidth * 0.5f - _lRashaSize * .5f) - _lRashaSize * 1.5f, hudHeight * _lRashaYpos, _lRashaSize * _lRashaSizeMod, _lRashaSize * _lRashaSizeMod);
            else DrawArcaneBackgroundBrush(-_lRashaSize * 1.5f);
 
            if (me.Powers.BuffIsActive(429855, 2)) ColdBrush.DrawRectangle((hudWidth * 0.5f - _lRashaSize * .5f) - _lRashaSize / 2, hudHeight * _lRashaYpos, _lRashaSize * _lRashaSizeMod, _lRashaSize * _lRashaSizeMod);
            else DrawColdBackgroundBrush(-_lRashaSize / 2);
 
            if (me.Powers.BuffIsActive(429855, 3)) FireBrush.DrawRectangle((hudWidth * 0.5f - _lRashaSize * .5f) + _lRashaSize / 2, hudHeight * _lRashaYpos, _lRashaSize * _lRashaSizeMod, _lRashaSize * _lRashaSizeMod);
            else DrawFireBackgroundBrush(_lRashaSize / 2);
 
            if (me.Powers.BuffIsActive(429855, 4)) LightningBrush.DrawRectangle((hudWidth * 0.5f - _lRashaSize * .5f) + _lRashaSize * 1.5f, hudHeight * _lRashaYpos, _lRashaSize * _lRashaSizeMod, _lRashaSize * _lRashaSizeMod);
            else DrawLightningBackgroundBrush(_lRashaSize * 1.5f);
        }
 
        private void DrawArcaneBackgroundBrush(float xPos)
        {
            ArcaneBackgroundBrush.DrawRectangle((hudWidth * 0.5f - _lRashaSize * .5f) + xPos, hudHeight * _lRashaYpos, _lRashaSize * _lRashaSizeMod, _lRashaSize * _lRashaSizeMod);
        }
        private void DrawFireBackgroundBrush(float xPos)
        {
            FireBackgroundBrush.DrawRectangle((hudWidth * 0.5f - _lRashaSize * .5f) + xPos, hudHeight * _lRashaYpos, _lRashaSize * _lRashaSizeMod, _lRashaSize * _lRashaSizeMod);
        }
        private void DrawLightningBackgroundBrush(float xPos)
        {
            LightningBackgroundBrush.DrawRectangle((hudWidth * 0.5f - _lRashaSize * .5f) + xPos, hudHeight * _lRashaYpos, _lRashaSize * _lRashaSizeMod, _lRashaSize * _lRashaSizeMod);
        }
        private void DrawColdBackgroundBrush(float xPos)
        {
            ColdBackgroundBrush.DrawRectangle((hudWidth * 0.5f - _lRashaSize * .5f) + xPos, hudHeight * _lRashaYpos, _lRashaSize * _lRashaSizeMod, _lRashaSize * _lRashaSizeMod);
        }
 
    }
}