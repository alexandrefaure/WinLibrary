using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WinLibrary.Model;
using WinLibrary.Services;

namespace WinLibrary.Tests.Model
{
    [TestFixture]
    public sealed class BookObservableCollectionTest
    {
        [Test]
        public void ConstructorTest()
        {
            // Arrange
            var expectedTitle = "TestBook";
            var booksList = new List<Book> {new Book {Title = expectedTitle } };

            // Act
            var bookObservableCollection = new BookService(booksList);
            var booksCollection = bookObservableCollection.BooksCollection;

            // Assert
            Assert.AreEqual(1, booksCollection.Count);
            Assert.AreEqual(expectedTitle, booksCollection.Single().Title);
        }

        [Test]
        public void AddTest()
        {
            // Arrange
            var expectedTitle = "TestBookToAdd";
            var booksList = new List<Book>();
            var bookObservableCollection = new BookService(booksList);
            var bookToAdd = new Book { Title = expectedTitle };
            var booksCollection = bookObservableCollection.BooksCollection;

            // Act
            bookObservableCollection.Add(bookToAdd);

            // Assert
            Assert.AreEqual(1, booksCollection.Count);
            Assert.AreEqual(expectedTitle, booksCollection.Single().Title);
        }

        [Test]
        public void DeleteAllBooksTest()
        {
            // Arrange
            var expectedTitle = "TestBookToAdd";
            var booksList = new List<Book> { new Book { Title = "TestBook1" }, new Book { Title = "TestBook2" } };
            var bookObservableCollection = new BookService(booksList);
            var booksCollection = bookObservableCollection.BooksCollection;
            Assert.AreEqual(2, booksCollection.Count);

            // Act
            bookObservableCollection.DeleteAllBooks();

            // Assert
            Assert.AreEqual(0, booksCollection.Count);
        }
    }
}
