using System;

namespace MarsRover.Common.Input
{
    public class Input
    {
        public static string getInputFromUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
