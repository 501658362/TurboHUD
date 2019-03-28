using System;
using System.Collections.Generic;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_PlayerSkillCirclesPlugin : BasePlugin, IInGameWorldPainter, ICustomizer
    {
        public struct RadiusAndBrush
        {
            public float Radius;
            public bool ModifyByPickup;
            public float XRadius;
            public IBrush Brush;
        }
        public class customDictionary : Dictionary<Tuple<uint, int>, RadiusAndBrush>
        {
            public void Add(IBrush inpBrush, float inpRadius, bool inpModifyByPickup, float RadiusX, uint inpSno, int inpRune)
            {
                base.Add(
                    Tuple.Create(inpSno, inpRune),
                    new RadiusAndBrush()
                    {
                        Radius = inpRadius,
                        ModifyByPickup = inpModifyByPickup,
                        XRadius = RadiusX,
                        Brush = inpBrush,
                    }
                );
            }
            public void Add(IBrush inpBrush, float inpRadius, bool inpModifyByPickup, float RadiusX, uint inpSno)
            {
                base.Add(
                    Tuple.Create(inpSno, -1),
                    new RadiusAndBrush()
                    {
                        Radius = inpRadius,
                        ModifyByPickup = inpModifyByPickup,
                        XRadius = RadiusX,
                        Brush = inpBrush,
                    }
                );
            }
            public void Add(IBrush inpBrush, float inpRadius, bool inpModifyByPickup, uint inpSno, int inpRune)
            {
                base.Add(
                    Tuple.Create(inpSno, inpRune),
                    new RadiusAndBrush()
                    {
                        Radius = inpRadius,
                        ModifyByPickup = inpModifyByPickup,
                        XRadius = 1,
                        Brush = inpBrush,
                    }
                );
            }
            public void Add(IBrush inpBrush, float inpRadius, bool inpModifyByPickup, uint inpSno)
            {
                base.Add(
                    Tuple.Create(inpSno, -1),
                    new RadiusAndBrush()
                    {
                        Radius = inpRadius,
                        ModifyByPickup = inpModifyByPickup,
                        XRadius = 1,
                        Brush = inpBrush,
                    }
                );
            }
            public void Add(IBrush inpBrush, float inpRadius, uint inpSno, int inpRune)
            {
                base.Add(
                    Tuple.Create(inpSno, inpRune),
                    new RadiusAndBrush()
                    {
                        Radius = inpRadius,
                        ModifyByPickup = false,
                        XRadius = 1,
                        Brush = inpBrush,
                    }
                );
            }
            public void Add(IBrush inpBrush, float inpRadius, uint inpSno)
            {
                // add rune as any-rune if it's not specified
                base.Add(
                    Tuple.Create(inpSno, -1),
                    new RadiusAndBrush()
                    {
                        Radius = inpRadius,
                        XRadius = 1,
                        ModifyByPickup = false,
                        Brush = inpBrush,
                    }
                );
 
            }
 
        }
 
        public customDictionary SkillRadius { get; set; }
 
        public struct ScustomSnoRune
        {
            public uint Sno;
            public int Rune;
        }
 
        public bool OnlyOutOfTown { get; set; }
        public WorldDecoratorCollection CommonDecorator { get; set; }
        public IBrush CommonBrush { get; set; }
 
        public GLQ_PlayerSkillCirclesPlugin()
        {
            Enabled = true;
            OnlyOutOfTown = true; // set to false if you want the circles to show when in town
        }
 
        public override void Load(IController hud)
        {
            base.Load(hud);
 
            SkillRadius = new customDictionary();
        }
 
        public void Customize()
        {
            // Helper vars
            //var Solid = SharpDX.Direct2D1.DashStyle.Solid; // Solid is default if dashstyle isn't included in the CreateBrush parameter
            //var Dash = SharpDX.Direct2D1.DashStyle.Dash; // Regular dash
            //var Dashdot = SharpDX.Direct2D1.DashStyle.DashDot; // Sparser dash
            //SkillRadius.Add(Hud.Render.CreateBrush(128, 255, 000, 255, 1, Solid), 15f, 290545); // Crusader - Provoke - Any
            // SkillRadius.Add(Hud.Render.CreateBrush(128, 255, 000, 000, 2, Dash), 12f, 291804, 2); // Crusader - Iron Skin - Explosive Skin
            // SkillRadius.Add(Hud.Render.CreateBrush(128, 255, 255, 255, 2, Solid), 12f, 291804, 255); // Crusader - Iron Skin - No-Rune

            OnlyOutOfTown = false;
        }
 
        public void PaintWorld(WorldLayer layer)
        {
            if ((Hud.Game.MapMode == MapMode.WaypointMap) || (Hud.Game.MapMode == MapMode.ActMap) || (Hud.Game.MapMode == MapMode.Map)) return;
            Tuple<uint, int> tmpSkillSnoRune, tmpSkillSnoAllRune;
 
            // Aggregrate active skills and passive skills together
            List<ScustomSnoRune> Player_AllSkillSlots_List = new List<ScustomSnoRune>();
            foreach (var ctrActiveSkills in Hud.Game.Me.Powers.UsedSkills) // iterate through the active skills slots
            {
                if (ctrActiveSkills != null)
                {
                    Player_AllSkillSlots_List.Add(new ScustomSnoRune()
                    {
                        Sno = ctrActiveSkills.SnoPower.Sno,
                        Rune = Convert.ToInt32(ctrActiveSkills.Rune),
                    }
                    );
                }
            }
            foreach (var ctrPassiveSkills in Hud.Game.Me.Powers.UsedPassives) // iterate through the passive skills slots
            {
                if (ctrPassiveSkills != null)
                {
                    Player_AllSkillSlots_List.Add(new ScustomSnoRune()
                    {
                        Sno = ctrPassiveSkills.Sno,
                        Rune = -1,
                    }
                    );
                }
            }
 
            foreach (var ctrSkills in Player_AllSkillSlots_List)
            {
                if ((!OnlyOutOfTown || !Hud.Game.Me.IsInTown)) // check if in town, check if OnlyOutOfTown
                {
                    tmpSkillSnoRune = Tuple.Create(ctrSkills.Sno, ctrSkills.Rune); // to check if this skill is in the dictionary list of skillradius
                    if (SkillRadius.ContainsKey(tmpSkillSnoRune))
                    {
                        var foundSkill = SkillRadius[tmpSkillSnoRune];
                        foundSkill.Brush.DrawWorldEllipse(foundSkill.Radius + (foundSkill.ModifyByPickup ? (Hud.Game.Me.Stats.PickupRange - 5) * foundSkill.XRadius : 0), -1, Hud.Game.Me.FloorCoordinate);

                    }
                    else
                    {
                        tmpSkillSnoAllRune = Tuple.Create(ctrSkills.Sno, -1); // to check if this skill is in the dictionary list of skillradius with the any-rune option
                        if (SkillRadius.ContainsKey(tmpSkillSnoAllRune))
                        {
                            var foundSkill = SkillRadius[tmpSkillSnoAllRune];
                            foundSkill.Brush.DrawWorldEllipse(foundSkill.Radius + (foundSkill.ModifyByPickup ? (Hud.Game.Me.Stats.PickupRange - 5) * foundSkill.XRadius : 0), -1, Hud.Game.Me.FloorCoordinate);
                        }
                    }
                }
            }
        }
    }
}