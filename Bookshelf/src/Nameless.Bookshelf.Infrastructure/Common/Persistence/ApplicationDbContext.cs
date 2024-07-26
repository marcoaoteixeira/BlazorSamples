using Microsoft.EntityFrameworkCore;
using Nameless.Bookshelf.Domain.Entities;

namespace Nameless.Bookshelf.Infrastructure.Common.Persistence {
    public class ApplicationDbContext : DbContext {
        public DbSet<Book> Books => Set<Book>();

        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Root).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
