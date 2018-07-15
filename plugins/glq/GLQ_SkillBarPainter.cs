using SharpDX;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{

    public class GLQ_SkillBarPainter : ITransparentCollection
    {
        public bool Enabled { get; set; }
        public IController Hud { get; set; }

        public IFont CooldownFont { get; set; }

        public float TextureOpacity { get; set; }

        private readonly IWatch _lastTownEliteSimulation;

        public IBrush TimeLeftClockBrush { get; set; }

        public GLQ_SkillBarPainter(IController hud, bool setDefaultStyle)
        {
            Enabled = true;
            Hud = hud;

            _lastTownEliteSimulation = Hud.Time.CreateWatch();

            if (setDefaultStyle)
            {
                CooldownFont = Hud.Render.CreateFont("arial", 14, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true);
                TimeLeftClockBrush = Hud.Render.CreateBrush(220, 0, 0, 0, 0);


            }
        }

        public void Paint(IPlayerSkill skill, RectangleF rect)
        {
            if (skill == null) return;

            if (TextureOpacity > 0)
            {
                var texture = Hud.Texture.GetTexture(skill.SnoPower.NormalIconTextureId);
                if (texture != null)
                {
                    texture.Draw(rect.X, rect.Y, rect.Width, rect.Height, TextureOpacity);
                }
            }

            if (skill.IsOnCooldown && (skill.CooldownFinishTick > Hud.Game.CurrentGameTick))
            {
                var remaining = (skill.CooldownFinishTick - Hud.Game.CurrentGameTick) / 60.0d;
                var text = remaining > 1.0f ? remaining.ToString("F0", CultureInfo.InvariantCulture) : remaining.ToString("F1", CultureInfo.InvariantCulture);

                var textLayout = CooldownFont.GetTextLayout(text);
                DrawTimeLeftClock(rect, (Hud.Game.CurrentGameTick - skill.CooldownStartTick) / 60.0d , (skill.CooldownFinishTick - Hud.Game.CurrentGameTick) / 60.0d);
                CooldownFont.DrawText(textLayout, rect.X + (rect.Width - (float)Math.Ceiling(textLayout.Metrics.Width)) / 2.0f, rect.Y + (rect.Height - textLayout.Metrics.Height) / 2);
            }

            var rune = skill.Rune;
            if (rune == byte.MaxValue) rune = 0; else rune += 1;
        }

        private void DrawTimeLeftClock(RectangleF rect, double elapsed, double timeLeft)
        {
            if ((timeLeft > 0) && (elapsed >= 0) && (TimeLeftClockBrush != null))
            {
                var endAngle = Convert.ToInt32((360.0d / (timeLeft + elapsed)) * elapsed);
                var startAngle = 0;
                TimeLeftClockBrush.Opacity = 1 - (float)(0.3f / (timeLeft + elapsed) * elapsed);
                var rad = rect.Width * 0.45f;
                using (var pg = Hud.Render.CreateGeometry())
                {
                    using (var gs = pg.Open())
                    {
                        gs.BeginFigure(rect.Center, FigureBegin.Filled);
                        for (int angle = startAngle; angle <= endAngle; angle++)
                        {
                            var mx = rad * (float)Math.Cos((angle - 90) * Math.PI / 180.0f);
                            var my = rad * (float)Math.Sin((angle - 90) * Math.PI / 180.0f);
                            var vec = new Vector2(rect.Center.X + mx, rect.Center.Y + my);
                            gs.AddLine(vec);
                        }
                        gs.EndFigure(FigureEnd.Closed);
                        gs.Close();
                    }
                    TimeLeftClockBrush.DrawGeometry(pg);
                }
            }
        }

        public IEnumerable<ITransparent> GetTransparents()
        {
            yield return CooldownFont;
        }

    }

}