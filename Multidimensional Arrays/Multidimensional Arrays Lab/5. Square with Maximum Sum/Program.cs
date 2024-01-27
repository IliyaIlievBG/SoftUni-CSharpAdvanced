int[] matrixSize = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

int rows = matrixSize[0];
int columns = matrixSize[1];

int[,] myMatrix = new int[rows, columns];

for (int row = 0; row < myMatrix.GetLength(0); row++)
{
    int[] currentRow = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .Select(x => int.Parse(x))
        .ToArray();

    for (int column = 0; column < myMatrix.GetLength(1); column++)
    {
        myMatrix[row, column] = currentRow[column];
    }
}

int biggestSum = int.MinValue;

int[,] bestMatrix = { { 0, 0 }, { 0, 0 } };

for (int row = 0; row < myMatrix.GetLength(0) - 1; row++)
{
    for (int column = 0; column < myMatrix.GetLength(1) - 1; column++)
    {
        int currentSum = myMatrix[row, column]
                         + myMatrix[row, column + 1]
                         + myMatrix[row + 1, column]
                         + myMatrix[row + 1, column + 1];
        if (currentSum > biggestSum)
        {
            biggestSum = currentSum;

            bestMatrix[0, 0] = myMatrix[row, column];
            bestMatrix[0, 1] = myMatrix[row, column + 1];
            bestMatrix[1, 0] = myMatrix[row + 1, column];
            bestMatrix[1, 1] = myMatrix[row + 1, column + 1];
        }
    }
}

for (int row = 0; row < bestMatrix.GetLength(0); row++)
{
    for (int column = 0; column < bestMatrix.GetLength(1); column++)
    {
        Console.Write($"{bestMatrix[row, column]} ");
    }

    Console.WriteLine();
}

Console.WriteLine(biggestSum);