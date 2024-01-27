int matrixSize = int.Parse(Console.ReadLine());

char[,] charMatrix = new char[matrixSize, matrixSize];

for (int row = 0; row < charMatrix.GetLength(0); row++)
{
    char[] currentRow = Console.ReadLine().ToCharArray();

    for (int column = 0; column < charMatrix.GetLength(1); column++)
    {
        charMatrix[row, column] = currentRow[column];
    }
}

char charToCheck = char.Parse(Console.ReadLine());

for (int row = 0; row < charMatrix.GetLength(0); row++)
{
    for (int column = 0; column < charMatrix.GetLength(1); column++)
    {
        if (charMatrix[row, column] == charToCheck)
        {
            Console.WriteLine($"({row}, {column})");
            return;
        }
    }
}

Console.WriteLine($"{charToCheck} does not occur in the matrix");
