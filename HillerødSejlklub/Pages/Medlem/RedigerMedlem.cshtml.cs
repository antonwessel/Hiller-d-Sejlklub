using ClassLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Medlem;

public class RedigerMedlemModel : PageModel
{
    private IMedlemService _medlemService;

    [BindProperty]
    public ClassLibrary.Models.Medlem Medlem { get; set; }

    public RedigerMedlemModel(IMedlemService medlemService)
    {
        _medlemService = medlemService;
    }

    public IActionResult OnGet(string email)
    {
        Medlem = _medlemService.GetMedlem(email);
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _medlemService.UpdateMedlem(Medlem);
        return RedirectToPage("Medlemmer");
    }
}
