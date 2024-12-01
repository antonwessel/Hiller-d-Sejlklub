using ClassLibrary.Models;

namespace ClassLibrary.MockData;

public class MockBåd
{
    private static Dictionary<string, Båd> _både = new() // Bådens Navn fungere som key
    {
        {"Havfruen", new Båd("Motorbåd", "X123", "Havfruen", "https://obj3116.public-dk6.clu4.obj.storagefactory.io/yachtbroker-cms/motorbad_2_171ad29498.jpg") },
        {"Vinden", new Båd("Sejlbåd", "S456", "Vinden", "https://watergames.dk/wp-content/uploads/2023/02/Sejlbaad-top-scaled.jpg") }
    };

    public static List<Båd> GetBoatsAsList() => _både.Values.ToList();
}
