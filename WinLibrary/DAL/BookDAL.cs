using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using WinLibrary.Model;

namespace WinLibrary.DAL
{
    public class BookDal
    {
        public static void SaveBook(Book book)
        {
            using (var databaseEntities = new Entities())
            {
                databaseEntities.Books.AddOrUpdate(book);
                databaseEntities.SaveChanges();
            }
        }

        public static List<Book> LoadAllBooks()
        {
            List<Book> booksCollection;
            using (var databaseEntities = new Entities())
            {
                booksCollection = databaseEntities.Books.ToList();
            }
            return booksCollection;
        }

        public static void Clear()
        {
            using (var databaseEntities = new Entities())
            {
                foreach (var bookEntry in databaseEntities.Books)
                {
                    databaseEntities.Books.Remove(bookEntry);
                }
                databaseEntities.SaveChanges();
            }
        }
    }
}
