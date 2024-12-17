using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Members;

public class DeleteMemberModel : PageModel
{
    private readonly IMemberService _memberService;

    [BindProperty]
    public ClassLibrary.Core.Models.Member Member { get; set; }

    public DeleteMemberModel(IMemberService memberService)
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

        // 'asp-route-email' under Medlemmer.cshtml bliver brugt med parameter 'email'. Argumentet til email bliver givet når man klikker (router) til denne page.

        Member = _memberService.GetMember(memberEmail);
        return Page();
    }

    public IActionResult OnPost()
    {
        _memberService.DeleteMember(Member.Email);
        return RedirectToPage("AllMembers");
    }
}
