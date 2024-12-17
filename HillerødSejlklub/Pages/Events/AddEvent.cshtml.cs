using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Events;

public class AddEventModel : PageModel
{
    private readonly IEventService _eventService;

    [BindProperty]
    public Event Event { get; set; }

    public AddEventModel(IEventService eventService)
    {
        _eventService = eventService;
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
        _eventService.AddEvent(Event);


        return RedirectToPage("AllEvents");
    }
}
