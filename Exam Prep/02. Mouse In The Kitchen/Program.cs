using System.ComponentModel.DataAnnotations.Schema;

namespace _02._Mouse_In_The_Kitchen;

internal class Program
{
    static void Main(string[] args)
    {
        int[] dimensions = Console.ReadLine()
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        char[,] field = new char[dimensions[0], dimensions[1]];

        for (int row = 0; row < dimensions[0]; row++)
        {
            char[] rows = Console.ReadLine().ToCharArray();

            for (int col = 0; col < dimensions[1]; col++)
            {
                field[row, col] = rows[col];
            }
        }

        int[] mouseAt = new int[2];
        int[] mouseGoesTo = new int[2];
        string command = string.Empty;

        while (command.ToLower() != "danger")
        {

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'M')
                    {
                        mouseAt[0] = row;
                        mouseAt[1] = col;
                        mouseGoesTo[0] = row;
                        mouseGoesTo[1] = col;
                        break;
                    }
                }
            }
            command = Console.ReadLine();


            switch (command.ToLower())
            {
                case "up":
                    mouseGoesTo[0]--;
                    break;
                case "down":
                    mouseGoesTo[0]++;
                    break;
                case "left":
                    mouseGoesTo[1]--;
                    break;
                case "right":
                    mouseGoesTo[1]++;
                    break;

            }
            if (IsOutside(mouseGoesTo[0], mouseGoesTo[1], field))
            {
                Console.WriteLine("No more cheese for tonight!");
                PrintMatrix(field);
                break;
            }
            if (IsValidMove(mouseGoesTo[0], mouseGoesTo[1], field))
            {
                if (IsTrapped(mouseGoesTo[0], mouseGoesTo[1], field))
                {
                    MoveMouse(mouseAt[0], mouseAt[1], mouseGoesTo[0], mouseGoesTo[1], field);
                    Console.WriteLine("Mouse is trapped!");
                    PrintMatrix(field);
                    break;
                }
                MoveMouse(mouseAt[0], mouseAt[1], mouseGoesTo[0], mouseGoesTo[1], field);
                if (AteAllCheese(field))
                {
                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                    PrintMatrix(field);
                    break;
                }              
            }

           // PrintMatrix(field);
        }
        if (command.ToLower() == "danger")
        {
            Console.WriteLine("Mouse will come back later!");
            PrintMatrix(field);
        }
    }

    private static bool AteAllCheese(char[,] field)
    {
        foreach (char c in field)
        {
            if (c == 'C')
            {
                return false;
            }
        }
        return true;
    }

    private static void MoveMouse(int row, int col, int newRow, int newCol, char[,] field)
    {
        field[row, col] = '*';
        row = newRow;
        col = newCol;
        field[newRow, newCol] = 'M';
    }

    private static bool IsTrapped(int row, int col, char[,] field)
    {
        return field[row, col] == 'T';
    }

    private static bool IsValidMove(int row, int col, char[,] field)
    {
        return field[row, col] != '@';
    }

    private static bool IsOutside(int row, int col, char[,] field)
    {
        return row < 0 || col < 0
            || row >= field.GetLength(0)
            || col >= field.GetLength(1);
    }

    private static void PrintMatrix(char[,] field)
    {
        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                Console.Write(field[row, col]);
            }
            Console.WriteLine();
        }
    }
}
