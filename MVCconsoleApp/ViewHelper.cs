using System;
using System.Collections.Generic;
using System.Text;

namespace MVCconsoleApp
{
    public static class ViewHelper
    {
        public static int AskForInt(string message)
        {
            return 0;
        }

        public static string AskForString(string message)
        {
            return "";
        }
        public static double AskForDouble(string message, bool clear = true)
        {
            string answer;
            do
            {
                if (clear) Console.Clear();
                Console.Write(message);
                answer = Console.ReadLine();
                if (double.TryParse(answer, out double result)) return result;
                else
                {
                    Console.WriteLine("{0} nie jest liczbą!", answer);
                    Console.ReadLine();
                }
            } while (true);
        }
        public static void WriteAndWait(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
