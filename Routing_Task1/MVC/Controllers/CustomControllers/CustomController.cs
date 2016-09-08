using System.Web.Mvc;

namespace MVC.Controllers.CustomControllers
{
    public class CustomController : Controller
    {
        // GET: Custom
        [Route("Custom/Index/{id:interval}")]
        public ActionResult Index(int id)
        {
            ViewBag.Message = $"Custom controller with id = {id}";
            return View();
        }
    }
}