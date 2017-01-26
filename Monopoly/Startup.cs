using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        string[] fieldSize = Console.ReadLine().Split();
        int fieldRows = int.Parse(fieldSize[0]);

        char[][] field = new char[fieldRows][];
        for (int row = 0; row < fieldRows; row++)
        {
            field[row] = Console.ReadLine().ToCharArray();
        }

        int totalHotels = 0;
        int totalMoney = 50;
        int totalTurns = 0;
        List<string> resultItems = new List<string>();

        for (int row = 0; row < fieldRows; row++)
        {
            if (row % 2 == 0)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    string resultItem = string.Empty;
                    switch (field[row][col])
                    {
                        case 'H':
                            totalHotels++;
                            resultItem = $"Bought a hotel for {totalMoney}. Total hotels: {totalHotels}.";
                            totalMoney = 0;
                            break;
                        case 'J':
                            resultItem = $"Gone to jail at turn {totalTurns}.";
                            totalTurns += 2;
                            totalMoney += (10 * totalHotels) * 2;
                            break;
                        case 'S':
                            int moneySpent = Math.Min((row + 1) * (col + 1), totalMoney);
                            resultItem = $"Spent {moneySpent} money at the shop.";
                            totalMoney -= moneySpent;
                            if (totalMoney < 0)
                                totalMoney = 0;
                            break;
                        default:
                            break;
                    }

                    if (resultItem != string.Empty)
                        resultItems.Add(resultItem);

                    totalTurns++;
                    if (totalHotels > 0)
                        totalMoney += 10 * totalHotels;
                }
            }
            else
            {
                for (int col = field[row].Length - 1; col >= 0; col--)
                {
                    string resultItem = string.Empty;
                    switch (field[row][col])
                    {
                        case 'H':
                            totalHotels++;
                            resultItem = $"Bought a hotel for {totalMoney}. Total hotels: {totalHotels}.";
                            totalMoney = 0;
                            break;
                        case 'J':
                            resultItem = $"Gone to jail at turn {totalTurns}.";
                            totalTurns += 2;
                            totalMoney += (10 * totalHotels) * 2;
                            break;
                        case 'S':
                            int moneySpent = Math.Min((row + 1) * (col + 1), totalMoney);
                            resultItem = $"Spent {moneySpent} money at the shop.";
                            totalMoney -= moneySpent;
                            if (totalMoney < 0)
                                totalMoney = 0;
                            break;
                        default:
                            break;
                    }

                    if (resultItem != string.Empty)
                        resultItems.Add(resultItem);

                    totalTurns++;
                    if (totalHotels > 0)
                        totalMoney += 10 * totalHotels;
                }
            }
        }

        resultItems.Add($"Turns {totalTurns}");
        resultItems.Add($"Money {totalMoney}");
        Console.WriteLine(string.Join("\n", resultItems));
    }
}