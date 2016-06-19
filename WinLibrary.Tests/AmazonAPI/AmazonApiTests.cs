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
            var informations = AmazonApi.GetInformation(isbn);
            if (isbn != string.Empty)
            {
                Assert.IsNotNull(informations);
            }
            else
            {
                Assert.IsNull(informations);
            }
        }
    }
}