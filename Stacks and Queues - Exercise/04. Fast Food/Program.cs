int foodAvailable = int.Parse(Console.ReadLine());

Queue<int> orders = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());

int biggestOrder = orders.Max();

while (orders.Any())
{
    foodAvailable -= orders.Peek();

    if (foodAvailable < 0)
    {
        break;
    }

    orders.Dequeue();
}
    Console.WriteLine(biggestOrder);

if (orders.Any())
{
    Console.WriteLine("Orders left: " + string.Join(" ", orders));
}
else
{
    Console.WriteLine("Orders complete");
}