using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Text;

namespace Egorozh.Razor.Layout
{
    public partial class GridChild
    {
        #region Public Properties

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> InputAttributes { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public string Width { get; set; } = "100%";

        [Parameter] public string Height { get; set; } = "100%";

        [Parameter] public int Row { get; set; }

        [Parameter] public int Column { get; set; }

        [Parameter] public int RowSpan { get; set; }

        [Parameter] public int ColumnSpan { get; set; }

        [Parameter] public VerticalAlignment VerticalAlignment { get; set; }

        [Parameter] public HorizontalAlignment HorizontalAlignment { get; set; }

        #endregion

        #region Protected Methods

        protected override void OnParametersSet()
        {
            InputAttributes = InputAttributes.InitializeInputAttributes(out var style);

            InputAttributes.SetStyle(GenerateStyle(style));
        }

        #endregion

        #region Private Methods

        private string GenerateStyle(string style)
        {
            StringBuilder sb = new(style);

            sb.AddCssValue("width", Width)
                .AddCssValue("height", Height)
                .AddCssValue("grid-column", GetColumnOrRow(Column, ColumnSpan))
                .AddCssValue("grid-row", GetColumnOrRow(Row, RowSpan))
                .AddCssValue("justify-self", HorizontalAlignment.ToCss())
                .AddCssValue("align-self", VerticalAlignment.ToCss());

            return sb.ToString();
        }

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