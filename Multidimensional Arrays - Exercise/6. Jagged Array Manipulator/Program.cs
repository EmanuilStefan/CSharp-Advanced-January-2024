using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[][] jaggedArray = new int[n][];

        for (int i = 0; i < n; i++)
        {
            jaggedArray[i] = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        for (int i = 0; i < n - 1; i++)
        {
            if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] *= 2;
                    jaggedArray[i + 1][j] *= 2;
                }
            }
            else
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] /= 2;
                }
                for (int k = 0; k < jaggedArray[i + 1].Length; k++)
                {
                    jaggedArray[i + 1][k] /= 2;
                }
            }
        }

        while (true)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = input[0];

            if (command.ToLower() == "end")
            {
                break;
            }

            if (command.ToLower() == "add" || command.ToLower() == "subtract")
            {
                int row = int.Parse(input[1]);
                int column = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (row >= 0 && row < jaggedArray.Length && column >= 0 && column < jaggedArray[row].Length)
                {
                    if (command.ToLower() == "add")
                    {
                        jaggedArray[row][column] += value;
                    }
                    else
                    {
                        jaggedArray[row][column] -= value;
                    }
                }
            }
        }

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}
