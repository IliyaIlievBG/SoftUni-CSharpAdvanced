int numbersCount = int.Parse(Console.ReadLine());

Dictionary<int, int> numbers = new Dictionary<int, int>();

for (int i = 0; i < numbersCount; i++)
{
    int nextNum = int.Parse(Console.ReadLine());

    if (!numbers.ContainsKey(nextNum))
    {
        numbers.Add(nextNum, 0);
    }

    numbers[nextNum]++;
}
Console.WriteLine(numbers.First(x => x.Value % 2 == 0).Key);