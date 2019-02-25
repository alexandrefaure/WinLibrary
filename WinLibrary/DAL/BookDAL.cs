using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using WinLibrary.Model;

namespace WinLibrary.DAL
{
    public class BookDal
    {
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

        public void Update(Book currentBook)
        {
            using (var databaseEntities = new Entities())
            {
                databaseEntities.Books.AddOrUpdate(currentBook);
                databaseEntities.SaveChanges();
            }
        }

        public List<Book> GetBooks()
        {
            using (var databaseEntities = new Entities())
            {
                return databaseEntities.Books.ToList();
            }
        }
    }
}
