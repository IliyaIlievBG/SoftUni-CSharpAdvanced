string[] songs = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

Queue<string> playList = new Queue<string>(songs);

while (true)
{
    string[] commandInfo = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    string command = commandInfo[0];
    if (command == "Play")
    {
        if (playList.Any())
        {
            playList.Dequeue();
        }

        if (playList.Count == 0)
        {
            Console.WriteLine("No more songs!");
            break;
        }
    }
    else if (command == "Add")
    {
        string songToAdd = string.Join(' ', commandInfo.Skip(1));
        if (playList.Contains(songToAdd))
        {
            Console.WriteLine($"{songToAdd} is already contained!");
        }
        else
        {
            playList.Enqueue(songToAdd);
        }
    }
    else
    {
        Console.WriteLine(string.Join(", ", playList));     
    }
}