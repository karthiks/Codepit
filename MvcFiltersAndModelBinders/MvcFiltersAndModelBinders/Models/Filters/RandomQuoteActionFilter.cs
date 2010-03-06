using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcFiltersAndModelBinders.Models.Filters
{
    public class RandomQuoteActionFilter : FilterAttribute, IActionFilter
    {
        static Random prng = new Random();

        // Taken From: http://www.quotationspage.com/random.php3
        private readonly List<Quote> quoteLib = new List<Quote>
          {
              new Quote { Author = "Aldous Huxley", Content = "Maybe this world is another planet's hell." },
              new Quote { Author = "Ralph Waldo Emerson", Content = "Do not go where the path may lead, go instead where there is no path and leave a trail." },
              new Quote { Author = "Peter Ustinov", Content = "Critics search for ages for the wrong word, which, to give them credit, they eventually find." },
              new Quote { Author = "Theodore Roosevelt", Content = "No man is justified in doing evil on the ground of expediency." },
              new Quote { Author = "John Kenneth Galbraith", Content = "Meetings are indispensable when you don't want to do anything." },
              new Quote { Author = "Sir Winston Churchill", Content = "I like pigs. Dogs look up to us. Cats look down on us. Pigs treat us as equals." },
              new Quote { Author = "Albert Einstein", Content = "Only two things are infinite, the universe and human stupidity, and I'm not sure about the former." },
              new Quote { Author = "Albert Einstein", Content = "Everything that is really great and inspiring is created by the individual who can labor in freedom." },
              new Quote { Author = "Albert Einstein", Content = "Everything that is really great and inspiring is created by the individual who can labor in freedom." }
          };

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Grab a Random Quote from the "Library"
            var rnd = prng.Next(0, quoteLib.Count - 1);
            var quote = quoteLib[rnd];

            filterContext.Controller.ViewData["quote"] = quote;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Not Required..
        }
    }
}
