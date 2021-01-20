using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_ASP_Pluralsight.core;
using WebApp_ASP_Pluralsight.D;

namespace WebApp_ASP_Pluralsight.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetByID(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            if(Restaurant==null)
            {
                return Redirect("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if(!ModelState.IsValid)
            {
            return Page();
            }
            if (Restaurant.Id > 0)
            {
                restaurantData.Update(Restaurant);
                TempData["Message"] = "Restaurant Updated!";
            }
            else
            {
                restaurantData.New(Restaurant);
                TempData["Message"] = "Restaurant Created!";
            }
            restaurantData.Commit();
            return RedirectToPage("./Details", new { restaurantId = Restaurant.Id });
        }
    }
}
