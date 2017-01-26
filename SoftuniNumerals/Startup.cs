using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

public class Startup
{
    public static void Main()
    {
        string numberStr = Console.ReadLine();
        Dictionary<string, int> digits = new Dictionary<string, int>();
        digits.Add("aa", 0);
        digits.Add("aba", 1);
        digits.Add("bcc", 2);
        digits.Add("cc", 3);
        digits.Add("cdc", 4);

        StringBuilder decimalNum = new StringBuilder();
        while (numberStr != "")
        {
            foreach (var d in digits)
            {
                if (numberStr.StartsWith(d.Key))
                {
                    decimalNum.Append(d.Value);
                    numberStr = numberStr.Substring(d.Key.Length);
                    break;
                }
            }
        }

        Console.WriteLine(ConvertFromBase5(decimalNum.ToString()));
    }

    private static BigInteger ConvertFromBase5(string base5string)
    {
        BigInteger result = 0;
        for (int index = 0; index < base5string.Length; index++)
        {
            BigInteger nextDigit = base5string[base5string.Length - 1 - index] - '0';
            result += nextDigit * BigInteger.Pow(5, index);
        }

        return result;
    }
}
