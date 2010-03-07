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
            return retVal; 
        }

        public static string ToHex(this byte value)
        {
            var retVal = value.ToString("X2", null);
            return retVal.ToLower();
        }
    }
}
