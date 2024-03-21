SortedDictionary<string, int> students = new SortedDictionary<string, int>();
SortedDictionary<string, int> submissions = new SortedDictionary<string, int>();

string command = Console.ReadLine();

while (command != "exam finished")
{
    string[] currentCommand = command.Split('-', StringSplitOptions.RemoveEmptyEntries);

    string username = currentCommand[0];
    string language = currentCommand[1];

    if (language == "banned")
    {
        if (students.ContainsKey(username))
        {
            students.Remove(username);
        }
    }
    else
    {
        int points = int.Parse(currentCommand[2]);

        if (!students.ContainsKey(username))
        {
            students.Add(username, points);
        }
        else
        {
            if (points > students[username])
            {
                students[username] = points;
            }
        }

        if (!submissions.ContainsKey(language))
        {
            submissions.Add(language, 1);
        }
        else
        {
            submissions[language]++;
        }
    }
    command = Console.ReadLine();
}

Console.WriteLine("Results:");
foreach (var student in students.OrderByDescending(x => x.Value))
{
    Console.WriteLine($"{student.Key} | {student.Value}");
}

Console.WriteLine("Submissions:");

foreach (var contest in submissions.OrderByDescending(x => x.Value))
{
    Console.WriteLine($"{contest.Key} - {contest.Value}");
}