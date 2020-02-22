using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Restraunt { Id = 1, Name = "Scotts Pizza Place" };

            //return new ObjectResult(model); //returns json, ideal when building APIs.

            return View(model);
        }
    }
}
