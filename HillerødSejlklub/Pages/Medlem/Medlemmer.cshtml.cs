using ClassLibrary.Interfaces;
using ClassLibrary.MockData;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Medlem;

public class MedlemmerModel : PageModel
{
    private IMedlemService _medlemService;

    [BindProperty]
    public string NameSearch { get; set; }

    public List<ClassLibrary.Models.Medlem> Medlemmer { get; set; }

    public MedlemmerModel(IMedlemService medlemService)
    {
        _medlemService = medlemService;
    }

    public void OnGet()
    {
        Medlemmer = _medlemService.GetMedlemmer();
    }

    public IActionResult OnPostSearch()
    {
        if (NameSearch != null)
        {
            Medlemmer = _medlemService.FilterMembersByName(NameSearch.Trim());
        }
        else
        {
            Medlemmer = _medlemService.GetMedlemmer();
        }
        return Page();
    }
}