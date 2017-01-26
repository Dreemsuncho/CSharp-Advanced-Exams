using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class StartProg
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        StringBuilder textLines = new StringBuilder();

        for (int line = 0; line < lines; line++)
        {
            string messageLine = Console.ReadLine();
            textLines.Append(messageLine);
        }

        string namePattern = Console.ReadLine();
        string messagePattern = Console.ReadLine();
        int[] indexes = Console.ReadLine().Split()
                                          .Select(int.Parse)
                                          .ToArray();


        Regex nameRegex = new Regex(namePattern + @"([a-zA-Z]{" + namePattern.Length + @"})(?![a-zA-Z])");
        Regex messageRegex = new Regex(messagePattern + @"([a-zA-Z0-9]{" + messagePattern.Length + @"})(?![a-zA-Z0-9])");

        MatchCollection namesMatch = nameRegex.Matches(textLines.ToString());
        MatchCollection messagesMatch = messageRegex.Matches(textLines.ToString());


        Queue<string> names = new Queue<string>();
        foreach (Match name in namesMatch)
        {
            string currName = name.Groups[1].Value;
            names.Enqueue(currName);
        }

        List<string> messages = new List<string>();
        foreach (Match message in messagesMatch)
        {
            string currMessage = message.Groups[1].Value;
            messages.Add(currMessage);
        }


        indexes.ToList()
               .ForEach(ind =>
               {
                   if ((ind - 1) >= 0 &&
                       (ind - 1) < messages.Count &&
                        names.Count > 0)
                   {
                       string resultJedi = names.Dequeue();
                       string resultMsg = messages[ind - 1];

                       Console.WriteLine("{0} - {1}", resultJedi, resultMsg);
                   }
               });
    }
}