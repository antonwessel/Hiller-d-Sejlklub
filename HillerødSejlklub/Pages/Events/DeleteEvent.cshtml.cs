using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Events;

public class DeleteEventModel : PageModel
{
    private readonly IEventService _eventService;

    [BindProperty]
    public Event Event { get; set; }

    public DeleteEventModel(IEventService eventService)
    {
        _eventService = eventService;
    }

    public IActionResult OnGet(string eventName)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("AllEvents");
        }

        Event = _eventService.GetEvent(eventName);
        return Page();
    }

    public IActionResult OnPost(string eventName)
    {
        _eventService.DeleteEvent(eventName);
        return RedirectToPage("AllEvents");
    }
}
