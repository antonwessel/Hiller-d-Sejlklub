namespace ClassLibrary.Core.Interfaces;

/// <summary>
/// Bruges til at gemme og hente data fra JSON filer.
/// </summary>
/// <typeparam name="T">Typen af model, f.eks. Event, Maintenance, Blog.</typeparam>
public interface IJsonDataService<T>
{
    /// <summary>
    /// Gem data i en fil.
    /// </summary>
    /// <param name="data">Data der skal gemmes.</param>
    void SaveData(IEnumerable<T> data);

    /// <summary>
    /// Hent data fra en fil.
    /// </summary>
    IEnumerable<T> LoadData();

    string FilePath { get; } // Sti til filen
}
