using System.Collections.Generic;
using System.Text;
using WebApp_ASP_Pluralsight.core;

namespace WebApp_ASP_Pluralsight.D
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name = null);
        Restaurant GetByID(int id);
        Restaurant Update(Restaurant updateRestaurant);
        Restaurant New(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int Commit();

    }

}
