using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IMaintenanceService
{
    /// <summary>
    /// Henter alle vedligeholdelser for en båd.
    /// </summary>
    List<Maintenance> GetMaintenances(string bådNavn);

    /// <summary>
    /// Tilføjer en vedligeholdelse til en båd.
    /// </summary>
    void AddMaintenance(string bådNavn, Maintenance maintenance);

    /// <summary>
    /// Opdaterer en eksisterende vedligeholdelse.
    /// </summary>
    void UpdateMaintenance(string bådNavn, Maintenance maintenance);

    /// <summary>
    /// Sletter en vedligeholdelse for en båd.
    /// </summary>
    void DeleteMaintenance(string bådNavn, Maintenance maintenance);

    /// <summary>
    /// Henter en specifik vedligeholdelse baseret på MaintenanceId.
    /// </summary>
    Maintenance GetMaintenance(string bådNavn, Guid maintenanceId);

    /// <summary>
    /// Indlæser vedligeholdelsesdata fra JSON.
    /// </summary>
    Dictionary<string, List<Maintenance>> LoadMaintenanceJsonData();

    /// <summary>
    /// Gemmer vedligeholdelsesdata til JSON.
    /// </summary>
    void SaveMaintenanceJsonData(string bådNavn, List<Maintenance> maintenances);

    /// <summary>
    /// Beregner procentdelen af færdiggjorte vedligeholdelser for en båd.
    /// </summary>
    float GetMaintenancesDone(string bådNavn);
}
