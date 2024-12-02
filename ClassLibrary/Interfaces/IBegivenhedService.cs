using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IBegivenhedService
    {
        List<Event> GetBegivenhed();
        void AddBegivenhed(Event begivenhed);
        void UpdateBegivenhed(Event begivenhed);
        Event GetBegivenheder(string navn);
        Event DeleteBegivenhed(string navn);

    }
}
