using System;
using System.Collections.Generic;
using System.Text;

public class StartProg
{
    public static void Main()
    {
        StringBuilder message = new StringBuilder();
        string delimeter = string.Empty;

        while (true)
        {
            string messageLine = Console.ReadLine();
            if (messageLine.Equals("---NMS SEND---"))
            {
                delimeter = Console.ReadLine();
                break;
            }

            message.Append(messageLine);
        }


        StringBuilder fullMessage = new StringBuilder();

        foreach (char let in message.ToString())
        {
            if (!fullMessage.Length.Equals(0) &&
                char.ToLower(fullMessage[fullMessage.Length - 1]) < char.ToLower(let))
            {
                fullMessage.Append(let);
                continue;
            }
            else if (!fullMessage.Length.Equals(0))
            {
                fullMessage.Append(delimeter);
                fullMessage.Append(let);
                continue;
            }

            fullMessage.Append(let);
        }

        Console.WriteLine(fullMessage);
    }
}