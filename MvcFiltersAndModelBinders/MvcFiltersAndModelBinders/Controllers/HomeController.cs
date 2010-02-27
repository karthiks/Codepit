using System.Web.Mvc;

namespace MvcFiltersAndModelBinders.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
