using GoSolve.Tools.Common.Database.Models;

namespace GoSolve.Dummy.Book.Data.Models;

public class Book : BaseEntity<int>
{
    public string Title { get; set; }
    public int AmountOfPages { get; set; }
    public int GenreId { get; set; }
    public BookGenre Genre { get; set; }
}
