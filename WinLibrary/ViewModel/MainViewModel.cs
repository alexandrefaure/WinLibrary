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
        private ICommand _closeWindowCommand;


        private Book _currentBook;
        private ICommand _loadDummyBooksCommand;
        private ICommand _purgeAllBooksCommand;

        private ICommand _saveButtonCommand;

        //private ICommand _getBookFromAmazonCommand;
        private ICommand _shutdownAppCommand;

        public string ApplicationName = "WinLibrary";
        private GoogleApi googleApi;
        public ObservableCollection<Book> BooksCollection { get; set; }

        public MainViewModel()
        {
            BooksCollection = new ObservableCollection<Book>();
            googleApi = new GoogleApi();
            AddBookCommand = new RelayCommand(AddBook, () => true);
            SaveButtonCommand = new RelayCommand(SaveButton, () => true);
            CloseWindowCommand = new RelayCommand(CloseWindow, () => true);
            PurgeAllBooksCommand = new RelayCommand(PurgeAllDatabase, () => true);
            LoadDummyBooksCommand = new RelayCommand(LoadDummyBooks, () => true);
            ShutdownAppCommand = new RelayCommand(ShutDownApp, () => true);
        }

        public RelayCommand AddBookCommand { get; }
        public RelayCommand SaveButtonCommand { get; }
        public RelayCommand CloseWindowCommand { get; }
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

            //if (saveBookWindow.IsBookNeedToSave)
            //{
            //    var testBook = new Book
            //    {
            //        Title = saveBookWindow.BookToSaveTitle,
            //        Author = saveBookWindow.BookToSaveAuthor,
            //        Editor = saveBookWindow.BookToSaveEditor,
            //        //PublishedYear = saveBookWindow.BookToSaveYear,
            //        //PagesNumber = saveBookWindow.BookToSavePages,
            //        Isbn = saveBookWindow.IsbnBox.Text,
            //        //CoverImage = saveBookWindow.BookToSaveCoverImageUrl
            //    };
            //    BookService.Add(testBook);
            //}
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

        internal static BitmapImage ReturnImageFromUrl(string url)
        {
            BitmapImage bitmap = null;
            if (!string.IsNullOrEmpty(url))
            {
                var fullFilePath = url;
                bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                bitmap.EndInit();
            }

            return bitmap;
        }

        public Book GetBook(string text)
        {
            return Get(text);
        }

        //todo refactor CloseWindow et SaveButton + virer les méthodes du xaml.cs dans le viewModel
        public void CloseWindow()
        {
            var saveBookWindow = Application.Current.Windows.OfType<SaveBookWindow>().LastOrDefault(x => x.IsActive);
            if (saveBookWindow != null)
            {
                saveBookWindow.IsBookNeedToSave = false;
                saveBookWindow.Close();
            }
        }

        private void SaveButton()
        {
            var saveBookWindow = Application.Current.Windows.OfType<SaveBookWindow>().LastOrDefault(x => x.IsActive);
            if (saveBookWindow != null)
            {
                saveBookWindow.IsBookNeedToSave = true;
                saveBookWindow.Close();
            }
        }

        public void Add(Book testBook)
        {
            if (testBook != null)
            {
                BooksCollection.Add(testBook);
                BookDal.SaveBook(testBook);
            }
        }

        public void DeleteAllBooks()
        {
            BooksCollection.Clear();
            BookDal.Clear();
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