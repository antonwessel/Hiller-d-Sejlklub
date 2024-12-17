using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HillerødSejlklub.Pages.Events.Participation;

public class ParticipationListModel : PageModel
{
    private readonly IEventService _begivenhedService;
    private readonly IMemberService _medlemService;

    [BindProperty]
    public List<ClassLibrary.Core.Models.Member> Participants { get; set; }

    [BindProperty]
    public List<ClassLibrary.Core.Models.Member> AllAvailableParticipants { get; set; }

    [Required]
    [BindProperty]
    public Guid NewParticipantId { get; set; }

    [BindProperty]
    public Event CurrentEvent { get; set; }

    public ParticipationListModel(IEventService begivenhedService, IMemberService medlemService)
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
        // Find den valgte deltager fra listen af medlemmer
        var selectedParticipant = _medlemService.GetMembers()
            .FirstOrDefault(m => m.Id == NewParticipantId);

        _begivenhedService.AddParticipantToEvent(selectedParticipant, eventId);
        LoadData(eventId);
        return Page();
    }

    public IActionResult OnPostRemoveParticipant(Guid eventId, Guid participantId)
    {
        _begivenhedService.RemoveParticipantFromEvent(participantId, eventId);
        LoadData(eventId);
        return Page();
    }


    private void LoadData(Guid eventId)
    {
        CurrentEvent = _begivenhedService.GetEvent(eventId);
        Participants = _begivenhedService.GetParticipants(eventId);

        // Hent alle tilgængelige deltagere, som ikke allerede er med
        AllAvailableParticipants = _medlemService.GetMembers()
            .Where(member => !Participants.Contains(member))
            .ToList();
    }
}
