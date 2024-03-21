int inputLinesCount = int.Parse(Console.ReadLine());

SortedSet<string> periodicTable = new SortedSet<string>();

for (int i = 0; i < inputLinesCount; i++)
{
    string[] nextArrayOfElements = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    periodicTable.UnionWith(nextArrayOfElements);
}

Console.WriteLine(String.Join(' ', periodicTable));
