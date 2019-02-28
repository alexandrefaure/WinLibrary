using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WinLibrary.AmazonAPI;
using WinLibrary.DAL;
using WinLibrary.Model;
using WinLibrary.Views;

namespace WinLibrary.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly bool _canExecute;

        //private readonly Window _currentWindow =
        //    Application.Current.Windows.OfType<Window>().LastOrDefault(x => x.IsActive);

        //private readonly Entities _dataContext = new Entities();

        private ICommand _addBookCommand;


        private Book _currentBook;
        private ICommand _loadDummyBooksCommand;
        private ICommand _purgeAllBooksCommand;


        //private ICommand _getBookFromAmazonCommand;
        private ICommand _shutdownAppCommand;

        public string ApplicationName = "WinLibrary";
        private GoogleApi googleApi;
        private ObservableCollection<Book> _booksCollection;
        private BookDal bookDal;

        public ObservableCollection<Book> BooksCollection
        {
            get
            {
                return _booksCollection;
            }
            set
            {
                _booksCollection = value;
                RaisePropertyChanged(nameof(BooksCollection));
            }
        }

        public MainViewModel()
        {
            bookDal = new BookDal();
            BooksCollection = new ObservableCollection<Book>(bookDal.GetBooks());
            googleApi = new GoogleApi();
            AddBookCommand = new RelayCommand(AddBook, () => true);
            PurgeAllBooksCommand = new RelayCommand(PurgeAllDatabase, () => true);
            LoadDummyBooksCommand = new RelayCommand(LoadDummyBooks, () => true);
            ShutdownAppCommand = new RelayCommand(ShutDownApp, () => true);
        }

        public RelayCommand AddBookCommand { get; }
        public RelayCommand PurgeAllBooksCommand { get; }
        public RelayCommand LoadDummyBooksCommand { get; }
        public RelayCommand ShutdownAppCommand { get; }

        public Book CurrentBook
        {
            get => _currentBook;
            set
            {
                _currentBook = value;
                RaisePropertyChanged(nameof(_currentBook));
            }
        }

        private void AddBook()
        {
            var saveBookWindow = new SaveBookWindow();
            saveBookWindow.ShowDialog();

            var saveBookViewModel = saveBookWindow.DataContext as SaveBookViewModel;
            if (saveBookViewModel != null)
            {
                BooksCollection.Add(saveBookViewModel.CurrentBook);
            }
        }

        private void ShutDownApp()
        {
            var messageBoxResult = MessageBox.Show("Voulez-vous vraiment quitter WinLibrary ?", ApplicationName,
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes) Application.Current.Shutdown();
        }

        private void LoadDummyBooks()
        {
            BooksCollection.Add(googleApi.GetBook("9782100738748"));
            BooksCollection.Add(googleApi.GetBook("9782754038652"));
            BooksCollection.Add(googleApi.GetBook("9782212558517"));
            BooksCollection.Add(googleApi.GetBook("9782749142555"));
            BooksCollection.Add(googleApi.GetBook("9782218977275"));
            BooksCollection.Add(googleApi.GetBook("9782742716555"));
            BooksCollection.Add(googleApi.GetBook("9782067197251"));
            //BooksCollection.Add(googleApi.GetBook("9782960142907"));
            BooksCollection.Add(googleApi.GetBook("9782221066881"));
            BooksCollection.Add(googleApi.GetBook("9782749916347"));
        }

        public void PurgeAllDatabase()
        {
            DeleteAllBooks();
        }

        private void GetBookFromAmazon(object param)
        {
            var canvas = (SaveBookWindow) param;
            if (canvas.IsbnBox.Text != string.Empty)
            {
                var book = googleApi.GetBook(canvas.IsbnBox.Text);
                canvas.TitleBox.Text = book.Title;
                canvas.AuthorBox.Text = book.Author;
                canvas.EditorBox.Text = book.Editor;
                //canvas.YearBox.Text = book.PublishedYear;
                canvas.PagesNumberBox.Text = book.PagesNumber.ToString();

                //var bitmap = ReturnImageFromUrl(book.CoverImage);
                //canvas.CoverImage.Source = bitmap;
                //canvas.BookToSaveCoverImageUrl = book.CoverImage;
            }
        }

        public Book GetBook(string text)
        {
            return Get(text);
        }

        public void Add(Book testBook)
        {
            if (testBook != null)
            {
                BooksCollection.Add(testBook);
                bookDal.Add(testBook);
            }
        }

        public void DeleteAllBooks()
        {
            BooksCollection.Clear();
            //bookDal.C();
        }

        public void AddRange(List<Book> books)
        {
            foreach (var book in books)
            {
                Add(book);
            }
        }

        public Book Get(string isbn)
        {
            Book book = null;
            if (BooksCollection.Any())
            {
                book = BooksCollection.First(bk => bk.Isbn == isbn);
            }
            return book;
        }
    }
}