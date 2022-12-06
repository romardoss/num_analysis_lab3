using System;

namespace NumAnalysisLab3
{
    internal class Methods
    {
        private static double Equation(double x)
        {
            // returns the value of the given function
            double answer = 2 * Math.Pow(x, 3) - 4 * Math.Pow(x, 2) - x + 1;
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
            if(equationA * equationC < 0)
            {
                return new double[] { a, c };
            }
            else if (equationB * equationC < 0)
            {
                return new double[] { c, b };
            }
            else
            {
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

        private static double Tangent(double a, double b)
        {
            double fa = Equation(a);
            double der = Deritative(a);
            double c = -(fa / der) + a;
            Console.WriteLine($"fa = {fa}; der = {der}; a = {a}; c = {c}");
            if (c <= a || c >= b)
            {
                //throw new Exception("c is out of range");
            }
            return c;
        }

        public static double Controller(int methodCode, double accuracy, double a, double b)
        {
            double c = 0;
            double[] range;
            int i = 0;

            while (b - a > accuracy)
            {
                i++;
                switch (methodCode)
                {
                    case 1: c = HalfDivide(a , b); break;
                    case 2: c = Chord(a, b); break;
                    case 3: c = Tangent(a, b); break;
                }
                Console.WriteLine($"{i} {a} {b} {methodCode}");
                range = NewRange(a, b, c);
                if(a == range[0] && b == range[1])
                {
                    break;
                }
                a = range[0];
                b = range[1];
            }
            return (a + b) / 2;
        }

    }
}
