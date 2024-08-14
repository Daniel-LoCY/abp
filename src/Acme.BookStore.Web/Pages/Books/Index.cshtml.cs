using System;
using System.Collections.Generic;
using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Web.Pages.Books;

public class IndexModel : BookStorePageModel
{
    public List<BookDto> BookDtos { get; set; }

    private readonly IBookAppService _bookAppService;

    public IndexModel(IBookAppService bookAppService)
    {
        _bookAppService = bookAppService;
    }

    public void OnGet()
    {
        BookDtos = new List<BookDto>();
        var result = _bookAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        BookDtos.AddRange(result.Result.Items);
    }
}
