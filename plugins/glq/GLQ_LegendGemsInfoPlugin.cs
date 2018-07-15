using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_LegendGemsInfoPlugin : BasePlugin, IInGameTopPainter
    {

        public IFont InfoFont { get; set; }
        public GLQ_LegendGemsInfoPlugin()
        {
            Enabled = true;
        }
        public override void Load(IController hud)
        {
            base.Load(hud);

            InfoFont = Hud.Render.CreateFont("tahoma", 8, 240, 105, 105, 255, false, false, false);

        }
        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;

            var item = Hud.Inventory.HoveredItem;
            if (item == null) return;
            var InfoText = "";
            var uicMain = Hud.Inventory.GetHoveredItemMainUiElement();
            switch(item.FullNameEnglish)
            {
                case "Iceblink":
                    InfoText = "+0.4%/级";
                    break;
                case "Boyarsky's Chip":
                    InfoText = "+800/级";
                    break;
                case "Mutilation Guard":
                    InfoText = "+0.5%/级";
                    break;
                case "Bane of the Stricken":
                    InfoText = "+0.01%/级";
                    break;
                case "Molten Wildebeest's Gizzard":
                    InfoText = "+1000/级";
                    break;
                case "Esoteric Alteration":
                    InfoText = "+0.5%/级";
                    break;
                case "Taeguk":
                    InfoText = "+0.04%/级";
                    break;
                case "Boon of the Hoarder":
                    InfoText = "+1.5%/级";
                    break;
                case "Simplicity's Strength":
                    InfoText = "+0.5%/级";
                    break;
                case "Zei's Stone of Vengeance":
                    InfoText = "+0.08%/级 +0.4%/级";
                    break;
                case "Moratorium":
                    InfoText = "+0.1%/级";
                    break;
                case "Enforcer":
                    InfoText = "+0.3%/级";
                    break;
                case "Invigorating Gemstone":
                    InfoText = "+0.02%/级";
                    break;
                case "Gogok of Swiftness":
                    InfoText = "+0.01%/级";
                    break;
                case "Mirinae, Teardrop of the Starweaver":
                    InfoText = "+60%/级";
                    break;
                case "Mirinae":
                    InfoText = "+60%/级";
                    break;
                case "Pain Enhancer":
                    InfoText = "+50%/级";
                    break;
                case "Gem of Efficacious Toxin":
                    InfoText = "+50%/级";
                    break;
                case "Wreath of Lightning":
                    InfoText = "+25%/级";
                    break;
                case "Gem of Ease":
                    InfoText = "+50/级";
                    break;
                case "Bane of the Trapped":
                    InfoText = "+0.3%/级";
                    break;
                case "Bane of the Powerful":
                    InfoText = "+1秒/级";
                    break;
                case "Red Soul Shard":
                    InfoText = "+50%/级";
                    break;   
            }
            var InfoFontLayout = InfoFont.GetTextLayout(InfoText);
            InfoFont.DrawText(InfoFontLayout, uicMain.Rectangle.Left + Hud.Window.Size.Height * 0.035f, uicMain.Rectangle.Top + (Hud.Window.Size.Height * 0.302f - InfoFontLayout.Metrics.Height) / 2);
        }
    }
}