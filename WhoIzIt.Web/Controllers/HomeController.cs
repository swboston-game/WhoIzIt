using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.UI;

namespace WhoIzIt.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["error"]) && Request.QueryString["error"] == "access_denied")
            {
                //TODO: do something
            }
            string authUrl = String.Format("https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}&scope=friends_online_presence,publish_stream,publish_actions,user_games_activity,email", ConfigurationManager.AppSettings["AppID"], Url.Encode(ConfigurationManager.AppSettings["AppUri"]));
            ViewBag.AuthUrl = authUrl;
            ViewBag.Port = Request.Url.Port;
            ViewBag.AppID = ConfigurationManager.AppSettings["AppID"];
            ViewBag.WebApiUrl = ConfigurationManager.AppSettings["ApiUri"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }

        [OutputCache(Duration = 60 * 60 * 24 * 365, Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult Channel()
        {
            return View();
        }
    }
}
