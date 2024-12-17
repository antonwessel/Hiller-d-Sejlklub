using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Medlem;

public class RedigerMedlemModel : PageModel
{
    private IMemberService _medlemService;

    [BindProperty]
    public ClassLibrary.Core.Models.Member Medlem { get; set; }

    public RedigerMedlemModel(IMemberService medlemService)
    {
        _medlemService = medlemService;
    }

    public IActionResult OnGet(string email)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("Medlemmer");
        }

        Medlem = _medlemService.GetMember(email);
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _medlemService.UpdateMember(Medlem);
        return RedirectToPage("Medlemmer");
    }
}
