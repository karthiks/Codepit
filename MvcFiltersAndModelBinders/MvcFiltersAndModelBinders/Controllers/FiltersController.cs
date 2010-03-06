using System.Web.Mvc;
using MvcFiltersAndModelBinders.Models.Filters;

namespace MvcFiltersAndModelBinders.Controllers
{
    public class FiltersController : Controller
    {
        //
        // GET: /Filters/

        public ActionResult Index()
        {
            return new RedirectResult("~/");
        }


        [DeniedFilter]
        public ActionResult Denied()
        {
            return View();
        }

        [QueryStringAuthFilter]
        public ActionResult QueryString()
        {
            return View();
        }

        [RandomQuoteActionFilter]
        public ActionResult RandomQuote()
        {
            return View();
        }
    }
}
