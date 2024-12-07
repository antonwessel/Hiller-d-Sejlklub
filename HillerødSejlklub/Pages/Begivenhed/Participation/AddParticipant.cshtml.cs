using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Begivenhed.Participation;

public class AddParticipantModel : PageModel
{
    private IBegivenhedService _begivenhedService;

    [BindProperty]
    public Event Event { get; set; }

    [BindProperty]
    public ClassLibrary.Models.Medlem Participant { get; set; }

    public AddParticipantModel(IBegivenhedService begivenhedService)
    {
        _begivenhedService = begivenhedService;
    }

    public IActionResult OnGet()
    {
    }
}
