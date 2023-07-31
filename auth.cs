using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using valchecker;

public class Account
{
    public string errmsg { get; set; }
    public int code { get; set; }

    public string logpass { get; set; }
    public string token { get; set; }
    public string entt { get; set; }
    public string puuid { get; set; }
    public bool unverifiedmail { get; set; }
    public DateTimeOffset? banuntil { get; set; }
    public string gamename { get; set; }
    public string tagline { get; set; }
    public DateTimeOffset registerdate { get; set; }
    public string? region { get; set; }
    public string? country { get; set; }

    public int? lvl { get; set; }
    public string? rank { get; set; }
    public List<string>? skins { get; set; }
    public List<string>? uuids { get; set; }
    public int? vp { get; set; }
    public int? rp { get; set; }
    public int? kp { get; set; }
    public DateTimeOffset? lastplayed { get; set; }

    public override string ToString()
    {
        int? skinscount = skins != null ? skins.Count : null;
        int? uuidscount = uuids != null ? uuids.Count : null;
        return $"errmsg: {errmsg}\n" +
               $"code: {code}\n" +
               $"logpass: {logpass}\n" +
               $"token: {token!=null}\n" +
               $"entt: {entt!= null}\n" +
               $"puuid: {puuid}\n" +
               $"unverifiedmail: {unverifiedmail}\n" +
               $"banuntil: {banuntil}\n" +
               $"gamename: {gamename}\n" +
               $"tagline: {tagline}\n" +
               $"registerdate: {registerdate}\n" +
               $"region: {region}\n" +
               $"country: {country}\n" +
               $"lvl: {lvl}\n" +
               $"rank: {rank}\n" +
               $"skins: {skinscount}\n" +
               $"uuids: {uuidscount}\n" +
               $"vp: {vp}\n" +
               $"rp: {rp}\n" +
               $"kp: {kp}\n" +
               $"lastplayed: {lastplayed}";
    }
}

public class RiotClient
{

    private static Dictionary<string, string> ExtractTokensFromUri(string uri)
    {
        // Use regular expressions to extract tokens from the 'uri' based on the provided pattern
        string pattern = @"access_token=((?:[a-zA-Z]|\d|\.|\-|_)*).*id_token=((?:[a-zA-Z]|\d|\.|\-|_)*).*expires_in=(\d*)";
        Match match = Regex.Match(uri, pattern);

        if (match.Success)
        {
            string access_token = match.Groups[1].Value;
            string id_token = match.Groups[2].Value;
            string expires_in = match.Groups[3].Value;

            return new Dictionary<string, string>
        {
            { "access_token", access_token },
            { "id_token", id_token },
            { "expires_in", expires_in }
        };
        }

        return null; // Return null if the pattern is not matched
    }
    public async Task<Account> AuthAsync(string? logpass = null, string? username = null, string? password = null, string? proxy = null)
    {
        Account account = new Account();
        try
        {
            account.logpass = logpass;

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Accept-Language", "en-US,en;q=0.9" },
                { "Accept", "application/json, text/plain, */*" },
                { "User-Agent", $"RiotClient/{Constants.USERAGENT} (Windows;10;;Professional, x64)" }
            };

            HttpClientHandler handler = new HttpClientHandler();
            if (!string.IsNullOrEmpty(proxy))
            {
                handler.Proxy = new WebProxy(proxy);
                handler.UseProxy = true;
            }
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.AcceptLanguage.TryParseAdd("en-US,en;q=0.9");
            client.DefaultRequestHeaders.Accept.TryParseAdd("application/json, text/plain, */*");
            client.DefaultRequestHeaders.UserAgent.TryParseAdd($"RiotClient/{Constants.USERAGENT} (Windows;10;;Professional, x64)");

            if (string.IsNullOrEmpty(username))
            {
                username = logpass.Split(':')[0].Trim();
                password = logpass.Split(':')[1].Trim();
            }

            Dictionary<string, string> data = new Dictionary<string, string>
            {
                { "acr_values", "urn:riot:bronze" },
                { "claims", "" },
                { "client_id", "riot-client" },
                { "nonce", "oYnVwCSrlS5IHKh7iI16oQ" },
                { "redirect_uri", "http://localhost/redirect" },
                { "response_type", "token id_token" },
                { "scope", "openid link ban lol_region" }
            };

            StringContent content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(Constants.AUTH_URL, content);

            string responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                account.code = 6;
                return account;
            }

