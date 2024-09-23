using KoiCenter.Data.Models;
using KoiCenter.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCenter.WebApp.Pages.KoiFish
{
    public class CreateModel : PageModel
    {
        private readonly PetService _petService;
        public CreateModel(PetService petService)
        {
            _petService = petService;
        }



        [BindProperty]
        public Pet Pet { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _petService
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
