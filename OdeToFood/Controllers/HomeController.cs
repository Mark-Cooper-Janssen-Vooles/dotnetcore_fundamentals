using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData,
                                IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restraunts = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();



            //var model = _restaurantData.GetAll();
            //var model = new Restaurant { Id = 1, Name = "Scotts Pizza Place" };

            //return new ObjectResult(model); //returns json, ideal when building APIs.

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if(model == null) //aka if not found
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid) //aka validations passed, there was a name provided under 80 characters => always need to check this!!
            {
                var newRestaurant = new Restaurant(); 
                newRestaurant.Name = model.Name;
                newRestaurant.Cuisine = model.Cuisine;

                newRestaurant = _restaurantData.Add(newRestaurant);

                return RedirectToAction("details", new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
