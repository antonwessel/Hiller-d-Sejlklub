namespace ClassLibrary.Models;

public class Medlem
{
    public string Navn { get; set; }
    public string TelefonNummer { get; set; }
    public string Email { get; set; }

    public Medlem(string navn, string telefonNummer, string email)
    {
        Navn = navn;
        Email = email;
        TelefonNummer = telefonNummer;
    }
}
