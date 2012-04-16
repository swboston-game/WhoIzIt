using System.Web.Mvc;
using System.Web.UI;

namespace WhoIzIt.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 60 * 60 * 24 * 365, Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult Channel()
        {
            return View();
        }
    }
}
