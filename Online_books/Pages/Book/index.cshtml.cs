using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_books.Data;

namespace Online_books.Pages.Book
{
    [Authorize(Policy = "UserPolicy")]    
    public class indexModel : PageModel
    {
        private ApplicationDbContext db;

        public indexModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IEnumerable<Models.Book> Books { get; set; }
        [FromQuery]
        public int id { get; set; }


        public async Task OnGet()
        {
            Books = await db.Books.Include("Category").ToListAsync();
        }        
    }
}