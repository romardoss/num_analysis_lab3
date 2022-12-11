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
            return c;
        }

        public static double HalfDivideMethod(double accuracy, double a, double b)
        {
            double[] range;

            while (b - a > accuracy)
            {
                double c = HalfDivide(a, b);
                range = NewRange(a, b, c);
                a = range[0];
                b = range[1];
            }
            return (a + b) / 2;
        }

        public static double ChordMethod(double accuracy, double a, double b)
        {
            double[] range;
            int i = 0;
            double previousA = a;
            double previousB = b;

            while (b - a > accuracy)
            {
                i++;
                double c = Chord(a, b);
                //Console.WriteLine($"{i} {a} {b}");
                range = NewRange(a, b, c);
                if (((int)(a / accuracy * 10) == (int)(range[0] / accuracy * 10)) &&
                    ((int)(b / accuracy * 10) == (int)(range[1] / accuracy * 10)))
                {
                    if (previousB == range[1])   //перевірка на межу, що "застрягла"
                    {
                        b = a + accuracy;
                    }
                    else if (previousA == range[0])
                    {
                        a = b - accuracy;
                    }
                    break;
                }
                previousA = a;
                previousB = b;
                a = range[0];
                b = range[1];
            }
            return (a + b) / 2;
        }

        public static double TangentMethod(double accuracy, double a, double b)
        {
            double[] range;
            int i = 0;

            while (b - a > accuracy)
            {
                i++;
                double c = Tangent(a, b);
                if (c <= a || c >= b)
                {
                    //Console.WriteLine($"{i} {a} {b} {c}");
                    //Console.WriteLine("C is defined by half divide method");
                    c = HalfDivide(a, b);
                }
                
                range = NewRange(a, b, c);
                a = range[0];
                b = range[1];
            }
            return (a + b) / 2;
        }

    }
}
