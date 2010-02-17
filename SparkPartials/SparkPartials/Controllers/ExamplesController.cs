using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace SparkPartials.Controllers
{
    public class ExamplesController : Controller
    {
        public ActionResult RenderPartial()
        {
            return View();
        }

        public ActionResult PartialName()
        {
            return View();
        }

        public ActionResult InjectingVariables()
        {
            return View();
        }
    }
}
