using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IEventService
{
    List<Event> GetEvents();
    void AddEvent(Event eventToAdd);

    /// <summary>
    /// Opdaterer en eksisterende begivenhed.
    /// </summary>
    /// <param name="updatedEvent">Den opdaterede begivenhed.</param>
    void UpdateEvent(Event updatedEvent);

    Event GetEvent(string eventName);
    Event GetEvent(Guid eventId);
    Event DeleteEvent(string eventName);
    void AddParticipantToEvent(Member participantToAdd, Guid eventId);
    void RemoveParticipantFromEvent(Guid participantId, Guid eventId);
    List<Member> GetParticipants(Guid eventId);
    List<Event> FilterByDates(DateTime startDate, DateTime endDate);
    IJsonDataService<Event> JsonDataService { get; }
}
