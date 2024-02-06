namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string content = File.ReadAllText(inputFilePath);
            string[] lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            Queue<int> lettersCount = new(); Queue<int> symbolsCount = new();
            foreach (var line in lines)
            {
                int currentlettersCount = line.Where(x => char.IsLetter(x)).Count();
                lettersCount.Enqueue(currentlettersCount); 
                int currentsymbolsCount = line.Where(x => char.IsPunctuation(x)).Count();
                symbolsCount.Enqueue(currentsymbolsCount);
            }

            StringBuilder stringBuilder = new();
            int lineNumber = 1;

            foreach (var line in lines)
            {
                stringBuilder.Append($"Line {lineNumber}: {line.Trim()}");                
                stringBuilder.Append($" ({lettersCount.Dequeue()})({symbolsCount.Dequeue()})");
                stringBuilder.Append(Environment.NewLine);
                lineNumber++;
            }

            File.WriteAllText(outputFilePath, stringBuilder.ToString());

            //Console.WriteLine(stringBuilder);
        }
    }
}
