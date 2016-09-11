using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DevExpress.XtraPrinting.Native;
using WinLibrary.Model;
using WinLibrary.Services;

namespace WinLibrary.ViewModel
{
    public partial class BookViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly DatabaseEntities _dataContext = new DatabaseEntities();
        public ObservableCollection<Book> BooksCollection { get; set; }
        public BookService BookService { get; set; }
        public BookViewModel()
        {
            _canExecute = true;
            BookService = new BookService(_dataContext.Books);
            BooksCollection = BookService.BooksCollection;
        }

        public bool IsBooksDatabaseEmpty()
        {
            return BooksCollection.IsEmpty();
        }

        private Book _currentBook;

        public Book CurrentBook
        {
            get { return _currentBook; }
            set
            {
                _currentBook = value;
                this.OnPropertyChanged("CurrentBook");
            }
        }
    }
}