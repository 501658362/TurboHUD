//By JackCeparou
using Turbo.Plugins.Default; 

namespace Turbo.Plugins.glq 
{ 
    public class GLQ_MinimapTogglerPlugin : BasePlugin, IKeyEventHandler 
    { 
        public SharpDX.DirectInput.Key Key { get; set; } 

        public GLQ_MinimapTogglerPlugin() 
        { 
            Enabled = true; 

            Key = SharpDX.DirectInput.Key.Capital; 
        } 

        public void OnKeyEvent(IKeyEvent keyEvent) 
        { 
            if (keyEvent.Key == Key && !keyEvent.IsPressed) 
            { 
                Hud.SceneReveal.MinimapClip = !Hud.SceneReveal.MinimapClip; 
            } 
        } 
    } 
}  