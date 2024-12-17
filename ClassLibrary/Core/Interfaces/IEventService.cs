using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IEventService
{
    List<Event> GetEvents();
    void AddEvent(Event @event);
    void UpdateEvent(Event @event);
    Event GetEvent(string name);
    Event GetEvent(Guid id);
    Event DeleteEvent(string name);
    void AddParticipantToEvent(Member participant, Guid eventId);
    void RemoveParticipantFromEvent(Guid participantId, Guid eventId);
    List<Member> GetParticipants(Guid eventId);
    List<Event> FilterByDates(DateTime startDate, DateTime endDate);
    IJsonDataService<Event> JsonDataService { get; }
}
