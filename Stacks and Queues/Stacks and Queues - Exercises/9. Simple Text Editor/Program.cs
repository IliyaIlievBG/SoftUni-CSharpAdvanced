using System.Text;

int operationsCount = int.Parse(Console.ReadLine());

StringBuilder text = new StringBuilder();
Stack<string> states = new Stack<string>();

for (int i = 0; i < operationsCount; i++)
{
    string[] currentOperation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

    int currentCommand = int.Parse(currentOperation[0]);

    if (currentCommand == 1)
    {
        states.Push(text.ToString());
        text.Append(currentOperation[1]);
    }
    else if (currentCommand == 2)
    {
        states.Push(text.ToString());
        text.Remove(text.Length - int.Parse(currentOperation[1]), int.Parse(currentOperation[1]));
    }
    else if (currentCommand == 3)
    {
        Console.WriteLine(text[int.Parse(currentOperation[1]) - 1]);
    }
    else
    {
        RevertText(text, states);
    }
}

static void RevertText(StringBuilder text, Stack<string> states)
{
    if (text.Length!=0)
    {
        text.Replace(text.ToString(), states.Pop());
    }
    else
    {
        text.Append(states.Pop());
    }
}