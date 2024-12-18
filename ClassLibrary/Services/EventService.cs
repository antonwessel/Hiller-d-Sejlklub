using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;

namespace ClassLibrary.Services;

public class EventService : IEventService
{
    private readonly List<Event> _eventsList; // Liste med alle events
    public IJsonDataService<Event> JsonDataService { get; }

    public EventService(IJsonDataService<Event> jsonDataService)
    {
        JsonDataService = jsonDataService;

        _eventsList = JsonDataService.LoadData().ToList();
    }

    public void AddEvent(Event eventToAdd)
    {
        _eventsList.Add(eventToAdd);
        SaveEvents();
    }

    public void AddParticipantToEvent(Member participant, Guid eventId)
    {
        var eventToUpdate = FindEventById(eventId);
        if (eventToUpdate != null)
        {
            eventToUpdate.Participants.Add(participant);
            SaveEvents();
        }
    }

    public Event DeleteEvent(string eventName)
    {
        var eventToDelete = FindEventByName(eventName);
        if (eventToDelete != null)
        {
            _eventsList.Remove(eventToDelete);
            SaveEvents();
        }
        return eventToDelete;
    }

    public List<Event> FilterByDates(DateTime startDate, DateTime endDate)
    {
        DateTime adjustedEndDate = endDate.Date.AddDays(1).AddTicks(-1);
        // Sørger for at slutdatoen dækker hele dagen

        return _eventsList.Where(e => e.Date >= startDate && e.Date <= adjustedEndDate).ToList();
    }

    public Event GetEvent(string eventName)
    {
        return FindEventByName(eventName);
    }

    public Event GetEvent(Guid eventId)
    {
        return FindEventById(eventId);
    }

    public List<Event> GetEvents()
    {
        return _eventsList;
    }

    public List<Member> GetParticipants(Guid eventId)
    {
        var eventFound = FindEventById(eventId);
        return eventFound?.Participants ?? [];
    }

    public void RemoveParticipantFromEvent(Guid participantId, Guid eventId)
    {
        var eventToUpdate = FindEventById(eventId);
        if (eventToUpdate != null)
        {
            var participantToRemove = eventToUpdate.Participants.FirstOrDefault(p => p.Id == participantId);
            if (participantToRemove != null)
            {
                eventToUpdate.Participants.Remove(participantToRemove);
                SaveEvents();
            }
        }
    }

    public void UpdateEvent(Event eventToUpdate)
    {
        // Find eksisterende begivenhed med samme navn
        var existingEvent = FindEventByName(eventToUpdate.Name);
        if (existingEvent != null)
        {
            // Opdater dato og sted
            existingEvent.Date = eventToUpdate.Date;
            existingEvent.Location = eventToUpdate.Location;
            // Gem ændringer
            SaveEvents();
        }
    }

    private Event FindEventByName(string name)
    {
        return _eventsList.FirstOrDefault(e => e.Name == name);
    }

    private Event FindEventById(Guid id)
    {
        return _eventsList.FirstOrDefault(e => e.Id == id);
    }

    private void SaveEvents()
    {
        JsonDataService.SaveData(_eventsList);
    }
}
