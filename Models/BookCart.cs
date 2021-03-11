using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Website.Models
{
    // Is used to control Cart items and also contains methods for adding, removing, and clearing the cart.
    // Can also be called for statuses of the cart such as the cart total costs and cart total items
    public class BookCart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem(Book book, int quantity)
        {
            CartLine line = Lines.Where(b => b.book.BookId == book.BookId).FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    book = book,
                    Quanity = quantity,

                });
            }
            else
            {
                line.Quanity += quantity;
            }
        }

        public void RemoveLine (Book book)
        {
            Lines.RemoveAll(b => b.book.BookId == book.BookId);
        }

        public void Clear() => Lines.Clear();

        public double ComputeTotalSum() => Lines.Sum(e => e.book.Price * e.Quanity);

        public double ComputeTotalBooks() => Lines.Sum(e => e.Quanity);

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book book { get; set; }
            public int Quanity { get; set; }
        }
    }
}
