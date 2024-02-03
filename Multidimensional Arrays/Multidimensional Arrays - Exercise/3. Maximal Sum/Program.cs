int[] matrixSize = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

int[,] myMatrix = new int[matrixSize[0], matrixSize[1]];

for (int row = 0; row < myMatrix.GetLength(0); row++)
{
    int[] nextRow = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(x => int.Parse(x))
        .ToArray();

    for (int column = 0; column < myMatrix.GetLength(1); column++)
    {
        myMatrix[row, column] = nextRow[column];
    }
}

int bestSum = int.MinValue;
int bestRowIndex = 0;
int bestColumnIndex = 0;

for (int row = 0; row < myMatrix.GetLength(0) - 2; row++)
{
    for (int column = 0; column < myMatrix.GetLength(1) - 2; column++)
    {
        int currentSum = myMatrix[row, column]
                                       + myMatrix[row, column + 1]
                                       + myMatrix[row, column + 2]
                                       + myMatrix[row + 1, column]
                                       + myMatrix[row + 1, column + 1]
                                       + myMatrix[row + 1, column + 2]
                                       + myMatrix[row + 2, column]
                                       + myMatrix[row + 2, column + 1]
                                       + myMatrix[row + 2, column + 2];

        if (currentSum > bestSum)
        {
            bestSum = currentSum;
            bestRowIndex = row;
            bestColumnIndex = column;
        }
    }
}

Console.WriteLine($"Sum = {bestSum}");

for (int row = bestRowIndex; row <= bestRowIndex + 2; row++)
{
    for (int column = bestColumnIndex; column <= bestColumnIndex + 2; column++)
    {
        Console.Write($"{myMatrix[row, column]} ");
    }

    Console.WriteLine();
}