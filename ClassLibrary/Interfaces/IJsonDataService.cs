namespace ClassLibrary.Interfaces;

/// <summary>
/// Used for saving and loading to JSON files.
/// </summary>
/// <typeparam name="T">The type of model, e.g., Event, Maintenance, Blog.</typeparam>
public interface IJsonDataService<T>
{
    /// <summary>
    /// Write (save) the data to a file.
    /// </summary>
    /// <param name="data">The data to serialize.</param>
    void SaveData(IEnumerable<T> data);

    /// <summary>
    /// Read (load) the data from a file.
    /// </summary>
    IEnumerable<T> LoadData();

    string FilePath { get; }
}
