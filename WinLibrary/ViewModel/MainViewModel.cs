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
using WinLibrary.Model;
using WinLibrary.Services;
using WinLibrary.Views;

namespace WinLibrary.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly bool _canExecute;

        private readonly Window _currentWindow =
            Application.Current.Windows.OfType<Window>().LastOrDefault(x => x.IsActive);

        private readonly Entities _dataContext = new Entities();

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

        public MainViewModel()
        {
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
        public ObservableCollection<Book> BooksCollection { get; set; }
        public BookService BookService { get; set; }

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
            var livre1 = googleApi.GetBook("9782100738748");
            var livre2 = googleApi.GetBook("9782754038652");
            var livre3 = googleApi.GetBook("9782212558517");
            var livre4 = googleApi.GetBook("9782749142555");
            var livre5 = googleApi.GetBook("9782218977275");
            var livre6 = googleApi.GetBook("9782742716555");
            var livre7 = googleApi.GetBook("9782067197251");
            var livre8 = googleApi.GetBook("9782960142907");
            var livre9 = googleApi.GetBook("9782221066881");
            var livre10 =googleApi.GetBook("9782749916347");
            BookService.AddRange(new List<Book>
            {
                livre1,
                livre2,
                livre3,
                livre4,
                livre5,
                livre6,
                livre7,
                livre8,
                livre9,
                livre10
            });
        }

        public void PurgeAllDatabase()
        {
            BookService.DeleteAllBooks();
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
            return BookService.Get(text);
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
    }
}