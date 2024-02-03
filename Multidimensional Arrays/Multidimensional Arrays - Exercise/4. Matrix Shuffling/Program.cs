int[] matrixSize = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

string[,] myMatrix = new string[matrixSize[0], matrixSize[1]];

for (int row = 0; row < myMatrix.GetLength(0); row++)
{
    string[] currentRow = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    for (int column = 0; column < myMatrix.GetLength(1); column++)
    {
        myMatrix[row, column] = currentRow[column];
    }
}

while (true)
{
    string[] nextCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (nextCommand[0] == "END")
    {
        break;
    }

    bool commandIsValid = CheckIfCommandIsValid(nextCommand, myMatrix);

    if (commandIsValid)
    {
        int row1 = GetIndex(nextCommand[1]);
        int column1 = GetIndex(nextCommand[2]);
        int row2 = GetIndex(nextCommand[3]);
        int column2 = GetIndex(nextCommand[4]);

        (myMatrix[row1, column1], myMatrix[row2, column2]) = (myMatrix[row2, column2], myMatrix[row1, column1]);

        for (int row = 0; row < myMatrix.GetLength(0); row++)
        {
            for (int column = 0; column < myMatrix.GetLength(1); column++)
            {
                Console.Write($"{myMatrix[row, column]} ");
            }

            Console.WriteLine();
        }
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }
}

bool CheckIfCommandIsValid(string[] nextCommand, string[,] myMatrix)
{
    if (nextCommand[0] != "swap" || nextCommand.Length != 5)
    {
        return false;
    }
    int row1 = GetIndex(nextCommand[1]);
    int column1 = GetIndex(nextCommand[2]);
    int row2 = GetIndex(nextCommand[3]);
    int column2 = GetIndex(nextCommand[4]);

    if (row1 < 0 || row1 > myMatrix.GetLength(0) - 1
        || row2 < 0 || row2 > myMatrix.GetLength(0) - 1
        || column1 < 0 || column1 > myMatrix.GetLength(1) - 1
        || column2 < 0 || column2 > myMatrix.GetLength(1) - 1) 
    {
        return false;
    }

    return true;

}

int GetIndex(string index)
{
    return int.Parse(index);
}