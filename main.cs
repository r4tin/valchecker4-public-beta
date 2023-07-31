using System;
using System.Security.Principal;
using valchecker;
using valchecker_4._0_private_beta;

public class accountsinfodb
{
    public static int checkednum = 0;
    public static int totalnum = 0;
    public static int valid = 0;
    public static int banned = 0;
    public static int tempbanned = 0;
    public static int rlimits = 0;
    public static int retries = 0;

    public static Dictionary<string, int> ranks = new Dictionary<string, int>()
        {
            { "unranked", 0 },
            { "iron", 0 },
            { "bronze", 0 },
            { "silver", 0 },
            { "gold", 0 },
            { "platinum", 0 },
            { "diamond", 0 },
            { "ascendant", 0 },
            { "immortal", 0 },
            { "radiant", 0 },
            { "locked", 0 }
        };
    public static Dictionary<string, int> regions = new Dictionary<string, int>()
        {
            { "eu", 0 },
            { "na", 0 },
            { "br", 0 },
            { "latam", 0 },
            { "ap", 0 },
            { "kr", 0 }
        };
    public static Dictionary<string, int> skinsam = new Dictionary<string, int>()
        {
            { "1-10", 0 },
            { "10-20", 0 },
            { "20-45", 0 },
            { "45-65", 0 },
            { "65-100", 0 },
            { "100+", 0 }
        };
    public static int withskins = 0;
    public static int withfa = 0;
    public static async Task updateinfo(Account account)
    {
        if (account.rank != null) { ranks[account.rank.Split(" ")[0].ToLower()] += 1; }
        if (account.region != null) { regions[account.region.ToLower()] += 1; }
        if (account.unverifiedmail) { withfa += 1; }
        if (account.skins != null && account.skins.Count > 0)
        {
            withskins += 1;
            int _num = account.skins.Count;
            if (_num >= 1 && _num < 10) { skinsam["1-10"] += 1; }
            if (_num >= 10 && _num < 20) { skinsam["10-20"] += 1; }
            if (_num >= 20 && _num < 45) { skinsam["20-45"] += 1; }
            if (_num >= 45 && _num < 65) { skinsam["45-65"] += 1; }
            if (_num >= 65 && _num < 100) { skinsam["65-100"] += 1; }
            if (_num >= 100) { skinsam["100+"] += 1; }
        }
    }
}

public static class mainProgram
{
    public static async Task Main(string? logpass = null)
    {
        skinsjsonloader.load();
        string filePath = "C:\\Users\\roadhog\\source\\repos\\valchecker-4.0-private-beta\\assets\\test.txt";
        string[] lines;
        using (StreamReader sr = new StreamReader(filePath))
        {
            lines = sr.ReadToEnd().Split("\n");
        }
        accountsinfodb.totalnum = lines.Length;
        TextChangeHandler.RaiseTextChangeEvent($"Checked: 0/{accountsinfodb.totalnum}", "checkedlabel");
        int response;
        foreach (string line in lines)
        {
            Console.WriteLine(line);
            response = await checkaccount(line);

            if (response == 0) { TextChangeHandler.RaiseTextChangeEvent($"Valid: {++accountsinfodb.valid}", "validlabel"); }
            else if (response == 4) { TextChangeHandler.RaiseTextChangeEvent($"Banned: {++accountsinfodb.banned}", "bannedlabel"); }
            TextChangeHandler.RaiseTextChangeEvent($"Checked: {++accountsinfodb.checkednum}/" +
                $"{accountsinfodb.totalnum}", "checkedlabel");
        }
    }
    public static async Task<int> checkaccount(string line)
    {
        RiotClient client;
        Account account;
        client = new RiotClient();
        account = await client.AuthAsync(line.Trim());
        Console.WriteLine(account.errmsg != null ? account.errmsg : account.code);
        if (account.code == 1) { Console.WriteLine("rliomktjids"); }
        if (account.region == null || account.code != 0) { return account.code; } // do smth here
        await accountinfo.get_rank(account);
        await accountinfo.get_lastplayed(account);
        await accountinfo.get_balance(account);
        await accountinfo.get_skins(account);
        await accountsinfodb.updateinfo(account);
        Console.WriteLine(account.ToString());
        return 0;
    }
}
