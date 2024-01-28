int numOfLines = int.Parse(Console.ReadLine());

HashSet<string> lines = new HashSet<string>();

for (int i = 0; i < numOfLines; i++)
{
    string[] inputElements = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    for (int j = 0; j < inputElements.Length; j++)
    {
        lines.Add(inputElements[j]);
    }
}

string[] elements = lines.OrderBy(x => x).ToArray();

Console.WriteLine(string.Join(" ", elements).TrimEnd());