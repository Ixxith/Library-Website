using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Website.Models
{
    public class Book
        // Class for book object. Is stored in database. BookId is used as a key
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        // Use RegEx to ensure XXX-XXXXXXXXXX format where X is a number
        [RegularExpression(@"^[0-9]{3}[\-][0-9]{10}$",
                   ErrorMessage = "Entered ISBN format is not valid.")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
