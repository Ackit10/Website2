using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Murhpys_Electronic_Shop.Data;
using Murhpys_Electronic_Shop.Models;

namespace Murhpys_Electronic_Shop.Pages.EmailsDatabase
{
    public class DetailsModel : PageModel
    {
        private readonly Murhpys_Electronic_Shop.Data.EmailsDatabaseContext _context;

        public DetailsModel(Murhpys_Electronic_Shop.Data.EmailsDatabaseContext context)
        {
            _context = context;
        }

      public Emails Emails { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Emails == null)
            {
                return NotFound();
            }

            var emails = await _context.Emails.FirstOrDefaultAsync(m => m.Id == id);
            if (emails == null)
            {
                return NotFound();
            }
            else 
            {
                Emails = emails;
            }
            return Page();
        }
    }
}
