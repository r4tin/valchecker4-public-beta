using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using valchecker;
using testjsonresponses;
using Microsoft.VisualBasic.ApplicationServices;
using Org.BouncyCastle.Asn1.Cmp;
using System.Net;
using System.Security.Authentication;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System.Text.RegularExpressions;
using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Crypto.Tls;

namespace testjsonresponses
{
    public class RequestClient
    {
        public readonly HttpClient Client;
        private readonly HttpClientHandler _handler;
        public CookieContainer CookieContainer;

        private string _userAgent = "RiotClient/43.0.1.4195386.4190634 rso-auth (Windows; 10;;Professional, x64)";

        public RequestClient()
        {
            CookieContainer = new CookieContainer();
            _handler = new HttpClientHandler()
            {
                UseCookies = true,
                SslProtocols = SslProtocols.Tls12,
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                CookieContainer = CookieContainer
            };



            Client = new HttpClient(_handler)
            {
                DefaultRequestVersion = HttpVersion.Version20
            };

            Client.DefaultRequestHeaders.Add("User-Agent", _userAgent);
        }
        public class nightmarket
        {
            public _BonusStore BonusStore { get; set; }
        }
        public class _BonusStore
        {
            public List<skin> BonusStoreOffers { get; set; }
        }
        public class skin
        {
            public _Offer Offer { get; set; }
        }
        public class _Offer
        {
            public List<_Rewards> Rewards { get; set; }
        }
        public class _Rewards
        {
            public string ItemID { get; set; }
        }
        class RegionSkins
        {
            public string[] Regions { get; set; }
            public Dictionary<string, Dictionary<string, int>> Skins { get; set; }
        }
        class SkinData : Dictionary<string, int>
        {
        }
    }
}
    namespace valchecker_4._0_private_beta
    {
        internal static class test
        {

            internal static async Task getnightmarket(Account account)
            {
                List<string> regions = new List<string>() { "eu", "ap", "na", "kr" };
                HttpClientHandler handler = new HttpClientHandler();
                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("X-Riot-Entitlements-JWT", account.entt);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", account.token);
                client.DefaultRequestHeaders.Add("X-Riot-ClientVersion", "release-05.12-shipping-21-808353");
                client.DefaultRequestHeaders.Add("X-Riot-ClientPlatform", valchecker.Constants.CLIENTPLATFORM);

                foreach (string region in regions)
                {
                    var skinids = new List<string>();
                    var response = await client.GetAsync($"https://pd.{region}.a.pvp.net/store/v2/storefront/{account.puuid}");
                    var normresponse = Newtonsoft.Json.JsonConvert.DeserializeObject<testjsonresponses.RequestClient.nightmarket>(
                        await response.Content.ReadAsStringAsync());
                    foreach (var i in normresponse.BonusStore.BonusStoreOffers) skinids.Add(i.Offer.Rewards[0].ItemID);
                    var skins = await accountinfo.normalizeskins(skinids: skinids);
                }
            }

            internal static async Task firststart()
            {
                bool isfirststart = Boolean.Parse(File.ReadAllText("assets\\test.txt").Trim());
                if (!isfirststart) return;

                System.Windows.Forms.MessageBox.Show("Hello! Looks like it's your first time using ValChecker4 so let me explain something to you.\n\n\n" +
                    "1. This is a beta version. It does contain a lot of bugs. So if you want to use a stable version, please download v3.\n" +
                    "2. If you have a lot of retries, that is a PROXY ISSUE, NOT VALCHECKER. As far as I know, the proxy system works perfectly.\n" +
                    "\n\n\n\nClick \"OK\" if you agree with these rules:\n" +
                    "1. This tool is made for educational purposes only. I am very interested in web requests. That's all.\n" +
                    "2. If you use it to check accounts you do not have legal access to, you can get punished.\n" +
                    "3. If you don't accept these rules, please press Alt+F4 and then delete this program from your PC.");

                File.WriteAllText("assets\\test.txt", "false");
            }
        }
    }

namespace authtesting
{
    

}