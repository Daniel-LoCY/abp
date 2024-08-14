using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Pages.Books
{
    public class CreateModalModel : BookStorePageModel
    {
        [BindProperty]
        public SearchBookDto Book { get; set; }

        private readonly IBookAppService _bookAppService;

        public CreateModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        public void OnGet()
        {
            Book = new SearchBookDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var books = await _bookAppService.GetByNameAsync(Book.bookname);
            return new JsonResult(books.Items);;
        }
    }
}
