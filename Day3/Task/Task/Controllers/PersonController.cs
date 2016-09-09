using System.Linq;
using System.Web.Mvc;
using Task.Infrastructure;
using Task.Mappers;
using Task.Models;

namespace Task.Controllers
{
    public class PersonController : Controller
    {
        private static readonly Repository repository = new Repository();

        public ActionResult Index()
        {
            var persons = repository.GetAll().Select(person => person.ToPersonInfoModel()).ToList();

            return View(persons);
        }

        [HttpGet]
        public ActionResult ChangeSide(int id)
        {
            PersonInfoModel personInfo = repository.FindPersonById(id).ToPersonInfoModel();
            
            return View(personInfo);
        }

        [HttpPost]
        public ActionResult ChangeSide(PersonInfoModel model)
        {
            PersonInfoModel personInfo = repository.FindPersonById(model.Id).ToPersonInfoModel();

            if (personInfo.Side)
            {
                personInfo.Side = false;
                repository.Save(personInfo.ToPerson());
            }

            return View(personInfo);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonInfoModel personInfoModel)
        {
            if (ModelState.IsValid)
            {
                personInfoModel.Id = repository.AddPerson(personInfoModel.ToPerson());
               
                return RedirectToAction("Index");
            }

            return View();
        }

        [ChildActionOnly]
        public ActionResult ViewChangeSide(PersonInfoModel model)
        {
            return View(model);
        }
    }
}