using GoSolve.Dummy.Book.Data.Models;
using GoSolve.Tools.Common.Database.Models;
using GoSolve.Tools.Common.Database.Seeding.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoSolve.Dummy.Book.Data.Seeders;

public class BookGenreSeeder : ICoreDataSeeder
{
    public IEnumerable<TimestampedEntity> BuildData()
    {
        return new BookGenre[]
        {
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
            }
        };
    }
}
