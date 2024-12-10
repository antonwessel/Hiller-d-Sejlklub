using ClassLibrary.Models;

namespace ClassLibrary.MockData;

public class MockMedlem
{
    // This class is no longer used as we have data persistence

    private static Dictionary<string, Medlem> _medlemmer = new()
    {
        { "ib.andersen@hillerodsejlklub.dk", new Medlem("Ib Andersen", "24473004", "ib.andersen@hillerodsejlklub.dk") },
        { "emma.pedersen@hillerodsejlklub.dk", new Medlem("Emma Pedersen", "26807755", "emma.pedersen@hillerodsejlklub.dk") },
        { "lars.nielsen@hillerodsejlklub.dk", new Medlem("Lars Nielsen", "55667788", "lars.nielsen@hillerodsejlklub.dk") },
        { "marie.jensen@hillerodsejlklub.dk", new Medlem("Marie Jensen", "88776655", "marie.jensen@hillerodsejlklub.dk") },
        { "henrik.thomsen@hillerodsejlklub.dk", new Medlem("Henrik Thomsen", "22233344", "henrik.thomsen@hillerodsejlklub.dk") },
        { "karen.madsen@hillerodsejlklub.dk", new Medlem("Karen Madsen", "99887766", "karen.madsen@hillerodsejlklub.dk") },
        { "peter.olsen@hillerodsejlklub.dk", new Medlem("Peter Olsen", "44556677", "peter.olsen@hillerodsejlklub.dk") },
        { "susanne.christensen@hillerodsejlklub.dk", new Medlem("Susanne Christensen", "33445566", "susanne.christensen@hillerodsejlklub.dk") },
        { "niels.hansen@hillerodsejlklub.dk", new Medlem("Niels Hansen", "12345678", "niels.hansen@hillerodsejlklub.dk") },
        { "anne.sorensen@hillerodsejlklub.dk", new Medlem("Anne Sørensen", "87654321", "anne.sorensen@hillerodsejlklub.dk") },
        { "morten.larsen@hillerodsejlklub.dk", new Medlem("Morten Larsen", "23456789", "morten.larsen@hillerodsejlklub.dk") },
        { "lone.jorgensen@hillerodsejlklub.dk", new Medlem("Lone Jørgensen", "98765432", "lone.jorgensen@hillerodsejlklub.dk") },
        { "jens.bach@hillerodsejlklub.dk", new Medlem("Jens Bach", "11223344", "jens.bach@hillerodsejlklub.dk") },
        { "lotte.knudsen@hillerodsejlklub.dk", new Medlem("Lotte Knudsen", "55664433", "lotte.knudsen@hillerodsejlklub.dk") },
        { "anders.rasmussen@hillerodsejlklub.dk", new Medlem("Anders Rasmussen", "22334455", "anders.rasmussen@hillerodsejlklub.dk") },
        { "birgit.jeppesen@hillerodsejlklub.dk", new Medlem("Birgit Jeppesen", "66778899", "birgit.jeppesen@hillerodsejlklub.dk") },
        { "mikkel.jensen@hillerodsejlklub.dk", new Medlem("Mikkel Jensen", "77889900", "mikkel.jensen@hillerodsejlklub.dk") },
        { "sanne.lund@hillerodsejlklub.dk", new Medlem("Sanne Lund", "88990011", "sanne.lund@hillerodsejlklub.dk") },
        { "thomas.poulsen@hillerodsejlklub.dk", new Medlem("Thomas Poulsen", "99881122", "thomas.poulsen@hillerodsejlklub.dk") },
        { "camilla.vestergaard@hillerodsejlklub.dk", new Medlem("Camilla Vestergaard", "33447788", "camilla.vestergaard@hillerodsejlklub.dk") }
    };

    public static List<Medlem> GetMembersAsList() => _medlemmer.Values.ToList();
}
