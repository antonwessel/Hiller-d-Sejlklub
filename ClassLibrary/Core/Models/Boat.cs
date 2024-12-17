using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Core.Models;

public class Boat
{
    [Required(ErrorMessage = "Båd type er påkrævet.")]
    [StringLength(50, ErrorMessage = "Båd type må højst være 50 tegn.")]
    public string BoatType { get; set; }

    [Required(ErrorMessage = "Båd model er påkrævet.")]
    [StringLength(50, ErrorMessage = "Båd model må højst være 50 tegn.")]
    public string BoatModel { get; set; }

    [Required(ErrorMessage = "Navn er påkrævet.")]
    [StringLength(100, ErrorMessage = "Navn må højst være 100 tegn.")]
    public string BoatName { get; set; }

    [Required(ErrorMessage = "Billede Url er påkrævet.")]
    [Url(ErrorMessage = "Billede Url skal være en gyldig URL.")]
    [RegularExpression(@".+\.(jpg|jpeg|png|gif|bmp)$", ErrorMessage = "Billede Url skal være et link til en gyldig billedfil (jpg, jpeg, png, gif, bmp).")]
    public string ImageURL { get; set; }

    public List<Maintenance> Maintenances { get; set; } // Til vedligeholdese liste

    public Boat(string boatType, string boatModel, string boatName, string imageURL, List<Maintenance> maintenances)
    {
        BoatType = boatType;
        BoatModel = boatModel;
        BoatName = boatName;
        ImageURL = imageURL;
        Maintenances = maintenances;
    }

    public Boat()
    {
        Maintenances = [];
    }
}
