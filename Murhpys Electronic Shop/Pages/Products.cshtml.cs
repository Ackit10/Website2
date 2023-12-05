using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Murhpys_Electronic_Shop.Models;

namespace Murhpys_Electronic_Shop.Pages
{
	public class ProductsModel : PageModel
    {
        
        private readonly Murhpys_Electronic_Shop.Data.Murhpys_Electronic_ShopContext _context;
        public IList<Items> Items { get; set; } = default!;
        public ProductsModel(Murhpys_Electronic_Shop.Data.Murhpys_Electronic_ShopContext context)
        {
            _context = context;
        }
       
        public async Task OnGetAsync()
        {
            if (_context.Items != null)
            {
                Items = await _context.Items.ToListAsync();
            }
        }
    }
}
