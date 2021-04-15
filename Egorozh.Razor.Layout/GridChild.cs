using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
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

        protected override Dictionary<string, string> GenerateStyle()
        {
            Dictionary<string, string> endStyle = new()
            {
                {"width", Width},
                {"height", Height},
                {"grid-column", GetColumnOrRow(Column, ColumnSpan)},
                {"grid-row", GetColumnOrRow(Row, RowSpan)},
                {"justify-self", HorizontalAlignment.ToCss()},
                {"align-self", VerticalAlignment.ToCss()},
                {"overflow-x", HorizontalScrollBar.ToCss()},
                {"overflow-y", VerticalScrollBar.ToCss()},
                {"border-color", BorderColor},
            };

            return endStyle;
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