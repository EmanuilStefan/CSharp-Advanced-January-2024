using System.Threading.Channels;

char[] input = Console.ReadLine().ToCharArray();

Stack<char> stack = new();

if(input.Length % 2 != 0)
{
    Console.WriteLine("NO");
    return;
}

foreach(char c in input)
{
    if ("([{".Contains(c))
    {
        stack.Push(c);
    }
    else if (c == ')' && stack.Peek() == '(')
    {
        stack.Pop();
    }
    else if (c == ']' && stack.Peek() == '[')
    {
        stack.Pop();
    }
    else if (c == '}' && stack.Peek() == '{')
    {
        stack.Pop();
    }
}

Console.WriteLine(stack.Any() ? "NO" : "YES");