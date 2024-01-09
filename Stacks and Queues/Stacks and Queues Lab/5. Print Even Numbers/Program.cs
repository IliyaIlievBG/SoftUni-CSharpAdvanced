int[] numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

Queue<int> evenNums = new Queue<int>();

for (int i = 0; i < numbers.Length; i++)
{
    if (numbers[i] % 2 == 0)
    {
        evenNums.Enqueue(numbers[i]);
    }
}

Console.Write(evenNums.Dequeue());

while (evenNums.Count>0)
{
    Console.Write($", {evenNums.Dequeue()}");
}