using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Website.Models
{
    // Provides Database Context, stores database set of Books
    public class BookDBContext : DbContext
    {
        public BookDBContext (DbContextOptions<BookDBContext> options) : base(options)
        {

        }

        public DbSet <Book> books { get; set; }
    }
}
