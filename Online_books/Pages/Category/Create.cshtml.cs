using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_books.Data;

namespace Online_books.Pages.Category
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext db;

        public CreateModel(ApplicationDbContext _db)
        {
            db = _db;
        }


        [BindProperty]
        public Models.Category Category { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var oldCate = await db.Categories.FirstOrDefaultAsync(c => c.Name == Category.Name);
                if(oldCate == null)
                {
                    await db.Categories.AddAsync(Category);
                    await db.SaveChangesAsync();
                    return RedirectToPage("index");
                }                
            }
            return Page();
        }
    }
}