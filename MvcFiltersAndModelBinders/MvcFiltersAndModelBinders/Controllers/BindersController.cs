using System.Drawing;
using System.Web.Mvc;
using MvcFiltersAndModelBinders.Models;

namespace MvcFiltersAndModelBinders.Controllers
{
    public class BindersController : Controller
    {
        /* NOTE: Tossing the variables around in session like this is obviously
         * not "the way" to do it, done here for brevity :)
         */
 
        public ActionResult Index()
        {
            return new RedirectResult("~/");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Colour()
        {
            var existing = Session["banner"] ?? new Banner(Color.White, "Hello World!");
            return View(existing);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Colour(Banner banner)
        {
            Session["banner"] = banner;
            return new RedirectResult("~/binders/colour");
        }
    }
}
