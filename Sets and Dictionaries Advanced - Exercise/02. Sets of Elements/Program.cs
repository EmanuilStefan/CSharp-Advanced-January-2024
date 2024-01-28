int[] sizes = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int n = sizes[0];
int m = sizes[1];

HashSet<int> set1 = new HashSet<int>();
HashSet<int> set2 = new HashSet<int>();

for (int i = 0; i < n; i++)
{
    
    set1.Add(int.Parse(Console.ReadLine()));

}

for (int i = 0; i < m; i++)
{
    
    set2.Add(int.Parse(Console.ReadLine()));

}

set1.IntersectWith(set2);


    Console.Write(string.Join(" ",set1).TrimEnd());

