using System;
using System.Drawing;

namespace MvcFiltersAndModelBinders.Models
{
    public static class ColorExtensions
    {
        public static string ToHex(this Color colour)
        {
            var retVal = String.Concat(
                colour.R.ToHex(),
                colour.G.ToHex(),
                colour.B.ToHex());
            return retVal.ToLower(); 
        }

        public static string ToHex(this byte value)
        {
            var retVal = value.ToString("X2", null);
            return retVal.ToLower();
        }

        public static string ToCssOpacity(this byte value)
        {
            // Css Opacity is 0.0-1.0 (1.0 Being 'Full')
            if (value < 0 || value > 255)
                throw new ArgumentOutOfRangeException(
                    "value", value, "Value Must be Greater Than or Equal to 0 and No Greater Than 255.");

            var opacity = value / 255f;
            return opacity.ToString("0.0");
        }
    }
}
