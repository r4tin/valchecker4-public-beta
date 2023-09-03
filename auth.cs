using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using valchecker;
using Org.BouncyCastle.Crypto.Tls;
using System.Security.Authentication;
using System.Net.Http;
using System;
using RestSharp;
using valchecker_4._0_private_beta;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Text.Json.Nodes;
using System.Reflection.Metadata;

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
    public int? skinsprice { get; set; }

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
               $"token: {token != null}\n" +
               $"entt: {entt != null}\n" +
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

        return null;
    }
    public async Task<Account> AuthAsync(string logpass, proxy proxy = null)
    {
        Account account = new Account();
        if (!logpass.Contains(':'))
        {
            account.code = 3;
            return account;
        }
        try
        {
            account.logpass = logpass;

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Accept-Language", "en-US,en;q=0.9" },
                { "Accept", "application/json, text/plain, */*" },
                //{ "User-Agent", $"Mozilla/5.0 (iPhone; CPU iPhone OS 15_3_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 Instagram 225.0.0.9.115 (iPhone13,3; iOS 15_3_1; it_IT; it-IT; scale=3.00; 1170x2532; 355286437) NW/3" }
                { "User-Agent", $"RiotClient/{Constants.riotclientbuild} rso-auth (Windows;10;;Professional, x64)" }
            };

            HttpClientHandler handler = new HttpClientHandler();
            if (proxy != null)
            {
                Console.WriteLine($"{proxy.ip}:{proxy.port}");
                handler.Proxy = new WebProxy($"http://{proxy.ip}:{proxy.port}", true);
                handler.UseProxy = true;
                if (proxy.login != null)
                {
                    handler.Proxy.Credentials = new NetworkCredential(proxy.login, proxy.password);
                }
            }
            //var client = new HttpClient(handler);
            var client = new RestClient(handler);


            //client.Timeout = TimeSpan.FromSeconds(15);
            //client.DefaultRequestHeaders.UserAgent.TryParseAdd("Mozilla/5.0 (iPhone; CPU iPhone OS 15_3_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 Instagram 225.0.0.9.115 (iPhone13,3; iOS 15_3_1; it_IT; it-IT; scale=3.00; 1170x2532; 355286437) NW/3");
            client.AddDefaultHeaders(headers);
            string username = logpass.Split(':')[0].Trim();
            string password = logpass.Split(':')[1].Trim();

            //Auth2.Login(username, password);
            //return account;

            Dictionary<string, string> data = new Dictionary<string, string>
            {
                { "acr_values", "" },
                { "claims", "" },
                { "client_id", "riot-client" },
                { "nonce", "vYMrGocX3yrmrgnmKpVnOw" },
                { "redirect_uri", "http://localhost/redirect" },
                { "response_type", "token id_token" },
                { "scope", "openid link ban lol_region account" }
            };
            string jsonData = JsonConvert.SerializeObject(data);

            var authrequest = new RestRequest(Constants.AUTH_URL, Method.Post);
            //Console.WriteLine(jsonData);
            authrequest.AddParameter("application/json", jsonData, ParameterType.RequestBody);
            RestResponse response = await client.ExecuteAsync(authrequest);

            //string responseContent = response.Content;

            data = new Dictionary<string, string>
            {
                { "type", "auth" },
                { "username", username },
                { "password", password }
            };
            client.AddDefaultHeader("user-agent", $"RiotClient/{Constants.riotclientbuild} rso-authenticator (Windows;10;;Professional, x64)");
            jsonData = JsonConvert.SerializeObject(data);
            var auth2request = new RestRequest(Constants.AUTH_URL, Method.Put);
            auth2request.AddParameter("application/json", jsonData, ParameterType.RequestBody);
            RestResponse response2 = await client.ExecuteAsync(auth2request);

            var responseContent = response2.Content;
            //Console.WriteLine(responseContent);
            //Console.ReadLine();
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
                        Dictionary<string, string> tokens = ExtractTokensFromUri(uri);
                        if (tokens != null)
                        {
                            token = tokens["access_token"];
                            account.token = token;
                        }
                        else
                        {
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

            client.AddDefaultHeader("Authorization",$"Bearer {token}");
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var enttrequest = new RestRequest(Constants.ENTITLEMENT_URL, Method.Post);
            enttrequest.AddParameter("application/json", "{}", ParameterType.RequestBody);
            response = await client.ExecuteAsync(enttrequest);
            Console.WriteLine("entt good");

            responseContent = response.Content;
            Dictionary<string, string> dataentt = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
            string entt = dataentt["entitlements_token"];
            account.entt = entt;


            client.AddDefaultHeader("Authorization", $"Bearer {token}");
            content = new StringContent("", Encoding.UTF8, "application/json");
            var uinforequest = new RestRequest(Constants.USERINFO_URL, Method.Post);
            enttrequest.AddParameter("application/json", "{}", ParameterType.RequestBody);
            response = await client.ExecuteAsync(uinforequest);

            responseContent = response.Content;
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
            Console.WriteLine(e.ToString());
            Console.ReadLine();
        }
        return account;
        //catch (WebException ex)
        //{
        //    account.code = 3;
        //    return account;
        //}
        //catch (Exception e)
        //{
        //    account.errmsg = e.ToString();
        //    account.code = 2;
        //    return account;
        //}
    }
}