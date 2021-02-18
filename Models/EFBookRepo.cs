using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Website.Models
{// Use to create repository for the Book Class
    public class EFBookRepo : IBookRepository
    {
        private BookDBContext _context;

        public EFBookRepo (BookDBContext context)
        {
            _context = context;
        }
        public IQueryable<Book> books => _context.books;
    }
}
