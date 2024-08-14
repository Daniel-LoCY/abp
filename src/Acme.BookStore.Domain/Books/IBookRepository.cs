using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Books
{
    public interface IBookRepository : IBasicRepository<Book, Guid>
    {
        Task<List<Book>> GetByNameAsync(
            string bookname,
            bool includeDetails = true,
            CancellationToken cancellationToken = default);
    }
}
