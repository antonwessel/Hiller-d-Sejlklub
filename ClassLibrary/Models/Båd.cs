using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models;

public class Båd
{
    [Required(ErrorMessage = "BådType er påkrævet.")]
    [StringLength(50, ErrorMessage = "BådType må højst være 50 tegn.")]
    public string BådType { get; set; }

    [Required(ErrorMessage = "BådModel er påkrævet.")]
    [StringLength(50, ErrorMessage = "BådModel må højst være 50 tegn.")]
    public string BådModel { get; set; }

    [Required(ErrorMessage = "Navn er påkrævet.")]
    [StringLength(100, ErrorMessage = "Navn må højst være 100 tegn.")]
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
