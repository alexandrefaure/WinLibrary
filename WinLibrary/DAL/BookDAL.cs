using System.Data.Entity;
using WinLibrary.Entity;

namespace WinLibrary.DAL
{
    public class BookDAL
    {
        public static void SaveBook(Book book)
        {
            using (var databaseEntities = new DatabaseEntities())
            {
                databaseEntities.Books.Add(book);
                databaseEntities.SaveChanges();
            }
        }

        public static DbSet<Book> LoadAllBooks()
        {
            using (var databaseEntities = new DatabaseEntities())
            {
                return databaseEntities.Books;
            }
        }
    }
}
