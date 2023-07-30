using balancerequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace valchecker
{
    internal class accountinfo
    {
        async public static Task get_rank(Account account)
        {
            if(account.lvl < 20)
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
                Console.WriteLine(ex.Message);
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
                Console.WriteLine(ex.Message);
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
            var skins = new List<string>();
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
            var skinsjson = Newtonsoft.Json.JsonConvert.DeserializeObject<skinsjson.main>(File.ReadAllText("C:\\Users\\roadhog\\source\\repos\\" +
                "valchecker\\assets\\skins.json")); // change this later
            if (responsejson.Entitlements.Count == 0)
            {
                account.skins = skins;
                account.uuids = skinids;
                return;
            }
            foreach ( var skin in responsejson.Entitlements )
            {
                if (skinids.Contains(skin.ItemID)) { continue; }
                skinids.Add(skin.ItemID);
                foreach(var skinid in skinsjson.data)
                {
                    if(skin.ItemID == skinid.uuid)
                    {
                        skins.Add(skinid.displayName);
                        break;
                    }
                    foreach (var level in skinid.levels)
                    {
                        if(skin.ItemID == level.uuid)
                        {
                            skins.Add(skinid.displayName);
                            break;
                        }
                    }
                }
            }
            account.skins = skins;
            account.uuids = skinids;
        }
    }
}
