using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hnb.Controllers
{
    public class VolunteerController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        public ActionResult ApplyNow()
        {
            return View();
        }
    }
}
