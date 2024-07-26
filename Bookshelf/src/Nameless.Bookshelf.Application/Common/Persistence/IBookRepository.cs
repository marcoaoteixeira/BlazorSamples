using Nameless.Bookshelf.Domain.Entities;

namespace Nameless.Bookshelf.Application.Common.Persistence {
    public interface IBookRepository {
        Task CreateAsync(Book book, CancellationToken cancellationToken);

        IQueryable<Book> Query();
    }
}
