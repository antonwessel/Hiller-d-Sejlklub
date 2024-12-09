using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Services;

public class BegivenhedService : IBegivenhedService
{
    private readonly List<Event> _eventsList;

    public BegivenhedService()
    {
        _eventsList = MockData.MockBegivenhed.GetBegivenhederAsList();
    }

    public void AddBegivenhed(Event begivenhed)
    {
        _eventsList.Add(begivenhed);
    }

    public void AddParticipantToEvent(Medlem participant, Guid eventId)
    {
        foreach (var evt in _eventsList)
        {
            if (evt.Id == eventId)
            {
                evt.Participants.Add(participant);
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

        return eventToDelete;

    }

    public List<Event> FilterByDates(DateTime startDate, DateTime endDate)
    {
        // Return all events that matches the interval
        return _eventsList.Where(evt => evt.Dato >= startDate && evt.Dato <= endDate).ToList();
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


    public void UpdateBegivenhed(Event begivenhed)
    {
        foreach (var events in _eventsList)
        {
            if (events.Navn == begivenhed.Navn)

            {
                events.Dato = begivenhed.Dato;
                events.Lokation = begivenhed.Lokation;
                break;
            }
        }
    }
}
