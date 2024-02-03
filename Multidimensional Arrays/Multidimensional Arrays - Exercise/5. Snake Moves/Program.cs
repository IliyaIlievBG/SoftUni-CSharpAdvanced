int[] matrixSize = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

string input = Console.ReadLine();
Queue<char> snake = new Queue<char>(input);

char[,] myMatrix = new char[matrixSize[0], matrixSize[1]];

for (int row = 0; row < myMatrix.GetLength(0); row++)
{
    if (row % 2 == 0)
    {
        for (int column = 0; column < myMatrix.GetLength(1); column++)
        {
            AddCharsFromSnake(snake, myMatrix, row, column);
        }
    }
    else
    {
        for (int column = myMatrix.GetLength(1) - 1; column >= 0; column--)
        {
            AddCharsFromSnake(snake, myMatrix, row, column);
        }
    }
}

for (int row = 0; row < myMatrix.GetLength(0); row++)
{
    for (int column = 0; column < myMatrix.GetLength(1); column++)
    {
        Console.Write(myMatrix[row, column]);
    }

    Console.WriteLine();
}

void AddCharsFromSnake(Queue<char> snake, char[,] myMatrix, int row, int column)
{
    char nextCharFromSnake = snake.Dequeue();
    myMatrix[row, column] = nextCharFromSnake;
    snake.Enqueue(nextCharFromSnake);
}
