//by JackCeparou
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turbo.Plugins.Default;
using Turbo.Plugins.glq.Decorators.TopTables;

namespace Turbo.Plugins.glq
{
    public class GLQ_DifficultiesInfoPlugin : BasePlugin, IInGameTopPainter
    {
        public TopTable Table { get; set; }

        private string[,] difficultiesData = new string[,]
        {
            {   "-",        "1层",      "4层",      "7层",      "10层",     "13层",     "16层",     "19层",     "22层",     "25层",     "30层",     "35层",     "40层",     "45层",     "50层",     "55层",     "60层",         },
            {   "100%",     "200%",     "320%",     "512%",     "819%",     "1,311%",   "2,097%",   "3,355%",   "5,369%",   "8,590%",   "18,985%",  "41,625%",  "91,260%",  "200,082%", "438,669%", "961,759%", "2,108,607%",   },
            {   "100%",     "130",      "189%",     "273%",     "396%",     "575%",     "833%",     "1,208%",   "1,752%",   "2,540%",   "3,604%",   "5,097%",   "7,208%",   "10,194%",  "14,416%",  "20,387%",  "28,832%",      },
            {   "0%",       "75%",      "100%",     "200%",     "300%",     "400%",     "550%",     "800%",        "1,150%",   "1,600%",   "1,900%",   "2,425%",   "3,100%",   "4,000%",   "5,000%",   "6,400%",   "8,200%",       },
            {   "0%",       "75%",      "100%",     "200%",     "300%",     "400%",     "550%",     "800%",        "1,150%",   "1,600%",   "1,850%",   "2,150%",   "2,500%",   "2,900%",   "3,350%",   "3,900%",   "4,500%",       },
            {   "0%",       "0%",       "0%",       "0%",       "15%",      "32%",      "52%",      "75%",      "101%",     "131%",     "164%",     "205%",     "256%",     "320%",     "400%",     "500%",     "625%",         },
            {   "25%",      "25%",      "25%",      "25%",      "44%",      "65%",      "90%",      "119%",     "151%",     "189%",     "236%",     "295%",     "369%",     "461%",     "577%",     "721%",     "901%",         },
            {   "15%",      "18%",      "21%",      "25%",      "31%",      "37%",      "44%",      "53%",      "64%",      "75%",      "90%",      "115%",  "125%",  "150%",  "190%",  "212%",  "225%",      },
            {   "100%",        "105%",   "110%",  "115%",  "120%",  "125%",  "131%",  "138%",  "144%",  "151%",  "160%",  "170%",  "180%",  "190%",  "200%",        "212%",  "225%",      },
            {   "3个",        "3个",        "3个",        "3个",        "6个",        "6个",        "6个",        "6个",        "6个",        "6个",        "8个",        "8个",        "8个",        "10个",       "12个",       "14个",       "16个",           },
            {   "10%",      "10%",      "10%",      "10%",      "10%",      "50%",      "60%",      "75%",      "90%",      "100%",     "105%",   "115%",  "125%",  "150%",  "165%",  "180%",  "200%",            },
            {   "-",        "-",        "-",        "-",        "50%",      "75%",      "90%",      "100%",     "110%",  "120%",  "130%",  "140%",  "150%",  "160%",  "170%",  "180%",  "190%",      },
            {   "-",        "-",        "-",        "-",        "100%",        "110%",  "125%",  "150%",  "175%",  "190%",  "200%",     "210%",  "225%",  "250%",  "275%",  "290%",  "300%",            },
        };

        public GLQ_DifficultiesInfoPlugin()
        {
            Enabled = true;
            Order = int.MaxValue;
        }

        private void InitTable()
        {
            Table = new TopTable(Hud)
            {
                RatioPositionX = 0.5f,
                RatioPositionY = 0.2f,
                HorizontalCenter = true,
                VerticalCenter = false,
                PositionFromRight = false,
                PositionFromBottom = false,
                ShowHeaderLeft = true,
                ShowHeaderTop = true,
                ShowHeaderRight = false,
                ShowHeaderBottom = false,
                DefaultCellDecorator = new TopTableCellDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, -1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, false, false, true),
                },
                DefaultHighlightDecorator = new TopTableCellDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 242, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, -1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, false, false, true),
                },
                DefaultHeaderDecorator = new TopTableCellDecorator(Hud)
                {
                    //BackgroundBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
                    //BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, false, false, true),
                }
            };

            Table.DefineColumns(
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioHeight = 22 / 1080f, // define only once on first column, value on others will be ignored
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                }
            );

            for (var i = 0; i < 13; i++)
            {
                Table.AddLine(
                    new TopTableHeader(Hud, (pos, curPos) => GetLineHeaderText(pos))
                    {
                        RatioWidth = 62 / 1080f, // define only once on first line, value on other will be ignored
                        RatioHeight = 22 / 1080f,
                        HighlightFunc = (pos, curPos) => false,
                        TextAlign = HorizontalAlign.Right,
                        HighlightDecorator = new TopTableCellDecorator(Hud)
                        {
                            BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                            BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, -1),
                            TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, true, false, true),
                        },
                        CellHighlightDecorator = new TopTableCellDecorator(Hud)
                        {
                            BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                            BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, -1),
                            TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, true, false, true),
                        },
                    },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center }
                );
            }
        }

        private string GetCellText(int line, int column)
        {
            return difficultiesData[line, column];
        }

        private string GetColumnHeaderText(int pos)
        {
            switch (pos)
            {
                case 0:
                    return "普通";
                case 1:
                    return "困难";
                case 2:
                    return "专家";
                case 3:
                    return "大师";
                default:
                    return string.Format("折磨{0}", pos - 3);
            }
        }

        private string GetLineHeaderText(int pos)
        {
            switch (pos)
            {
                case 0:
                    return "等同大秘境层数";
                case 1:
                    return "怪物血量加成";
                case 2:
                    return "怪物伤害加成";
                case 3:
                    return "经验获取加成";
                case 4:
                    return "金币获取加成";
                case 5:
                    return "传奇掉落加成";
                case 6:
                    return "传奇掉落加成（小秘境）";
                case 7:
                    return "死亡气息掉落";
                case 8:
                    return "秘境钥匙掉落";
                case 9:
                    return "悬赏礼包材料";
                case 10:
                    return "悬赏礼包传奇";
                case 11:
                    return "钥匙守护者掉落";
                case 12:
                    return "红门器官掉落";
                default:
                    return "";

            }
        }

        private bool HighlightColumn(int pos)
        {
            return (int) Hud.Game.GameDifficulty == pos;
        }

        public void PaintTopInGame(ClipState clipState)
        {
            //if (!Hud.Game.IsInTown) return;
            if (clipState != ClipState.AfterClip) return;
            var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.BoostWrapper.BoostsDifficultyStackPanel.clock");
            if (!Hud.Window.CursorInsideRect(uiRect.Rectangle.X, uiRect.Rectangle.Y, uiRect.Rectangle.Width, uiRect.Rectangle.Height)) return;

            if (Table == null)
                InitTable();
            else
                Table.Paint();
        }
    }
}
