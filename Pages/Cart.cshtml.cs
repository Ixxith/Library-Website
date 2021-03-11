using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Website.Infrastructure;
using Library_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library_Website.Pages
{

    // Handles the razor page for the Cart
    public class CartModel : PageModel
    {
        // Retrieve and initilize the repository so we can query out of it
        private IBookRepository repository;

        public CartModel (IBookRepository repo)
        {
            repository = repo;
        }

        public BookCart Cart { get; set; }

        public string ReturnUrl { get; set; }

        
        // Used when a Get method is called 
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<BookCart>("cart") ?? new BookCart();
            
        }
        // Used for post methods, pass "Remove" as an additional string parameter to remove the item from cart, otherwise if null, the system will add 1 item to the cart.
        public IActionResult OnPost(long bookId, string returnUrl, string action)
        {
            Cart = HttpContext.Session.GetJson<BookCart>("cart") ?? new BookCart();

            if (action == null)
            {
                Book book = repository.books.FirstOrDefault(b => b.BookId == bookId);

                Cart.AddItem(book, 1);

            }
            else if (action=="Remove") {
                Book book = repository.books.FirstOrDefault(b => b.BookId == bookId);
                Cart.RemoveLine(book);
            }

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
