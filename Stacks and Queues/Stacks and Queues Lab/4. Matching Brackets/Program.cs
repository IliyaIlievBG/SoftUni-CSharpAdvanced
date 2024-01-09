
string expression = Console.ReadLine();

Stack<int> openingBracketsIndexes = new Stack<int>();

for (int i = 0; i < expression.Length; i++)
{
    if (expression[i] == '(')
    {
        openingBracketsIndexes.Push(i);
    }

    if (expression[i] == ')') 
    {
        int openBracketIndex = openingBracketsIndexes.Pop();

        Console.WriteLine(expression.Substring(openBracketIndex, i - openBracketIndex+1));
    }
}