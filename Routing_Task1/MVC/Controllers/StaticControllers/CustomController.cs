using System.Web.Mvc;
using Newtonsoft.Json;

namespace MVC.Controllers.StaticControllers
{
    public class CustomController : Controller
    {
        // GET: Custom
        [Route("Custom/Index/{id:minlength(3):maxlength(6)}")]
        public ActionResult Index(string id)
        {
            string json = JsonConvert.SerializeObject($"Static controller with id = {id}");
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}