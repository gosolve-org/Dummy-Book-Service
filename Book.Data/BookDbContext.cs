using System.Diagnostics;
using GoSolve.Dummy.Book.Data.Models;
using GoSolve.Dummy.Book.Data.Seeders;
using GoSolve.Dummy.Book.Data.Seeders.TestDataSeeders;
using GoSolve.Tools.Common.Database.Models;
using GoSolve.Tools.Common.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace GoSolve.Dummy.Book.Data
{
    public class BookDbContext : BaseDbContext<BookDbContext>
    {
        public DbSet<Models.Book> Books { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        private readonly BookGenreSeeder _bookGenreSeeder;
        private readonly BookTestDataSeeder _bookTestDataSeeder;

        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
            _bookGenreSeeder = new BookGenreSeeder();
            _bookTestDataSeeder = new BookTestDataSeeder();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Book>()
                .HasOne(b => b.Genre)
                .WithMany();

            modelBuilder.SeedCoreData(builder =>
                builder.AddSeeder<BookGenreSeeder>());
        }
    }
}
