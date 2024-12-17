using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Medlem;

public class TilføjMedlemModel : PageModel
{
    private IMemberService _medlemService;

    [BindProperty]
    public ClassLibrary.Core.Models.Member Medlem { get; set; }

    public TilføjMedlemModel(IMemberService medlemService)
    {
        _medlemService = medlemService;
    }

    public IActionResult OnGet()
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("Medlemmer");
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _medlemService.AddMember(Medlem);
        return RedirectToPage("Medlemmer");
    }
}