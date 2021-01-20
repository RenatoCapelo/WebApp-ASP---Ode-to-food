using System;
using System.Collections.Generic;
using System.Linq;
using WebApp_ASP_Pluralsight.core;

namespace WebApp_ASP_Pluralsight.D
{
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

        public Restaurant GetByID(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id==id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name=null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault<Restaurant>(r => r.Id == updateRestaurant.Id);
            if(restaurant!=null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.cuisine = updateRestaurant.cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant New(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }
    }

}
