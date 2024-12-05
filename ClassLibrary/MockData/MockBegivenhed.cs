using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.MockData;

public class MockBegivenhed
{
    private static Dictionary<string, Event> _begivenheder = new()
    {
        { "SuperSejleSøndag", new Event("SuperSejleSøndag", "27-06-2025","Roskilde")},
        { "SejleMesterdag", new Event("SejleMesterdag", "15-02-2025","København") }
    };


    public static List<Event> GetBegivenhederAsList() => _begivenheder.Values.ToList();
}

