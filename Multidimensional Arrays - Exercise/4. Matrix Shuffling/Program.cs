int[] dimensions = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string[,] matrix = new string[dimensions[0], dimensions[1]];

for (int row = 0; row < dimensions[0]; row++)
{
    int[] rows = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

    for (int col = 0; col < dimensions[1]; col++)
    {
        matrix[row, col] = rows[col].ToString();
    }
}

while (true)
{
    string[] command = Console.ReadLine()
        .Split(' ',StringSplitOptions.RemoveEmptyEntries)
        .ToArray();

    switch (command[0])
    {
        case "swap":
            int takeFromRow = int.Parse(command[1]);
            int takeFromCol = int.Parse(command[2]);
            int value = int.Parse(matrix[takeFromRow, takeFromCol]);
            matrix[]

    }
}