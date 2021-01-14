using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp_ASP_Pluralsight.core
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType cuisine { get; set; } 
    }
}
