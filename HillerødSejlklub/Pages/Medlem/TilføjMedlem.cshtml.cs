using ClassLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Medlem;

public class TilføjMedlemModel : PageModel
{
    private IMedlemService _medlemService;

    [BindProperty]
    public ClassLibrary.Models.Medlem Medlem { get; set; }

    public TilføjMedlemModel(IMedlemService medlemService)
    {
        _medlemService = medlemService;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _medlemService.AddMedlem(Medlem);
        return RedirectToPage("Medlemmer");
    }
}