string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
var reversedInput = input.Reverse();

Stack<string> inputToStack = new Stack<string>(reversedInput);

int result = 0;
result += int.Parse(inputToStack.Pop());

while (inputToStack.Count > 0)
{
    char operation = char.Parse(inputToStack.Peek());
	inputToStack.Pop();

	if (operation == '+')
	{
		result += int.Parse(inputToStack.Pop());
	}	
	else
	{
		result -= int.Parse(inputToStack.Pop());
	}
}
Console.WriteLine(result);