using System;
using valchecker;

public class Program
{
    public static async Task Main(string[] args)
    {
        RiotClient client = new RiotClient();
        Account account = await client.AuthAsync("Spiacydamixus:BOBERKOWNICAak8");
        if(account.region == null) { return; } // do smth here
        await accountinfo.get_rank(account);
        await accountinfo.get_lastplayed(account);
        await accountinfo.get_balance(account);
        await accountinfo.get_skins(account);

        Console.WriteLine(account.ToString());
        Console.WriteLine(account.errmsg!=null ? account.errmsg : account.code);
    }
}
