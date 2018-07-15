
namespace Turbo.Plugins.cyj
{
    using System.Globalization;
    using System.Linq;
    using Turbo.Plugins.Default;
    using Turbo.Plugins.glq;

    public class Cyj_Plugin : BasePlugin, INewAreaHandler, IInGameTopPainter
    {
        public TopTable Table { get; set; }

        private int lastPlayerCount = -1;
        private int hoveredPlayerIndex = -1;

        public Cyj_Plugin()
        {
            Enabled = true;
            Order = int.MaxValue;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            Table = new TopTable(Hud)
            {
                RatioPositionX = 0.9f,
                RatioPositionY = 0.04f,
                HorizontalCenter = true,
                VerticalCenter = false,
                PositionFromRight = false,
                PositionFromBottom = false,
                ShowHeaderLeft = false,
                ShowHeaderTop = true,
                ShowHeaderRight = false,
                ShowHeaderBottom = false,
                DefaultCellDecorator = new TopTableCellDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 70, 56, 42, 1.5f),
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, false, false, false),
                },
                DefaultHighlightDecorator = new TopTableCellDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 242, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 70, 56, 42, 1.5f),
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, false, false, false),
                },
                DefaultHeaderDecorator = new TopTableCellDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 70, 56, 42, 1.5f),
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, false, false, true),
                }
            };
            DefineColumns();
        }

        public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (!newGame) return;

            lastPlayerCount = -1;
        }

        private void DefineTable()
        {
            Table.Reset(true); // keep columns
              /* for 循环执行 */
            for (int a = 0; a < 27; a = a + 1)
            {
              Table.AddLine(
                                            new TopTableHeader(Hud, (pos, curPos) => "")
                                            {
                                                RatioWidth = 120 / 1080f,
                                                RatioHeight = 28 / 1080f,
                                                HighlightFunc = (pos, curPos) => hoveredPlayerIndex == pos,
                                                HighlightDecorator = new TopTableCellDecorator(Hud)
                                                {
                                                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 255, 128, 0),
                                                    BorderBrush = Hud.Render.CreateBrush(255, 70, 56, 42, 1.5f),
                                                    TextFont = Hud.Render.CreateFont("tahoma", 7, 0, 255,  0, 0, true, false, false),
                                                },
                                                CellHighlightDecorator = new TopTableCellDecorator(Hud)
                                                {
                                                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 255, 0),
                                                    BorderBrush = Hud.Render.CreateBrush(255, 70, 56, 42, 1.5f),
                                                    TextFont = Hud.Render.CreateFont("tahoma", 7, 0, 255, 0, 255, true, false, true),
                                                },
                                            },
                                            new TopTableCell(Hud, (l, c, ls, cs) => GetCellText(l, c))
                                            );
            }



        }

        private string GetCellText(int line, int column)
        {

            switch (line)
            {
                case 0:
                    return "0 ::  分解普通材料";
                case 1:
                    return "1 ::  停止循环";
                case 2:
                    return "2 ::  升级宝石";
                case 3:
                    return "3 ::  传送到我这";
                case 4:
                    return "4  / F1::  连点鼠标左键 捡东西";
                case 5:
                    return "5 ::  批量升级双格稀有装备";
                case 6:
                    return "6 ::  悬赏开关键  开启后 右键停止技能释放3s";
                case 7:
                    return "7 / F2 ::  循环点击25次右键 购物物品 使用血岩";
                case 8:
                    return "8 ::  批量敲碎装备";
                case 9:
                    return "9 ::  批量扔装备";
                case 10:
                    return "Div::  除号 未使用";
                case 11:
                    return "Mult *:: 重启导航插件";
                case 12:
                    return "Add +::  批量敲碎装备";
                case 13:
                    return "Sub -::  批量扔装备";
                case 14:
                    return "鼠标右键::   战马技能";
                case 15:
                    return "鼠标测键::   天谴技能宏开关";
                case 16:
                    return string.Empty;
                case 17:
                    return string.Empty;
                case 18:
                    return string.Empty;
                case 19:
                    return string.Empty;
                case 20:
                    return "退出插件：ctrl+end";
                case 21:
                    return "隐藏界面：F4";
                case 22:
                    return "reload_pickit: F3";
                case 23:
                    return "capture: alt+C";
                case 24:
                    return "追踪统计: F5";
                case 25:
                    return "debug_overlay: F11";
                case 26:
                    return "保持Debug数据: ctrl+alt+D";
                default:
                    return string.Empty;

            }
        }

        private void DefineColumns()
        {
            Table.DefineColumns(
                new TopTableHeader(Hud, (pos, curPos) => "宏脚本说明")
                {
                    RatioHeight = 28 / 1080f,
                    RatioWidth = 400 / 1080f,
                }
            );
        }

        public void PaintTopInGame(ClipState clipState)
        {
//            if (clipState != ClipState.BeforeClip) return;
//            if (Hud.Inventory.StashMainUiElement.Visible) return;
//            var myPortrait = Hud.Game.Me.PortraitUiElement.Rectangle;
//            if (Hud.Window.CursorX > myPortrait.Right)
//            {
//                lastPlayerCount = -1;
//                return; // cursor is too much to the right, no need to go further
//            }
//
//            if (lastPlayerCount != Hud.Game.Players.Count())
//            {
//                lastPlayerCount = Hud.Game.Players.Count();
//                DefineTable();
//                return; // no need to lose more time within this frame
//            }
//
//            var displayTable = false;
//            foreach (var player in Hud.Game.Players.OrderBy(p => p.PortraitIndex))
//            {
//                if (player == null) continue;
//                var portrait = player.PortraitUiElement.Rectangle;
//                if (!Hud.Window.CursorInsideRect(portrait.X, portrait.Y, portrait.Width, portrait.Height)) continue;
//
//                hoveredPlayerIndex = (Hud.Game.NumberOfPlayersInGame > 1) ? player.PortraitIndex : -1;
//                displayTable = true;
//            }
             var displayTable = true;
             if (clipState != ClipState.BeforeClip) return;
             var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.BoostWrapper.BoostsDifficultyStackPanel.clock");
            if (!Hud.Window.CursorInsideRect(uiRect.Rectangle.X, uiRect.Rectangle.Y, uiRect.Rectangle.Width, uiRect.Rectangle.Height)) return;

            if (displayTable && Table != null)
                Table.Paint();

             DefineTable();


            if (Table != null)
                Table.Paint();
        }
    }
}