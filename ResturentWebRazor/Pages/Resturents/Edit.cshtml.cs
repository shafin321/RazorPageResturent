using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResturentWebRazor.Core;
using ResturentWebRazor.DataAccess;

namespace ResturentWebRazor.Pages.Resturents
{
    public class EditModel : PageModel
    {
        private readonly IHtmlHelper htmlHelper;
        private readonly IResturantData _resturant;
        public EditModel(IResturantData resturant,IHtmlHelper htmlHelper)
        {
            _resturant = resturant;
            this.htmlHelper = htmlHelper;   
        }

        [BindProperty]
        public Resturant Resturant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        
        public IActionResult OnGet(int id)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            Resturant = _resturant.GetById(id);
            if (Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

      
        public IActionResult OnPost( )
        {
            if (ModelState.IsValid)
            {
                
               _resturant.Update(Resturant);
                _resturant.Commit();

                return RedirectToPage("./Detail", new { id =Resturant.Id});
            }
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            

            return Page();
        }
    }
}