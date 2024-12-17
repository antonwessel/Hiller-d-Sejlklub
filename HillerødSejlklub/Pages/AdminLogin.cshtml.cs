using ClassLibrary.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages;

public class AdminLoginModel : PageModel
{
    [BindProperty]
    public string UsernameInput { get; set; }

    [BindProperty]
    public string PasswordInput { get; set; }

    public string ErrorMessage { get; set; } // Til at gemme fejlbesked

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // forsøg at logge ind
        if (!AdminState.AdminLogin(UsernameInput, PasswordInput))
        {
            ErrorMessage = "Forkert brugerName eller adgangskode.";
            return Page();
        }

        return RedirectToPage();
    }

    public IActionResult OnPostLogout()
    {
        AdminState.Logout();
        return RedirectToPage();
    }
}