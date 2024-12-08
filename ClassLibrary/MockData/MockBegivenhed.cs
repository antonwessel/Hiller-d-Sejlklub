using ClassLibrary.Models;

namespace ClassLibrary.MockData;

public class MockBegivenhed
{
    private static Dictionary<string, Event> _begivenheder = new()
    {
        {
            "Sommersejlads",
            new Event(
                "Sommersejlads",
                new DateTime(2025, 7, 10, 14, 30, 0),
                "Esrum Sø"
            )
        },
        {
            "Efterårstur",
            new Event(
                "Efterårstur",
                new DateTime(2025, 9, 15, 10, 0, 0),
                "Nødebo Jollehavn"
            )
        }
    };

    public static List<Event> GetBegivenhederAsList() => _begivenheder.Values.ToList();
}
