using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Books
{
    public class SearchBookDto
    {
        [Required]
        [StringLength(128)]
        public string bookname { get; set; }
    }
}
