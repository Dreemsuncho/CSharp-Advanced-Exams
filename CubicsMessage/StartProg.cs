using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class EncryptedMessage
{
    public string message { get; set; }
    public List<int> indexes { get; set; }

    public EncryptedMessage(string message, List<int> indexes)
    {
        this.message = message;
        this.indexes = indexes;
    }
}

public class StartProg
{
    public static void Main()
    {
        List<EncryptedMessage> encrypterdMessages = new List<EncryptedMessage>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input.Equals("Over!"))
                break;

            int numberLen = int.Parse(Console.ReadLine());

            Match match = Regex.Match(input, @"^\d+([a-zA-Z]+)[^a-zA-Z]*$");
            if (match.Success)
            {
                string message = match.Groups[1].ToString();

                if (message.Length.Equals(numberLen))
                {
                    List<int> indexes = new List<int>();
                    List<char> charIndexes = match.Value
                                                  .ToCharArray()
                                                  .Where(ch => ch > 47 && ch < 58)
                                                  .ToList();

                    charIndexes.ForEach(ind => indexes.Add(int.Parse(ind.ToString())));

                    encrypterdMessages.Add(new EncryptedMessage(message, indexes));
                }
            }
        }

        encrypterdMessages.ForEach(mess =>
        {
            Console.Write("{0} == ", mess.message);
            mess.indexes.ForEach(ind =>
            {
                int maxLen = mess.message.Length;

                if (ind < maxLen &&
                    ind > -1)
                {
                    Console.Write(mess.message[ind]);
                }
                else
                {
                    Console.Write(' ');
                }
            });
            Console.WriteLine();
        });
    }
}