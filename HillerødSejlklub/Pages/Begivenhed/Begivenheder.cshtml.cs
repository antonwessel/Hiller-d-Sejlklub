using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary.Models;
using ClassLibrary.Services;

namespace HillerødSejlklub.Pages.Begivenhed
{
    public class BegivenhederModel : PageModel
    {
        public string Navn {  get; set; }
        public List<Event> BegivenhedList { get; set; }


        public void OnGet()
        {
            BegivenhedService begivenhedservice = new BegivenhedService();
             BegivenhedList = begivenhedservice.GetBegivenheder();
        }
    }
}
