using ClassLibrary.Models;

namespace ClassLibrary.MockData;

public class MockBåd
{
    private static Dictionary<string, Båd> _både = new() // Bådens Navn fungere som key
    {
        {"Havfruen", new Båd("Motorbåd", "X123", "Havfruen", "https://obj3116.public-dk6.clu4.obj.storagefactory.io/yachtbroker-cms/motorbad_2_171ad29498.jpg", [new Maintenance(Maintenance.WorkStatus.Pending, "Lukke huller"), new Maintenance(Maintenance.WorkStatus.Done, "Ny maling")]) },
        {"Vinden", new Båd("Sejlbåd", "S456", "Vinden", "https://watergames.dk/wp-content/uploads/2023/02/Sejlbaad-top-scaled.jpg", [new(Maintenance.WorkStatus.Pending, "Nyt anker"), new Maintenance(Maintenance.WorkStatus.Done, "Nyt sejl")]) }
    };

    public static List<Båd> GetBoatsAsList() => _både.Values.ToList();
}
