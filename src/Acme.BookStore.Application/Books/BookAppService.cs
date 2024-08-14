using System;
using System.Data;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Data.SqlClient;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.Books
{
    public class BookAppService :
        CrudAppService<
            Book, //The Book entity
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBookDto>, //Used to create/update a book
        IBookAppService //implement the IBookAppService
    {
        protected IBookRepository BookRepository => LazyServiceProvider.LazyGetRequiredService<IBookRepository>();
        
        public BookAppService(IRepository<Book, Guid> repository)
            : base(repository)
        {

        }

        public async Task<PagedResultDto<BookDto>> GetByNameAsync(string bookname)
        {
            var book = await BookRepository.GetByNameAsync(bookname);
            if (book.Count == 0)
                throw new EntityNotFoundException($"This time '{bookname}' was not found");
            return new PagedResultDto<BookDto>(book.Count, ObjectMapper.Map<List<Book>, List<BookDto>>(book));
        }
    }
}

