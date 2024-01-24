using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string text = "";
        Stack<string> operationsStack = new Stack<string>();

        for (int i = 0; i < n; i++)
        {
            string[] operation = Console.ReadLine().Split();
            string command = operation[0];

            switch (command)
            {
                case "1":
                    string someString = operation[1];
                    operationsStack.Push(text);
                    text += someString;
                    break;
                case "2":
                    int count = int.Parse(operation[1]);
                    operationsStack.Push(text);
                    text = text.Substring(0, text.Length - count);
                    break;
                case "3":
                    int index = int.Parse(operation[1]) - 1;
                    Console.WriteLine(text[index]);
                    break;
                case "4":
                    if (operationsStack.Count > 0)
                    {
                        text = operationsStack.Pop();
                    }
                    break;
            }
        }
    
    }
}
