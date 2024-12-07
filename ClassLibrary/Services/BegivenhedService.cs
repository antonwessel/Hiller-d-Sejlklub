using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Services;

public class BegivenhedService : IBegivenhedService
{
    List<Event> _eventList;

    public BegivenhedService()
    {
        _eventList = MockData.MockBegivenhed.GetBegivenhederAsList();
    }

    public void AddBegivenhed(Event begivenhed)
    {
        _eventList.Add(begivenhed);
    }

    public void AddParticipantToEvent(Medlem participant, Event @event)
    {
        throw new NotImplementedException();
    }

    public Event DeleteBegivenhed(string? navn)
    {
        Event eventToDelete = null;

        foreach (Event events in _eventList)
        {
            if (navn == events.Navn)
            {
                eventToDelete = events;
                break;
            }
        }
        if (eventToDelete != null)
        {
            _eventList.Remove(eventToDelete);
        }
        return eventToDelete;

    }

    public Event GetEvent(string navn)
    {
        foreach (var events in _eventList)
        {
            if (navn == events.Navn)
            {
                return events;
            }

        }
        return null;
    }

    public List<Event> GetEvents() => _eventList;

    public void UpdateBegivenhed(Event begivenhed)
    {
        foreach (var events in _eventList)
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
