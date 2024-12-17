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

    public void AddEvent(Event @event)
    {
        _eventsList.Add(@event);
        JsonDataService.SaveData(_eventsList);
    }

    public void AddParticipantToEvent(Member participant, Guid eventId)
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

    public Event DeleteEvent(string? name)
    {
        Event eventToDelete = null;

        foreach (Event events in _eventsList)
        {
            if (name == events.Name)
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
        return _eventsList.Where(evt => evt.Date >= startDate && evt.Date <= adjustedEndDate).ToList();
    }

    public Event GetEvent(string name)
    {
        foreach (var @event in _eventsList)
        {
            if (name == @event.Name)
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

    public List<Member> GetParticipants(Guid eventId)
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

    public void UpdateEvent(Event @event)
    {
        foreach (var events in _eventsList)
        {
            if (events.Name == @event.Name)

            {
                events.Date = @event.Date;
                events.Location = @event.Location;
                JsonDataService.SaveData(_eventsList);
                break;
            }
        }
    }
}
