using System.Diagnostics;
using GoSolve.Dummy.Book.Data.Models;
using GoSolve.Tools.Common.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace GoSolve.Dummy.Book.Data
{
    public class BookDbContext : BaseDbContext<BookDbContext>
    {
        public DbSet<Models.Book> Books { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Book>()
                .HasOne(b => b.Genre)
                .WithMany();

            modelBuilder.Entity<Models.BookGenre>()
                .HasData(
                    new BookGenre
                    {
                        Id = 1,
                        Name = "Fiction",
                        Description = "Narrative storytelling with imaginary characters and events."
                    },
                    new BookGenre
                    {
                        Id = 2,
                        Name = "Non-fiction",
                        Description = "Narrative storytelling based on real events and factual information."
                    },
                    new BookGenre
                    {
                        Id = 3,
                        Name = "Mystery",
                        Description = "Narrative storytelling involving a crime or puzzle to be solved."
                    },
                    new BookGenre
                    {
                        Id = 4,
                        Name = "Romance",
                        Description = "Narrative storytelling centered on the romantic relationships of the characters."
                    },
                    new BookGenre
                    {
                        Id = 5,
                        Name = "Science fiction",
                        Description = "Narrative storytelling set in the future or in an alternative reality and involving scientific or technological elements."
                    });
        }
    }
}
