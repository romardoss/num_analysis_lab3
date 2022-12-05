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
                return new double[] { equationA, equationC };
            }
            else if (equationB * equationC < 0)
            {
                return new double[] { equationC, equationB };
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

        private static double Tangent(double a)
        {
            double fa = Equation(a);
            double der = Deritative(a);
            return -(fa / der) + a;
        }

        public static double Controller(int methodCode, double accuracy, double a, double b)
        {
            double c = 0;
            double[] range;

            while (b - a < accuracy)
            {
                switch (methodCode)
                {
                    case 1: c = HalfDivide(a , b); break;
                    case 2: c = Tangent(a); break;
                    case 3: c = Tangent(a); break;
                }
                range = NewRange(a, b, c);
                a = range[0];
                b = range[1];
            }
            return (a + b) / 2;
        }

    }
}
