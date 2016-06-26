using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WinLibrary.DAL;

namespace WinLibrary.Model
{
    public class BookObservableCollection : ObservableCollection<Book>
    {
        public ObservableCollection<Book> BooksCollection { get; set; }

        public BookObservableCollection(IEnumerable<Book> booksList)
        {
            BooksCollection = new ObservableCollection<Book>(booksList);
        }

        public new void Add(Book testBook)
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