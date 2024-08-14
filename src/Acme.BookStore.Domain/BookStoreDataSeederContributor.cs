using System;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class BookStoreDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;

        public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            // if (await _bookRepository.GetCountAsync() <= 0)
            // {
            //     await _bookRepository.InsertAsync(
            //         new Book
            //         {
            //             Name = "test",
            //             // Type = BookType.Dystopia,
            //             PublishDate = new DateTime(2024, 5, 1),
            //             Price = 0.1f
            //         },
            //         autoSave: true
            //     );
            // }
        }
    }
}
