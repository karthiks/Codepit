using System.Drawing;

namespace MvcFiltersAndModelBinders.Models
{
    public class Banner
    {
        public string Text;
        public Color Colour;

        public Banner(Color colour, string text)
        {
            Text = text;
            Colour = colour;
        }
    }
}
