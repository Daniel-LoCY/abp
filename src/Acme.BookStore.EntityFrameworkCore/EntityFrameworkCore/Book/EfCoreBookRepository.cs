using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;

namespace Acme.BookStore.Books
{
    public class EfCoreBookRepository : EfCoreRepository<BookStoreDbContext, Book, Guid>, IBookRepository
    {
        public EfCoreBookRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        //查詢
        public async Task<List<Book>> GetByNameAsync(
            string bookname,
            bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {

            var dbSet = await GetDbSetAsync();

            // 查找所有 Time 等于指定 time 的记录
            var query = dbSet.Where(cg => cg.bookname == bookname);

            if (includeDetails)
            {
                // 如果有需要加载的导航属性，可以在这里 Include
                // 例如：query = query.Include(cg => cg.Author);
            }

            // 返回符合条件的所有记录
            return await query.ToListAsync(GetCancellationToken(cancellationToken));
        }
        /*public async Task<Book> GetUserByGenderAsync(string gender)
        {
            Console.WriteLine("select");
            return await (await GetDbSetAsync())
                .FromSqlRaw($"select * from AbpUsers where Gender == '{gender}'")
                .FirstOrDefaultAsync();
        }*/
    }
}
