int[] matrixSize = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

int rows = matrixSize[0];
int columns = matrixSize[1];

int[,] myMatrix = ReadMatrix(rows, columns, ", ");

int sum = 0;

for (int row = 0; row < myMatrix.GetLength(0); row++)
{
    for (int column = 0; column < myMatrix.GetLength(1); column++)
    {
        sum += myMatrix[row, column];
    }
}

Console.WriteLine(myMatrix.GetLength(0));
Console.WriteLine(myMatrix.GetLength(1));
Console.WriteLine(sum);
int[,] ReadMatrix(int rows, int columns, string separator)
{
    int[,] myMatrix = new int[rows, columns];

    for (int row = 0; row < myMatrix.GetLength(0); row++)
    {
        int[] rowArray = Console.ReadLine()
            .Split(separator, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();

        for (int column = 0; column < myMatrix.GetLength(1); column++)
        {
            myMatrix[row, column] = rowArray[column];
        }
    }
    
    return myMatrix;
}