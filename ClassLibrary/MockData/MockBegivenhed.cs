using ClassLibrary.Models;

namespace ClassLibrary.MockData;

public class MockBegivenhed
{
    private static Dictionary<string, Event> _begivenheder = new()
    {
        {
            "Sommersejlads",
            new Event("Sommersejlads", new DateTime(2025, 7, 10, 14, 30, 0), "Esrum Sø")
        },
        {
            "Efterårstur",
            new Event("Efterårstur", new DateTime(2025, 9, 15, 10, 0, 0), "Nødebo Jollehavn")
        },
        {
            "Forårstræf",
            new Event("Forårstræf", new DateTime(2024, 5, 5, 11, 0, 0), "Frederiksværk Kanal")
        },
        {
            "Familiedag",
            new Event("Familiedag", new DateTime(2026, 6, 12, 12, 0, 0), "Hillerød Havnebassin")
        },
        {
            "Sejlskole Afslutning",
            new Event("Sejlskole Afslutning", new DateTime(2023, 8, 20, 13, 30, 0), "Nødebo Jollehavn")
        },
        {
            "Natsejlads",
            new Event("Natsejlads", new DateTime(2025, 8, 18, 22, 0, 0), "Esrum Sø")
        },
        {
            "Standerhejsning",
            new Event("Standerhejsning", new DateTime(2024, 4, 15, 9, 30, 0), "Hillerød Klubhus")
        },
        {
            "Kapsejlads",
            new Event("Kapsejlads", new DateTime(2027, 7, 2, 15, 0, 0), "Esrum Sø")
        },
        {
            "Vintertræf",
            new Event("Vintertræf", new DateTime(2026, 1, 14, 11, 0, 0), "Hillerød Klubhus")
        },
        {
            "Børnedag",
            new Event("Børnedag", new DateTime(2023, 6, 25, 12, 0, 0), "Frederiksværk Kanal")
        },
        {
            "Sommerlejr",
            new Event("Sommerlejr", new DateTime(2025, 7, 24, 10, 0, 0), "Esrum Sø")
        },
        {
            "Efterårshygge",
            new Event("Efterårshygge", new DateTime(2026, 10, 8, 14, 0, 0), "Nødebo Jollehavn")
        },
        {
            "Introduktion til Sejlads",
            new Event("Introduktion til Sejlads", new DateTime(2024, 5, 8, 10, 0, 0), "Esrum Sø")
        },
        {
            "Familiepicnic",
            new Event("Familiepicnic", new DateTime(2023, 7, 18, 11, 0, 0), "Nødebo Jollehavn")
        },
        {
            "Fælles Sejlads",
            new Event("Fælles Sejlads", new DateTime(2027, 8, 22, 13, 0, 0), "Hillerød Havnebassin")
        },
        {
            "Sejlads for Nybegyndere",
            new Event("Sejlads for Nybegyndere", new DateTime(2024, 6, 10, 14, 30, 0), "Esrum Sø")
        },
        {
            "Julehygge",
            new Event("Julehygge", new DateTime(2025, 12, 5, 16, 0, 0), "Hillerød Klubhus")
        },
        {
            "Sejladstur til Helsingør",
            new Event("Sejladstur til Helsingør", new DateTime(2027, 9, 12, 9, 0, 0), "Helsingør Havn")
        },
        {
            "Afslutning på Sæsonen",
            new Event("Afslutning på Sæsonen", new DateTime(2023, 10, 1, 14, 0, 0), "Nødebo Jollehavn")
        },
        {
            "Langdistance Sejlads",
            new Event("Langdistance Sejlads", new DateTime(2026, 8, 14, 10, 0, 0), "Esrum Sø")
        }
    };

    public static List<Event> GetBegivenhederAsList() => _begivenheder.Values.ToList();
}
