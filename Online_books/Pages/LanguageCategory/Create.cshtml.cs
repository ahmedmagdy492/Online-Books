using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Online_books.Data;
using Online_books.Models;

namespace Online_books.Pages.LanguageCategory
{
    [Authorize(Policy = "AdminPolicy")]
    public class CreateModel : PageModel
    {
        private ApplicationDbContext db;

        public CreateModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        [BindProperty]
        public RealLanguageCategory LanguageCategory { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await db.LanguageCategories.AddAsync(LanguageCategory);
                await db.SaveChangesAsync();
                return RedirectToPage("index");
            }
            else
            {
                return Page();
            }
        }
    }
}