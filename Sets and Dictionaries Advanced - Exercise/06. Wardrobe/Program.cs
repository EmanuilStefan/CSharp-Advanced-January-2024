using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(" -> ");
            string color = input[0];
            string[] clothes = input[1].Split(',');

            if (!wardrobe.ContainsKey(color))
            {
                wardrobe[color] = new Dictionary<string, int>();
            }

            foreach (string cloth in clothes)
            {
                if (!wardrobe[color].ContainsKey(cloth))
                {
                    wardrobe[color][cloth] = 1;
                }
                else
                {
                    wardrobe[color][cloth]++;
                }
            }
        }

        string[] search = Console.ReadLine().Split(" ");
        string colorToFind = search[0];
        string clothesToFind = search[1];

        foreach (var color in wardrobe.Keys)
        {
            Console.WriteLine($"{color} clothes:");

            foreach (var item in wardrobe[color])
            {
                string itemName = item.Key;
                int itemCount = item.Value;

                if (itemName == clothesToFind && color == colorToFind)
                {
                    Console.WriteLine($"* {itemName} - {itemCount} (found!)");
                }
                else
                {
                    Console.WriteLine($"* {itemName} - {itemCount}");
                }
            }
        }
    }
}
