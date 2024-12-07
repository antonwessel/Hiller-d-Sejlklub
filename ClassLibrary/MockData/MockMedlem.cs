using ClassLibrary.Models;

namespace ClassLibrary.MockData;

public class MockMedlem
{
    private static Dictionary<string, Medlem> _medlemmer = new()
    {
        { "ib.andersen@hillerodsejlklub.dk", new Medlem("Ib Andersen", "24473004", "ib.andersen@hillerodsejlklub.dk") },
        { "emma.pedersen@hillerodsejlklub.dk", new Medlem("Emma Pedersen", "26807755", "emma.pedersen@hillerodsejlklub.dk") },
        { "lars.nielsen@hillerodsejlklub.dk", new Medlem("Lars Nielsen", "55667788", "lars.nielsen@hillerodsejlklub.dk") },
        { "marie.jensen@hillerodsejlklub.dk", new Medlem("Marie Jensen", "88776655", "marie.jensen@hillerodsejlklub.dk") }
    };

    public static List<Medlem> GetMembersAsList() => _medlemmer.Values.ToList();
}
