using System;
using GoSolve.Tools.Common.Database.Models;

namespace GoSolve.Dummy.Book.Data.Models
{
    public class BookGenre : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
