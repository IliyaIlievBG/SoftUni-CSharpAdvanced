int pascalTriangleSize = int.Parse(Console.ReadLine());

long[][] pascalTriangle = new long[pascalTriangleSize][];
pascalTriangle[0] = new long[1] { 1 };

for (int row = 1; row < pascalTriangle.GetLength(0); row++)
{
    long[] nextRow = new long[row + 1];

    for (int column = 0; column < nextRow.Length; column++)
    {
        long elementAtPreviousRowSameColumn = column > pascalTriangle[row-1].Length-1 ? 0 : pascalTriangle[row - 1][column];
        long elementAtPreviousRowOneColumnBack = column - 1 < 0 ? 0 : pascalTriangle[row - 1][column - 1];
       
        nextRow[column] = elementAtPreviousRowSameColumn + elementAtPreviousRowOneColumnBack;
    }

    pascalTriangle[row] = nextRow;
}

for (int row = 0; row < pascalTriangle.GetLength(0); row++)
{
    for (int column = 0; column < pascalTriangle[row].Length; column++)
    {
        Console.Write($"{pascalTriangle[row][column]} ");
    }

    Console.WriteLine();
}