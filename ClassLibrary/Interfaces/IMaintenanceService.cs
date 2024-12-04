using ClassLibrary.Models;

namespace ClassLibrary.Interfaces;

public interface IMaintenanceService
{
    List<Maintenance> GetMaintenances(string bådNavn);
    void AddMaintenance(string bådNavn, Maintenance maintenance);
    void UpdateMaintenance(string bådNavn, Maintenance maintenance);
    void DeleteMaintenance(string bådNavn, Maintenance maintenance);
    Maintenance GetMaintenance(string bådNavn, Guid maintenanceId);
}
