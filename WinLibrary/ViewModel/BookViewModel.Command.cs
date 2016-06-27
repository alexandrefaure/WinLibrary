using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WinLibrary.AmazonAPI;
using WinLibrary.Model;
using WinLibrary.Views;

namespace WinLibrary.ViewModel
{
    public partial class BookViewModel
    {
        public string ApplicationName = "WinLibrary";

        private ICommand _addBookCommand;
        private readonly bool _canExecute;
        private ICommand _purgeAllBooksCommand;
        private ICommand _loadDummyBooksCommand;
        private ICommand _getBookFromAmazonCommand;
        private ICommand _shutdownAppCommand;

        public ICommand AddBookCommand
        {
            get { return _addBookCommand ?? (_addBookCommand = new CommandHandler(AddBook, _canExecute)); }
        }

        public ICommand PurgeAllBooksCommand
        {
            get { return _purgeAllBooksCommand ?? (_purgeAllBooksCommand = new CommandHandler(PurgeAllDatabase, _canExecute)); }
        }

        public ICommand LoadDummyBooksCommand
        {
            get { return _loadDummyBooksCommand ?? (_loadDummyBooksCommand = new CommandHandler(LoadDummyBooks, _canExecute)); }
        }

        public ICommand GetBookFromAmazonCommand
        {
            get { return _getBookFromAmazonCommand ?? (_getBookFromAmazonCommand = new CommandHandler(param => GetBookFromAmazon(param), _canExecute)); }
        }

        public ICommand ShutdownAppCommand
        {
            get { return _shutdownAppCommand ?? (_shutdownAppCommand = new CommandHandler(param => ShutDownApp(param), _canExecute)); }
        }

        private void ShutDownApp(object o)
        {
            var messageBoxResult = MessageBox.Show("Voulez-vous vraiment quitter WinLibrary ?", ApplicationName,
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void LoadDummyBooks(object obj)
        {
            var livre1 = AmazonApi.GetBook("9782100738748");
            var livre2 = AmazonApi.GetBook("9782754038652");
            var livre3 = AmazonApi.GetBook("9782212558517");
            var livre4 = AmazonApi.GetBook("9782749142555");
            var livre5 = AmazonApi.GetBook("9782218977275");
            var livre6 = AmazonApi.GetBook("9782742716555");
            var livre7 = AmazonApi.GetBook("9782067197251");
            var livre8 = AmazonApi.GetBook("9782960142907");
            var livre9 = AmazonApi.GetBook("9782221066881");
            var livre10 = AmazonApi.GetBook("9782749916347");
            BookObservableCollection.AddRange(new List<Book>
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

        public void AddBook(object obj)
        {
            var saveBookWindow = new SaveBookWindow();
            saveBookWindow.ShowDialog();

            if (saveBookWindow.IsBookNeedToSave)
            {
                var testBook = new Book
                {
                    Title = saveBookWindow.BookToSaveTitle,
                    Author = saveBookWindow.BookToSaveAuthor,
                    Editor = saveBookWindow.BookToSaveEditor,
                    PublishedYear = saveBookWindow.BookToSaveYear,
                    PagesNumber = saveBookWindow.BookToSavePages,
                    Isbn = saveBookWindow.IsbnBox.Text,
                    CoverImage = saveBookWindow.BookToSaveCoverImageUrl
                };
                BookObservableCollection.Add(testBook);
            }
        }

        public void PurgeAllDatabase(object obj)
        {
            BookObservableCollection.DeleteAllBooks();
        }

        private void GetBookFromAmazon(object param)
        {
            var canvas = (SaveBookWindow) param;
            if (canvas.IsbnBox.Text != string.Empty)
            {
                var book = AmazonAPI.AmazonApi.GetBook(canvas.IsbnBox.Text);
                canvas.TitleBox.Text = book.Title;
                canvas.AuthorBox.Text = book.Author;
                canvas.EditorBox.Text = book.Editor;
                canvas.YearBox.Text = book.PublishedYear;
                canvas.PagesNumberBox.Text = book.PagesNumber.ToString();

                var bitmap = ReturnImageFromUrl(book.CoverImage);
                canvas.CoverImage.Source = bitmap;
                canvas.BookToSaveCoverImageUrl = book.CoverImage;
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
           return BookObservableCollection.Get(text);
        }
    }
}