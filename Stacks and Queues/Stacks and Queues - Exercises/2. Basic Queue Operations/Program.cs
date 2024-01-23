int[] input = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

int[] numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

int numbersToAdd = input[0];
int numbersToRemove = input[1];
int numberToCheck = input[2];

Queue<int> myQueue = new Queue<int>(numbers.Take(numbersToAdd));

while (numbersToRemove > 0 && myQueue.Count > 0)
{
    myQueue.Dequeue();
    numbersToRemove--;
}

if (myQueue.Contains(numberToCheck))
{
    Console.WriteLine("true");
}
else if (myQueue.Count == 0)
{
    Console.WriteLine(0);
}
else
{
    Console.WriteLine(myQueue.Min());
}