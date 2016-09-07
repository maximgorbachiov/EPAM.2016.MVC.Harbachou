using System.Web.Mvc;
using Task.Infrastructure;
using Task.Mappers;
using Task.Models;

namespace Task.Controllers
{
    public class PersonController : Controller
    {
        private Repository repository = new Repository();
        
        public ActionResult Index(int? id)
        {
            PersonInfoModel personInfo = null;

            if (id != null)
            {
                personInfo = repository.FindPersonById((int)id)?.ToPersonInfoModel();
            }
            
            return View(personInfo);
        }
    }
}