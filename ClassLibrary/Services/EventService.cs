using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;

namespace ClassLibrary.Services;

public class EventService : IEventService
{
    private readonly List<Event> _eventsList;
    public IJsonDataService<Event> JsonDataService { get; }

    public EventService(IJsonDataService<Event> jsonDataService)
    {
        JsonDataService = jsonDataService;
        _eventsList = JsonDataService.LoadData().ToList();
    }

    public void AddBegivenhed(Event begivenhed)
    {
        _eventsList.Add(begivenhed);
        JsonDataService.SaveData(_eventsList);
    }

    public void AddParticipantToEvent(Medlem participant, Guid eventId)
    {
        foreach (var evt in _eventsList)
        {
            if (evt.Id == eventId)
            {
                evt.Participants.Add(participant);
                JsonDataService.SaveData(_eventsList);
                break;
            }
        }
    }

    public Event DeleteBegivenhed(string? navn)
    {
        Event eventToDelete = null;

        foreach (Event events in _eventsList)
        {
            if (navn == events.Navn)
            {
                eventToDelete = events;
                break;
            }
        }

        if (eventToDelete != null)
        {
            _eventsList.Remove(eventToDelete);
        }

        JsonDataService.SaveData(_eventsList);
        return eventToDelete;

    }

    public List<Event> FilterByDates(DateTime startDate, DateTime endDate)
    {
        // Gør slutdatoen til hele dagen
        DateTime adjustedEndDate = endDate.Date.AddDays(1).AddTicks(-1);

        // Find begivenheder i dato-intervallet
        return _eventsList.Where(evt => evt.Dato >= startDate && evt.Dato <= adjustedEndDate).ToList();
    }

    public Event GetEvent(string navn)
    {
        foreach (var @event in _eventsList)
        {
            if (navn == @event.Navn)
            {
                return @event;
            }

        }
        return null;
    }

    public Event GetEvent(Guid id)
    {
        foreach (var @event in _eventsList)
        {
            if (@event.Id == id)
            {
                return @event;
            }

        }
        return null;
    }

    public List<Event> GetEvents() => _eventsList;

    public List<Medlem> GetParticipants(Guid eventId)
    {
        foreach (var @event in _eventsList)
        {
            if (eventId == @event.Id)
            {
                return @event.Participants ?? []; // Tjek om Participants er null
            }
        }
        return [];
    }

    public void RemoveParticipantFromEvent(Guid participantId, Guid eventId)
    {
        foreach (var evt in _eventsList)
        {
            if (evt.Id == eventId)
            {
                var participantToRemove = evt.Participants.FirstOrDefault(p => p.Id == participantId);
                if (participantToRemove != null)
                {
                    evt.Participants.Remove(participantToRemove);
                    JsonDataService.SaveData(_eventsList);
                }
                break;
            }
        }
    }

    public void UpdateBegivenhed(Event begivenhed)
    {
        foreach (var events in _eventsList)
        {
            if (events.Navn == begivenhed.Navn)

            {
                events.Dato = begivenhed.Dato;
                events.Lokation = begivenhed.Lokation;
                JsonDataService.SaveData(_eventsList);
                break;
            }
        }
    }
}
