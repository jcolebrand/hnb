using System.Web.Mvc;

namespace hnb.Controllers
{
    public class MeetController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WhereAreOurDogsFrom() {
            return View();
        }
    }
}
