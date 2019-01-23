using System;
using System.Linq;
using Nager.AmazonProductAdvertising;
using Nager.AmazonProductAdvertising.Model;
using WinLibrary.Model;

namespace WinLibrary.AmazonAPI
{
    public class AmazonApi
    {
        private const string AccesKeyId = null;//AmazonApiCredentials.AccesKeyId;
        private const string SecretKeyId = null;//AmazonApiCredentials.SecretKeyId;

        public static Book GetBook(string isbn)
        {
            var bookInformation = GetBookInformation(isbn);
            var book = FillBookInformation(bookInformation);
            return book;
        }

        public static AmazonAuthentication GetAuthentication()
        {
            var authentication = new AmazonAuthentication
            {
                AccessKey = AccesKeyId,
                SecretKey = SecretKeyId
            };
            return authentication;
        }

        public static Item GetBookInformation(string isbn)
        {
            var wrapper = new AmazonWrapper(GetAuthentication(), AmazonEndpoint.FR);
            var itemResponse = wrapper.Lookup(isbn, AmazonResponseGroup.Large);
            if (itemResponse != null && itemResponse.Items.Item != null)
            {
                var result = itemResponse.Items.Item.SingleOrDefault();
                return result;
            }
            return null;
        }

        public static Book FillBookInformation(Item item)
        {
            Book book = null;
            if (item != null)
            {
                var itemAttributes = item.ItemAttributes;
                var authorList = itemAttributes.Author.ToList();
                book = new Book
                {
                    Title = itemAttributes.Title,
                    Author = authorList.First(),
                    Editor = itemAttributes.Label,
                    //PublishedYear = itemAttributes.PublicationDate,
                    //PagesNumber = Convert.ToInt64(itemAttributes.NumberOfPages),
                    Isbn = itemAttributes.EAN,
                    //CoverImage = item.LargeImage.URL
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