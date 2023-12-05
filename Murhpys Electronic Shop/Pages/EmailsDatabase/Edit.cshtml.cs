using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Murhpys_Electronic_Shop.Data;
using Murhpys_Electronic_Shop.Models;

namespace Murhpys_Electronic_Shop.Pages.EmailsDatabase
{
    public class EditModel : PageModel
    {
        private readonly Murhpys_Electronic_Shop.Data.EmailsDatabaseContext _context;

        public EditModel(Murhpys_Electronic_Shop.Data.EmailsDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Emails Emails { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Emails == null)
            {
                return NotFound();
            }

            var emails =  await _context.Emails.FirstOrDefaultAsync(m => m.Id == id);
            if (emails == null)
            {
                return NotFound();
            }
            Emails = emails;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Emails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailsExists(Emails.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmailsExists(int id)
        {
          return (_context.Emails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
