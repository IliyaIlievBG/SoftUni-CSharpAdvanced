int boardSize = int.Parse(Console.ReadLine());

char[,] board = new char[boardSize, boardSize];

for (int row = 0; row < board.GetLength(0); row++)
{
    string nextRow = Console.ReadLine();

    for (int column = 0; column < board.GetLength(1); column++)
    {
        board[row, column] = nextRow[column];
    }
}

int removedAggressiveHorses = 0;

while (true)
{
    int mostAggressiveHorseyAttacksCount = 0;
    int currentHorseyAttacksCount = 0;
    int[] mostAggressiveHorseyCoordinates = new int[2];

    for (int row = 0; row < board.GetLength(0); row++)
    {
        for (int column = 0; column < board.GetLength(1); column++)
        {
            if (board[row, column] == 'K')
            {
                currentHorseyAttacksCount = GetCurrentHorseyAttackCount(board, row, column);
            }

            if (mostAggressiveHorseyAttacksCount < currentHorseyAttacksCount)
            {
                mostAggressiveHorseyAttacksCount = currentHorseyAttacksCount;
                mostAggressiveHorseyCoordinates[0] = row;
                mostAggressiveHorseyCoordinates[1] = column;
            }
        }
    }

    if (mostAggressiveHorseyAttacksCount == 0)
    {
        break;
    }
    board[mostAggressiveHorseyCoordinates[0], mostAggressiveHorseyCoordinates[1]] = '0';
    removedAggressiveHorses++;
}

Console.WriteLine(removedAggressiveHorses);
int GetCurrentHorseyAttackCount(char[,] board, int row, int column)
{
    int attacksCount = 0;

    if (CanAttack(board, row - 2, column - 1) && board[row - 2, column - 1] == 'K') //two down, one to the left
    {
        attacksCount++;
    }

    if (CanAttack(board, row - 2, column + 1) && board[row - 2, column + 1] == 'K') //two down, one to the right
    {
        attacksCount++;
    }

    if (CanAttack(board, row + 2, column - 1) && board[row + 2, column - 1] == 'K') //two up, one to the left
    {
        attacksCount++;
    }

    if (CanAttack(board, row + 2, column + 1) && board[row + 2, column + 1] == 'K') //two up, one to the right
    {
        attacksCount++;
    }

    if (CanAttack(board, row + 1, column - 2) && board[row + 1, column - 2] == 'K') //one up, two to the left
    {
        attacksCount++;
    }
    if (CanAttack(board, row + 1, column + 2) && board[row + 1, column + 2] == 'K') //one up, two to the right
    {
        attacksCount++;
    }
    if (CanAttack(board, row - 1, column - 2) && board[row - 1, column - 2] == 'K') //one down, two to the left
    {
        attacksCount++;
    }
    if (CanAttack(board, row - 1, column + 2) && board[row - 1, column + 2] == 'K') //one down, two to the right
    {
        attacksCount++;
    }
    return attacksCount;
}

static bool CanAttack(char[,] board, int row, int column)
{
    if (row >= 0 && row < board.GetLength(0)  && column >= 0 && column < board.GetLength(1))
    {
        return true;
    }

    return false;
}