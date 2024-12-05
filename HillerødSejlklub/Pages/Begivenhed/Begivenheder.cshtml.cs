using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary.Models;
using ClassLibrary.Services;
using ClassLibrary.Interfaces;

namespace HillerødSejlklub.Pages.Begivenhed
{
    public class BegivenhederModel : PageModel
    {
        private IBegivenhedService _begivenhedService;


        public List<Event> Begivenheder { get; set; }

        public BegivenhederModel(IBegivenhedService begivenhedService)
        {
            _begivenhedService = begivenhedService;
        }


        public void OnGet()
        {
            Begivenheder = _begivenhedService.GetEvents();
        }
    }
}
