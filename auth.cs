using System;
using RestSharp;
using Newtonsoft.Json.Linq;

public class auth
{
	public auth()
	{
	}

    // token,entitlement,puuid,mailverif,banuntil
    public static (string,string,string,bool,string|null) auth(string logpass)
	{
        var session = new RestClient();
    }
}
