using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;

namespace ClassLibrary.Services;

public class MemberService : IMemberService
{
    private readonly List<Member> _memberList = [];
    public IJsonDataService<Member> JsonDataService { get; }

    public MemberService(IJsonDataService<Member> jsonDataService)
    {
        JsonDataService = jsonDataService;

        // Hent medlemmer fra JSON
        _memberList = JsonDataService.LoadData().ToList();
    }

    public void AddMember(Member member)
    {
        // Tjekker om medlemmet allerede findes
        if (!_memberList.Any(m => m.Email == member.Email))
        {
            _memberList.Add(member);
            JsonDataService.SaveData(_memberList); // Gemmer medlemmer
        }
    }

    public Member DeleteMember(string? email)
    {
        var memberToDelete = _memberList.FirstOrDefault(m => m.Email == email);
        if (memberToDelete != null)
        {
            _memberList.Remove(memberToDelete);
        }
        JsonDataService.SaveData(_memberList);
        return memberToDelete;
    }

    public List<Member> FilterMembersByName(string name)
    {
        return _memberList
            .Where(m => m.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase))
            .ToList();
        // Søger medlemmer uden forskel på store og små bogstaver
    }

    public Member GetMember(string email)
    {
        return _memberList.FirstOrDefault(m => m.Email == email);
    }

    public Member GetMember(Guid id)
    {
        return _memberList.FirstOrDefault(m => m.Id == id);
    }

    public List<Member> GetMembers()
    {
        return _memberList;
    }

    public void UpdateMember(Member member)
    {
        // Find medlem med samme email
        var existingMember = _memberList.FirstOrDefault(m => m.Email == member.Email);
        if (existingMember != null)
        {
            // Opdater medlem med nye oplysninger
            existingMember.Name = member.Name;
            existingMember.PhoneNumber = member.PhoneNumber;
        }
        // Gem ændringer i data
        JsonDataService.SaveData(_memberList);
    }
}