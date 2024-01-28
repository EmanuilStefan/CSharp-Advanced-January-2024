int numberCount = int.Parse(Console.ReadLine());
Dictionary<int,int> numbers = new();

for (int i = 0; i < numberCount; i++)
{
    int input = int.Parse(Console.ReadLine());
    if (!numbers.ContainsKey(input))
    {
        numbers.Add(input, 1);
    }
    else if (numbers.ContainsKey(input))
    {
        numbers[input]++;
    }
}

foreach (var keyValuePair in numbers)
{
    if (keyValuePair.Value % 2 == 0)
    {
        Console.WriteLine(keyValuePair.Key);
    }
}

