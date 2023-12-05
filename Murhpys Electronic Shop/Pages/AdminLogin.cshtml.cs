using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Murhpys_Electronic_Shop.Pages
{
	public class AdminLoginModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; } = default!;
        [BindProperty]
        public string Password { get; set; } = default!;

        public string Message { get; set; } = default!;
        public string color { get; set; } = default!;


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (UserName == "Admin" && Password == "Password")
            {
                return RedirectToPage("/AdminField/Index");
            }
            else
            {
                Message = "Wrong Username or Password";
                color = "red";
                return Page();
            }
        }
    }
}
