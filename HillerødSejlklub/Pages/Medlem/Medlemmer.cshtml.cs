using ClassLibrary.MockData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Medlem
{
    public class MedlemmerModel : PageModel
    {
        public List<ClassLibrary.Models.Medlem> Medlemmer { get; set; }

        public void OnGet()
        {
            Medlemmer = MockMedlem.GetMembersAsList();
        }
    }
}