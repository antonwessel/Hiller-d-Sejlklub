using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IMaintenanceService
{
    List<Maintenance> GetMaintenances(string bådNavn);
    void AddMaintenance(string bådNavn, Maintenance maintenance);
    void UpdateMaintenance(string bådNavn, Maintenance maintenance);
    void DeleteMaintenance(string bådNavn, Maintenance maintenance);
    Maintenance GetMaintenance(string bådNavn, Guid maintenanceId);

    /// <summary>
    /// Returns a float which represents a percentage done of all the maintenances on a boat.
    /// </summary>
    /// <param name="bådNavn">The name of the boat</param>
    /// <returns></returns>
    float GetMaintenancesDone(string bådNavn);
}
