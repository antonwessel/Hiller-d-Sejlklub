using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;

namespace ClassLibrary.Services;

public class MedlemService : IMemberService
{
    private List<Member> _medlemList = [];

    public IJsonDataService<Member> JsonDataService { get; }

    public MedlemService(IJsonDataService<Member> jsonDataService)
    {
        JsonDataService = jsonDataService;
        _medlemList = JsonDataService.LoadData().ToList();
    }

    public void AddMember(Member medlem)
    {
        _medlemList.Add(medlem);
        JsonDataService.SaveData(_medlemList);
    }

    public Member DeleteMember(string? email)
    {
        Member medlemToDelete = _medlemList.FirstOrDefault(m => m.Email == email);
        if (medlemToDelete != null)
        {
            _medlemList.Remove(medlemToDelete);
        }
        JsonDataService.SaveData(_medlemList);
        return medlemToDelete;
    }

    public List<Member> FilterMembersByName(string name)
    {
        return _medlemList
            .Where(m => m.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase))
            .ToList();
    }

    public Member GetMember(string email)
    {
        return _medlemList.FirstOrDefault(m => m.Email == email);
    }

    public Member GetMember(Guid id)
    {
        return _medlemList.FirstOrDefault(m => m.Id == id);
    }

    public List<Member> GetMembers() => _medlemList;

    public void UpdateMember(Member medlem)
    {
        var existingMedlem = _medlemList.FirstOrDefault(m => m.Email == medlem.Email);
        if (existingMedlem != null)
        {
            existingMedlem.Name = medlem.Name;
            existingMedlem.PhoneNumber = medlem.PhoneNumber;
        }
        JsonDataService.SaveData(_medlemList);
    }
}
