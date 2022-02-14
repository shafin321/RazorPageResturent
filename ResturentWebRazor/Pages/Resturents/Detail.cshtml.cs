using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResturentWebRazor.Core;
using ResturentWebRazor.DataAccess;

namespace ResturentWebRazor.Pages.Resturents
{
    public class DetailModel : PageModel
    {
        private readonly IResturantData _resturant;
        public DetailModel(IResturantData resturant)
        {
            _resturant = resturant;
        }
          
        public Resturant Resturant { get; set; }
        public IActionResult OnGet(int id)
        {
            
          Resturant = _resturant.GetById(id);

            if (Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }

           
             return Page(); 
                                  

        }
    }
}