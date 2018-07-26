using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class TestBookController : Controller
    {
        // GET: TestBook
        public ActionResult Create()
        {
           
            List<SelectListItem> books = new List<SelectListItem>() {
                new SelectListItem() { Value="0", Text="-- Select Books --" },
            };

            ViewBag.BookId = books;

            List<SelectListItem> categories = new List<SelectListItem>() {
                new SelectListItem() { Value="1", Text="Category 1" },
                new SelectListItem() { Value="2", Text="Category 2" },
                new SelectListItem() { Value="3", Text="Category 3" }
            };

            return View(categories);

        }

        public ActionResult FillBooks(int? CategoryId)
        {
            List<Book> Books = new List<Book>()
            {
                new Book() { BookId= 1, CategoryId=1, BookName = "1984" },
                new Book() { BookId= 2, CategoryId=2, BookName = "The Adventures Of Huckleberry Finn" },
                new Book() { BookId= 3, CategoryId=3, BookName = "The Great Gatsby" },
                new Book() { BookId= 4, CategoryId=1, BookName = "Pride And Prejudice" },
                new Book() { BookId= 5, CategoryId=2, BookName = "Brave New World" },
                new Book() { BookId= 6, CategoryId=3, BookName = "To Kill A Mockingbird" },
            };

            return Json(Books.Where(m => m.CategoryId == CategoryId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(SelectdBook selectdBook)
        {

            var t = selectdBook;
            List<SelectListItem> categories = new List<SelectListItem>() {
                new SelectListItem() { Value="1", Text="Category 1" },
                new SelectListItem() { Value="2", Text="Category 2" },
                new SelectListItem() { Value="3", Text="Category 3" }
            };
            return RedirectToAction("FillBooks", "TestBook", selectdBook);
            
        }
    }
}