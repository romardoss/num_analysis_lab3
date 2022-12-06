using System;

namespace NumAnalysisLab3
{
    internal class Program
    {
        private static readonly string Equation = "2*x^3 - 4*x^2 - x + 1";
        private static double a;
        private static double b;
        private static double answer;
        private static double accuracy = 0.001;

        static void Main(string[] args)
        {
            Console.WriteLine(Equation);
            Console.WriteLine();

            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Введіть межі a та b для {i + 1}-го кореня (в стовпчик, дробові числа через кому):");
                a = double.Parse(Console.ReadLine());
                b = double.Parse(Console.ReadLine());
                answer = Methods.Controller(1, accuracy, a, b);
                Console.Write("Результат методу половинного ділення: ");
                Console.WriteLine(answer);
                answer = Methods.Controller(2, accuracy, a, b);
                Console.Write("Результат методу хорд: ");
                Console.WriteLine(answer);
                answer = Methods.Controller(3, accuracy, a, b);
                Console.Write("Результат методу дотичної: ");
                Console.WriteLine(answer);
            }
            
        }
    }
}
