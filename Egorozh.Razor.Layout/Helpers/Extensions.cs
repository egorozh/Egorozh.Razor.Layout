using System.Collections.Generic;
using System.Text;

namespace Egorozh.Razor.Layout
{
    internal static class Extensions
    {
        public static Dictionary<string, object> InitializeInputAttributes(this Dictionary<string, object> initInputs,
            out string initStyle)
        {
            if (initInputs != null)
            {
                var style = string.Empty;

                if (initInputs.ContainsKey("style"))
                {
                    style = (string) initInputs["style"];

                    if (!style.EndsWith(";"))
                        style += ";";
                }

                initStyle = style;
                return initInputs;
            }

            initStyle = string.Empty;
            return new Dictionary<string, object>();
        }

        public static void SetStyle(this Dictionary<string, object> inputAttributes, string style)
        {
            if (inputAttributes.ContainsKey("style"))
                inputAttributes["style"] = style;
            else
                inputAttributes.Add("style", style);
        }

        public static string ToCss(this HorizontalAlignment horizontalAlignment) =>
            horizontalAlignment switch
            {
                HorizontalAlignment.Stretch => "stretch",
                HorizontalAlignment.Center => "center",
                HorizontalAlignment.Right => "end",
                HorizontalAlignment.Left => "start",
                _ => ""
            };

        public static string ToCss(this VerticalAlignment verticalAlignment) =>
            verticalAlignment switch
            {
                VerticalAlignment.Stretch => "stretch",
                VerticalAlignment.Center => "center",
                VerticalAlignment.Bottom => "end",
                VerticalAlignment.Top => "start",
                _ => ""
            };

        public static string ToCss(this ScrollBar scrollBar) =>
            scrollBar switch
            {
                ScrollBar.None => "hidden",
                ScrollBar.Show => "scroll",
                ScrollBar.Auto => "auto",
                _ => "visible"
            };

        public static StringBuilder AddCssValue(this StringBuilder builder, string name, string value)
        {
            builder.Append(name).Append(':').Append(value).Append(';');

            return builder;
        }
    }
}