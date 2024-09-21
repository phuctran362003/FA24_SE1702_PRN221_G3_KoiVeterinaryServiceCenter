﻿using KoiCenter.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiFarmShop.RazorWebApp.Pages.KoiFish
{
    public class DetailsModel : PageModel
    {
        private readonly FA24_SE1702_PRN221_G3_KoiVeterinaryServiceCenterContext _context;

        public DetailsModel(FA24_SE1702_PRN221_G3_KoiVeterinaryServiceCenterContext context)
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