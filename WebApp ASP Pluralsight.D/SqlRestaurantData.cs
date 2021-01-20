using System.Collections.Generic;
using WebApp_ASP_Pluralsight.core;
using System.Linq;

namespace WebApp_ASP_Pluralsight.D
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly WebAppDbContext db;

        public SqlRestaurantData(WebAppDbContext db)
        {
            this.db = db;
        }
        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetByID(id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            };
            return restaurant;
        }

        public Restaurant GetByID(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant New(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var entity = db.Restaurants.Attach(updateRestaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updateRestaurant;
        }
    }

}
