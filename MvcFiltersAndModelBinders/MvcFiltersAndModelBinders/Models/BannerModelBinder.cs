using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFiltersAndModelBinders.Models
{
    public class BannerModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(
                    "bindingContext");

            var colour = GetStringFromContext(bindingContext, "colour");
            var alpha = GetStringFromContext(bindingContext, "alpha");
            var text = GetStringFromContext(bindingContext, "text");         

            var newColour = ColourFromHexValues(colour, alpha);
            var newText = text;

            return new Banner(newColour, newText);
        }

        static string GetStringFromContext(ModelBindingContext bindingContext, string keyName)
        {
            ValueProviderResult result;
            bindingContext.ValueProvider.TryGetValue(keyName, out result);
            var raw = result.RawValue as string[];

            if (raw == null)
                throw new NullReferenceException(string.Format(
                    "String[] was Expected from ValueProvider, But Not Returned for Key '{0}'.", keyName));

            return raw[0];
        }

        static Color ColourFromHexValues(string colour, string alpha)
        {
            var cleanAlpha = alpha.Replace("#", string.Empty);
            var alphaVal = Convert.ToInt32(cleanAlpha, 16);

            var cleanColour = colour.Replace("#", string.Empty);
            var r = cleanColour.Substring(0, 2);
            var rVal = Convert.ToInt32(r, 16);
            var g = cleanColour.Substring(2, 2);
            var gVal = Convert.ToInt32(g, 16);
            var b = cleanColour.Substring(4, 2);
            var bVal = Convert.ToInt32(b, 16);

            return Color.FromArgb(alphaVal, rVal, gVal, bVal);
        }
    }
}
