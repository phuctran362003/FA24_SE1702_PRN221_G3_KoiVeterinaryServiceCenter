using KoiCenter.Data.Models;
using KoiCenter.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFarmShop.RazorWebApp.Pages.KoiFish
{
    public class IndexModel : PageModel
    {
        //private readonly KoiFarmShop.Data.Models.FA24_SE1702_PRN221_G3_KoiVeterinaryServiceCenterContext _context;
        private readonly PetService _petService;
        public IndexModel() => _petService ??= new PetService();
        public IList<Pet> Pet { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //Pet = await _context.Pets
            //    .Include(p => p.Owner)
            //    .Include(p => p.PetType).ToListAsync();

            //var result = await _petService.GetAll();

            //Pet = (IList<Pet>)result.Data;

            Pet = (await _petService.GetAll()).Data as IList<Pet>;

        }
    }
}
