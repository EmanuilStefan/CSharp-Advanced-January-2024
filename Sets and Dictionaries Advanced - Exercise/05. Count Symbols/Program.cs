string readText = Console.ReadLine();

SortedDictionary<char, int> dictionary = new();

for (int i = 0; i < readText.Length; i++)
{
    char character = readText[i];
    if (!dictionary.ContainsKey(character))
    {
        dictionary.Add(character, 1);
    }
    else if (dictionary.ContainsKey(character))
    {
        dictionary[character]++;
    }
}

foreach (var kvp in dictionary)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s" );
}