using System;
using System.Configuration;
using System.Linq;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using WinLibrary.Model;

namespace WinLibrary.AmazonAPI
{
    public class GoogleApi
    {
        public static BooksService service = new BooksService(new BaseClientService.Initializer
        {
            ApplicationName = ConfigurationManager.AppSettings["ApplicationName"],
            ApiKey = ConfigurationManager.AppSettings["ApiKey"],
        });

        public static Volume SearchISBN(string isbn)
        {
            Console.WriteLine("Executing a book search request…");
            var result = service.Volumes.List(isbn).ExecuteAsync();
            if (result != null && result.Result.Items != null)
            {
                var item = result.Result.Items.FirstOrDefault();
                return item;
            }
            return null;
        }

        public static Book GetBook(string isbn)
        {
            var bookInformation = SearchISBN(isbn);

            //Assert.AreEqual(output.Result != null, true);

            //var result = output.Result;
            //Trace.WriteLine("\nBook Name: " + result.VolumeInfo.Title);
            //Trace.WriteLine("Author: " + result.VolumeInfo.Authors.FirstOrDefault());
            //Trace.WriteLine("Publisher: " + result.VolumeInfo.Publisher);
            var googleBook = bookInformation;
            if (googleBook != null)
            {
                var book = FillBookInformation(googleBook);
                return book;
            }

            return null;
        }

        private static Book FillBookInformation(Volume googleBook)
        {
            Book book = null;
            if (googleBook != null)
            {
                var googleBookInformation = googleBook.VolumeInfo;
                book = new Book
                {
                    Title = googleBookInformation.Title,
                    Author = googleBookInformation.Authors.FirstOrDefault(),
                    Editor = googleBookInformation.Publisher,
                    PublishedYear = googleBookInformation.PublishedDate,
                    PagesNumber = googleBookInformation.PageCount,
                    //Isbn = googleBookInformation.
                    Image = googleBookInformation.ImageLinks?.Thumbnail
                    //BookToSaveAuthor = itemAttributes.BookToSaveAuthor,
                    //Editor = itemAttributes.Edition,
                    //Year = itemAttributes.ModelYear,
                    //Pages = itemAttributes.NumberOfPages
                };
            }
            return book;
        }
    }
}