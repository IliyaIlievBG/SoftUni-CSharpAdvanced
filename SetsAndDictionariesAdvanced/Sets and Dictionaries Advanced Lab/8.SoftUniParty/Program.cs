string input = Console.ReadLine();

HashSet<string> VIP = new HashSet<string>();
HashSet<string> peasants = new HashSet<string>();

while (input != "PARTY")
{
    if (char.IsDigit(input[0]))
    {
        VIP.Add(input);
    }
    else
    {
        peasants.Add(input);
    }

    input = Console.ReadLine();
}

while (input != "END")
{
    if (char.IsDigit(input[0]))
    {
        VIP.Remove(input);
    }
    else
    {
        peasants.Remove(input);
    }

    input = Console.ReadLine();
}

Console.WriteLine(VIP.Count + peasants.Count);

foreach (var guest in VIP)
{
    Console.WriteLine(guest);
}

foreach (var guest in peasants)
{
    Console.WriteLine(guest);
}
