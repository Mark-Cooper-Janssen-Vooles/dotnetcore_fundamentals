using OdeToFood.Models;
using System.Collections.Generic;

namespace OdeToFood.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restraunts { get; set; }
        public string CurrentMessage { get; set; }
    }
}
