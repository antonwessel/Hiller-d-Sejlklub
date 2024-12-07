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
                new DateTime(2025, 9, 15, 10, 0, 0),
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
