using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebApp_ASP_Pluralsight.core;

namespace WebApp_ASP_Pluralsight.D
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name = null);

    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza",Location = "Porto", cuisine=CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Portugalia",Location="Lisbon", cuisine=CuisineType.None},
                new Restaurant {Id = 3, Name = "Hamburgueria Fidalgo", Location="Barreiro", cuisine=CuisineType.None}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name=null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }

}
