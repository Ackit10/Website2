using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Murhpys_Electronic_Shop.Data;
using Murhpys_Electronic_Shop.Models;

namespace Murhpys_Electronic_Shop.Pages.EmailsDatabase
{
    public class CreateModel : PageModel
    {
        private readonly Murhpys_Electronic_Shop.Data.EmailsDatabaseContext _context;

        public CreateModel(Murhpys_Electronic_Shop.Data.EmailsDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Emails Emails { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Emails == null || Emails == null)
            {
                return Page();
            }

            _context.Emails.Add(Emails);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
