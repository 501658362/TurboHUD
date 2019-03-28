namespace Turbo.Plugins.glq.Decorators.TopTables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class TopTable : IDisposable
    {
        public IController Hud { get; private set; }

        public float RatioPositionX { get; set; }
        public float RatioPositionY { get; set; }
        public float SpacingAdjustmentInPixels { get; set; }

        public bool PositionFromBottom { get; set; }
        public bool PositionFromRight { get; set; }

        public bool HorizontalCenter { get; set; }
        public bool VerticalCenter { get; set; }

        public bool ShowHeaderTop { get; set; }
        public bool ShowHeaderBottom { get; set; }
        public bool ShowHeaderLeft { get; set; }
        public bool ShowHeaderRight { get; set; }

        public TopTableCellDecorator DefaultCellDecorator { get; set; }
        public TopTableCellDecorator DefaultHighlightDecorator { get; set; }
        public TopTableCellDecorator DefaultHeaderDecorator { get; set; }

        public List<TopTableHeader> Columns { get; private set; }
        public List<TopTableHeader> Lines { get; private set; }

        public TopTable(IController hud)
        {
            Hud = hud;

            Columns = new List<TopTableHeader>();
            Lines = new List<TopTableHeader>();

            SpacingAdjustmentInPixels = -1;
        }

        public void Paint()
        {
            if (Columns.Count == 0) return;
            if (Lines.Count == 0) return;

            var w = Columns.Select(c => c.Width).Sum() + (Columns.Count * SpacingAdjustmentInPixels) - SpacingAdjustmentInPixels;
            var h = Lines.Select(c => c.Height).Sum() + (Lines.Count * SpacingAdjustmentInPixels) - SpacingAdjustmentInPixels;

            if (ShowHeaderLeft) w += Lines.First().Width + SpacingAdjustmentInPixels;
            if (ShowHeaderRight) w += Lines.First().Width + SpacingAdjustmentInPixels;
            if (ShowHeaderTop) h += Columns.First().Height + SpacingAdjustmentInPixels;
            if (ShowHeaderBottom) h += Columns.First().Height + SpacingAdjustmentInPixels;

            var left = RatioPositionX * Hud.Window.Size.Width;
            var top = RatioPositionY * Hud.Window.Size.Height;

            if (VerticalCenter)
                top -= h / 2;
            else if (PositionFromBottom)
                top -= h;

            if (HorizontalCenter)
                left -= w / 2;
            else if (PositionFromRight)
                left -= w;

            Paint(left, top);
        }

        protected void Paint(float x, float y)
        {
            if (ShowHeaderLeft)
            {
                var _y = y;
                if (ShowHeaderTop)
                    _y += Columns.First().Height + SpacingAdjustmentInPixels;

                foreach (var lineHeader in Lines)
                {
                    lineHeader.Paint(x, _y, HorizontalAlign.Right);
                    _y += lineHeader.Height + SpacingAdjustmentInPixels;
                }
            }
            if (ShowHeaderTop)
            {
                var _x = x;
                if (ShowHeaderLeft)
                    _x += Lines.First().Width + SpacingAdjustmentInPixels;

                foreach (var columnHeader in Columns)
                {
                    columnHeader.Paint(_x, y, HorizontalAlign.Center);
                    _x += columnHeader.Width + SpacingAdjustmentInPixels;
                }
            }

            if (ShowHeaderLeft)
                x += Lines.First().Width + SpacingAdjustmentInPixels;

            if (ShowHeaderTop)
                y += Columns.First().Height + SpacingAdjustmentInPixels;

            var _yCell = y;
            for (var line = 0; line < Lines.Count; line++)
            {
                var _x = x;
                //for (var column = 0; column < Columns.Count; column++)
                //{
                //    if (line >= Columns[column].Cells.Count) continue;

                //    Columns[column].Cells[line].Paint(_x, _yCell, line, column);
                //    _x += Columns[column].Cells[line].Width + SpacingAdjustmentInPixels;
                //}
                for (var column = 0; column < Columns.Count; column++)
                {
                    Lines[line].Cells[column].Paint(_x, _yCell, line, column);
                    _x += Lines[line].Cells[column].Width + SpacingAdjustmentInPixels;
                }
                _yCell += Lines[line].Height + SpacingAdjustmentInPixels;
            }

            if (ShowHeaderRight)
            {
                var _y = y;
                var _x = x + Columns.Select(c => c.Width).Sum() + (Columns.Count * SpacingAdjustmentInPixels) - SpacingAdjustmentInPixels;

                foreach (var lineHeader in Lines)
                {
                    lineHeader.Paint(_x, _y, HorizontalAlign.Left);
                    _y += lineHeader.Height + SpacingAdjustmentInPixels;
                }
            }

            if (ShowHeaderBottom)
            {
                var _x = x;

                foreach (var columnHeader in Columns)
                {
                    columnHeader.Paint(_x, _yCell, HorizontalAlign.Center);
                    _x += columnHeader.Width + SpacingAdjustmentInPixels;
                }
            }
        }

        public void DefineColumns(params TopTableHeader[] columns)
        {
            if (columns == null)
                return;

            if (Lines.Count > 0)
                throw new Exception("You can't define columns because there is already lines defined.");

            var ratioHeight = Columns.Count == 0 ? columns.First().RatioHeight : Columns.First().RatioHeight;

            foreach (var column in columns)
            {
                column.Table = this;
                column.Siblings = Columns;
                column.RatioHeight = ratioHeight;

                column.Position = Columns.Count;
                Columns.Add(column);
            }
        }

        public void AddLine(TopTableHeader line, params TopTableCell[] cells)
        {
            if (cells == null) return;

            if (Columns.Count == 0)
                throw new Exception("You can't add lines because there is no columns defined. Call DefineColumns() once before calling AddLine().");

            if (cells.Length < Columns.Count)
                throw new Exception(string.Format("Not enough columns!! Trying to insert {0} columns with {1} column headers defined.", cells.Length, Columns.Count));

            if (cells.Length > Columns.Count)
                throw new Exception(string.Format("Too much columns!! Trying to insert {0} columns with only {1} column headers defined.", cells.Length, Columns.Count));

            line.Table = this;
            line.Siblings = Lines;
            line.RatioWidth = Lines.Count == 0 ? line.RatioWidth : Lines.First().RatioWidth;

            for (var i = 0; i < cells.Length; i++)
            {
                cells[i].Table = this;
                cells[i].Column = Columns[i];
                cells[i].Line = line;

                line.Cells.Add(cells[i]);
                Columns[i].Cells.Add(cells[i]);
            }

            line.Position = Lines.Count;
            Lines.Add(line);
        }

        public void SortLines(int column, bool descending = false)
        {
            Lines.Sort((a, b) =>
            {
                var compare = string.Compare(a.Cells[column].TextFunc(a.Position, column, 0, 0), b.Cells[column].TextFunc(b.Position, column, 0, 0), StringComparison.Ordinal);
                return descending ? -compare : compare;
            });
        }

        /*
         table.SortLines(1, (column, a, b) =>
            {
                var val1 = getValue(column, a.Position);
                var val2 = getValue(column, b.Position);

                if (val1 == val2) return 0;
                return val1 > val2 ? 1 : -1;
            });
        */
        public void SortLines(int column, Func<int, TopTableHeader, TopTableHeader, int> sortFunc)
        {
            Lines.Sort((a, b) => sortFunc(column, a, b));
        }

        public void RemoveLines()
        {
            Reset(true);
        }

        public void Reset(bool keepColumns = false)
        {
            if (keepColumns)
            {
                foreach (var column in Columns)
                {
                    column.Cells.Clear();
                }
            }
            else
            {
                foreach (var column in Columns.ToArray())
                {
                    column.Dispose();
                }
                Columns.Clear();
            }

            foreach (var line in Lines.ToArray())
            {
                line.Dispose();
            }
            Lines.Clear();
        }

        public void Dispose()
        {
            Reset();
            if (DefaultCellDecorator != null)
            {
                DefaultCellDecorator.Dispose();
            }
            if (DefaultHighlightDecorator != null)
            {
                DefaultHighlightDecorator.Dispose();
            }
            if (DefaultHeaderDecorator != null)
            {
                DefaultHeaderDecorator.Dispose();
            }
        }
    }
}