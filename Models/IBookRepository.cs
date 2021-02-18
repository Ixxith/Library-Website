using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Website.Models
{// Repository for the website
    public interface IBookRepository
    {
        IQueryable <Book> books { get;  }
    }
}
