using ClassLibrary.Interfaces;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Begivenhed
{
    public class SletBegivenhedModel : PageModel
    {
        private IBegivenhedService _begivenhedService;

        [BindProperty]

        public ClassLibrary.Models.Event Begivenhed { get; set; }

        
        public SletBegivenhedModel(IBegivenhedService begivenhedService)
        {
            _begivenhedService = begivenhedService;
        }

        public IActionResult OnGet(string navn)
        {
            Begivenhed=_begivenhedService.GetEvent(navn);
            return Page();
        }

        public IActionResult OnPost()
        {
            _begivenhedService.DeleteBegivenhed(Begivenhed.Navn);
            return RedirectToPage("Begivenheder");
        }
    }
}
