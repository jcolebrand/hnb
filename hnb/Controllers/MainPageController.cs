using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hnb.Controllers
{
    public class MainPageController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }
    }
}
