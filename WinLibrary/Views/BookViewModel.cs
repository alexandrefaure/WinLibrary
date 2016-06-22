using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using WinLibrary.Entity;

namespace WinLibrary.Views
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private static DatabaseEntities context;
        public BookViewModel()
        {
            context = new DatabaseEntities();
        }

        private string _bookTitle = "Entrez un titre";

        public string BookTitle
        {
            get { return _bookTitle; }
            set { _bookTitle = value; }
        }

        //public DbSet<Book> LoadAllBooks()
        //{
        //    return context.Books;
        //}

        //public void SaveBook(Book book)
        //{
        //    context.Books.Add(book);
        //    context.SaveChanges();
        //}
        public event PropertyChangedEventHandler PropertyChanged;
    }
}