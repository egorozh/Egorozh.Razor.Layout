﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egorozh.Razor.Layout
{
    public partial class Grid
    {
        #region Public Properties

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> InputAttributes { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public string RowDefinitions { get; set; } = "*";

        [Parameter] public string ColumnDefinitions { get; set; } = "*";

        [Parameter] public string Width { get; set; } = "100%";

        [Parameter] public string Height { get; set; } = "100%";

        [Parameter] public string ItemMargin { get; set; } = "0px";
            
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

            sb.AddCssValue("display", "grid")
                .AddCssValue("grid-template-columns", ReplaceStarToFr(ColumnDefinitions))
                .AddCssValue("grid-template-rows", ReplaceStarToFr(RowDefinitions))
                .AddCssValue("width", Width)
                .AddCssValue("height", Height)
                .AddCssValue("gap", ItemMargin);

            return sb.ToString();
        }

        private static string ReplaceStarToFr(string input)
        {
            // "* auto *" -> "1fr auto 1fr"

            var splits = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var sb = new StringBuilder();

            foreach (var split in splits)
            {
                if (split.Contains('*'))
                {
                    var value = GetStarValue(split);

                    sb.Append(value);
                    sb.Append("fr");
                }
                else
                {
                    sb.Append(split);
                }

                sb.Append(' ');
            }

            return sb.ToString();
        }

        private static double GetStarValue(string input)
        {
            // input: *  or  1*  or   2*

            var value = 1.0;

            var splits = input.Split('*');

            if (splits.Length > 0)
            {
                var res = double.TryParse(splits[0], out var value2);

                if (res)
                    value = value2;
            }

            return value;
        }

        #endregion
    }
}