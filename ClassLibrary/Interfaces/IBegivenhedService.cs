using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces;

public interface IBegivenhedService
{
    List<Event> GetEvents();
    void AddBegivenhed(Event begivenhed);
    void UpdateBegivenhed(Event begivenhed);
    Event GetEvent(string navn);
    Event DeleteBegivenhed(string navn);
    void AddParticipantToEvent(Medlem participant, Event @event);
}
