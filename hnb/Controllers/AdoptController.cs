using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hnb.Controllers
{
    public class AdoptController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        public ActionResult BeforeYouAdopt()
        {
            return View();
        }

        public ActionResult AfterAdoption()
        {
            return View();
        }
    }
}
