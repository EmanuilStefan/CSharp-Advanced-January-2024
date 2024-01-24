using System.Data;

int[] input = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int[] numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> stack = new Stack<int>();

for (int i = 0; i < input[0]; i++)
{
    stack.Push(numbers[i]);
}

for (int i = 0; i < input[1]; i++)
{
    if (stack.Count > 0)
    {
        stack.Pop();
    }
}

if (stack.Contains(input[2]))
{
    Console.WriteLine("true");
}
else if(stack.Count > 0)
{
    Console.WriteLine(stack.Min());
}
else
{
    Console.WriteLine("0");
}
