﻿using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Name = "Scotts Pizza Place", Id = 1},
                new Restaurant { Name = "Joes Donut Shop", Id = 2 },
                new Restaurant { Name = "King Pasta", Id = 3}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }
        List<Restaurant> _restaurants;
    }
}
