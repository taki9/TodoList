using System.Web.Mvc;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return new EmptyResult();
        }
    }
}
