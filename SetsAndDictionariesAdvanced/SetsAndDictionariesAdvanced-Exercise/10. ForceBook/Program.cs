SortedDictionary<string, SortedSet<string>> sides = new SortedDictionary<string, SortedSet<string>>();

string command = Console.ReadLine();

while (command != "Lumpawaroo")
{
    string[] currentCommand = command.Split(new string[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries);

    if (command.Contains(" | "))
    {
        string user = GetDataFromCurrentCommand(currentCommand, 1);
        string side = GetDataFromCurrentCommand(currentCommand, 0);

        AddUser(sides, side, user);
    }
    else
    {
        string user = GetDataFromCurrentCommand(currentCommand, 0);
        string side = GetDataFromCurrentCommand(currentCommand, 1);

        if (sides.Any(x => x.Value.Contains(user)))
        {
            var sideToBeAmmended = sides
                .Where(x => x.Value.Contains(user))
                .Select(x => x.Key).Single();

            sides[sideToBeAmmended].Remove(user);
        }

        AddUser(sides, side, user);

        Console.WriteLine($"{user} joins the {side} side!");
    }

    command = Console.ReadLine();
}

foreach (var side in sides.OrderByDescending(x => x.Value.Count))
{
    if (side.Value.Count > 0)
    {
        Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
        foreach (var user in side.Value)
        {
            Console.WriteLine($"! {user}");
        }
    }
}

string GetDataFromCurrentCommand(string[] currentCommand, int index)
{
    return currentCommand[index];
}

void AddUser(SortedDictionary<string, SortedSet<string>> sides, string side, string user)
{
    if (!sides.ContainsKey(side))
    {
        sides.Add(side, new SortedSet<string>());
    }
    sides[side].Add(user);

}