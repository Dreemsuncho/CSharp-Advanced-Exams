using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Startup
{
    public static void Main()
    {
        string[] numbersLine = Console.ReadLine().Split(", ".ToArray(),
                                                             StringSplitOptions.RemoveEmptyEntries)
                                                 .ToArray();

        List<KeyValuePair<string, string>> resultedNumbers = new List<KeyValuePair<string, string>>();


        foreach (var num in numbersLine)
        {
            string currNum = string.Empty;

            foreach (var dig in num)
            {
                switch (dig)
                {
                    case '0':
                        currNum += "zero-";
                        break;
                    case '1':
                        currNum += "one-";
                        break;
                    case '2':
                        currNum += "two-";
                        break;
                    case '3':
                        currNum += "three-";
                        break;
                    case '4':
                        currNum += "four-";
                        break;
                    case '5':
                        currNum += "five-";
                        break;
                    case '6':
                        currNum += "six-";
                        break;
                    case '7':
                        currNum += "seven-";
                        break;
                    case '8':
                        currNum += "eight-";
                        break;
                    case '9':
                        currNum += "nine-";
                        break;
                    default:
                        break;
                }
            }
            resultedNumbers.Add(new KeyValuePair<string, string>(currNum.Trim('-'), num));
        }

        StringBuilder orderedNumbers = new StringBuilder();
        resultedNumbers.OrderBy(p => p.Key)
                       .ToList()
                       .ForEach(p =>
                       {
                           orderedNumbers.Append($"{p.Value}, ");
                       });
        Console.WriteLine(orderedNumbers.ToString().Trim(", ".ToCharArray()));
    }
}