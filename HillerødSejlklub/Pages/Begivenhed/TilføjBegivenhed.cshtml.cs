using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace HillerødSejlklub.Pages.Begivenhed
{
    public class TilføjBegivenhedModel : PageModel
    {

        private IBegivenhedService _begivenhedService;

        [BindProperty]
        public Event Begivenhed { get; set; }
        public TilføjBegivenhedModel(IBegivenhedService begivenhedService)
        {
            _begivenhedService = begivenhedService;
        }



        public IActionResult OnGet()
        {
            return Page ();
        }

        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {

                return Page();
            }
            _begivenhedService.AddBegivenhed(Begivenhed);


            return RedirectToPage("Begivenheder");
        }
    }

}
