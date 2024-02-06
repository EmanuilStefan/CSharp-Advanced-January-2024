namespace EvenLines;

using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

public class EvenLines
{
    static void Main()
    {
        string inputFilePath = @"..\..\..\text.txt";

        Console.WriteLine(ProcessLines(inputFilePath));
    }

    public static string ProcessLines(string inputFilePath)
    {
        StringBuilder sb = new();
        using (StreamReader sr = new StreamReader(inputFilePath))
        {
            while (!sr.EndOfStream)
            {
                sb.AppendLine(sr.ReadLine());
            }
        }
        char[] symbols = new char[] { '-', ',', '.', '!', '?' };

        foreach (char symbol in symbols)
        {
            sb.Replace(symbol, '@');
        }

        string[] processedText = sb.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] reversedProcessedText = processedText.Reverse().ToArray();

        return string.Join(' ', reversedProcessedText);
    }
}
