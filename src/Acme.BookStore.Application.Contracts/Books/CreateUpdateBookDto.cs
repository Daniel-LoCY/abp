using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Books
{
    public class CreateUpdateBookDto
    {
        [Required]
        [StringLength(128)]
        public string bookname { get; set; }

        [Required]
        public float price { get; set; }
    }
}
