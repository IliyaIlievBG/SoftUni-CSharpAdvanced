int numberOfCommands = int.Parse(Console.ReadLine());

Stack<int> numbers = new Stack<int>();

for (int i = 0; i < numberOfCommands; i++)
{
    int[] currentCommandInfo = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(x => int.Parse(x))
        .ToArray();

    int currentCommand = currentCommandInfo[0];
    if (currentCommand == 1)
    {
        AddNumber(numbers, currentCommandInfo);
    }
    else if (currentCommand == 2)
    {
        RemoveNumbers(numbers);
    }
    else
    {
        PrintNumber(currentCommand, numbers);
    }
}

Console.WriteLine(string.Join(", ", numbers));
void PrintNumber(int currentCommand, Stack<int> numbers)
{
    if (numbers.Count() > 0)
    {
        int numberToPrint = currentCommand == 3 ? numbers.Max() : numbers.Min();
        Console.WriteLine(numberToPrint);
    }
}

static void AddNumber(Stack<int> numbers, int[] currentCommandInfo)
{
    numbers.Push(currentCommandInfo[1]);
}

static void RemoveNumbers(Stack<int> numbers)
{
    if (numbers.Count > 0)
    {
        numbers.Pop();
    }
}
