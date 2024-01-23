int[] inputCups = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

int[] inputBottles = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

Queue<int> cups = new Queue<int>(inputCups);
Stack<int> bottles = new Stack<int>(inputBottles);

int wastedWater = 0;
while (cups.Count > 0 && bottles.Count > 0)
{
    int nextBottle = bottles.Pop(); //4
    int nextCup = cups.Peek(); //5
    if (nextBottle >= nextCup)
    {
        wastedWater += nextBottle - cups.Dequeue();
    }
    else
    {
        nextCup -= nextBottle;

        while (nextCup > 0)
        {
            int additionalBottle = bottles.Pop();
            nextCup -= additionalBottle;

            if (nextCup <= 0)
            {
                cups.Dequeue();
                wastedWater += Math.Abs(nextCup);
            }

        }

    }
}

string output = cups.Count() > 0 ? $"Cups: {string.Join(' ', cups)}" : $"Bottles: {string.Join(' ', bottles)}";
Console.WriteLine(output);
Console.WriteLine($"Wasted litters of water: {wastedWater}");