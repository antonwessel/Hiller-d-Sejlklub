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
                "10-07-2025",
                "Esrum Sø",
                [
                    new Medlem("Ib Andersen", "24473004", "ib.andersen@hillerodsejlklub.dk"),
                    new Medlem("Emma Pedersen", "26807755", "emma.pedersen@hillerodsejlklub.dk")
                ]
            )
        },
        {
            "Efterårstur",
            new Event(
                "Efterårstur",
                "15-09-2025",
                "Nødebo Jollehavn",
                [
                    new Medlem("Lars Nielsen", "55667788", "lars.nielsen@hillerodsejlklub.dk"),
                    new Medlem("Marie Jensen", "88776655", "marie.jensen@hillerodsejlklub.dk")
                ]
            )
        }
    };

    public static List<Event> GetBegivenhederAsList() => _begivenheder.Values.ToList();
}
