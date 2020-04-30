using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_books.Data;
using Online_books.Models;

namespace Online_books.Pages.Category
{
    public class indexModel : PageModel
    {
        private ApplicationDbContext db;

        public indexModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IEnumerable<Models.Category> Categories { get; set; }
        public async Task OnGet()
        {
            Categories = await db.Categories.ToListAsync();
        }
    }
}