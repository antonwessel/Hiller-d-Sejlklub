namespace ClassLibrary.Models;

public class Medlem
{
public string Navn { get; set; }
public string Efternavn { get; set; }

public string TelefonNummer {  get; set; }


 
public Medlem (string navn, string efternavn, string telefonNummer)
    {
        Navn = navn;
        Efternavn = efternavn;
        TelefonNummer = telefonNummer;
    }
}
