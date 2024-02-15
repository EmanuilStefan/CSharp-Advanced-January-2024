using System.Threading.Channels;

namespace AdvancedExamPrep;

internal class Program
{
    static void Main(string[] args)
    {
        int[] tools = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        Queue<int> queueTools = new Queue<int>();

        int[] substances = Console.ReadLine()
           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .ToArray();
        Stack<int> stackSubstances = new Stack<int>();

        List<int> challenges = Console.ReadLine()
           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .ToList();

        foreach (int i in tools)
        {
            queueTools.Enqueue(i);
        }
        foreach (int i in substances)
        {
            stackSubstances.Push(i);
        }

        int target = int.MinValue;

        while (stackSubstances.Any() && challenges.Any() && queueTools.Any())
        {
            target = stackSubstances.Peek() * queueTools.Peek();

            if (challenges.Any(x => x == target))
            {
                challenges.Remove(target);
                stackSubstances.Pop();
                queueTools.Dequeue();
                break;
            }
            else if (!challenges.Any(x => x == target))
            {
                int tool = queueTools.Dequeue();
                tool++;
                queueTools.Enqueue(tool);

                int substance = stackSubstances.Pop();
                substance--;
                if (substance > 0)
                {
                    stackSubstances.Push(substance);
                }
            }
        }

        if (challenges.Any())
        {
            Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
        }
        else if (!challenges.Any())
        {
            Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
        }

        if (queueTools.Any()) Console.WriteLine($"Tools: {string.Join(", ", queueTools).TrimEnd()}");
        if (stackSubstances.Any()) Console.WriteLine($"Substances: {string.Join(", ", stackSubstances).TrimEnd()}");
        if (challenges.Any()) Console.WriteLine($"Challenges: {string.Join(", ", challenges).TrimEnd()}");
    }
}
