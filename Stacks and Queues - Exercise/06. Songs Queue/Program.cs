Queue<string> playlist = new(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries));

while (playlist.Any())
{
    string[] command = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    switch (command[0])
    {
        case "Add":
            string song = string.Join(" ", command, 1, command.Length - 1);
            if (!playlist.Contains(song))
            {
                playlist.Enqueue(song);
            }
            else
            {
                Console.WriteLine($"{song} is already contained!");
            }
            break;
        case "Play":
            playlist.Dequeue();
            break;
        case "Show":
            Console.WriteLine(string.Join(", ", playlist));
            break;
    }
}
Console.WriteLine("No more songs!");