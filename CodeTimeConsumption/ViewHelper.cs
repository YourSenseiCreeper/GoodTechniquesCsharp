using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTimeConsumption
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
        public static double AskForDoubleWhile(string message, bool clear = false)
        {
            bool answerOk = false;
            double result = 0;
            string answer;
            while(!answerOk)
            {
                if (clear) Console.Clear();
                Console.WriteLine(message);
                answer = "13";//Console.ReadLine();
                try { result = Convert.ToDouble(answer); answerOk = true; }
                catch (FormatException) { WriteAndWait($"{answer} nie jest liczbą!"); }
            }
            return result;
        }
        public static double AskForDouble(string message, bool clear = false)
        {
            bool answerOk = false;
            double result = 0;
            string answer;
            do
            {
                if (clear) Console.Clear();
                Console.WriteLine(message);
                answer = "13";//Console.ReadLine();
                try { result = Convert.ToDouble(answer); answerOk = true; }
                catch (FormatException) { WriteAndWait($"{answer} nie jest liczbą!"); }
            } while (!answerOk);
            return result;
        }
        public static double AskForDoubleBreakLoop(string message)
        {
            bool answerOk = false;
            double result = 0;
            string answer;
            do
            {
                Console.Write(message);
                answer = "13"; //Console.ReadLine();
                try { result = Convert.ToDouble(answer); break; }
                catch (FormatException) { WriteAndWait($"{answer} nie jest liczbą!"); }
            } while (!answerOk);
            return result;
        }

        public static double AskForDoubleTryParse(string message)
        {
            string answer;
            do
            {
                Console.WriteLine(message);
                answer = "13";
                if (double.TryParse(answer, out double result)) return result;
                else { Console.WriteLine($"{answer} nie jest liczbą!"); }
            } while (true);
        }

        public static double AskForDoubleOptimised(string message)
        {
            string answer;
            do
            {
                Console.WriteLine(message);
                answer = "13";
                if (double.TryParse(answer, out double result)) return result;
                else {
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

    public class ViewHelperConstructor
    {
        public ViewHelperConstructor() { }
        public double AskForDouble(string message, bool clear = false)
        {
            bool answerOk = false;
            double result = 0;
            string answer;
            do
            {
                if (clear) Console.Clear();
                Console.WriteLine(message);
                answer = "13";//Console.ReadLine();
                try { result = Convert.ToInt32(answer); answerOk = true; }
                catch (FormatException) { WriteAndWait($"{answer} nie jest liczbą!"); }
            } while (!answerOk);
            return result;
        }
        public void WriteAndWait(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
