using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_books.Data;

namespace Online_books.Pages.Book
{
    public class DetailsModel : PageModel
    {
        private ApplicationDbContext db;

        public DetailsModel(ApplicationDbContext _db)
        {
            db = _db;
        }

        public Models.Book Book { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Book = await db.Books.FirstOrDefaultAsync(b => b.Id == id);

            if(Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}