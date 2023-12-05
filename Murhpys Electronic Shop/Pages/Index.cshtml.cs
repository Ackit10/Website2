using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Murhpys_Electronic_Shop.Models;
using Microsoft.EntityFrameworkCore;
namespace Murhpys_Electronic_Shop.Pages;

public class IndexModel : PageModel
{
     private readonly Murhpys_Electronic_Shop.Data.Murhpys_Electronic_ShopContext _context;
     public IList<Items> Items { get; set; } = default!;

       
        
    public IndexModel (Murhpys_Electronic_Shop.Data.Murhpys_Electronic_ShopContext context)
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


