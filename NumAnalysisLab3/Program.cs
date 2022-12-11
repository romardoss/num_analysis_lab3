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
            Console.WriteLine("Функцiя: " + Equation);
            Console.WriteLine();

            Console.Write("Введiть потрiбну точнiсть: ");
            string input = Console.ReadLine();
            if (input != "")
            {
                Console.WriteLine("change the accuracy");
            }

            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Введiть межi a та b для {i + 1}-го кореня (в стовпчик, дробовi числа через кому):");
                a = double.Parse(Console.ReadLine());
                b = double.Parse(Console.ReadLine());

                answer = Methods.HalfDivideMethod(accuracy, a, b);
                Console.Write("Результат методу половинного дiлення: ");
                Console.WriteLine(answer);

                answer = Methods.ChordMethod(accuracy, a, b);
                Console.Write("Результат методу хорд: ");
                Console.WriteLine(answer);

                answer = Methods.TangentMethod(accuracy, a, b);
                Console.Write("Результат методу дотичної: ");
                Console.WriteLine(answer);
            }
            
        }
    }
}
