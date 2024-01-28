using System.Linq;

int numOfInputs = int.Parse(Console.ReadLine());
HashSet<string> inputs = new HashSet<string>();

for (int i = 0; i < numOfInputs; i++)
{
    string input = Console.ReadLine();
    if (input != null)
    {
        inputs.Add(input);
    }    
}

foreach (string input in inputs)
{
    Console.WriteLine(input);
}