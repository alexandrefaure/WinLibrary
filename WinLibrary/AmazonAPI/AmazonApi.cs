using System.Linq;
using Nager.AmazonProductAdvertising;
using Nager.AmazonProductAdvertising.Model;

namespace WinLibrary.AmazonAPI
{
    public class AmazonApi
    {
        private const string AccesKeyId = "AKIAIP6L4WACU6L6GVOA";
        private const string SecretKeyId = "Gl3jqN8wfInYqlyZwmtjG6VoTsd0q4w3RoqdMOwb";

        public static AmazonAuthentication GetAuthentication()
        {
            var authentication = new AmazonAuthentication
            {
                AccessKey = AccesKeyId,
                SecretKey = SecretKeyId
            };
            return authentication;
        }
        public static Item GetInformation(string isbn)
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
    }
}