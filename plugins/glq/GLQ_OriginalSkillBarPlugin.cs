using SharpDX;
using System;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{

    public class GLQ_OriginalSkillBarPlugin : BasePlugin, IInGameTopPainter
    {

        public GLQ_SkillPainter SkillPainter { get; set; }

        public GLQ_OriginalSkillBarPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            SkillPainter = new GLQ_SkillPainter(Hud, true)
            {
                TextureOpacity = 0.0f,
                EnableSkillDpsBar = true,
                EnableDetailedDpsHint = true,
            };
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;

            var uiSkill1 = Hud.Render.GetPlayerSkillUiElement(ActionKey.Skill1);

            foreach (var skill in Hud.Game.Me.Powers.UsedSkills)
            {
                var ui = Hud.Render.GetPlayerSkillUiElement(skill.Key);

                var rect = new RectangleF((float)Math.Round(ui.Rectangle.X) + 0.5f, (float)Math.Round(uiSkill1.Rectangle.Y) + 0.5f, (float)Math.Round(ui.Rectangle.Width), (float)Math.Round(uiSkill1.Rectangle.Height));

                SkillPainter.Paint(skill, rect);
            }
        }

    }

}