using System;

class Program
{
    static void Main()
    {
        // Read dimensions of the stairs
        string[] dimensions = Console.ReadLine().Split();
        int rows = int.Parse(dimensions[0]);
        int columns = int.Parse(dimensions[1]);

        // Read the string representing the snake
        string snake = Console.ReadLine();

        // Create a 2D string array
        string[,] matrix = new string[rows, columns];

        // Fill the matrix with the snake's path
        int snakeIndex = 0;
        for (int i = 0; i < rows; i++)
        {
            // Alternate between left-to-right and right-to-left based on row index
            if (i % 2 == 0)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = snake[snakeIndex % snake.Length].ToString();
                    snakeIndex++;
                }
            }
            else
            {
                for (int j = columns - 1; j >= 0; j--)
                {
                    matrix[i, j] = snake[snakeIndex % snake.Length].ToString();
                    snakeIndex++;
                }
            }
        }

        // Print the filled matrix
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}
