using System.Windows;
using System.Windows.Input;
using WinLibrary.Model;

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
            var messageBoxResult = MessageBox.Show("Vous vous apprétez à ajouter un livre");
            var testBook = new Book {Title = "BookAddedMDR"};

            BookObservableCollection.Add(testBook);
        }
    }
}