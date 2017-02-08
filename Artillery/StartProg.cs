using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class StartProg
{
    public static void Main()
    {
        int maxCapacity = int.Parse(Console.ReadLine());

        Queue<string> bunkers = new Queue<string>();
        Queue<int> weapons = new Queue<int>();
        int currCapacity = maxCapacity;

        Regex bunkMatch = new Regex(@"[a-zA-Z]");
        while (true)
        {
            string input = Console.ReadLine();
            if (input.Equals("Bunker Revision"))
                break;

            string[] inputArgs = input.Split();
            foreach (var token in inputArgs)
            {
                if (bunkMatch.IsMatch(token))
                {
                    bunkers.Enqueue(token);
                    continue;
                }


                int weapon = int.Parse(token);
                while (bunkers.Count > 1)
                {
                    if (currCapacity >= weapon)
                    {
                        currCapacity -= weapon;
                        weapons.Enqueue(weapon);
                        continue;
                    }

                    Console.WriteLine("{0} -> {1}", bunkers.Dequeue(), weapons.Count > 0 ? string.Join(", ", weapons) : "Empty");
                    weapons.Clear();
                    currCapacity = maxCapacity;
                }

                if (bunkers.Count == 1)
                {
                    if (maxCapacity >= weapon)
                    {
                        while (currCapacity < weapon)
                        {
                            currCapacity += weapons.Dequeue();
                        }

                        weapons.Enqueue(weapon);
                        currCapacity -= weapon;
                    }
                }
            }
        }
    }
}