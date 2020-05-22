using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_books.Data;
using Online_books.Models;

namespace Online_books.Pages.LanguageCategory
{
    [Authorize(Policy = "AdminPolicy")]
    public class indexModel : PageModel
    {
        private ApplicationDbContext db;

        public indexModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IEnumerable <RealLanguageCategory> LanguageCategories { get; set; }
        public async Task OnGet()
        {
            LanguageCategories = await db.LanguageCategories.ToListAsync();
        }
    }
}