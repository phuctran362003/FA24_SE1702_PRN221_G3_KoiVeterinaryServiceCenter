using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCenter.Data.Models;

namespace KoiCenter.WebApp.Pages.KoiFish
{
    public class DetailsModel : PageModel
    {
        private readonly KoiCenter.Data.Models.FA24_SE1702_PRN221_G3_KoiVeterinaryServiceCenterContext _context;

        public DetailsModel(KoiCenter.Data.Models.FA24_SE1702_PRN221_G3_KoiVeterinaryServiceCenterContext context)
        {
            _context = context;
        }

        public Pet Pet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets.FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }
            else
            {
                Pet = pet;
            }
            return Page();
        }
    }
}
