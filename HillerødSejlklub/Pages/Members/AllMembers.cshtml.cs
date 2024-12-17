using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Members;

public class AllMembersModel : PageModel
{
    private readonly IMemberService _memberService;

    [BindProperty]
    public string NameSearch { get; set; }

    public List<ClassLibrary.Core.Models.Member> Members { get; set; }

    public AllMembersModel(IMemberService memberService)
    {
        _memberService = memberService;
    }

    public void OnGet()
    {
        Members = _memberService.GetMembers();
    }

    public IActionResult OnPostSearch()
    {
        if (NameSearch != null)
        {
            Members = _memberService.FilterMembersByName(NameSearch.Trim());
        }
        else
        {
            Members = _memberService.GetMembers();
        }
        return Page();
    }
}