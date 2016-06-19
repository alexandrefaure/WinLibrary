using System.Data.Entity;

namespace WinLibrary.Model
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
