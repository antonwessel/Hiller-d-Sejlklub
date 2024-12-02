using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary.Models;
using ClassLibrary.Services;
using ClassLibrary.Interfaces;

namespace HillerødSejlklub.Pages.Begivenhed
{
    public class BegivenhederModel : PageModel
    {
        private IBegivenhedService _begivenhedService;

        public string Navn {  get; set; }
        public List<Event> BegivenhedList { get; set; }

        public BegivenhederModel(IBegivenhedService begivenhedService)
        {
            _begivenhedService = begivenhedService;
        }


        public void OnGet()
        {
            BegivenhedList = _begivenhedService.GetBegivenhed();
        }
    }
}
