using System.Security.Cryptography.X509Certificates;

Dictionary<string, VloggerInfo> vloggers = new Dictionary<string, VloggerInfo>();

string command = Console.ReadLine();

while (command != "Statistics")
{
    string[] currentCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string vloggerName = currentCommand[0];

    if (currentCommand[1] == "joined")
    {
        AddVlogger(vloggers, vloggerName);
    }
    else
    {
        bool commandIsValid = CheckIfCommandIsValid(vloggerName, currentCommand[2], vloggers);

        if (commandIsValid)
        {
            if (!vloggers[currentCommand[2]].Followers.Contains(vloggerName))
            {
                vloggers[vloggerName].Following++;
                vloggers[currentCommand[2]].Followers.Add(vloggerName);
            }
        }
    }

    command = Console.ReadLine();
}

Console.WriteLine("The V-Logger has a total of {0} vloggers in its logs.", vloggers.Count);

int ranking = 1;

foreach (var (vlogger, vloggerInfo) in vloggers
             .OrderByDescending(x => x.Value.Followers.Count)
             .ThenBy(x => x.Value.Following))
{
    Console.WriteLine($"{ranking}. {vlogger} : {vloggerInfo.Followers.Count} followers, {vloggerInfo.Following} following");

    if (ranking == 1)
    {
        foreach (string follower in vloggerInfo.Followers)
        {
            Console.WriteLine($"*  {follower}");
        }
    }
    ranking++;
}

void AddVlogger(Dictionary<string, VloggerInfo> vloggers, string vloggerToAdd)
{
    if (!vloggers.ContainsKey(vloggerToAdd))
    {
        vloggers.Add(vloggerToAdd, new VloggerInfo(new SortedSet<string>(), 0));
    }
}

bool CheckIfCommandIsValid(string firstVlogger, string secondVlogger, Dictionary<string, VloggerInfo> vloggers)
{
    return firstVlogger != secondVlogger &&
           (vloggers.ContainsKey(firstVlogger) && vloggers.ContainsKey(secondVlogger));
}

class VloggerInfo
{
    public VloggerInfo(SortedSet<string> followers, int following)
    {
        Followers = new SortedSet<string>();
        Following = 0;
    }
    public SortedSet<string> Followers { get; set; }
    public int Following { get; set; }
}