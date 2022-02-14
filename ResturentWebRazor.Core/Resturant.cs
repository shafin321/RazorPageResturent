using System;
using System.Collections.Generic;
using System.Text;

namespace ResturentWebRazor.Core
{

    public enum CuisineType
    {
        None,
        Mexican,
        Italian,
        Indain
    }
   public class Resturant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location  { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
