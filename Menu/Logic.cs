using System;

namespace Menu
{
    public class Logic
    {
        public void Sum()
        {
            double number1 = ViewHelper.AskForDouble("Podaj 1 liczbę: ");
            double number2 = ViewHelper.AskForDouble("Podaj 2 liczbę: ");
            double sum = number1 + number2;
            ViewHelper.WriteAndWait($"Suma {number1} i {number2} to {sum}");
        }

        public void Subtract()
        {
            double number1 = ViewHelper.AskForDouble("Podaj 1 liczbę: ");
            double number2 = ViewHelper.AskForDouble("Podaj 2 liczbę: ");
            double difference = number1 - number2;
            ViewHelper.WriteAndWait($"Różnica {number1} i {number2} to {difference}");
        }

        public void Multiply()
        {
            double number1 = ViewHelper.AskForDouble("Podaj 1 liczbę: ");
            double number2 = ViewHelper.AskForDouble("Podaj 2 liczbę: ");
            double result = number1 * number2;
            ViewHelper.WriteAndWait($"Iloczyn {number1} i {number2} to {result}");
        }

        public void Divide()
        {
            double number1 = ViewHelper.AskForDouble("Podaj 1 liczbę: ");
            double number2 = ViewHelper.AskForDouble("Podaj 2 liczbę: ");
            if (number2 == 0)
            {
                ViewHelper.WriteAndWait("Nie można dzielić przez 0!");
                return;
            }
            double result = number1 / number2;
            ViewHelper.WriteAndWait($"Iloraz {number1} i {number2} to {result}");
        }

        public void Power()
        {
            double number1 = ViewHelper.AskForDouble("Podaj liczbę którą chcesz podnieść do 2 potęgi: ");
            double result = Math.Pow(number1, 2);
            ViewHelper.WriteAndWait($"{number1} do potęgi 2 to {result}");
        }

        public void Sqrt()
        {
            double number1 = ViewHelper.AskForDouble("Podaj liczbę którą chcesz spierwiastkować: ");
            if (number1 < 0)
            {
                ViewHelper.WriteAndWait("Liczba nie może być mniejsza niż 0!");
                return;
            }
            double result = Math.Sqrt(number1);
            ViewHelper.WriteAndWait($"Pierwiastek z {number1} to {result}");
        }
    }
}
