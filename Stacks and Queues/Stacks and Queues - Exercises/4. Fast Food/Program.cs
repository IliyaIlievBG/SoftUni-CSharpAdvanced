int foodQuantity = int.Parse(Console.ReadLine());

int[] ordersInput = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

Queue<int> orders = new Queue<int>(ordersInput);

Console.WriteLine(orders.Max());

while (orders.Count > 0)
{
    if (foodQuantity - orders.Peek() >= 0)
    {
        foodQuantity -= orders.Dequeue();
    }
    else
    {
        Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
        return;
    }
}
Console.WriteLine("Orders complete");