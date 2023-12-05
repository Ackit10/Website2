using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Murhpys_Electronic_Shop.Data;
using Murhpys_Electronic_Shop.Models;

namespace Murhpys_Electronic_Shop.Pages.AdminField
{
    public class CreateModel : PageModel
    {
        private readonly Murhpys_Electronic_Shop.Data.Murhpys_Electronic_ShopContext _context;
        private readonly IHostEnvironment _environment;

        [BindProperty]
        public IFormFile UploadedFile { get; set; } = default!;

        public CreateModel(Murhpys_Electronic_ShopContext context, IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Items Items { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Items == null || Items == null)
            {
                return Page();
            }
            if (UploadedFile == null || UploadedFile.Length == 0)
            {
                return Page();
            }

            string targetFileName = $"{_environment.ContentRootPath}/wwwroot/images/{UploadedFile.FileName}";
            

            using (var stream = new FileStream(targetFileName, FileMode.Create))
            {
                await UploadedFile.CopyToAsync(stream);
            }
            Items.PhotoPath = $"/images/{UploadedFile.FileName}";
            _context.Items.Add(Items);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
