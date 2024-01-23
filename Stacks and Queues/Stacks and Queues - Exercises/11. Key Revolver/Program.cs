int bulletPrice = int.Parse(Console.ReadLine());
int gunBarrelSize = int.Parse(Console.ReadLine());

int[] samsBullets = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

int[] samsLocks = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

int intelligenceValue = int.Parse(Console.ReadLine());

Queue<int> locks = new Queue<int>(samsLocks);
Stack<int> bullets = new Stack<int>(samsBullets);

int costOfShots = 0;
int shots = gunBarrelSize;
while (locks.Count > 0 && bullets.Count > 0)
{
    int nextShot = bullets.Pop();
    costOfShots += bulletPrice;
    shots--;

    if (nextShot <= locks.Peek())
    {
        Console.WriteLine("Bang!");
        locks.Dequeue();
    }
    else
    {
        Console.WriteLine("Ping!");
    }

    if (bullets.Count == 0)
    {
        continue;
    }

    if (shots == 0)
    {
        Console.WriteLine("Reloading!");
        shots = gunBarrelSize;
    }
}

string output = locks.Count > 0 ? $"Couldn't get through. Locks left: {locks.Count}"
    : $"{bullets.Count} bullets left. Earned ${intelligenceValue - costOfShots}";

Console.WriteLine(output);