Dictionary<string, string> contests = new Dictionary<string, string>();
SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();

string contest = Console.ReadLine();

while (contest != "end of contests")
{
    string[] currentContest = contest.Split(':', StringSplitOptions.RemoveEmptyEntries);
    bool validStrings = CheckIfStringsAreValid(currentContest);

    if (validStrings)
    {
        if (!contests.ContainsKey(currentContest[0]))
        {
            contests.Add(currentContest[0], currentContest[1]);
        }
    }

    contest = Console.ReadLine();
}

string userInfo = Console.ReadLine();

while (userInfo != "end of submissions")
{
    string[] currentUserInfo = userInfo.Split("=>", StringSplitOptions.RemoveEmptyEntries);
    bool validStrings = CheckIfStringsAreValid(currentUserInfo);

    if (validStrings)
    {
        string userContest = GetUserDetails(currentUserInfo, 0);
        string passwordForCurrentContext = GetUserDetails(currentUserInfo, 1);
        string user = GetUserDetails(currentUserInfo, 2);
        int pointsFromCurrentContest = int.Parse(GetUserDetails(currentUserInfo, 3));

        if (!users.ContainsKey(user))
        {
            users.Add(user, new Dictionary<string, int>());
        }

        if (contests.ContainsKey(userContest) && contests[userContest] == passwordForCurrentContext)
        {
            if (!users[user].ContainsKey(userContest))
            {
                users[user].Add(userContest, pointsFromCurrentContest);
            }

            else
            {
                if (pointsFromCurrentContest > users[user][userContest])
                {
                    users[user][userContest] = pointsFromCurrentContest;
                }
            }
        }
    }

    userInfo = Console.ReadLine();
}

Dictionary<string, Dictionary<string, int>> usersOrderedByTotalPoints = users
    .OrderByDescending(x => x.Value.Values.Sum())
    .ToDictionary(x => x.Key, x => x.Value);

string bestCandidate = usersOrderedByTotalPoints.Select(x => x.Key).First();
int bestCandidateTotalPoints = usersOrderedByTotalPoints.Select(x => x.Value.Values.Sum()).First();

Console.WriteLine("Best candidate is {0} with total {1} points.", bestCandidate, bestCandidateTotalPoints);
Console.WriteLine("Ranking:");

foreach (var (user, contestsList) in users.Where(x => x.Value.Count>0))
{
    Console.WriteLine(user);

    foreach (var (userContest, points) in contestsList.OrderByDescending(x => x.Value))
    {
        Console.WriteLine($"#  {userContest} -> {points}");
    }
}

bool CheckIfStringsAreValid(string[] stringToCheck)
{
    if (stringToCheck.Any(x => x.Contains(':'))
        || stringToCheck.Any(x => x.Contains('='))
        || stringToCheck.Any(x => x.Contains('>')))
    {
        return false;
    }

    return true;
}

string GetUserDetails(string[] userInfo, int index)
{
    return userInfo[index];
}