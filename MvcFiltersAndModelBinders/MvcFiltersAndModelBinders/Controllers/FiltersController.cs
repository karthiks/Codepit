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
            return View();
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
    }
}
