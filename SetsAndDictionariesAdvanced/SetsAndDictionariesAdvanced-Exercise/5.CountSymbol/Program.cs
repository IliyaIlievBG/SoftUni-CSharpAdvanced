string input = Console.ReadLine();

SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

for (int i = 0; i < input.Length; i++)
{
    if (!symbols.ContainsKey(input[i]))
    {
        symbols.Add(input[i], 0);
    }

    symbols[input[i]]++;
}

foreach (var (symbol, count) in symbols)
{
    Console.WriteLine($"{symbol}: {count} time/s");
}