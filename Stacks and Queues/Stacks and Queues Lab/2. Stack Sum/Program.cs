int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

string command = Console.ReadLine().ToLower();

Stack<int> numbersToSum = new Stack<int>(numbers);
while (command != "end")
{
    string[] currentCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string currentAction = currentCommand[0].ToLower();

    if (currentAction == "add")
    {
        numbersToSum.Push(int.Parse(currentCommand[1]));
        numbersToSum.Push(int.Parse(currentCommand[2]));
    }
    else
    {
        bool currentCommandIsValid = CheckCurrentCommand(int.Parse(currentCommand[1]), numbersToSum);
        if (currentCommandIsValid)
        {
            for (int i = 0; i < int.Parse(currentCommand[1]); i++)
            {
                numbersToSum.Pop();
            }
        }
    }

    command = Console.ReadLine().ToLower();
}

int sum = 0;

foreach (var num in numbersToSum)
{
    sum += num;
}
Console.WriteLine(sum);
static bool CheckCurrentCommand(int numbersToRemove, Stack<int> numbersToSum)
{
    return numbersToRemove > numbersToSum.Count ? false : true;
}