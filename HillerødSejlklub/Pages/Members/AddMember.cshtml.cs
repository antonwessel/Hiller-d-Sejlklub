using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Members;

public class AddMemberModel : PageModel
{
    private readonly IMemberService _memberService;

    [BindProperty]
    public ClassLibrary.Core.Models.Member Member { get; set; }

    public AddMemberModel(IMemberService memberService)
    {
        _memberService = memberService;
    }

    public IActionResult OnGet()
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("AllMembers");
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _memberService.AddMember(Member);
        return RedirectToPage("AllMembers");
    }
}