            data = new Dictionary<string, string>
            {
                { "type", "auth" },
                { "username", username },
                { "password", password }
            };

            content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            response = await client.PutAsync(Constants.AUTH_URL, content);

            responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                account.code = 6;
                return account;
            }
            string token = "";
            Dictionary<string, object> responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent);
            if (responseData.ContainsKey("type") && responseData["type"].ToString() == "response")
            {
                //Console.WriteLine(responseContent);
                tokenauthjson.ApiResponse apiresponse = JsonConvert.DeserializeObject<tokenauthjson.ApiResponse>(responseContent);
                if (apiresponse != null && apiresponse.response != null)
                {
                    string uri = apiresponse.response.parameters?.uri;
                    if (!string.IsNullOrEmpty(uri))
                    {
                        // Extract tokens using the provided pattern
                        Dictionary<string, string> tokens = ExtractTokensFromUri(uri);
                        if (tokens != null)
                        {
                            // Now you can use 'access_token', 'id_token', and 'expires_in' as needed
                            token = tokens["access_token"];
                            account.token = token;
                        }
                        else
                        {
                            // Handle the case when the pattern does not match
                            Console.WriteLine("Failed to extract tokens from the uri.");
                            return account;
                        }
                    }
                }
            }
            else if (responseContent.Contains("invalid_session_id"))
            {
                account.code = 6;
                return account;
            }
            else if (responseContent.Contains("auth_failure"))
            {
                account.code = 3;
                return account;
            }
            else if (responseContent.Contains("rate_limited"))
            {
                account.code = 1;
                return account;
            }
            else if (responseContent.Contains("multifactor"))
            {
                account.code = 3;
                return account;
            }
            else if (responseContent.Contains("cloudflare"))
            {
                account.code = 5;
                return account;
            }
            else
            {
                account.code = 3;
                return account;
            }

            Console.WriteLine("entt good");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            content = new StringContent("", Encoding.UTF8, "application/json");
            response = await client.PostAsync(Constants.ENTITLEMENT_URL, content);

            responseContent = await response.Content.ReadAsStringAsync();
            Dictionary<string, string> dataentt = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
            string entt = dataentt["entitlements_token"];
            account.entt = entt;


            content = new StringContent("", Encoding.UTF8, "application/json");
            response = await client.PostAsync(Constants.USERINFO_URL, content);

            responseContent = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseContent);

            var userinfodata = Newtonsoft.Json.JsonConvert.DeserializeObject<userinfojson.ApiResponse>(responseContent);
            var banlist = userinfodata.ban.restrictions;
            DateTimeOffset? bantime = someusefulshit.normalize_ban(banlist);
            if (bantime == new DateTimeOffset())
            {
                account.code = 4;
                Console.WriteLine("banned");
                return account;
            }
            account.banuntil = bantime;

            account.unverifiedmail = !userinfodata.email_verified;
            account.puuid = userinfodata.sub;
            account.gamename = userinfodata.acct.game_name;
            account.tagline = userinfodata.acct.tag_line;
            DateTimeOffset creationdate_patched = someusefulshit.normalizemillis(userinfodata.acct.created_at);
            account.registerdate = creationdate_patched;

            await someusefulshit.get_region(account, userinfodata);
            return account;
        }
        catch (Exception e)
        {
            account.errmsg = e.ToString();
            account.code = 2;
            return account;
        }
    }
}