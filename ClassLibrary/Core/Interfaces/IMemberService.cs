using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IMemberService
{
    List<Member> GetMembers();
    void AddMember(Member memberToAdd);
    void UpdateMember(Member updatedMember);
    Member GetMember(string memberEmail);
    Member GetMember(Guid memberId);
    Member DeleteMember(string? memberEmail);
    List<Member> FilterMembersByName(string nameSearch); // Brugt til søge funktion
    IJsonDataService<Member> JsonDataService { get; }
}
