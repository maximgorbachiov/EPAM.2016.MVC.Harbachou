using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Models;
using Task.Repositories;

namespace Task.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePerson(User model)
        {
            return View(model);
        }

        [HttpGet]
        public ActionResult CreatePersonByGetMethod()
        {
            var user = new User();

            if (TryUpdateModel(user, new QueryStringValueProvider(ControllerContext)))
            {
                return View("CreatePerson", user);
            }

            return View("CreatePerson");
        } 
    }
}