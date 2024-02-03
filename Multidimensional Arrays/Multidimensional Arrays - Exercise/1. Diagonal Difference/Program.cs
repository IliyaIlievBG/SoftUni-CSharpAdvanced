int matrixSize = int.Parse(Console.ReadLine());

int[,] myMatrix = new int[matrixSize, matrixSize];

for (int row = 0; row < myMatrix.GetLength(0); row++)
{
    int[] rowArray = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(x => int.Parse(x))
        .ToArray();

    for (int column = 0; column < myMatrix.GetLength(1); column++)
    {
        myMatrix[row, column] = rowArray[column];
    }
}

int primaryDiagonalSum = 0;
int secondaryDiagonalSum = 0;

for (int row = 0; row < myMatrix.GetLength(0); row++)
{
    primaryDiagonalSum += myMatrix[row, row];
}

for (int row = 0; row < myMatrix.GetLength(0); row++)
{
    secondaryDiagonalSum += myMatrix[row, matrixSize - 1 - row];
}

Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));