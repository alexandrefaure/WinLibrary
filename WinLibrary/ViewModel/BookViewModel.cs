using System.Collections.ObjectModel;
using DevExpress.XtraPrinting.Native;
using WinLibrary.Model;

namespace WinLibrary.ViewModel
{
    public partial class BookViewModel
    {
        private readonly DatabaseEntities _dataContext = new DatabaseEntities();

        public BookViewModel()
        {
            _canExecute = true;
            BookObservableCollection = new BookObservableCollection(_dataContext.Books);
            _booksCollection = BookObservableCollection.BooksCollection;
        }

        public ObservableCollection<Book> _booksCollection { get; set; }
        public BookObservableCollection BookObservableCollection { get; set; }

        public bool IsBooksDatabaseEmpty()
        {
            return _booksCollection.IsEmpty();
        }
    }
}