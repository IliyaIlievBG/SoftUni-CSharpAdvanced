int[] matrixSize = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

char[,] charMatrix = new char[matrixSize[0], matrixSize[1]];

for (int row = 0; row < charMatrix.GetLength(0); row++)
{
    char[] nextCharRow = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(x => char.Parse(x))
        .ToArray();

    for (int column = 0; column < charMatrix.GetLength(1); column++)
    {
        charMatrix[row, column] = nextCharRow[column];
    }
}

int squareMatrixesCount = 0;

for (int row = 0; row < charMatrix.GetLength(0) - 1; row++)
{
    for (int column = 0; column < charMatrix.GetLength(1) - 1; column++)
    {
        if (charMatrix[row, column] == charMatrix[row, column + 1]
            && charMatrix[row, column] == charMatrix[row + 1, column]
            && charMatrix[row, column] == charMatrix[row+1, column+1])
        {
            squareMatrixesCount++;
        }
    }
}

Console.WriteLine(squareMatrixesCount);