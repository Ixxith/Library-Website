using Library_Website.Models;
using Library_Website.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // Create private variable for book repository to be used in Index view
        private IBookRepository _repository;

        // Set items per page
        public int PageSize = 5;
        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int page = 1)
        {
            // Pass BookListViewModel the repository with books to index page. Order by BookId and skip items according to page number and takes only PageSize number of item
            return View(
                new BookListViewModel
                {
                    books = _repository.books
                            .Where(b => category == null || b.Category == category)
                            .OrderBy(b => b.BookId)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize),

                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalNumItems = category == null ? _repository.books.Count() : _repository.books.Where(b => b.Category == category).Count()
                    },

                    CurrentCategory = category
                }

                

                );
        }

     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
