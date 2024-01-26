int[] dimensions = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string[,] matrix = new string[dimensions[0], dimensions[1]];

for (int row = 0; row < dimensions[0]; row++)
{
    string[] rows = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)    
    .ToArray();

    for (int col = 0; col < dimensions[1]; col++)
    {
        matrix[row, col] = rows[col].ToString();
    }
}

while (true)
{
    string[] command = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .ToArray();

    if (command[0].StartsWith("swap".ToLower()) && command.Length == 5)
    {
        int takeFromRow, takeFromCol, placeToRow, placeToCol;

        // Parse the command parameters
        if (int.TryParse(command[1], out takeFromRow) &&
            int.TryParse(command[2], out takeFromCol) &&
            int.TryParse(command[3], out placeToRow) &&
            int.TryParse(command[4], out placeToCol) &&
            takeFromRow >= 0 && takeFromRow < dimensions[0] &&
            takeFromCol >= 0 && takeFromCol < dimensions[1] &&
            placeToRow >= 0 && placeToRow < dimensions[0] &&
            placeToCol >= 0 && placeToCol < dimensions[1])
        {
            // The indices are valid, perform the swap
            string value = matrix[takeFromRow, takeFromCol];
            matrix[takeFromRow, takeFromCol] = matrix[placeToRow, placeToCol];
            matrix[placeToRow, placeToCol] = value;

            PrintMatrix(matrix);
        }
        else
        {
            Console.WriteLine("Invalid input!");
            continue;
        }
    }
    else if (command[0].ToLower() == "end")
    {
        break; // Exit the loop when "end" is encountered
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }
}

void PrintMatrix(string[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]} ");
        }
        Console.WriteLine();
    }
}