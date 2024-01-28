

int boardSize = int.Parse(Console.ReadLine());
char[,] matrix = new char[boardSize, boardSize];

for (int row = 0; row < boardSize; row++)
{
    string data = Console.ReadLine();

    for (int col = 0; col < boardSize; col++)
    {
        matrix[row, col] = data[col];
    }
}
int knightsRemoved = 0;

while (true)
{
    int mostViolentKnight = 0;
    int rowMostViolentKnight = -1;
    int colMostViolentKnight = -1;
    if (boardSize < 3)
    {
        break;
    }

    for (int row = 0; row < boardSize; row++)
    {
        for (int col = 0; col < boardSize; col++)
        {
            if (matrix[row, col] == 'K')
            {
                int attackedKnights = CountAttackedKnights(row, col, boardSize, matrix);
                if (mostViolentKnight < attackedKnights)
                {
                    mostViolentKnight = attackedKnights;
                    rowMostViolentKnight = row;
                    colMostViolentKnight = col;
                }
            }
        }
    }

    if(mostViolentKnight == 0)
    {
        break;
    }
    else
    {
        matrix[rowMostViolentKnight, colMostViolentKnight] = '0';
        knightsRemoved++;
    }
}

Console.WriteLine(knightsRemoved);

int CountAttackedKnights(int row, int col, int boardSize, char[,] matrix)
{
    int attackedKnights = 0;

    if (boardSize < 3)
    {
        return 0;
    }
    else
    {
        //Left-Up
        if (ValidateCell(row + 1, col - 2, boardSize))
        {
            if (matrix[row + 1, col - 2] == 'K')
            {
                attackedKnights++;
            }
        }

        //Left-Down
        if (ValidateCell(row - 1, col - 2, boardSize))
        {
            if (matrix[row - 1, col - 2] == 'K')
            {
                attackedKnights++;
            }
        }

        //Down-Left
        if (ValidateCell(row - 2, col - 1, boardSize))
        {
            if (matrix[row - 2, col - 1] == 'K')
            {
                attackedKnights++;
            }
        }

        //Down-Right
        if (ValidateCell(row - 2, col + 1, boardSize))
        {
            if (matrix[row - 2, col + 1] == 'K')
            {
                attackedKnights++;
            }
        }

        //Right-Up
        if (ValidateCell(row - 1, col + 2, boardSize))
        {
            if (matrix[row - 1, col + 2] == 'K')
            {
                attackedKnights++;
            }
        }

        //Right-Down
        if (ValidateCell(row + 1, col + 2, boardSize))
        {
            if (matrix[row + 1, col + 2] == 'K')
            {
                attackedKnights++;
            }
        }

        //Up-Left
        if (ValidateCell(row + 2, col - 1, boardSize))
        {
            if (matrix[row + 2, col - 1] == 'K')
            {
                attackedKnights++;
            }
        }

        //Up-Right
        if (ValidateCell(row + 2, col + 1, boardSize))
        {
            if (matrix[row + 2, col + 1] == 'K')
            {
                attackedKnights++;
            }
        }

        return attackedKnights;
    }
}

bool ValidateCell(int row, int col, int boardSize)
{
    return
        row >= 0 && col >= 0 && row < boardSize && col < boardSize;
}