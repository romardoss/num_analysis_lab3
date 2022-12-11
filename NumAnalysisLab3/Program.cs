using System;

namespace NumAnalysisLab3
{
    internal class Program
    {
        private static double a;
        private static double b;
        private static double answer;
        private static double accuracy = 0.001;

        static void Main()
        {
            int[] Coefficients = new int[6];
            for (int i = 5; i >= 0; i--)
            {
                Console.WriteLine($"Введiть значення коефiцiєнту a{i}");
                Coefficients[Coefficients.Length-1-i] = int.Parse(Console.ReadLine());
            }
            Methods.Coefficients = Coefficients;

            Console.WriteLine("Функцiя: " + Methods.getEquationString());
            Console.WriteLine();

            Console.Write("Введiть потрiбну точнiсть (за замовчуванням 0.001): ");
            string input = Console.ReadLine();
            if (input != "")
            {
                accuracy = double.Parse(input);
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
