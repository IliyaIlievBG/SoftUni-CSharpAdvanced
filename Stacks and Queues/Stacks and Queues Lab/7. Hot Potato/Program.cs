Queue<string> children = new Queue<string>
    (Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
int allowedTosses = int.Parse(Console.ReadLine());

int performedTosses = 0;

while (children.Count > 1)
{
    string childWithPotato = children.Dequeue();
    performedTosses++;
    if (performedTosses == allowedTosses)
    {
        Console.WriteLine("Removed {0}", childWithPotato);
        performedTosses = 0;
    }
    else
    {
        children.Enqueue(childWithPotato);
    }
}

Console.WriteLine("Last is {0}", children.Dequeue());