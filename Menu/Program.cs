using System;
using System.Collections.Generic;

namespace Menu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logic logic = new Logic();
            Menu("Dostępne opcje:",
                new Dictionary<string, Action>
                {
                    { "Dodaj", new Action(logic.Sum) },
                    { "Odejmij", new Action(logic.Subtract) },
                    { "Pomnóż", new Action(logic.Multiply)},
                    { "Podziel", new Action(logic.Divide) },
                    { "Podnieś do drugiej potęgi", new Action(logic.Power) },
                    { "Spierwiastkuj", new Action(logic.Sqrt) }
                }, "Wyjdź");
        }

        // You can use only methods which return void
        private static void Menu(string header, Dictionary<string, Action> keyValues, string footer)
        {
            bool exit = false;
            double input;
            int index = 1;

            keyValues.Add(footer, null); // Last option - return
            List<string> keys = new List<string>();
            List<Action> values = new List<Action>();
            foreach (var entry in keyValues)
            {
                keys.Add($"{index++}. {entry.Key}");
                values.Add(entry.Value);
            }
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(header);
                keys.ForEach(x => Console.WriteLine(x));
                input = ViewHelper.AskForDouble("", clear: false); //Waiting for answer
                if (input > 0 && input <= keyValues.Count)
                {
                    if (input == keyValues.Count) exit = true;
                    else values[((int) input) - 1].DynamicInvoke();
                }
                else ViewHelper.WriteAndWait($"Nie ma opcji: {input}!");
            }
        }
    }
}
