using System;

namespace Menu
{
    public static class ViewHelper
    {
        public static double AskForDouble(string message, bool inline = true, bool clear = true)
        {
            bool answerOk = false;
            int result = 0;
            string answer;
            while (!answerOk)
            {
                if (clear) Console.Clear();
                if (inline) Console.Write(message);
                else Console.WriteLine(message);
                answer = Console.ReadLine();
                try { result = Convert.ToInt32(answer); answerOk = true; }
                catch (FormatException)
                {
                    WriteAndWait($"{answer} nie jest liczbą!");
                }
            }
            return result;
        }
        public static void WriteAndWait(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
