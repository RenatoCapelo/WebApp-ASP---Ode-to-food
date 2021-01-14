using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_ASP_Pluralsight.core;

namespace WebApp_ASP_Pluralsight.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant restaurant { get; set; }
        public void OnGet(int restaurantId)
        {
            restaurant = new Restaurant();
            restaurant.Id = restaurantId;
        }
    }
}
