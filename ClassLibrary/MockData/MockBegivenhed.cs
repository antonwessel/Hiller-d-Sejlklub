using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.MockData;

public class MockBegivenhed
{
    private static Dictionary<string, Begivenhed> _begivenheder = new()
    {
        { "SuperSejleSøndag", new Begivenhed("SuperSejleSøndag", "27-06-2025","Roskilde")},
        { "SejleMesterdag", new Begivenhed("SejleMesterdag", "15-02-2025","København") }
    };


    public static List<Begivenhed> GetBegivenheder() => _begivenheder.Values.ToList();
}

