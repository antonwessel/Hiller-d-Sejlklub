using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Medlem;

public class SletMedlemModel : PageModel
{
    private IMedlemService _medlemService;

    [BindProperty]
    public ClassLibrary.Core.Models.Medlem Medlem { get; set; }

    public SletMedlemModel(IMedlemService medlemService)
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

        // 'asp-route-email' under Medlemmer.cshtml bliver brugt med parameter 'email'. Argumentet til email bliver givet når man klikker (router) til denne page.

        Medlem = _medlemService.GetMedlem(email);
        return Page();
    }

    public IActionResult OnPost()
    {
        _medlemService.DeleteMedlem(Medlem.Email);
        return RedirectToPage("Medlemmer");
    }
}
