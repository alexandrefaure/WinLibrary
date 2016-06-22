using WinLibrary.Entity;

namespace WinLibrary.DAL
{
    public class BookDAL
    {
        public static void SaveBook(Book book)
        {
            using (var db = new DatabaseEntities())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }
    }
}
