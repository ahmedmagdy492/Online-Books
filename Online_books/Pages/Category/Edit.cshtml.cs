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
    public class EditModel : PageModel
    {
        private ApplicationDbContext db;

        public EditModel(ApplicationDbContext _db)
        {
            db = _db;
        }

        [BindProperty]
        public Models.Category Category { get; set; }

        [FromQuery]
        public int id { get; set; }

        public async Task<IActionResult> OnGet()
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
            if(ModelState.IsValid)
            {
                var oldCate = await db.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if(oldCate == null)
                {
                    return NotFound();
                }
                oldCate.Name = Category.Name;
                db.Entry(oldCate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}