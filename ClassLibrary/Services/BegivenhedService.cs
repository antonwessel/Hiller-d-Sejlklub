using ClassLibrary.Interfaces;
using ClassLibrary.MockData;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public class BegivenhedService : IBegivenhedService
    {
        List<Event> events = new List<Event>();
        public BegivenhedService()
        {
            events = MockBegivenhed.GetBegivenheder();
        }

        public void AddBegivenhed(Event begivenhed)
        {
            throw new NotImplementedException();
        }

        public Event DeleteBegivenhed(string navn)
        {
            Event begivenhedToDelete = null;

            foreach (var begivenhed in events)
            {
                if(navn == begivenhed.Navn)
                    begivenhedToDelete = begivenhed;
                break;
            }

            if (begivenhedToDelete != null)
            {
                events.Remove(begivenhedToDelete);
            }
            return begivenhedToDelete;
        }

        public List<Event> GetBegivenheder()
        {
            return events;
        }

        public Event GetBegivenhed(string navn)
        {
            throw new NotImplementedException();
        }

        public void UpdateBegivenhed(Event begivenhed)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetEvents()
        {
            return events;
        }

        public Event GetEvent(string navn)
        {
            throw new NotImplementedException();
        }
    }
}
