using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net.Core.MVC.Basic.Models;

namespace Net.Core.MVC.Basic.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext db;
        [BindProperty]
        public Book Book { get; set; }
        public BookController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Book = new Book();
            if (id == null)
            {
                return View(Book);
            }

            Book = db.Books.FirstOrDefault(u => u.Id == id);
            if (Book == null)
                return NotFound();

            return View(Book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Book.Id == 0)
                {
                    db.Books.Add(Book);
                }
                else {
                    db.Books.Update(Book);
                }

                db.SaveChanges();
            }

            return View(Book);
        }

        #region APICalls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data=await db.Books.ToListAsync() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            var book = await db.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return Json(new { success=true, message = "Delete sucessful"});
        }
        #endregion
    }
}