using System;

namespace NumAnalysisLab3
{
    internal class Program
    {
        private static double a;
        private static double b;
        private static string answer;
        private static double accuracy = 0.001;
        private static int[] Coefficients;
        private static int PolynomPower;

        static void Main()
        {
            Console.Write("Введiть порядок полiному: ");
            PolynomPower = int.Parse(Console.ReadLine());
            Coefficients = new int[PolynomPower+1];
            for (int i = 5; i >= 0; i--)
            {
                Console.WriteLine($"Введiть значення коефiцiєнту a{i}");
                Coefficients[Coefficients.Length-1-i] = int.Parse(Console.ReadLine());
            }
            Polynom.Coefficients = Coefficients;

            Console.WriteLine("Функцiя: " + Polynom.getEquationString());
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

                answer = Polynom.HalfDivideMethod(accuracy, a, b);
                Console.WriteLine("Результат методу половинного дiлення: ");
                Console.WriteLine(answer);

                answer = Polynom.ChordMethod(accuracy, a, b);
                Console.WriteLine("Результат методу хорд: ");
                Console.WriteLine(answer);

                answer = Polynom.TangentMethod(accuracy, a, b);
                Console.WriteLine("Результат методу дотичної: ");
                Console.WriteLine(answer);
                Console.WriteLine();
            }

            Mistake m = new();
            Console.Write("Середньоквадратична похибка методу бiсекцiї: ");
            Console.WriteLine(Mistake.SquareMistake(m.HalfDivideMethodOnlineCalculatorResults,
                m.HalfDivideMethodResults));
            Console.Write("Середньоквадратична похибка методу хорд: ");
            Console.WriteLine(Mistake.SquareMistake(m.ChordMethodOnlineCalculatorResults,
                m.ChordMethodResults));
            Console.Write("Середньоквадратична похибка методу дотичної: ");
            Console.WriteLine(Mistake.SquareMistake(m.TangentMethodOnlineCalculatorResults,
                m.TangentMethodResults));
        }
    }
}
