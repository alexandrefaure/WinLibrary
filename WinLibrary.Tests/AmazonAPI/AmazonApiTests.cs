using Nager.AmazonProductAdvertising.Model;
using NUnit.Framework;
using WinLibrary.AmazonAPI;

namespace WinLibrary.Tests.AmazonAPI
{
    [TestFixture]
    public sealed class AmazonApiTests
    {
        [Test]
        public void GetAuthenticationTest()
        {
            var authentication = AmazonApi.GetAuthentication();
            Assert.IsNotNull(authentication);
        }

        [TestCase("9782100738748")] //SCRUM Le guide de la méthode agile la plus populaire
        [TestCase("")]
        public void GetIsbnInformation(string isbn)
        {
            var informations = AmazonApi.GetBookInformation(isbn);
            if (isbn != string.Empty)
            {
                Assert.IsNotNull(informations);
            }
            else
            {
                Assert.IsNull(informations);
            }
        }

        [Test]
        public void FillBookInformationTest()
        {
            var item = new Item
            {
                ItemAttributes = new ItemAttributes
                {
                    Title = "TestBookTitle",
                    Author = new []{"TestAuthor"},
                    Edition = "TestEdition",
                    ModelYear = "2003",
                    NumberOfPages = "122"
                }
            };

            var itemAttributes = item.ItemAttributes;
            var book = AmazonApi.FillBookInformation(item);
            Assert.AreEqual(itemAttributes.Title, book.Title);
            //Assert.AreEqual(itemAttributes.BookToSaveAuthor, book.BookToSaveAuthor);
            //Assert.AreEqual(itemAttributes.Edition, book.Editor);
            //Assert.AreEqual(itemAttributes.ModelYear, book.Year);
            //Assert.AreEqual(itemAttributes.NumberOfPages, book.Pages);
        }

        [TestCase("9782100738748")] //SCRUM Le guide de la méthode agile la plus populaire
        [TestCase("")]
        public void GetBook(string isbn)
        {
            var book = AmazonApi.GetBook(isbn);
            if (isbn != string.Empty)
            {
                Assert.IsNotNull(book);
            }
            else
            {
                Assert.IsNull(book);
            }
        }
    }
}