using System;
using System.Configuration;
using System.Linq;
using System.Windows;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using WinLibrary.Model;

namespace WinLibrary.AmazonAPI
{
    public class GoogleApi
    {
        public GoogleApi()
        {
            CheckGoogleApiIsActive();
            Service = new BooksService(new BaseClientService.Initializer
            {
                ApplicationName = ConfigurationManager.AppSettings["ApplicationName"],
                ApiKey = ConfigurationManager.AppSettings["ApiKey"],
            });
        }

        public static BooksService Service;

        private bool CheckGoogleApiIsActive()
        {
            return true;
        }

        public Volume SearchISBN(string isbn)
        {
            Console.WriteLine("Executing a book search request…");
            var result = Service.Volumes.List(isbn).ExecuteAsync();
            if (result?.Result != null)
            {
                var item = result?.Result?.Items?.FirstOrDefault();
                if (item == null)
                {
                    MessageBox.Show($"No ISBN found with reference {isbn}", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                return item;
            }
            return null;
        }

        public Book GetBook(string isbn)
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