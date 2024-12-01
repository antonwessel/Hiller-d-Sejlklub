using ClassLibrary.Models;

namespace ClassLibrary.MockData;

public class MockBåd
{
    private static Dictionary<string, Båd> _både = new() // Bådens Navn fungere som key
    {
        {"Havfruen", new Båd("Motorbåd", "X123", "Havfruen") },
        {"Vinden", new Båd("Sejlbåd", "S456", "Vinden") }
    };

    public static List<Båd> GetBoatsAsList() => _både.Values.ToList();
}
