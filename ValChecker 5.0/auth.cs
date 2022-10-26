using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO;
using System.Net.Http.Headers;
using System.Windows;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace ValChecker_5._0
{
    internal class auth
    {
        public string EntitlementToken { get; set; }
        public string AccessToken { get; set; }
        public string subject { get; set; }
        public CookieContainer cookies { get; set; }
        public string version;
        public string region;
        // token,entitlement,puuid,mailverif,banuntil
        public static string Main(string logpass,string proxy)
        {

            auth au = new auth();
            string[] splitted = logpass.Split(':');
            string login = splitted[0];
            string password = splitted[1];

            au.cookies = new CookieContainer();
            RestClient client = new RestClient("https://auth.riotgames.com/api/v1/authorization");
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            client.CookieContainer = au.cookies;
            client.AddDefaultHeader("Accept-Language", "en-US,en;q=0.9");
            client.AddDefaultHeader("Accept", "application/json, text/plain, */*");
            client.AddDefaultHeader("User-Agent", "RiotClient/58.0.0.4640299.4552318 rso-auth (Windows;10;;Professional, x64)");
            RestRequest request = new RestRequest(Method.POST);
            string body =
                "{\"client_id\":\"riot-client\"," +
                "\"nonce\":\"1\"," +
                "\"redirect_uri\":\"http://localhost/redirect\"," +
                "\"response_type\":\"token id_token\"," +
                "\"scope\":\"account openid link ban lol_region\"}";
            request.AddJsonBody(body);
            client.Execute(request);

            RestClient authclient = new RestClient("https://auth.riotgames.com/api/v1/authorization");
            authclient.CookieContainer = au.cookies;
            RestRequest authrequest = new RestRequest(Method.PUT);
            string authbody = "{\"type\":\"auth\",\"username\":\"" + login + "\",\"password\":\"" + password + "\"}";
            authrequest.AddJsonBody(authbody);
            string authresult = authclient.Execute(authrequest).Content;

            return authresult;
        }
    }
}
