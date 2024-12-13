using ClassLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Core.Interfaces;

public interface IEventService
{
    List<Event> GetEvents();
    void AddBegivenhed(Event begivenhed);
    void UpdateBegivenhed(Event begivenhed);
    Event GetEvent(string navn);
    Event GetEvent(Guid id);
    Event DeleteBegivenhed(string navn);
    void AddParticipantToEvent(Medlem participant, Guid eventId);
    void RemoveParticipantFromEvent(Guid participantId, Guid eventId);
    List<Medlem> GetParticipants(Guid eventId);
    List<Event> FilterByDates(DateTime startDate, DateTime endDate);
    IJsonDataService<Event> JsonDataService { get; }
}
