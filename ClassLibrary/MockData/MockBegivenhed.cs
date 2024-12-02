﻿using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.MockData
{
    public class MockBegivenhed
    {
        private static Dictionary<string, Begivenhed> _begivenhed = new()
        {"SuperSejleSøndag", new Begivenhed("SuperSejleSøndag", "27-06-2025","Roskilde")}
        

    }

    public static List<Begivenhed> GetBegivenhed() => _begivenhed.Values.;
}
