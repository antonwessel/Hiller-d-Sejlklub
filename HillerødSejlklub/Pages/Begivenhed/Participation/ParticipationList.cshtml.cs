using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HillerødSejlklub.Pages.Begivenhed.Participation;

public class ParticipationListModel : PageModel
{
    private readonly IBegivenhedService _begivenhedService;
    private readonly IMedlemService _medlemService;

    [BindProperty]
    public List<ClassLibrary.Models.Medlem> Participants { get; set; }

    [BindProperty]
    public List<ClassLibrary.Models.Medlem> AllAvailableParticipants { get; set; }

    [Required]
    [BindProperty]
    public Guid NewParticipantId { get; set; }

    [BindProperty]
    public Event CurrentEvent { get; set; }

    public ParticipationListModel(IBegivenhedService begivenhedService, IMedlemService medlemService)
    {
        _begivenhedService = begivenhedService;
        _medlemService = medlemService;
    }

    public IActionResult OnGet(Guid eventId)
    {
        LoadData(eventId);
        return Page();
    }

    public IActionResult OnPost(Guid eventId)
    {
        if (NewParticipantId == Guid.Empty)
        {
            ModelState.AddModelError("", "Vælg venligst en deltager.");
            LoadData(eventId);
            return Page();
        }

        var selectedParticipant = _medlemService.GetMedlemmer()
            .FirstOrDefault(m => m.Id == NewParticipantId);

        if (selectedParticipant == null)
        {
            ModelState.AddModelError("", "Valgt deltager blev ikke fundet.");
            LoadData(eventId);
            return Page();
        }

        _begivenhedService.AddParticipantToEvent(selectedParticipant, eventId);

        LoadData(eventId);

        return Page();
    }

    private void LoadData(Guid eventId)
    {
        CurrentEvent = _begivenhedService.GetEvent(eventId);
        Participants = _begivenhedService.GetParticipants(eventId);


        AllAvailableParticipants = _medlemService.GetMedlemmer()
            .Where(member => !Participants.Contains(member))
            .ToList();
    }
}
