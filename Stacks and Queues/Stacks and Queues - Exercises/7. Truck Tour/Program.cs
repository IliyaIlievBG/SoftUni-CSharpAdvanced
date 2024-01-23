int petrolPumpsCount = int.Parse(Console.ReadLine());

Queue<int[]> pumps = new Queue<int[]>();

for (int i = 0; i < petrolPumpsCount; i++)
{
    pumps.Enqueue(Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(x => int.Parse(x))
        .ToArray());
}

int bestStartIndex = 0;
int pumpsToCheck = pumps.Count();

while (pumpsToCheck > 0)
{
    int petrolInTruck = 0;

    foreach (int[] pump in pumps)
    {
        int petrolInCurrentPump = pump[0];
        int distanceToNextPump = pump[1];

        petrolInTruck += petrolInCurrentPump;

        if (petrolInTruck < distanceToNextPump)
        {
            petrolInTruck = -1;
            break;
        }
        else
        {
            petrolInTruck -= distanceToNextPump;
        }
    }

    if (petrolInTruck >= 0)
    {
        break;
    }
    else
    {
        bestStartIndex++;
        pumps.Enqueue(pumps.Dequeue());
    }

    pumpsToCheck--;
}

Console.WriteLine(bestStartIndex);