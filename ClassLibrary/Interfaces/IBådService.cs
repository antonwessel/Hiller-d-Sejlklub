using ClassLibrary.Models;

namespace ClassLibrary.Interfaces;

public interface IBådService
{
    List<Båd> GetBåde();
    void AddBåd(Båd båd);
    void UpdateBåd(Båd båd);
    Båd GetBåd(string navn);
    Båd DeleteBåd(string? navn);
    List<Maintenance> GetMaintenances(string navn);
}