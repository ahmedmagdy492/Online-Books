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
    public class DeleteModel : PageModel
    {
        private ApplicationDbContext db;

        public DeleteModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        
        [BindProperty]
        public Models.Category Category { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Category = await db.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if(Category == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category != null)
            {
                db.Categories.Remove(Category);
                await db.SaveChangesAsync();
                return RedirectToPage("index");
            }
            return NotFound();
        }
    }
}