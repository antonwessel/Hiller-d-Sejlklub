using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IMemberService
{
    List<Member> GetMembers();
    void AddMember(Member memberToAdd);

    /// <summary>
    /// Opdaterer et eksisterende medlem ved at bruge et nyt medlem med samme email som det gamle medlem.
    /// </summary>
    /// <param name="updatedMember">Det nye medlem, der skal opdatere det gamle.</param>
    void UpdateMember(Member updatedMember);

    Member GetMember(string memberEmail);
    Member GetMember(Guid memberId);
    Member DeleteMember(string? memberEmail);
    List<Member> FilterMembersByName(string nameSearch); // Brugt til søge funktion
    IJsonDataService<Member> JsonDataService { get; }
}
