using System;

namespace NumAnalysisLab3
{
    internal class Mistake
    {
        public readonly double[] HalfDivideMethodOnlineCalculatorResults =
        {
            -0.5511262207, 0.4270209961, 2.1247558594
        };
        public readonly double[] ChordMethodOnlineCalculatorResults =
        {
           -0.5461759051, 0.4268094440 , 2.1239701395
        };
        public readonly double[] TangentMethodOnlineCalculatorResults =
        {
            -0.5513875248, 0.4270209961, 2.1245702691
        };

        public readonly double[] HalfDivideMethodResults =
        {
            -0.551, 0.4267, 2.1245
        };
        public readonly double[] ChordMethodResults =
        {
            -0.550, 0.4268, 2.1244
        };
        public readonly double[] TangentMethodResults =
        {
            -0.551, 0.4268, 2.1245
        };

        public static double SquareMistake(double[] arr1, double[] arr2)
        {
            int n = arr1.Length;
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += Math.Pow((arr1[i] - arr2[i]), 2);
            }
            sum /= n;
            return Math.Sqrt(sum);
        }
    }
}
