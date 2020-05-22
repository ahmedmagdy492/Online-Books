using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_books.Data;

namespace Online_books.Pages.Book
{
    [Authorize(Policy = "AdminPolicy")]
    public class CreateModel : PageModel
    {
        private ApplicationDbContext db;
        private IWebHostEnvironment env;

        public CreateModel(ApplicationDbContext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }

        [BindProperty]
        public Models.Book Book { get; set; }
        [BindProperty]
        public IFormFile PdfFile { get; set; }
        [BindProperty]
        public IFormFile ImgFile { get; set; }
        public SelectList Categories { get; set; }
        public SelectList LangCategories { get; set; }

        public async Task OnGet()
        {
            Categories = new SelectList(await db.Categories.ToListAsync(), "Id", "Name");
            LangCategories = new SelectList(await db.LanguageCategories.ToListAsync(), "Id", "Name");
        }

        public async Task<IActionResult> OnPost()
        {
            if(PdfFile == null || ImgFile == null)
            {
                return BadRequest();
            }
            else
            {
                Book.CreationDate = DateTime.Now;
                if(ModelState.IsValid)
                {
                    #region pdf file
                    string pdfFileName = Guid.NewGuid().ToString() + Path.GetFileName(PdfFile.FileName);
                    string pdfFilePath = Path.Combine(env.WebRootPath, "files");
                    string fullPath = Path.Combine(pdfFilePath, pdfFileName);
                    Book.Url = pdfFileName;
                    await PdfFile.CopyToAsync(new FileStream(fullPath, FileMode.Create));
                    #endregion

                    #region img file
                    string imgFileName = Guid.NewGuid().ToString() + Path.GetFileName(ImgFile.FileName);
                    string imgFilePath = Path.Combine(env.WebRootPath, "imgs");
                    string imgFullPath = Path.Combine(imgFilePath, imgFileName);
                    Book.ImgUrl = imgFileName;
                    await ImgFile.CopyToAsync(new FileStream(imgFullPath, FileMode.Create));
                    #endregion

                    await db.Books.AddAsync(Book);
                    await db.SaveChangesAsync();
                    return RedirectToPage("index");
                }
                return Page();
            }
        }
    }
}