using System;
using System.Collections.Generic;
using System.Text;

namespace Egorozh.Razor.Layout
{
    internal static class Extensions
    {
        public static Dictionary<string, object> InitializeInputAttributes(this Dictionary<string, object> initInputs,
            out Dictionary<string, string> initStyle)
        {
            if (initInputs != null)
            {
                var style = string.Empty;

                if (initInputs.ContainsKey("style"))
                {
                    style = (string) initInputs["style"];
                }

                initStyle = ParseStyle(style);
                return initInputs;
            }

            initStyle = new Dictionary<string, string>();
            return new Dictionary<string, object>();
        }

        public static void SetStyle(this Dictionary<string, object> inputAttributes, Dictionary<string, string> style)
        {
            if (inputAttributes.ContainsKey("style"))
                inputAttributes["style"] = style.ToCss();
            else
                inputAttributes.Add("style", style.ToCss());
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

        public static string ToCss(this Dictionary<string, string> style)
        {
            StringBuilder builder = new();

            foreach (var (key,value) in style) 
                builder.Append(key).Append(':').Append(value).Append(';');

            return builder.ToString();
        }
        
        private static Dictionary<string, string> ParseStyle(string style)
        {
            var dict = new Dictionary<string, string>();    

            var props = style.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var prop in props)
            {
                var keyValues = prop.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);

                if (keyValues.Length == 2)
                {
                    var key = keyValues[0];
                    var value = keyValues[1];

                    if (dict.ContainsKey(key))
                        dict[key] = value;
                    else
                        dict.Add(key, value);
                }
            }

            return dict;
        }
    }
}