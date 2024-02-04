double[] input = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => double.Parse(x))
    .ToArray();

Dictionary<double, int> doubles = new Dictionary<double, int>();

for (int number = 0; number < input.Length; number++)
{
    if (!doubles.ContainsKey(input[number]))
    {
        doubles.Add(input[number], 1);
    }
    else
    {
        doubles[input[number]]++;
    }
}

foreach (KeyValuePair<double, int> number in doubles)
{
    Console.WriteLine($"{number.Key} - {number.Value} times");
}