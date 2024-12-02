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
    public class BegivenhedService : IBegivenhed
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
            throw new NotImplementedException();
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

        public List<Event> GetBegivenhed()
        {
            throw new NotImplementedException();
        }

        public Event GetBegivenheder(string navn)
        {
            throw new NotImplementedException();
        }
    }
}
