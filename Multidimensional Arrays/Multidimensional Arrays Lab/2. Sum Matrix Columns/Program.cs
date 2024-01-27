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
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(x => int.Parse(x))
        .ToArray();

    for (int column = 0; column < myMatrix.GetLength(1); column++)
    {
        myMatrix[row, column] = currentRow[column];
    }
}

for (int column = 0; column < myMatrix.GetLength(1); column++)
{
    int sum = 0;
    for (int row = 0; row < myMatrix.GetLength(0); row++)
    {
        sum += myMatrix[row, column];
    }

    Console.WriteLine(sum);
}
