using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Begivenhed;

public class RedigerBegivenhedModel : PageModel
{

    private IBegivenhedService _begivenhedService;

    [BindProperty]

    public Event Event { get; set; }
    public RedigerBegivenhedModel(IBegivenhedService begivenhedService)
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

        Event = _begivenhedService.GetEvent(navn);
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();

        }

        _begivenhedService.UpdateBegivenhed(Event);
        return RedirectToPage("Begivenheder");
    }
}
