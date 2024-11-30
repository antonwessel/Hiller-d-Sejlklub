using ClassLibrary.Interfaces;
using ClassLibrary.MockData;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Medlem;

public class MedlemmerModel : PageModel
{
    private IMedlemService _medlemService;

    public List<ClassLibrary.Models.Medlem> Medlemmer { get; set; }

    public MedlemmerModel(IMedlemService medlemService)
    {
        _medlemService = medlemService;
    }

    public void OnGet()
    {
        Medlemmer = _medlemService.GetMedlemmer();
    }
}