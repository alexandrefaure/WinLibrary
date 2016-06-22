using System;
using NUnit.Framework;
using WinLibrary.DAL;
using WinLibrary.Entity;

namespace WinLibrary.Tests.DAL
{
    [TestFixture]
    public sealed class BookDALTests
    {
        [TestCase("TestTitle", "TestAuthor", "TestEditor", "TestYear", 22)]
        public void SaveBookTest(string bookTitle, string bookAuthor, string bookEditor, string bookYear, int bookPages)
        {
            var testbook = new Book
            {
                Title = bookTitle,
                Author = bookAuthor,
                Editor = bookEditor,
                PublishedYear = bookYear,
                PagesNumber = bookPages
            };
            BookDAL.SaveBook(testbook);
        }
    }
}
