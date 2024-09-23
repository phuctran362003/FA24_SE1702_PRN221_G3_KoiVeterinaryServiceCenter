using KoiCenter.Data.Models;
using KoiCenter.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCenter.WebApp.Pages.KoiFish
{
    public class IndexModel : PageModel
    {
        //private readonly KoiCenter.Data.Models.FA24_SE1702_PRN221_G3_KoiVeterinaryServiceCenterContext _context;
        private readonly PetService _petService;

        public IndexModel(PetService petService)
        {
            _petService = petService;
        }

        public IList<Pet> Pet { get; set; } = default!;

        public async Task OnGetAsync()
        {

            Pet = (await _petService.GetAll()).Data as IList<Pet>;
        }
    }
}
