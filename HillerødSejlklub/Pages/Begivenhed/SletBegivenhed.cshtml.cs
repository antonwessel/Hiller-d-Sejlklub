using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Begivenhed;

public class SletBegivenhedModel : PageModel
{
    private IEventService _begivenhedService;

    [BindProperty]

    public Event Begivenhed { get; set; }


    public SletBegivenhedModel(IEventService begivenhedService)
    {
        _begivenhedService = begivenhedService;
    }

    public IActionResult OnGet(string navn)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("Begivenheder");
        }

        Begivenhed = _begivenhedService.GetEvent(navn);
        return Page();
    }

    public IActionResult OnPost()
    {
        _begivenhedService.DeleteEvent(Begivenhed.Name);
        return RedirectToPage("Begivenheder");
    }
}
