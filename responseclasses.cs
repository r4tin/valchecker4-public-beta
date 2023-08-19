namespace tokenauthjson
{
    public class Parameters
    {
        public string uri { get; set; }
    }

    public class ResponseData
    {
        public string mode { get; set; }
        public Parameters parameters { get; set; }
    }

    public class ApiResponse
    {
        public string type { get; set; }
        public ResponseData response { get; set; }
    }
}

namespace userinfojson
{
    public class LolAccountData
    {

    }
    public class Ban
    {
        public List<bantypes.mainrestrictionpart> restrictions { get; set; }
    }
    public class MainAccountData
    {
        public int type { get; set; }
        public string state { get; set; }
        public bool adm { get; set; }
        public string game_name { get; set; }
        public string tag_line { get; set; }
        public long created_at { get; set; }
    }
    public class Regioninfo
    {
        public string id { get; set; }
    }
    public class ApiResponse
    {
        public string country { get; set; }
        public string sub { get; set; }
        public LolAccountData lol_account { get; set; }
        public bool email_verified { get; set; }
        public Ban ban { get; set; }
        public Regioninfo region { get; set; }
        public MainAccountData acct { get; set; }
    }
}

namespace bantypes
{
    public class mainrestrictionpart
    {
        public string type { get; set; }
        public string reason { get; set; }
        public string scope { get; set; }
        public data dat { get; set; }

    }

    public class data
    {
        public long expirationMillis { get; set; }
        public gamedata gameData { get; set; }

    }
    public class gamedata
    {
        public string productName { get; set; }
        public string gameLocation { get; set; }
        public string triggerGameId { get; set; }
    }
}

namespace lvlrequest
{
    public class main
    {
        public progress Progress { get; set; }
    }

    public class progress
    {
        public int Level { get; set; }
        public int XP { get; set; }
    }
}

namespace rankedrequest
{
    public class main
    {
        public List<match> Matches { get; set; }
    }

    public class match
    {
        public int TierAfterUpdate { get; set; }
        public long MatchStartTime { get; set; }
    }
}

namespace lastplayedrequest
{
    public class main
    {
        public List<match> History { get; set; }
    }

    public class match
    {
        public long GameStartTime { get; set; }
    }
}

namespace balancerequest
{
    public class balancesdata
    {
        public Dictionary<string, int> Balances { get; set; }
    }
}

namespace skinsrequest
{
    public class main
    {
        public List<skin> Entitlements { get; set; }
    }
    public class skin
    {
        public string ItemID { get; set; }
    }
}

namespace skininfo
{
    public class main
    {
        public skindata data { get; set; }
    }
    public class skindata
    {
        public string displayName { get; set; }
    }
}

namespace skinsjson
{
    public class main
    {
        public List<skin> data { get; set; }
    }
    public class skin
    {
        public string uuid { get; set; }
        public string displayName { get; set; }
        public List<level> levels { get; set; }
    }
    public class level
    {
        public string uuid { get; set; }
    }
}