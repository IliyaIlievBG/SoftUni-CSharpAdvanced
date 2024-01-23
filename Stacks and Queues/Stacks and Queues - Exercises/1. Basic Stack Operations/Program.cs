int[] input = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

static int GetSmallestNum(Stack<int> myStack)
{
    int smallestNum = int.MaxValue;
    while (myStack.Count > 0)
    {
        int nextPoppedNum = myStack.Pop();
        smallestNum = nextPoppedNum < smallestNum ? nextPoppedNum : smallestNum;
    }

    return smallestNum;
}

int[] numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

Stack<int> myStack = new Stack<int>();

int numbersToPush = input[0];
int numbersToPop = input[1];
int numberToCheck = input[2];

PushNumbers(numbersToPush, numbers, myStack);

PopNumbers(numbersToPop, numbers, myStack);

if (myStack.Count == 0)
{
    Console.WriteLine(0);
}
else
{
    if (myStack.Contains(numberToCheck))
    {
        Console.WriteLine("true");
    }
    else
    {
        int smallestNum = GetSmallestNum(myStack);
        Console.WriteLine(smallestNum);
    }
}
void PushNumbers(int numbersToPush, int[] numbers, Stack<int> myStack)
{
    for (int i = 0; i < numbersToPush; i++)
    {
        if (i <= numbers.Length)
        {
            myStack.Push(numbers[i]);
        }
    }
}

void PopNumbers(int numbersToPop1, int[] ints, Stack<int> stack)
{
    for (int i = 0; i < numbersToPop1; i++)
    {
        if (i <= ints.Length)
        {
            stack.Pop();
        }
    }
}