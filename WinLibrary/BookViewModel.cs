using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DevExpress.XtraPrinting.Native;
using WinLibrary.Entity;

namespace WinLibrary
{
    public class BookViewModel
    {
        DatabaseEntities dataContext = new DatabaseEntities();

        public ObservableCollection<Book> BooksCollection { get; set; }

        public BookViewModel()
        {
            _canExecute = true;
            BooksCollection = new ObservableCollection<Book>(dataContext.Books);
        }


        public void SaveBook(Book book)
        {
            BooksCollection.Add(book);
            dataContext.Books.Add(book);
            dataContext.SaveChanges();
        }

        public bool IsBooksDatabaseEmpty()
        {
            return BooksCollection.IsEmpty();
        }


        private ICommand _addBookCommand;
        public ICommand AddBookCommand
        {
            get
            {
                return _addBookCommand ?? (_addBookCommand = new CommandHandler(() => AddBook(), _canExecute));
            }
        }
        private bool _canExecute;
        public void AddBook()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Vous vous apprétez à ajouter un livre");
            var testBook = new Book {Title = "BookAdded"};
            BooksCollection.Add(testBook);
            dataContext.Books.Add(testBook);
            dataContext.SaveChanges();
        }
    }

    public class CommandHandler : ICommand
    {
        private Action _action;
        private bool _canExecute;
        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }
}