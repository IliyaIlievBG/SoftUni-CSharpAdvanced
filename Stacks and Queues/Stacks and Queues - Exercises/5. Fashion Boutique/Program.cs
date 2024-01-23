int[] boxesWithClothes = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

int rackCapacity = int.Parse(Console.ReadLine());

Stack<int> clothesToOrganise = new Stack<int>(boxesWithClothes);

int usedRacks = 1;
int currentRackUsedCapacity = 0;

while (clothesToOrganise.Count() > 0)
{
    int currentBox = clothesToOrganise.Pop();

    if (currentBox + currentRackUsedCapacity > rackCapacity)
    {
        usedRacks++;
        currentRackUsedCapacity = currentBox;
    }
    else
    {
        currentRackUsedCapacity += currentBox;
    }
}

Console.WriteLine(usedRacks);