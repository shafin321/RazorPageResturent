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
    public class ListModel : PageModel
    {
        private readonly IResturantData _resturant;
        public ListModel(IResturantData resturant)
        {
            _resturant = resturant;
        }

        public IEnumerable<Resturant> Resturants { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTearm { get; set; }


        public void OnGet()
        {
            Resturants = _resturant.GettAllResturantByName(SearchTearm);


        }
    }
}
