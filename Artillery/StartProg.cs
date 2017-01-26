using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Bunker
{
    public string init { get; set; }
    public int capacity { get; set; }
    public Queue<int> weapons { get; set; }

    public Bunker(string init, int capacity, Queue<int> weapons)
    {
        this.init = init;
        this.capacity = capacity;
        this.weapons = weapons;
    }
}

public class StartProg
{
    public static void Main()
    {
        int maxCapacity = int.Parse(Console.ReadLine());

        Queue<Bunker> bunkers = new Queue<Bunker>();
        Queue<int> weapons = new Queue<int>();


        Regex regex = new Regex(@"[a-zA-Z]");

        while (true)
        {
            string input = Console.ReadLine();
            if (input.Equals("Bunker Revision"))
                break;

            input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                 .ToList()
                 .ForEach(tok =>
                 {
                     if (regex.IsMatch(tok))
                     {
                         bunkers.Enqueue(new Bunker(tok, maxCapacity, new Queue<int>()));
                     }
                     else
                     {
                         weapons.Enqueue(int.Parse(tok));
                     }
                 });


            while (weapons.Count > 0)
            {
                int currWep = weapons.Peek();
                Bunker currBunk = bunkers.Peek();

                if (currWep <= currBunk.capacity)
                {
                    currBunk.capacity -= currWep;
                    currBunk.weapons.Enqueue(currWep);
                    weapons.Dequeue();

                    if (currBunk.capacity == 0 && bunkers.Count > 1)
                    {
                        Console.WriteLine("{0} -> {1}", currBunk.init, string.Join(", ", currBunk.weapons));
                        bunkers.Dequeue();
                    }
                }
                else if (bunkers.Count > 1)
                {
                    if (currBunk.weapons.Count > 1)
                    {
                        Console.WriteLine("{0} -> {1}", currBunk.init, string.Join(", ", currBunk.weapons));
                    }
                    else
                    {
                        Console.WriteLine("{0} -> Empty", currBunk.init);
                    }
                    bunkers.Dequeue();
                }
                else if (maxCapacity >= currWep)
                {
                    while (currBunk.capacity < currWep)
                    {
                        int firstWep = currBunk.weapons.Dequeue();
                        currBunk.capacity += firstWep;
                    }
                    currBunk.capacity -= currWep;
                    currBunk.weapons.Enqueue(currWep);
                    weapons.Dequeue();
                }
                else
                {
                    weapons.Dequeue();
                }
            }
        }
    }
}