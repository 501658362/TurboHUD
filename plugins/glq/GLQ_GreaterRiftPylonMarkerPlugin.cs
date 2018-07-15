using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    //by 我想静静  大秘境进度球
    public class GLQ_GreaterRiftPylonMarkerPlugin : BasePlugin, IInGameTopPainter
    {
        public IBrush ProgressionLineBrush { get; set; }
        public Dictionary<string, double> ProgressionofShrines { get; set; }
        public IFont GreaterRiftFont { get; set; }
        public bool flag_wn { get; set; }
        public bool flag_dj { get; set; }
        public bool flag_jh { get; set; }
        public bool flag_hd { get; set; }
        public bool flag_js { get; set; }

        public GLQ_GreaterRiftPylonMarkerPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            GreaterRiftFont = Hud.Render.CreateFont("tahoma", 6, 255, 200, 100, 200, false, false, 160, 0, 0, 0, true);
            ProgressionLineBrush = Hud.Render.CreateBrush(255, 125, 175, 240, 1f);
            ProgressionofShrines = new Dictionary<string, double>();
            flag_wn = false;
            flag_dj = false;
            flag_jh = false;
            flag_hd = false;
            flag_js = false;
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;
            if ((Hud.Game.SpecialArea != SpecialArea.Rift) && (Hud.Game.SpecialArea != SpecialArea.GreaterRift)) return;

            if (Hud.Game.SpecialArea == SpecialArea.GreaterRift)
            //if (Hud.Game.SpecialArea == SpecialArea.Rift)
            {
                var percent = Hud.Game.RiftPercentage;
                if (percent <= 0)
                {
                    ProgressionofShrines.Clear();
                    flag_wn = false;
                    flag_dj = false;
                    flag_jh = false;
                    flag_hd = false;
                    flag_js = false;
                    return;
                }
                var ui = Hud.Render.GreaterRiftBarUiElement;
                //var ui = Hud.Render.NephalemRiftBarUiElement;
                var uiRect = ui.Rectangle;
                if (ui.Visible)
                {
                    var shrines = Hud.Game.Shrines;
                    //if (shrines.Count() <= 0) return;
                    foreach (var actor in shrines)
                    {
                        switch (actor.SnoActor.Sno)
                        {
                            case 330695:
                                if (flag_wn == false) ProgressionofShrines.Add("威能", percent);
                                flag_wn = true;
                                break;
                            case 330696:
                            case 398654:
                                if (flag_dj == false) ProgressionofShrines.Add("电击", percent);
                                flag_dj = true;
                                break;
                            case 330697:
                                if (flag_jh == false) ProgressionofShrines.Add("减耗", percent);
                                flag_jh = true;
                                break;
                            case 330698:
                                if (flag_hd == false) ProgressionofShrines.Add("护盾", percent);
                                flag_hd = true;
                                break;
                            case 330699:
                                if (flag_js == false) ProgressionofShrines.Add("加速", percent);
                                flag_js = true;
                                break;
                        }
                    }
                    var x = (float)(uiRect.Left + uiRect.Width / 100.0f * percent);
                    var py = Hud.Window.Size.Height / 30;
                    foreach (var pos in ProgressionofShrines)
                    {
                        var xPos = (float)(uiRect.Left + uiRect.Width / 100.0f * pos.Value);
                        ProgressionLineBrush.DrawLine(xPos, uiRect.Bottom, xPos, uiRect.Bottom + py, 0);
                        var text = pos.Value.ToString("F1") + "%" + "\r\n" + pos.Key;
                        GreaterRiftFont.DrawText(text, xPos, uiRect.Bottom + py, true);
                    }
                }
            }
        }
    }
}