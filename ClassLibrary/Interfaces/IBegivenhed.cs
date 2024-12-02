using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    internal interface IBegivenhed
    {
        List<Begivenhed> GetBegivenhed();
        void AddBegivenhed(Begivenhed begivenhed);
        void UpdateBegivenhed(Begivenhed begivenhed);
        Begivenhed GetBegivenhed(string navn);
        Begivenhed DeleteBegivenhed(string navn);

    }
}
