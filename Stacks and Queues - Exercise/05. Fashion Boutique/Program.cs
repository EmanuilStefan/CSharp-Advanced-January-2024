Stack<int> clothes = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

int rackCapacity = int.Parse(Console.ReadLine());
int numOfRacks = 1;
int clothesOnRack = 0;

while (clothes.Any())
{
    int next = clothes.Peek();
    if(clothesOnRack + next <= rackCapacity)
    {
        clothesOnRack += clothes.Pop();
    }
    else
    {
        numOfRacks++;
        clothesOnRack = 0 + clothes.Pop();
    }
}
Console.WriteLine(numOfRacks);
