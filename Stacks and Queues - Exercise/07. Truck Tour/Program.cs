using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int countOfPumps = int.Parse(Console.ReadLine());
        Queue<int[]> queue = new Queue<int[]>();

        for (int i = 0; i < countOfPumps; i++)
        {
            int[] data = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            queue.Enqueue(data);
        }

        int tank = 0;
        int[] startingPump = null;
        int startingIndex = 0;

        for (int i = 0; i < countOfPumps; i++)
        {
            int[] current = queue.Dequeue();
            queue.Enqueue(current);

            tank += current[0] - current[1];

            if (tank < 0)
            {
                // If the tank goes negative, reset starting index and starting pump
                startingIndex = i + 1;
                startingPump = null;
                tank = 0;
            }
            else if (startingPump == null)
            {
                // Update starting pump only when it's null (first time tank becomes non-negative)
                startingPump = current;
            }
        }

        // Check if tour is completable
        if (startingPump != null && startingIndex < countOfPumps)
        {
            Console.WriteLine(startingIndex);
        }
        else
        {
            return; //Console.WriteLine("Tour is not completable");
        }
    }
}
