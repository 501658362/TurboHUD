//by Turbro
using System.Linq;
using Turbo.Plugins.Default;
 
namespace Turbo.Plugins.glq
{
    public class GLQ_InventoryMainStatPlugin : BasePlugin, IInGameTopPainter
    {
        public bool OverlayMainStatOnItems { get; set; }
        public IFont MainStat_strFont { get; set; }
        public IFont MainStat_intFont { get; set; }
        public IFont MainStat_dexFont { get; set; }

        private int stashPage, stashTab, stashTabAbs;
        private float rv;
 
        public GLQ_InventoryMainStatPlugin()
        {
            Enabled = true;
            OverlayMainStatOnItems = true;
        }
 
        public override void Load(IController hud)
        {
            base.Load(hud);

            MainStat_strFont = Hud.Render.CreateFont("tahoma", 6.5f, 255, 255, 0, 0, false, false, false);
            MainStat_strFont.SetShadowBrush(128, 0, 0, 0, true);
            MainStat_intFont = Hud.Render.CreateFont("tahoma", 6.5f, 255, 255, 255, 0, false, false, false);
            MainStat_intFont.SetShadowBrush(128, 0, 0, 0, true);
            MainStat_dexFont = Hud.Render.CreateFont("tahoma", 6.5f, 255, 0, 255, 0, false, false, false);
            MainStat_dexFont.SetShadowBrush(128, 0, 0, 0, true);
        }
 
        public void PaintTopInGame(ClipState clipState)
        {
            if(!OverlayMainStatOnItems) return;
            if (clipState != ClipState.Inventory) return;
           
            stashTab = Hud.Inventory.SelectedStashTabIndex;
            stashPage = Hud.Inventory.SelectedStashPageIndex;
            stashTabAbs = stashTab + stashPage * Hud.Inventory.MaxStashTabCountPerPage;
 
            rv = 32.0f / 600.0f * Hud.Window.Size.Height;
 
            var items = Hud.Game.Items.Where(x => x.Location != ItemLocation.Merchant && x.Location != ItemLocation.Floor);
            foreach (var item in items)
            {
                if (item.Location == ItemLocation.Stash)
                {
                    var tabIndex = item.InventoryY / 10;
                    if (tabIndex != stashTabAbs) continue;
                }
 
                if ((item.InventoryX < 0) || (item.InventoryY < 0)) continue;
 
                var rect = Hud.Inventory.GetItemRect(item);
                if (rect == System.Drawing.RectangleF.Empty) continue;
 
                DrawItemMainStat(item, rect);
            }
       }
 
        private static string GetMainStatString(IItem item)
        {
            if (item != null && item.Perfections != null)
            {
                foreach (IItemPerfection perfection in item.Perfections)
                {
                    if (perfection.Attribute.Code == "Dexterity_Item") return "敏";
                    if (perfection.Attribute.Code == "Intelligence_Item") return "智";
                    if (perfection.Attribute.Code == "Strength_Item") return "力";
                }
            }
            return null;
        }
 
        private void DrawItemMainStat(IItem item, System.Drawing.RectangleF rect)
        {
            var text = GetMainStatString(item);
            if(text == "力")
            {
                var font = MainStat_strFont;
                var textLayout = font.GetTextLayout(text);
                font.DrawText(textLayout, rect.Left + rv / 15.0f, rect.Top + rv / 35.0f);
            }
            if (text == "智")
            {
                var font = MainStat_intFont;
                var textLayout = font.GetTextLayout(text);
                font.DrawText(textLayout, rect.Left + rv / 15.0f, rect.Top + rv / 35.0f);
            }
            if (text == "敏")
            {
                var font = MainStat_dexFont;
                var textLayout = font.GetTextLayout(text);
                font.DrawText(textLayout, rect.Left + rv / 15.0f, rect.Top + rv / 35.0f);
            }
        }
    }
}