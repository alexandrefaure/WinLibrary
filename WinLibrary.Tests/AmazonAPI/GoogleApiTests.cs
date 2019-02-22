using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using WinLibrary.AmazonAPI;
using Assert = NUnit.Framework.Assert;

namespace WinLibrary.Tests.AmazonAPI
{
    [TestFixture]
    public sealed class GoogleApiTests
    {
        //[Test]
        //public void GetAuthenticationTest()
        //{
        //    var authentication = AmazonApi.GetAuthentication();
        //    Assert.IsNotNull(authentication);
        //}

        //[TestCase("9782100738748")] //SCRUM Le guide de la méthode agile la plus populaire
        //[TestCase("")]
        //public void GetIsbnInformation(string isbn)
        //{
        //    var informations = AmazonApi.GetBookInformation(isbn);
        //    if (isbn != string.Empty)
        //    {
        //        Assert.IsNotNull(informations);
        //    }
        //    else
        //    {
        //        Assert.IsNull(informations);
        //    }
        //}

        [Test]
        public void TestIsbnSearch()
        {
            var isbn = "9782100742165";
            var googleApi = new GoogleApi();
            var output = googleApi.SearchISBN(isbn);

            Assert.AreEqual(output != null, true);

            var result = output;
            Trace.WriteLine("\nBook Name: " + result.VolumeInfo.Title);
            Trace.WriteLine("Author: " + result.VolumeInfo.Authors.FirstOrDefault());
            Trace.WriteLine("Publisher: " + result.VolumeInfo.Publisher);
        }
    }
}