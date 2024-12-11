using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IBådService
{
    List<Båd> GetBåde();
    void AddBåd(Båd båd);
    void UpdateBåd(Båd båd);
    Båd GetBåd(string navn);
    Båd DeleteBåd(string? navn);
    IJsonDataService<Båd> JsonDataService { get; }
}