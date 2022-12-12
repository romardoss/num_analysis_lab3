using System;

namespace NumAnalysisLab3
{
    internal class Polynom
    {
        public static int[] Coefficients { get; set; }

        private static double Equation(double x)
        {
            // returns the value of the given function
            double answer = 0;
            for(int i = 0; i < Coefficients.Length; i++)
            {
                answer += Coefficients[i] * Math.Pow(x, Coefficients.Length-i-1);
            }
            return answer;
        }

        public static string getEquationString()
        {
            string answer = "";
            for (int i = 0; i < Coefficients.Length-1; i++)
            {
                answer += $"{Coefficients[i]}*(x^{Coefficients.Length - i - 1}) + ";
            }
            answer += $"{Coefficients[Coefficients.Length-1]}";
            return answer;
        }

        private static double Deritative(double x)
        {
            // returns the deritative value of the given function
            return 6 * Math.Pow(x, 2) - 8 * x - 1;
        }

        private static double[] NewRange(double a, double b, double c)
        {
            // a-start b-end c-divider
            double equationA = Equation(a);
            double equationB = Equation(b);
            double equationC = Equation(c);
            if (equationA * equationC < 0)
            {
                return new double[] { a, c };
            }
            else if (equationB * equationC < 0)
            {
                return new double[] { c, b };
            }
            else if (equationC == 0)
            {
                return new double[] { c, c };
            }
            else
            {
                //Console.WriteLine($"{equationA} {equationB} {equationC} {c}");
                return new double[] { -1 };
            }
        }

        private static double HalfDivide(double a, double b)
        {
            return (a + b) / 2;
        }

        private static double Chord(double a, double b)
        {
            double fa = Equation(a);
            double fb = Equation(b);
            return (-fa / (fb - fa)) * (b - a) + a;
        }

        private static double Tangent(double a)
        {
            double fa = Equation(a);
            double der = Deritative(a);
            double c = -(fa / der) + a;
            return c;
        }

        public static string HalfDivideMethod(double accuracy, double a, double b)
        {
            double[] range;
            int iterations = 0;

            while ((b - a > accuracy) || (Math.Abs(Equation((a+b)/2)) > accuracy))
            {
                iterations++;
                double c = HalfDivide(a, b);
                range = NewRange(a, b, c);
                a = range[0];
                b = range[1];
            }
            return GenerateAnswer(a, b, accuracy, iterations);
        }

        public static string ChordMethod(double accuracy, double a, double b)
        {
            double[] range;
            int iterations = 0;
            double previousA = a;
            double previousB = b;

            while ((b - a > accuracy) || (Math.Abs(Equation((a + b) / 2)) > accuracy))
            {
                iterations++;
                double c = Chord(a, b);
                //Console.WriteLine($"{i} {a} {b}");
                range = NewRange(a, b, c);
                if (((int)(a / accuracy * 10) == (int)(range[0] / accuracy * 10)) &&
                    ((int)(b / accuracy * 10) == (int)(range[1] / accuracy * 10)))
                {
                    if (previousB == range[1])   //перевірка на межу, що "застрягла"
                    {
                        b = a + (accuracy/10);
                    }
                    else if (previousA == range[0])
                    {
                        a = b - (accuracy / 10);
                    }
                    break;
                }
                previousA = a;
                previousB = b;
                a = range[0];
                b = range[1];
            }
            return GenerateAnswer(a, b, accuracy, iterations);
        }

        public static string TangentMethod(double accuracy, double a, double b)
        {
            double[] range;
            int iterations = 0;

            while ((b - a > accuracy) || (Math.Abs(Equation((a + b) / 2)) > accuracy))
            {
                iterations++;
                double c = Tangent(a);
                if (c <= a || c >= b)
                {
                    c = Tangent(b);
                    if (c <= a || c >= b)
                    {
                        //Console.WriteLine($"{i} {a} {b} {c}");
                        //Console.WriteLine("C is defined by half divide method");
                        c = HalfDivide(a, b);
                    }
                }
                
                range = NewRange(a, b, c);
                a = range[0];
                b = range[1];
            }
            return GenerateAnswer(a, b, accuracy, iterations);
        }

        private static string GenerateAnswer(double a, double b, double accuracy, int iterations)
        {
            double xValue = (a + b) / 2;
            double equationValue = Equation(xValue);
            string x = Print.Number(xValue);
            string equation = Print.Number(equationValue);
            string range = Print.Number(b - a);
            string answer = $"x = {x}\n";
            answer += "|b-a| < eps\t->\t";
            answer += $"|{range}| < {accuracy}\n";
            answer += "|f(xk)| < eps\t->\t";
            answer += $"|{equation}| < {accuracy}\n";
            answer += $"number of iterations: {iterations}\n";
            return answer;
        }

    }
}
