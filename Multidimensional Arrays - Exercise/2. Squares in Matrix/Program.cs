int[] dimensions = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int rows = dimensions[0];
int columns = dimensions[1];
string[,] matrix = new string[rows, columns];

for (int row = 0; row < rows; row++)
{
    string[] input = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    for (int col = 0; col < columns; col++)
    {
        matrix[row, col] = input[col];
    }
}

int foundResults = 0;
for (int row = 0; row < rows-1; row++)
{
    for (int col = 0; col < columns-1; col++)
    {
        if (matrix[row, col] == matrix[row + 1, col] && matrix[row, col + 1] == matrix[row + 1, col + 1]
            && matrix[row, col] == matrix[row,col+1])
        {
            foundResults++;
        }
    }
}

Console.WriteLine(foundResults);