using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();

        string input;
        while ((input = Console.ReadLine()) != "Statistics")
        {
            string[] tokens = input.Split();

            if (tokens.Length == 4 && tokens[1] == "joined" && tokens[2] == "The" && tokens[3] == "V-Logger")
            {
                string vloggerName = tokens[0];
                if (!vloggers.ContainsKey(vloggerName))
                {
                    vloggers.Add(vloggerName, new Vlogger());
                }
            }
            else if (tokens.Length == 3 && tokens[1] == "followed")
            {
                string followerName = tokens[0];
                string followedName = tokens[2];

                if (vloggers.ContainsKey(followerName) && vloggers.ContainsKey(followedName) && followerName != followedName)
                {
                    vloggers[followerName].Follow(followedName);
                    vloggers[followedName].AddFollower(followerName);
                }
            }
        }

        Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

        int counter = 1;
        foreach (var vlogger in vloggers.OrderByDescending(v => v.Value.Followers.Count)
                                       .ThenBy(v => v.Value.Following.Count))
        {
            Console.Write($"{counter}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");

            if (counter == 1)
            {
                Console.WriteLine();
                foreach (var follower in vlogger.Value.Followers.OrderBy(f => f))
                {
                    Console.WriteLine($"*  {follower}");
                }
            }
            else
            {
                Console.WriteLine();
            }

            counter++;
        }
    }
}

class Vlogger
{
    public HashSet<string> Followers { get; private set; }
    public HashSet<string> Following { get; private set; }

    public Vlogger()
    {
        Followers = new HashSet<string>();
        Following = new HashSet<string>();
    }

    public void AddFollower(string follower)
    {
        Followers.Add(follower);
    }

    public void Follow(string vlogger)
    {
        Following.Add(vlogger);
    }
}
