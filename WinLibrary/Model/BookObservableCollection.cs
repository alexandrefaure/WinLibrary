using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using WinLibrary.DAL;

namespace WinLibrary.Model
{
    public class BookObservableCollection : ObservableCollection<Book>
    {
        public ObservableCollection<Book> BooksCollection { get; set; }

        public BookObservableCollection(DbSet<Book> booksList)
        {
            BooksCollection = new ObservableCollection<Book>(booksList);
        }

        public void Add(Book testBook)
        {
            BooksCollection.Add(testBook);
            BookDal.SaveBook(testBook);
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
    }
}