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
        List<Bunker> bunkers = new List<Bunker>();
        Queue<int> weapons = new Queue<int>();
        List<Bunker> resultedBunkers = new List<Bunker>();

        int maxCapacity = int.Parse(Console.ReadLine());

        while (true)
        {
            string input = Console.ReadLine();
            if (input.Equals("Bunker Revision"))
                break;

            string[] tokens = Regex.Split(input, $"\\s+");
            tokens.ToList()
                  .ForEach(tok =>
                  {
                      int weapon;
                      if (int.TryParse(tok, out weapon))
                      {
                          weapons.Enqueue(weapon);
                      }
                      else
                      {
                          bunkers.Add(new Bunker(tok, maxCapacity, new Queue<int>()));
                      }
                  });


            while (weapons.Count > 0)
            {
                int currWep = weapons.Dequeue();

                bool isInside = false;
                for (int i = 0; i < bunkers.Count; i++)
                {
                    Bunker currBunker = bunkers[i];

                    if (currWep <= currBunker.capacity)
                    {
                        currBunker.capacity -= currWep;
                        currBunker.weapons.Enqueue(currWep);

                        if (currBunker.capacity.Equals(0))
                        {
                            resultedBunkers.Add(currBunker);
                            bunkers.RemoveAt(0);

                            currBunker = bunkers[0];
                        }
                        isInside = true;
                        break;
                    }
                }

                if (bunkers.Count.Equals(1) && !isInside)
                {
                    if (maxCapacity >= currWep)
                    {
                        while (bunkers[0].capacity < currWep)
                        {
                            int weapCapacity = bunkers[0].weapons.Dequeue();
                            bunkers[0].capacity += weapCapacity;
                        }
                        bunkers[0].capacity -= currWep;
                        bunkers[0].weapons.Enqueue(currWep);

                        if (bunkers[0].capacity.Equals(0))
                        {
                            resultedBunkers.Add(bunkers[0]);
                            bunkers.RemoveAt(0);
                        }
                    }
                    break;
                }
            }
        }

        resultedBunkers.ForEach(bunker =>
        {
            Console.WriteLine("{0} -> {1}", bunker.init, string.Join(", ", bunker.weapons));
        });
        for (int i = 0; i < bunkers.Count - 1; i++)
        {
            if (bunkers[i].weapons.Count.Equals(0))
            {
                Console.WriteLine("{0} -> Empty", bunkers[i].init);
            }
            else
            {
                Console.WriteLine("{0} -> {1}", bunkers[i].init, string.Join(", ", bunkers[i].weapons));
            }
        }
    }
}