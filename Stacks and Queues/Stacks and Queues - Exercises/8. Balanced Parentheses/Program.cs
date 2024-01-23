string input = Console.ReadLine();

Stack<char> parentheses = new Stack<char>();

foreach (char symbol in input)
{
    if (symbol == '(' || symbol == '[' || symbol == '{')
    {
        parentheses.Push(symbol);
        continue;
    }

    if (parentheses.Count==0)
    {
        parentheses.Push(symbol);
    }

    PopItemsFromParentheses(symbol, parentheses);
}

string output = parentheses.Count == 0 ? "YES" : "NO";
Console.WriteLine(output);

static void PopItemsFromParentheses(char symbol, Stack<char> parentheses)
{
    if (symbol == ')' && parentheses.Peek() == '(')
    {
        parentheses.Pop();
    }
    else if (symbol == ']' && parentheses.Peek() == '[')
    {
        parentheses.Pop();
    }
    else if (symbol == '}' && parentheses.Peek() == '{')
    {
        parentheses.Pop();
    }
}