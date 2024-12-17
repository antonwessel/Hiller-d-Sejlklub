using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Members;

public class EditMemberModel : PageModel
{
    private readonly IMemberService _memberService;

    [BindProperty]
    public ClassLibrary.Core.Models.Member Member { get; set; }

    public EditMemberModel(IMemberService memberService)
    {
        _memberService = memberService;
    }

    public IActionResult OnGet(string memberEmail)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("AllMembers");
        }

        Member = _memberService.GetMember(memberEmail);
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _memberService.UpdateMember(Member);
        return RedirectToPage("AllMembers");
    }
}
