using System.Data;

int[] input = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int[] numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> queue = new();

for (int i = 0; i < input[0]; i++)
{
    queue.Enqueue(numbers[i]);
}

for (int i = 0; i < input[1]; i++)
{
    if (queue.Count > 0)
    {
        queue.Dequeue();
    }
}

if (queue.Contains(input[2]))
{
    Console.WriteLine("true");
}
else if (queue.Count > 0)
{
    Console.WriteLine(queue.Min());
}
else
{
    Console.WriteLine("0");
}
