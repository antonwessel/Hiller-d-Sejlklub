using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IMemberService
{
    List<Member> GetMembers();
    void AddMember(Member member);
    void UpdateMember(Member member);
    Member GetMember(string email);
    Member GetMember(Guid id);
    Member DeleteMember(string? email);
    List<Member> FilterMembersByName(string name); // Brugt til søge funktion
    IJsonDataService<Member> JsonDataService { get; }
}
