using System.Collections.Generic;
using System.Windows.Input;
using WinLibrary.Model;
using WinLibrary.Views;

namespace WinLibrary.ViewModel
{
    public partial class BookViewModel
    {
        private ICommand _addBookCommand;
        private readonly bool _canExecute;
        private ICommand _purgeAllBooksCommand;
        private ICommand _loadDummyBooksCommand;

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

        private void LoadDummyBooks()
        {
            var livre1 = new Book
            {
                Title = "Les misérables",
                Author = "Victor Hugo",
                Editor = "Flamarion",
                PublishedYear = "1960",
                PagesNumber = 120
            };
            var livre2 = new Book
            {
                Title = "Le rouge et le noir",
                Author = "Stendhal",
                Editor = "Grasset",
                PublishedYear = "1780",
                PagesNumber = 253
            };
            var livre3 = new Book
            {
                Title = "Avant le big bang",
                Author = "Igor et Grichka Bogdanov",
                Editor = "Dunod",
                PublishedYear = "2005",
                PagesNumber = 154
            };
            BookObservableCollection.AddRange(new List<Book> {livre1, livre2, livre3});
        }

        public void AddBook()
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
                    PagesNumber = saveBookWindow.BookToSavePages
                };
                BookObservableCollection.Add(testBook);
            }
        }

        public void PurgeAllDatabase()
        {
            BookObservableCollection.DeleteAllBooks();
        }
    }
}