using GoSolve.Dummy.Book.Data.Models;
using GoSolve.Tools.Common.Database.Models;
using GoSolve.Tools.Common.Database.Seeding.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoSolve.Dummy.Book.Data.Seeders.TestDataSeeders;

public class BookTestDataSeeder : ITestDataSeeder
{
    public IEnumerable<TimestampedEntity> BuildData()
    {
        return new Models.Book[]
        {
            new Models.Book
            {
                Id = 1,
                Title = "The Lost City of Atlantis",
                AmountOfPages = 356,
                GenreId = 1
            },
            new Models.Book
            {
                Id = 2,
                Title = "The History of the Roman Empire",
                AmountOfPages = 542,
                GenreId = 2
            },
            new Models.Book
            {
                Id = 3,
                Title = "The Case of the Missing Heirloom",
                AmountOfPages = 752,
                GenreId = 3
            },
            new Models.Book
            {
                Id = 4,
                Title = "Love in the Time of Cholera",
                AmountOfPages = 438,
                GenreId = 4
            },
            new Models.Book
            {
                Id = 5,
                Title = "Escape from Earth",
                AmountOfPages = 459,
                GenreId = 5
            }
        };
    }
}
