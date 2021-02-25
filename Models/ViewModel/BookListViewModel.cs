using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Website.Models.ViewModel
{
    // This class is used to create a view model for the Book class / table
    public class BookListViewModel
    {
        public IEnumerable<Book> books { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
