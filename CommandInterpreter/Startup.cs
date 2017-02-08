using System;
using System.Collections.Generic;
using System.Linq;

static class ListExtensed
{
    public static T PopAt<T>(this List<T> list, int index)
    {
        T removed = list[index];
        list.RemoveAt(index);
        return removed;
    }
}

public class Startup
{
    public static void Main()
    {
        List<string> initArray = Console.ReadLine().Split(" ".ToCharArray(),
                                                 StringSplitOptions.RemoveEmptyEntries)
                                                 .ToList();

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] cmdArgs = command.Split();
            string initCmd = cmdArgs[0];

            switch (initCmd)
            {
                case "reverse":
                case "sort":
                    int from = int.Parse(cmdArgs[2]);
                    int to = int.Parse(cmdArgs[4]);
                    ReverseOrSortArr(initArray, from, to, initCmd);
                    break;

                case "rollLeft":
                case "rollRight":
                    int count = int.Parse(cmdArgs[1]);
                    SlideArray(initArray, count, initCmd);
                    break;

                default:
                    break;
            }
        }

        Console.WriteLine("[{0}]", string.Join(", ", initArray));
    }

    private static void SlideArray(List<string> initArray, int count, string initCmd)
    {
        if (count < 0)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }
        count %= initArray.Count;

        if (count > initArray.Count / 2)
        {
            count = initArray.Count - count;

            if (initCmd == "rollLeft") initCmd = "rollRight";
            else initCmd = "rollLeft";
        }

        int times = 0;

        if (initCmd == "rollLeft")
        {
            while ((times++) != count)
            {
                string first = initArray.PopAt(0);
                initArray.Add(first);
            }
            return;
        }

        while ((times++) != count)
        {
            string last = initArray.PopAt(initArray.Count - 1);
            initArray.Insert(0, last);
        }
    }

    private static void ReverseOrSortArr(List<string> initArray, int from, int to, string initCmd)
    {
        if (CheckCountAndIndex(initArray, from, to))
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }

        if (initCmd == "reverse")
            initArray.Reverse(from, to);
        else
            initArray.Sort(from, to, StringComparer.InvariantCulture);
    }

    private static bool CheckCountAndIndex(List<string> initArray, int from, int to)
    {
        return from < 0 || to < 0 || from + to > initArray.Count || from >= initArray.Count;
    }
}