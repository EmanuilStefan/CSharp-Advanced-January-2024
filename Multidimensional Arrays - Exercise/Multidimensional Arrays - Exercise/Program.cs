int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size, size];

for (int rows = 0; rows < size; rows++)
{
    int[] inputRows = Console.ReadLine().Split().Select(int.Parse).ToArray();

    for (int cols = 0; cols < size; cols++)
    {
        matrix[rows, cols] = inputRows[cols];
    }
}

int sum = 0;

for (int i = 0; i < size; i++)
{
    sum += matrix[i, i];
    sum -= matrix[i, size - 1 - i];
}

Console.WriteLine(Math.Abs(sum));