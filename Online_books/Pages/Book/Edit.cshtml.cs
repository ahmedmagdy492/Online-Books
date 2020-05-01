using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_books.Data;

namespace Online_books.Pages.Book
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext db;
        private IWebHostEnvironment env;

        public EditModel(ApplicationDbContext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }

        [FromQuery]
        public int id { get; set; }
        [BindProperty]
        public Models.Book Book { get; set; }
        public SelectList LanguageCategories { get; set; }
        public SelectList Categories { get; set; }
        [BindProperty]
        public IFormFile PdfFile { get; set; }
        [BindProperty]
        public IFormFile ImgFile { get; set; }


        public async Task<IActionResult> OnGet()
        {
            Book = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
            LanguageCategories = new SelectList(await db.LanguageCategories.ToListAsync(), "Id", "Name");
            Categories = new SelectList(await db.Categories.ToListAsync(), "Id", "Name");
            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                #region files code
                if (PdfFile != null || ImgFile != null)
                {
                    if (PdfFile != null)
                    {
                        #region pdf file
                        string pdfFileName = Guid.NewGuid().ToString() + Path.GetFileName(PdfFile.FileName);
                        string pdfFilePath = Path.Combine(env.WebRootPath, "files");
                        string fullPath = Path.Combine(pdfFilePath, pdfFileName);
                        Book.Url = pdfFileName;
                        await PdfFile.CopyToAsync(new FileStream(fullPath, FileMode.Create));
                        #endregion
                    }
                    if (ImgFile != null)
                    {
                        #region img file
                        string imgFileName = Guid.NewGuid().ToString() + Path.GetFileName(ImgFile.FileName);
                        string imgFilePath = Path.Combine(env.WebRootPath, "imgs");
                        string imgFullPath = Path.Combine(imgFilePath, imgFileName);
                        Book.ImgUrl = imgFileName;
                        await ImgFile.CopyToAsync(new FileStream(imgFullPath, FileMode.Create));
                        #endregion
                    }
                }
                #endregion
                var oldBook = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
                if (oldBook == null)
                {
                    return NotFound();
                }
                oldBook.Name = Book.Name;
                oldBook.Auther = Book.Auther;
                oldBook.CategoryId = Book.CategoryId;
                oldBook.LangCategoryId = Book.LangCategoryId;
                oldBook.Description = Book.Description;

                db.Entry(oldBook).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToPage("index");
            }            
            return Page();
        }
    }
}