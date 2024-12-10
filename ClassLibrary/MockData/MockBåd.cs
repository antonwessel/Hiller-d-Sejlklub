using ClassLibrary.Core.Models;

namespace ClassLibrary.MockData;

public class MockBåd
{
    private static readonly Dictionary<string, Båd> _både = new()
    {
        ["Havfruen"] = new Båd(
            "Sejljolle",
            "J123",
            "Havfruen",
            "https://billeder.dba.dk/dba/4f85a7ef-4805-4344-9602-c4efc3f16fc9.jpeg?class=S960X960",
            [
                new Maintenance(Maintenance.WorkStatus.Færdig, "Udskiftning af ror", DateTime.Now.AddMonths(-2).AddHours(-3).AddMinutes(-45)),
                new Maintenance(Maintenance.WorkStatus.Igang, "Reparation af bom", DateTime.Now.AddDays(-3).AddHours(-5).AddMinutes(-30))
            ]
        ),
        ["Vinden"] = new Båd(
            "Sejlbåd",
            "S456",
            "Vinden",
            "https://watergames.dk/wp-content/uploads/2023/02/Sejlbaad-top-scaled.jpg",
            [
                new Maintenance(Maintenance.WorkStatus.Afventer, "Udskiftning af mast", DateTime.Now.AddDays(-10).AddHours(-1).AddMinutes(-20)),
                new Maintenance(Maintenance.WorkStatus.Igang, "Justering af sejlhæfter", DateTime.Now.AddDays(-5).AddHours(-4).AddMinutes(-10)),
                new Maintenance(Maintenance.WorkStatus.Færdig, "Reparation af sejl", DateTime.Now.AddMonths(-3).AddHours(-2).AddMinutes(-50))
            ]
        ),
        ["Lillebror"] = new Båd(
            "Jolle",
            "J789",
            "Lillebror",
            "https://dansksejlunion.dk/media/dykg05ll/190629-sommerlejr-2019-044.jpg?width=730&height=382&format=jpg&rnd=133209435279400000",
            [
                new Maintenance(Maintenance.WorkStatus.Afventer, "Tætning af lækager", DateTime.Now.AddDays(-14).AddHours(-6).AddMinutes(-25)),
                new Maintenance(Maintenance.WorkStatus.Igang, "Udskiftning af årer", DateTime.Now.AddDays(-7).AddHours(-3).AddMinutes(-35)),
                new Maintenance(Maintenance.WorkStatus.Færdig, "Maling af bunden", DateTime.Now.AddMonths(-4).AddHours(-8).AddMinutes(-40)),
                new Maintenance(Maintenance.WorkStatus.Igang, "Udskiftning af sæder", DateTime.Now.AddDays(-3).AddHours(-2).AddMinutes(-15))
            ]
        ),
        ["Eventyreren"] = new Båd(
            "Kajak",
            "K101",
            "Eventyreren",
            "https://image.alt.dk/1513646.webp?imageId=1513646&width=960&height=574&format=jpg",
            [
                new Maintenance(Maintenance.WorkStatus.Afventer, "Reparation af pagajholder", DateTime.Now.AddDays(-8).AddHours(-1).AddMinutes(-5)),
                new Maintenance(Maintenance.WorkStatus.Igang, "Tætning af revner", DateTime.Now.AddDays(-2).AddHours(-4).AddMinutes(-15))
            ]
        ),
        ["Svanen"] = new Båd(
            "Kapsejladsbåd",
            "R999",
            "Svanen",
            "https://www.baadmagasinet.dk/images/stories/egen%20ann/_DSC0095-web.jpg",
            [
                new Maintenance(Maintenance.WorkStatus.Færdig, "Udskiftning af sejl", DateTime.Now.AddMonths(-3).AddHours(-2).AddMinutes(-50)),
                new Maintenance(Maintenance.WorkStatus.Igang, "Tjek af rig", DateTime.Now.AddDays(-5).AddHours(-4).AddMinutes(-10)),
                new Maintenance(Maintenance.WorkStatus.Afventer, "Opgradering af skrog", DateTime.Now.AddDays(-15).AddHours(-5).AddMinutes(-20))
            ]
        )
    };

    public static List<Båd> GetBoatsAsList() => _både.Values.ToList();
}
