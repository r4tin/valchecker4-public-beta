using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text.Json;

namespace valchecker
{
    internal class accountinfo
    {
        async public static Task<List<string>?> normalizeskins(Account account = null, List<string> skinids = null)
        {
            var skins = new List<string>();
            var uuids = new List<string>();
            if(account != null) { uuids = account.uuids; }
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            int sum = 0;
            foreach(string id in uuids)
            {
                var response = await client.GetAsync($"https://valorant-api.com/v1/weapons/skinlevels/{id}");
                var normresponse = Newtonsoft.Json.JsonConvert.DeserializeObject<skininfo.main>(
                    await response.Content.ReadAsStringAsync());
                skins.Add(normresponse.data.displayName);
            }
            if(account != null)
            {
                account.skins = skins;
                return null;
            }
            return skins;
        }
        async public static Task get_rank(Account account)
        {
            if (account.lvl < 20)
            {
                account.rank = "locked";
                return;
            }
            string region = account.region;
            if (region == "latam" || region == "br")
            {
                region = "na";
            }
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("X-Riot-Entitlements-JWT", account.entt);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", account.token);
                client.DefaultRequestHeaders.Add("X-Riot-ClientVersion", "release-05.12-shipping-21-808353");
                client.DefaultRequestHeaders.Add("X-Riot-ClientPlatform", Constants.CLIENTPLATFORM);
                Console.WriteLine($"https://pd.{region}.a.pvp.net/mmr/v1/players/{account.puuid}/competitiveupdates");
                var response = await client.GetAsync($"https://pd.{region}.a.pvp.net/mmr/v1/players/{account.puuid}/competitiveupdates");
                var responsetext = await response.Content.ReadAsStringAsync();
                var responsejson = Newtonsoft.Json.JsonConvert.DeserializeObject<rankedrequest.main>(responsetext);
                if (responsetext.Contains("\",\"Matches\":[]}"))
                {
                    account.rank = "unranked";
                    return;
                }
                account.lastplayed = someusefulshit.normalizemillis(responsejson.Matches[0].MatchStartTime);
                account.rank = Constants.RANKID2RANK[Convert.ToString(responsejson.Matches[0].TierAfterUpdate)];

            }
            catch (Exception ex)
            {
                Console.WriteLine("getrank: " + ex.Message);
            }
        }
        async public static Task get_lastplayed(Account account)
        {
            try
            {
                string region = account.region;
                if (region == "latam" || region == "br")
                {
                    region = "na";
                }
                HttpClientHandler handler = new HttpClientHandler();
                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("X-Riot-Entitlements-JWT", account.entt);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", account.token);
                client.DefaultRequestHeaders.Add("X-Riot-ClientVersion", "release-05.12-shipping-21-808353");
                client.DefaultRequestHeaders.Add("X-Riot-ClientPlatform", Constants.CLIENTPLATFORM);
                var response = await client.GetAsync($"https://pd.{region}.a.pvp.net/match-history/v1/history/{account.puuid}?startIndex=0&endIndex=10");
                var responsetext = await response.Content.ReadAsStringAsync();
                if (responsetext.Contains("\"History\":[]"))
                {
                    if (account.lastplayed == null)
                    {
                        account.lastplayed = new DateTimeOffset();
                        return;
                    }
                    return;
                }
                var responsejson = Newtonsoft.Json.JsonConvert.DeserializeObject<lastplayedrequest.main>(responsetext);
                account.lastplayed = someusefulshit.normalizemillis(responsejson.History[0].GameStartTime);
            }
            catch (Exception ex)
            {
                if (account.lastplayed == null)
                {
                    account.lastplayed = new DateTimeOffset();
                    return;
                }
                Console.WriteLine("getlp: " + ex.Message);
            }
        }
        async public static Task get_balance(Account account)
        {
            string region = account.region;
            if (region == "latam" || region == "br")
            {
                region = "na";
            }
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("X-Riot-Entitlements-JWT", account.entt);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", account.token);
            var response = await client.GetAsync($"https://pd.{region}.a.pvp.net/store/v1/wallet/{account.puuid}");
            var responsetext = await response.Content.ReadAsStringAsync();
            var responsejson = JsonSerializer.Deserialize<balancerequest.balancesdata>(responsetext);
            account.vp = responsejson.Balances["85ad13f7-3d1b-5128-9eb2-7cd8ee0b5741"];
            account.rp = responsejson.Balances["e59aa87c-4cbf-517a-5983-6e81511be9b7"];
            account.kp = responsejson.Balances["85ca954a-41f2-ce94-9b45-8ca3dd39a00d"];
        }
        async public static Task get_skins(Account account)
        {
            var skinids = new List<string>();
            //var skins = new List<string>();
            string region = account.region;
            if (region == "latam" || region == "br")
            {
                region = "na";
            }
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("X-Riot-Entitlements-JWT", account.entt);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", account.token);
            var response = await client.GetAsync($"https://pd.{region}.a.pvp.net/store/v1/entitlements/{account.puuid}/e7c63390-eda7-46e0-bb7a-a6abdacd2433");
            var responsetext = await response.Content.ReadAsStringAsync();
            var responsejson = Newtonsoft.Json.JsonConvert.DeserializeObject<skinsrequest.main>(responsetext);
            //var skinsjson = skinsjsonloader.skins;
            if (responsejson.Entitlements.Count == 0)
            {
                //account.skins = skins;
                account.uuids = skinids;
                return;
            }
            foreach (var skin in responsejson.Entitlements)
            {
                if (skinids.Contains(skin.ItemID)) { continue; }
                skinids.Add(skin.ItemID);
            }
            //account.skins = skins;
            account.uuids = skinids;
        }
    }
}
