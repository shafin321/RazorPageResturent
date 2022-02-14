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
    public class CreateModel : PageModel
    {


        private readonly IHtmlHelper htmlHelper;
        private readonly IResturantData _resturant;
        public CreateModel(IResturantData resturant, IHtmlHelper htmlHelper)
        {
            _resturant = resturant;
            this.htmlHelper = htmlHelper;
        }

        [BindProperty]
        public Resturant Resturant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public IActionResult OnGet()
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            return Page();

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _resturant.Create(Resturant);
               

                return RedirectToPage("./List");
            }

            return Page();
        }
    }
}