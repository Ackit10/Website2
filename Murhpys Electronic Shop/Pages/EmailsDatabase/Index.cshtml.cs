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
    public class IndexModel : PageModel
    {
        private readonly Murhpys_Electronic_Shop.Data.EmailsDatabaseContext _context;

        public IndexModel(Murhpys_Electronic_Shop.Data.EmailsDatabaseContext context)
        {
            _context = context;
        }

        public IList<Emails> Emails { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Emails != null)
            {
                Emails = await _context.Emails.ToListAsync();
            }
        }
    }
}
