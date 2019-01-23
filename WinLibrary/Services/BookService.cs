using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using WinLibrary.DAL;
using WinLibrary.Model;

namespace WinLibrary.Services
{
    public class BookService : ObservableCollection<Book>
    {
        public ObservableCollection<Book> BooksCollection { get; set; }

        public BookService(IEnumerable<Book> booksList)
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