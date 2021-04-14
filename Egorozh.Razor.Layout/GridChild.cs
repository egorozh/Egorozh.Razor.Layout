﻿using Microsoft.AspNetCore.Components;
using System.Text;

namespace Egorozh.Razor.Layout
{
    public class GridChild : BaseDiv
    {
        #region Public Properties

        [Parameter] public string Width { get; set; } = "100%";

        [Parameter] public string Height { get; set; } = "100%";

        [Parameter] public int Row { get; set; }

        [Parameter] public int Column { get; set; }

        [Parameter] public int RowSpan { get; set; }

        [Parameter] public int ColumnSpan { get; set; }

        [Parameter] public VerticalAlignment VerticalAlignment { get; set; }

        [Parameter] public HorizontalAlignment HorizontalAlignment { get; set; }

        [Parameter] public ScrollBar HorizontalScrollBar { get; set; }

        [Parameter] public ScrollBar VerticalScrollBar { get; set; }

        [Parameter] public string BorderColor { get; set; } = "transparent";

        #endregion

        #region Protected Methods

        protected override string GenerateStyle(string style)
        {
            StringBuilder sb = new();

            sb.AddCssValue("width", Width)
                .AddCssValue("height", Height)
                .AddCssValue("grid-column", GetColumnOrRow(Column, ColumnSpan))
                .AddCssValue("grid-row", GetColumnOrRow(Row, RowSpan))
                .AddCssValue("justify-self", HorizontalAlignment.ToCss())
                .AddCssValue("align-self", VerticalAlignment.ToCss())
                .AddCssValue("overflow-x", HorizontalScrollBar.ToCss())
                .AddCssValue("overflow-y", VerticalScrollBar.ToCss())
                .AddCssValue("border-color", BorderColor);

            sb.Append(style);

            return sb.ToString();
        }

        #endregion

        #region Private Methods

        private static string GetColumnOrRow(int columnOrRow, int columnOrRowSpan)
        {
            StringBuilder sb = new();

            sb.Append(columnOrRow > 1 ? columnOrRow : 1);
            sb.Append("/span ");
            sb.Append(columnOrRowSpan > 1 ? columnOrRowSpan : 1);

            return sb.ToString();
        }

        #endregion
    }
}