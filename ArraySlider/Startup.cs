using System;
using System.Linq;
using System.Numerics;

public class Startup
{
    public static void Main()
    {
        BigInteger[] initArray = Console.ReadLine().Split(" ".ToCharArray(),
                                                      StringSplitOptions.RemoveEmptyEntries)
                                            .Select(BigInteger.Parse)
                                            .ToArray();

        string operations;
        BigInteger currIndex = 0;

        while ((operations = Console.ReadLine()) != "stop")
        {
            string[] operationsArgs = operations.Split();

            BigInteger offset = BigInteger.Parse(operationsArgs[0]);
            string operation = operationsArgs[1];
            BigInteger operand = BigInteger.Parse(operationsArgs[2]);


            currIndex += offset;
            if (currIndex < 0)
            {
                currIndex = Math.Abs((int)(initArray.Length - currIndex));
                if (currIndex >= initArray.Length)
                {
                    currIndex %= initArray.Length;
                    currIndex = (initArray.Length - currIndex);
                }
            }

            currIndex %= initArray.Length;

            switch (Convert.ToChar(operation))
            {
                case '&':
                    initArray[(int)currIndex] &= operand;
                    break;
                case '|':
                    initArray[(int)currIndex] |= operand;
                    break;
                case '^':
                    initArray[(int)currIndex] ^= operand;
                    break;
                case '+':
                    initArray[(int)currIndex] += operand;
                    break;
                case '-':
                    initArray[(int)currIndex] -= operand;
                    if (initArray[(int)currIndex] < 0)
                        initArray[(int)currIndex] = 0;
                    break;
                case '*':
                    initArray[(int)currIndex] *= operand;
                    break;
                case '/':
                    initArray[(int)currIndex] /= operand;
                    break;

                default:
                    break;
            }
        }
        Console.WriteLine("[{0}]", string.Join(", ", initArray));
    }
}