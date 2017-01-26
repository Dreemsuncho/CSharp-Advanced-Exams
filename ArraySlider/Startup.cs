using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        long[] initArray = Console.ReadLine().Split(" ".ToCharArray(),
                                                      StringSplitOptions.RemoveEmptyEntries)
                                            .Select(long.Parse)
                                            .ToArray();

        string operations;
        long currIndex = 0;

        while ((operations = Console.ReadLine()) != "stop")
        {
            string[] operationsArgs = operations.Split();

            long offset = long.Parse(operationsArgs[0]);
            string operation = operationsArgs[1];
            long operand = long.Parse(operationsArgs[2]);


            currIndex += offset;
            if (currIndex < 0)
            {
                currIndex = Math.Abs(initArray.Length - currIndex);
                if (currIndex >= initArray.Length)
                {
                    currIndex %= initArray.Length;
                    currIndex = (initArray.Length - currIndex);
                }
            }

            currIndex %= initArray.Length;

            switch (char.Parse(operation))
            {
                case '&':
                    initArray[currIndex] &= operand;
                    break;
                case '|':
                    initArray[currIndex] |= operand;
                    break;
                case '^':
                    initArray[currIndex] ^= operand;
                    break;
                case '+':
                    initArray[currIndex] += operand;
                    break;
                case '-':
                    initArray[currIndex] -= operand;
                    if (initArray[currIndex] < 0)
                        initArray[currIndex] = 0;
                    break;
                case '*':
                    initArray[currIndex] *= operand;
                    break;
                case '/':
                    initArray[currIndex] /= operand;
                    break;

                default:
                    break;
            }
        }
        Console.WriteLine("[{0}]", string.Join(", ", initArray));
    }
}