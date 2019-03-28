using Turbo.Plugins.Default;
using SharpDX;
using System.Collections.Generic;
namespace Turbo.Plugins.glq
{
    public class GLQ_PlayerSkillBarPlugin : BasePlugin, IInGameWorldPainter
    {
        public GLQ_SkillBarPainter SkillPainter { get; set; }
        public float XOffset { get; set; }
        public float YOffset { get; set; }
        public bool Wizard { get; set; }
        public bool WitchDoctor { get; set; }
        public bool Barbarian { get; set; }
        public bool DemonHunter { get; set; }
        public bool Crusader { get; set; }
        public bool Monk { get; set; }
        public bool Necromancer { get; set; }
        private float currentX { get; set; }
        //public List<uint> WatchedSnos;
        private Dictionary<string, string> List = new Dictionary<string, string>();
        public bool AllSkill { get; set; }
        public GLQ_PlayerSkillBarPlugin()
        {
            Enabled = true;
            Wizard = true;
            WitchDoctor = true;
            Barbarian = true;
            DemonHunter = true;
            Crusader = true;
            Monk = true;
            Necromancer = true;
            AllSkill = true;
        }
        public override void Load(IController hud)
        {
            base.Load(hud);
            SkillPainter = new GLQ_SkillBarPainter(Hud, true)
            {
                TextureOpacity = 1.0f,
                CooldownFont = Hud.Render.CreateFont("arial", 7, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true),
            };
        }
        public void AddNames(params string[] names)
        {
            foreach (var name in names)
            {
                List[name] = name;
            }
        }
        public void RemoveName(string name)
        {
            if (List.ContainsKey(name)) List.Remove(name);
        }
        public void PaintWorld(WorldLayer layer)
        {
            if (layer != WorldLayer.Ground)
            {
                return;
            }
            
            foreach (IPlayer player in Hud.Game.Players)
            {
                currentX = XOffset;
                if (!player.IsMe)
                {
                    if (Wizard && player.HeroClassDefinition.HeroClass == HeroClass.Wizard)
                    {
                        DrawPlayerSkills(player);
                    }
                    if (WitchDoctor && player.HeroClassDefinition.HeroClass == HeroClass.WitchDoctor)
                    {
                        DrawPlayerSkills(player);
                    }
                    if (Barbarian && player.HeroClassDefinition.HeroClass == HeroClass.Barbarian)
                    {
                        DrawPlayerSkills(player);
                    }
                    if (DemonHunter && player.HeroClassDefinition.HeroClass == HeroClass.DemonHunter)
                    {
                        DrawPlayerSkills(player);
                    }
                    if (Crusader && player.HeroClassDefinition.HeroClass == HeroClass.Crusader)
                    {
                        DrawPlayerSkills(player);
                    }
                    if (Monk && player.HeroClassDefinition.HeroClass == HeroClass.Monk)
                    {
                        DrawPlayerSkills(player);
                    }
                    if (Necromancer && player.HeroClassDefinition.HeroClass == HeroClass.Necromancer)
                    {
                        DrawPlayerSkills(player);
                    }
                } 
            }
        }

        private void DrawPlayerSkills(IPlayer player)
        {
            var portraitRect = player.PortraitUiElement.Rectangle;
            var size = portraitRect.Width * 0.3f;
            var passivesX = portraitRect.Right;
            YOffset = portraitRect.Height * 0.095f;
            foreach (var skill in player.Powers.SkillSlots)
            {
                if (skill != null && (List.ContainsKey(skill.SnoPower.Sno.ToString()) || AllSkill))
                {
                    var y = portraitRect.Y + YOffset;

                    var rect = new RectangleF( passivesX + currentX, y, size, size);

                    SkillPainter.Paint(skill, rect);

                    if (Hud.Window.CursorInsideRect(rect.X, rect.Y, rect.Width, rect.Height))
                    {
                        Hud.Render.SetHint(skill.RuneNameLocalized);
                    }
                    currentX += size;
                }
            }
        }
    }
}
