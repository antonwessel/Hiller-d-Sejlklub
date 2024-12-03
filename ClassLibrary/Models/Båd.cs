using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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

    [Required(ErrorMessage = "BilledeUrl er påkrævet.")]
    [Url(ErrorMessage = "BilledeUrl skal være en gyldig URL.")]
    [RegularExpression(@".+\.(jpg|jpeg|png|gif|bmp)$", ErrorMessage = "BilledeUrl skal være et link til en gyldig billedfil (jpg, jpeg, png, gif, bmp).")]
    public string BilledeUrl { get; set; }

    public List<Maintenance> Maintenances { get; set; } // Til vedligeholdese liste

    public Båd(string bådType, string model, string navn, string billedeUrl, List<Maintenance> maintenances)
    {
        BådType = bådType;
        BådModel = model;
        Navn = navn;
        BilledeUrl = billedeUrl;
        Maintenances = maintenances;
    }

    public Båd()
    {
        Maintenances = new List<Maintenance>();
    }
}
