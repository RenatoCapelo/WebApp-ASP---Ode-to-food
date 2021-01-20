using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_ASP_Pluralsight.core;
using WebApp_ASP_Pluralsight.D;

namespace WebApp_ASP_Pluralsight.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant restaurant { get; set; }

        [TempData]
        public string Message { get; set; }
        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            restaurant = restaurantData.GetByID(restaurantId);
            if (restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }
    }
}
