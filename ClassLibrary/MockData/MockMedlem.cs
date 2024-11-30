using ClassLibrary.Models;

namespace ClassLibrary.MockData;

public class MockMedlem
{
    // temporary class, ideally would use a JSON file for data persistence.

    private static Dictionary<string, Medlem> _medlemmer = new()
        {
            {"frankjensen@gmail.com", new Medlem("Frank Jensen", "2121", "frankjensen@gmail.com") },
            {"karenstoltt", new Medlem("Karen Stoltt", "3131", "karenstoltt@gmail.com") }
        };

    public static List<Medlem> GetMembersAsList() => _medlemmer.Values.ToList();
}
