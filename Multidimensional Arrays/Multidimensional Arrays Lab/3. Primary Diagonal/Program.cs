int squareMatrixSize = int.Parse(Console.ReadLine());

int[,] mySquare = new int[squareMatrixSize, squareMatrixSize];

for (int row = 0; row < mySquare.GetLength(0); row++)
{
    int[] currentRow = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(x => int.Parse(x))
        .ToArray();

    for (int column = 0; column < mySquare.GetLength(1); column++)
    {
        mySquare[row, column] = currentRow[column];
    }
}

int sumOfPrimaryDiagonalElements = 0;

for (int i = 0; i < mySquare.GetLength(0); i++)
{
    sumOfPrimaryDiagonalElements += mySquare[i, i];
}

Console.WriteLine(sumOfPrimaryDiagonalElements);