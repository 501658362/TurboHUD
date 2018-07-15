// https://github.com/User5981/Resu
// Group GR Level Adviser Plugin for TurboHUD version 08/07/2018 06:56
using Turbo.Plugins.Default;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Turbo.Plugins.Resu
{

    public class GroupGRLevelAdviserPlugin : BasePlugin, IInGameWorldPainter
    {
        public TopLabelDecorator GRLevelDecorator { get; set; }
        public string GRLevelText{ get; set; }
        
        public GroupGRLevelAdviserPlugin()
        {
            Enabled = true;
        }

        
        public override void Load(IController hud)
        {
         base.Load(hud);
         GRLevelText = "";
         
         GRLevelDecorator = new TopLabelDecorator(Hud)
          {
           TextFont = Hud.Render.CreateFont("arial", 7, 220, 198, 174, 49, true, false, 255, 0, 0, 0, true),
           TextFunc = () => "",
           HintFunc = () => "GR level advised for this group : " + GRLevelText
          };
        }
        
        
         public void PaintWorld(WorldLayer layer)
         {
          if (Hud.Game.NumberOfPlayersInGame > 1 && Hud.Render.GetUiElement("Root.NormalLayer.rift_dialog_mainPage").Visible)
           {
            int maxGRlevel = 0;
            foreach (var player in Hud.Game.Players)
                  {
                   maxGRlevel +=  player.HighestSoloRiftLevel;
                  }
           
            int GRAverage = Convert.ToInt32(Convert.ToDouble(maxGRlevel / Hud.Game.NumberOfPlayersInGame + (((1 + Math.Sqrt(5)) / 2) * (Hud.Game.NumberOfPlayersInGame - 1))));
            GRLevelText = GRAverage.ToString();
            var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.rift_dialog_mainPage").Rectangle;
            GRLevelDecorator.Paint(uiRect.Left, uiRect.Top, uiRect.Width, uiRect.Height, HorizontalAlign.Right);
           }
        }
    }

}