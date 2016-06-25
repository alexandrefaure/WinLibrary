using System;
using System.Collections.ObjectModel;
using DevExpress.XtraPrinting.Native;
using WinLibrary.Model;

namespace WinLibrary.ViewModel
{
    public partial class BookViewModel
    {
        private readonly DatabaseEntities _dataContext = new DatabaseEntities();
        public ObservableCollection<Book> BooksCollection { get; set; }
        public BookObservableCollection BookObservableCollection { get; set; }
        public BookViewModel()
        {
            _canExecute = true;
            BookObservableCollection = new BookObservableCollection(_dataContext.Books);
            BooksCollection = BookObservableCollection.BooksCollection;
        }

        public bool IsBooksDatabaseEmpty()
        {
            return BooksCollection.IsEmpty();
        }
    }
}