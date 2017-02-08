using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Startup
{
    public static void Main()
    {
        StringBuilder text = new StringBuilder();

        string input;
        while ((input = Console.ReadLine()) != "burp")
        {
            text.Append(input);
        }


        string replaced = Regex.Replace(text.ToString(), @"\s+", " ");

        string specialPattern = @"([$&'%])([^$&'%]+)\1";
        MatchCollection matches = Regex.Matches(replaced, specialPattern);

        Queue<string> results = new Queue<string>();

        foreach (Match match in matches)
        {
            int power = 0;
        
            switch (match.Groups[1].Value)
            {
                case "$":
                    power = 1;
                    break;
                case "%":
                    power = 2;
                    break;
                case "&":
                    power = 3;
                    break;

                default:
                    power = 4;
                    break;
            }

            string part = match.Groups[2].Value;

            string result = DecodingText(part, power, text);
            results.Enqueue(result);
        }

        Console.WriteLine(string.Join(" ", results));
    }

    private static string DecodingText(string part, int power, StringBuilder result)
    {
        result.Clear();

        for (int ind = 0; ind < part.Length; ind++)
        {
            int asciiPos = part[ind];

            if (ind % 2 == 0)
                asciiPos += power;
            else
                asciiPos -= power;

            result.Append((char)asciiPos);
        }

        return result.ToString();
    }
}