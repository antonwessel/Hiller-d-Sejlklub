namespace ClassLibrary.Models;

public class Båd
{
    public string BådType { get; set; }
    public string BådModel { get; set; }
    public string Navn { get; set; }

    public Båd(string bådType, string model, string navn)
    {
        BådType = bådType;
        BådModel = model;
        Navn = navn;
    }

    public Båd()
    {

    }
}
