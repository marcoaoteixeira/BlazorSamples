using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nameless.Bookshelf.Application.Common.Persistence;
using Nameless.Bookshelf.Infrastructure.Books.Persistence;
using Nameless.Bookshelf.Infrastructure.Common.Persistence;

namespace Nameless.Bookshelf.Infrastructure {
    public static class ServiceCollectionExtension {
        public static IServiceCollection RegisterInfrastructureLayer(this IServiceCollection self)
            => self.RegisterPersistence();

        private static IServiceCollection RegisterPersistence(this IServiceCollection self)
            => self
               .AddDbContext<ApplicationDbContext>(configure => {
                   configure.UseSqlite("Data Source=bookshelf.db");
               })
               .AddScoped<IBookRepository, BookRepository>();
    }
}
