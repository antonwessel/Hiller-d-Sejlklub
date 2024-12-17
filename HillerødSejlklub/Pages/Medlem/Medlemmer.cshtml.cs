using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Medlem;

public class MedlemmerModel : PageModel
{
    private IMemberService _medlemService;

    [BindProperty]
    public string NameSearch { get; set; }

    public List<ClassLibrary.Core.Models.Member> Medlemmer { get; set; }

    public MedlemmerModel(IMemberService medlemService)
    {
        _medlemService = medlemService;
    }

    public void OnGet()
    {
        Medlemmer = _medlemService.GetMembers();
    }

    public IActionResult OnPostSearch()
    {
        if (NameSearch != null)
        {
            Medlemmer = _medlemService.FilterMembersByName(NameSearch.Trim());
        }
        else
        {
            Medlemmer = _medlemService.GetMembers();
        }
        return Page();
    }
}