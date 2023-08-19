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

namespace testjsonresponses
{
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

namespace valchecker_4._0_private_beta
{
    internal static class test
    {
        internal static async Task updatejson(List<string> skins, string region)
        {

            string jsonFilePath = "skins.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            var skinsData = JsonSerializer.Deserialize<RegionSkins>(jsonContent);
            foreach(string skin in skins)
            {
                if (skinsData.Skins.ContainsKey(region))
                {
                    if (skinsData.Skins[region].ContainsKey(skin))
                    {
                        skinsData.Skins[region][skin]++;
                    }
                    else
                    {
                        skinsData.Skins[region][skin] = 1;
                    }
                }
                else
                {
                    skinsData.Skins[region] = new SkinData { { skin, 1 } };
                }
            }

            // Serialize and write back to the JSON file
            string updatedJson = JsonSerializer.Serialize(skinsData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, updatedJson);

        }

        internal static async Task getnightmarket(Account account)
        {
            List<string> regions = new List<string>() { "eu","ap","na","kr" };
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("X-Riot-Entitlements-JWT", account.entt);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", account.token);
            client.DefaultRequestHeaders.Add("X-Riot-ClientVersion", "release-05.12-shipping-21-808353");
            client.DefaultRequestHeaders.Add("X-Riot-ClientPlatform", valchecker.Constants.CLIENTPLATFORM);

            foreach(string region in regions)
            {
                var skinids = new List<string>();
                var response = await client.GetAsync($"https://pd.{region}.a.pvp.net/store/v2/storefront/{account.puuid}");
                var normresponse = Newtonsoft.Json.JsonConvert.DeserializeObject<testjsonresponses.nightmarket>(
                    await response.Content.ReadAsStringAsync());
                foreach (var i in normresponse.BonusStore.BonusStoreOffers) skinids.Add(i.Offer.Rewards[0].ItemID);
                var skins = await accountinfo.normalizeskins(skinids: skinids);
                await updatejson(skins, region);
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
