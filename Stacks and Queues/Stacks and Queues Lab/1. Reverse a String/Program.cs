string input = Console.ReadLine();

Stack<char> reveresedInput = new Stack<char>();

foreach (var symbol in input)
{
   reveresedInput.Push(symbol);
}

while (reveresedInput.Count > 0)
{
    Console.Write(reveresedInput.Pop());
}