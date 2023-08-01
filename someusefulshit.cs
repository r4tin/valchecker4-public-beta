using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using valchecker_4._0_private_beta;

namespace valchecker
{
    public static class proxysystem
    {
        private static int num = 0;
        public static string? get_proxy()
        {
            if (vars.proxylist.Count == 0) return null;
            string proxy = vars.proxylist[num];
            num++;
            if (num == vars.proxylist.Count) num = 0;
            return proxy;
        }
    }
    public static class skinsjsonloader
    {
        public static skinsjson.main skins;
        public static void load()
        {
            skins = Newtonsoft.Json.JsonConvert.DeserializeObject<skinsjson.main>(File.ReadAllText("C:\\Users\\roadhog\\source\\repos\\" +
                "valchecker-4.0-private-beta\\assets\\skins.json")); // change this later
        }
    }
    internal class someusefulshit
    {
        public static DateTimeOffset? normalize_ban(List<bantypes.mainrestrictionpart> data)
        {
            if (data.Count == 0) return null;
            bool istimeban = false;
            DateTimeOffset exptime = new DateTimeOffset();
            foreach(bantypes.mainrestrictionpart bandata in data)
            {
                if (bandata.scope == "riot" && bandata.type == "PERMANENT_BAN") return new DateTimeOffset();
                if(bandata.scope == "ares")
                {
                    if (bandata.type == "PERMANENT_BAN") return new DateTimeOffset();
                    if (bandata.type == "TIME_BAN")
                    {
                        istimeban = true;
                        exptime = DateTimeOffset.FromUnixTimeMilliseconds(bandata.dat.expirationMillis);
                    }
                }
            }
            return istimeban ? exptime : null;
        }

        public async static Task get_region(Account account, userinfojson.ApiResponse data)
        {
            string region;
            string fixedregion;
            string progregion;
            string country;
            try
            {
                country = data.country.ToUpper();
                if (data.region != null && Constants.LOL2REG.TryGetValue(data.region.id, out fixedregion)) { Console.WriteLine($"yeee- {data.region.id}"); }
                else if(data.country != null)
                {
                    Console.WriteLine("uuu");
                    fixedregion = Constants.COU2REG[Constants.A2TOA3[data.country.ToUpper()]];   
                }
                else
                {
                    account.region = null;
                    account.lvl = null;
                    Console.WriteLine("FUCKYOU");
                    return;
                }
                fixedregion = fixedregion.ToLower();
                progregion = fixedregion;
                if(fixedregion == "latam" || fixedregion == "br")
                {
                    progregion = "na";
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                account.region = null;
                account.lvl = null;
                return;
            }
            account.region = fixedregion;
            account.country = country;

            //lvl
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("X-Riot-Entitlements-JWT", account.entt);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", account.token);
            var response = await client.GetAsync($"https://pd.{progregion}.a.pvp.net/account-xp/v1/players/{account.puuid}");
            var responsecontent = await response.Content.ReadAsStringAsync();
            var responsejson = Newtonsoft.Json.JsonConvert.DeserializeObject<lvlrequest.main>(responsecontent);
            account.lvl = responsejson.Progress.Level;
            return;
        }
        public static DateTimeOffset normalizemillis(long millisec)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(millisec);
        }
    }
}
