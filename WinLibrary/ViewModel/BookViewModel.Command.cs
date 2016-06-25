using System.Windows.Input;
using WinLibrary.Model;
using WinLibrary.Views;

namespace WinLibrary.ViewModel
{
    public partial class BookViewModel
    {
        private ICommand _addBookCommand;
        private readonly bool _canExecute;

        public ICommand AddBookCommand
        {
            get { return _addBookCommand ?? (_addBookCommand = new CommandHandler(() => AddBook(), _canExecute)); }
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
    }
}