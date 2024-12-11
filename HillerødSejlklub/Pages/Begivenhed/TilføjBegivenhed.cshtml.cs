using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Begivenhed;

public class TilføjBegivenhedModel : PageModel
{

    private IEventService _begivenhedService;

    [BindProperty]
    public Event Begivenhed { get; set; }
    public TilføjBegivenhedModel(IEventService begivenhedService)
    {
        _begivenhedService = begivenhedService;
    }


    public IActionResult OnGet()
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("Begivenheder");
        }

        return Page();
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
