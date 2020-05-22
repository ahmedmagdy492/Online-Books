using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_books.Data;

namespace Online_books.Pages.Book
{
    [Authorize(Policy = "AdminPolicy")]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public DeleteModel(ApplicationDbContext _db)
        {
            db = _db;
        }

        [FromQuery]
        public int id { get; set; }
        [BindProperty]
        public Models.Book Book { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Book = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
            if(Book == null)
            {
                return NotFound();
            }                        
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {            
            if (Book == null)
            {
                return NotFound();
            }
            db.Books.Remove(Book);
            await db.SaveChangesAsync();
            return RedirectToPage("index");
        }
    }
}