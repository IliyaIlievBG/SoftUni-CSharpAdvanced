int rowsCount = int.Parse(Console.ReadLine());

int[][] myJaggedArray = new int[rowsCount][];

for (int row = 0; row < rowsCount; row++)
{
    int[] currentRow = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(x => int.Parse(x))
        .ToArray();

    myJaggedArray[row] = currentRow;
}

string command = Console.ReadLine();

while (command != "END")
{
    string[] currentAction = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

    string action = currentAction[0];
    int row = int.Parse(currentAction[1]);
    int column = int.Parse(currentAction[2]);
    int value = int.Parse(currentAction[3]);

    bool validCoordinates = CheckCoordinates(row, column, myJaggedArray);

    if (validCoordinates)
    {
        if (action == "Add")
        {
            myJaggedArray[row][column] += value;
        }
        else if (action == "Subtract")
        {
            myJaggedArray[row][column] -= value;
        }
    }

    command = Console.ReadLine();
}

for (int row = 0; row < myJaggedArray.GetLength(0); row++)
{
    for (int column = 0; column < myJaggedArray[row].Length; column++)
    {
        Console.Write($"{myJaggedArray[row][column]} ");
    }

    Console.WriteLine();
}

bool CheckCoordinates(int row, int column, int[][] myJaggedArray)
{
    if (row < myJaggedArray.GetLength(0) && row >= 0)
    {
        if (column < myJaggedArray[row].Length && column >= 0)
        {
            return true;
        }
    }

    Console.WriteLine("Invalid coordinates");
    return false;
}