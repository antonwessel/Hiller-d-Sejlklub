using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;

namespace ClassLibrary.Services;

public class MemberService : IMemberService
{
    private List<Member> _memberList = [];

    public IJsonDataService<Member> JsonDataService { get; }

    public MemberService(IJsonDataService<Member> jsonDataService)
    {
        JsonDataService = jsonDataService;
        _memberList = JsonDataService.LoadData().ToList();
    }

    public void AddMember(Member member)
    {
        _memberList.Add(member);
        JsonDataService.SaveData(_memberList);
    }

    public Member DeleteMember(string? email)
    {
        Member memberToDelete = _memberList.FirstOrDefault(m => m.Email == email);
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
    }

    public Member GetMember(string email)
    {
        return _memberList.FirstOrDefault(m => m.Email == email);
    }

    public Member GetMember(Guid id)
    {
        return _memberList.FirstOrDefault(m => m.Id == id);
    }

    public List<Member> GetMembers() => _memberList;

    public void UpdateMember(Member member)
    {
        var existingMedlem = _memberList.FirstOrDefault(m => m.Email == member.Email);
        if (existingMedlem != null)
        {
            existingMedlem.Name = member.Name;
            existingMedlem.PhoneNumber = member.PhoneNumber;
        }
        JsonDataService.SaveData(_memberList);
    }
}
