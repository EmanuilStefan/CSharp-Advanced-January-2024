int[] dimentions = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int[,] matrix = new int[dimentions[0], dimentions[1]];

for (int rows = 0; rows < dimentions[0]; rows++)
{
    int[] data = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

    for (int cols = 0; cols < dimentions[1]; cols++)
    {
        matrix[rows, cols] = data[cols];
    }
}

int maxSum = int.MinValue;
int[,] biggestSumMatrix = new int[3, 3];
for (int i = 0; i < dimentions[0] - 2; i++)
{
    for (int j = 0; j < dimentions[1] - 2; j++)
    {
        int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
            + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
            + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

        if (sum > maxSum)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    biggestSumMatrix[row, col] = matrix[i + row, j + col];
                }
            }
            maxSum = sum;
        }
    }
}

Console.WriteLine($"Sum = {maxSum}");

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write($"{biggestSumMatrix[i, j]} ");
    }
    Console.WriteLine();
}