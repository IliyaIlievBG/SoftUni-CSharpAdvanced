List<int> numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .OrderByDescending(x => x)
    .ToList();

List<int> outputNumbers = numbers.Take(3).ToList();

Console.WriteLine(String.Join(' ', outputNumbers));