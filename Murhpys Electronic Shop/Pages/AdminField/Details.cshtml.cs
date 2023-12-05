using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Murhpys_Electronic_Shop.Data;
using Murhpys_Electronic_Shop.Models;

namespace Murhpys_Electronic_Shop.Pages.AdminField
{
    public class DetailsModel : PageModel
    {
        private readonly Murhpys_Electronic_Shop.Data.Murhpys_Electronic_ShopContext _context;

        public DetailsModel(Murhpys_Electronic_Shop.Data.Murhpys_Electronic_ShopContext context)
        {
            _context = context;
        }

      public Items Items { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var items = await _context.Items.FirstOrDefaultAsync(m => m.Id == id);
            if (items == null)
            {
                return NotFound();
            }
            else 
            {
                Items = items;
            }
            return Page();
        }
    }
}
