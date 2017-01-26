using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        int[] initArray = Console.ReadLine().Split()
                                            .Select(int.Parse)
                                            .ToArray();

        List<string> results = new List<string>();

        while (true)
        {
            string cmd = Console.ReadLine();
            if (cmd.Equals("end"))
                break;

            string[] cmdArgs = cmd.Split();
            string initCommand = cmdArgs[0];

            switch (initCommand)
            {
                case "exchange":
                    int index = int.Parse(cmdArgs[1]);
                    initArray = ExchangeArr(initArray, index, results);
                    break;

                case "max":
                case "min":
                    string oddOrEven = cmdArgs[1];
                    string result = ReturnIndexOfElement(initArray, initCommand, oddOrEven);
                    results.Add(result);
                    break;

                case "first":
                case "last":
                    oddOrEven = cmdArgs[2];
                    int count = int.Parse(cmdArgs[1]);
                    result = ReturnCountElements(initArray, initCommand, oddOrEven, count);
                    results.Add(result);
                    break;

                default:
                    break;
            }
        }

        Console.WriteLine(string.Join("\n", results));
        Console.WriteLine("[{0}]", string.Join(", ", initArray));
    }

    private static string ReturnCountElements(int[] initArray, string initCommand, string oddOrEven, int count)
    {
        string result = string.Empty;
        if (count > initArray.Length)
        {
            result = "Invalid count";
        }
        else
        {
            switch (initCommand)
            {
                case "first":
                    if (oddOrEven == "odd")
                        result = string.Format("[{0}]", string.Join(", ", initArray.Where(d => d % 2 != 0).Take(count)));
                    else
                        result = string.Format("[{0}]", string.Join(", ", initArray.Where(d => d % 2 == 0).Take(count)));
                    break;

                case "last":
                    if (oddOrEven == "odd")
                        result = string.Format("[{0}]", string.Join(", ", initArray.Where(d => d % 2 != 0).Reverse().Take(count).Reverse()));
                    else
                        result = string.Format("[{0}]", string.Join(", ", initArray.Where(d => d % 2 == 0).Reverse().Take(count).Reverse()));
                    break;
            }
        }
        return result;
    }

    private static string ReturnIndexOfElement(int[] initArray, string initCommand, string oddOrEven)
    {
        string result = string.Empty;
        try
        {
            switch (initCommand)
            {
                case "max":
                    if (oddOrEven == "odd")
                        result = Array.LastIndexOf(initArray, initArray.Where(e => e % 2 != 0).Max()).ToString();
                    else
                        result = Array.LastIndexOf(initArray, initArray.Where(e => e % 2 == 0).Max()).ToString();
                    break;

                case "min":
                    if (oddOrEven == "odd")
                        result = Array.LastIndexOf(initArray, initArray.Where(e => e % 2 != 0).Min()).ToString();
                    else
                        result = Array.LastIndexOf(initArray, initArray.Where(e => e % 2 == 0).Min()).ToString();
                    break;
            }
        }
        catch (InvalidOperationException)
        {
            result = "No matches";
        }

        return result;
    }

    private static int[] ExchangeArr(int[] initArray, int index, List<string> results)
    {
        if (index >= initArray.Length || index < 0)
        {
            results.Add("Invalid index");
            return initArray;
        }
        else
        {
            return initArray.Skip(index + 1).Concat(initArray.Take(index + 1)).ToArray();
        }
    }
}
