using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Online_books.Data;

namespace Online_books.Controllers
{
    [Route("/api/Category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private ApplicationDbContext db;

        public CategoryController(ApplicationDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = db.Categories.ToList() });
        }
    }
}