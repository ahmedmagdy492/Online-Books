using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_books.Data;

namespace Online_books.Pages.Book
{
    public class DownloadModel : PageModel
    {
        private ApplicationDbContext db;

        public DownloadModel(ApplicationDbContext _db)
        {
            db = _db;
        }

        [FromQuery]
        public int id { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var book = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
            return File(Path.Combine("files", book.Url), "application/pdf");
        }
    }
}