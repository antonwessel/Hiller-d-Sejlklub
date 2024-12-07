using ClassLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Begivenhed.Participation;

public class ParticipationListModel : PageModel
{
    private readonly IBegivenhedService _begivenhedService;

    [BindProperty]
    public List<ClassLibrary.Models.Medlem> Participants { get; set; }

    public ParticipationListModel(IBegivenhedService begivenhedService)
    {
        _begivenhedService = begivenhedService;
    }


    public IActionResult OnGet(Guid eventId)
    {
        Participants = _begivenhedService.GetParticipants(eventId);
        return Page();
    }
}
