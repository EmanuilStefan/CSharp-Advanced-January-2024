int numberOfQueries = int.Parse(Console.ReadLine());
Stack<int> stack = new();


for (int i = 0; i < numberOfQueries; i++)
{
    string currentQuery = Console.ReadLine();
    if (currentQuery.StartsWith("1 "))
    {
       int[] num = currentQuery
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        stack.Push(num[1]);
    }
    else if (currentQuery == "2" & stack.Count > 0)
    {
        stack.Pop();
    }
    else if (currentQuery == "3" & stack.Count > 0)
    {
        Console.WriteLine(stack.Max());
    }
    else if (currentQuery == "4" & stack.Count > 0)
    {
        Console.WriteLine(stack.Min());
    }

}
    Console.WriteLine(string.Join(", ",stack));