using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumAnalysisLab3
{
    internal class Print
    {
        public static string Number(double num)
        {
            string s = num.ToString("N10");
            string answer = "";
            if (num < 0)
            {
                answer = "-";
                s = s[1..];
            }
            int k = (num >= 0) ? 6 : 5;
            if (s.Length >= k)
            {
                answer += s[..k];
            }
            else
            {
                answer += string.Concat(Enumerable.Repeat("0", k - s.Length)) + s;
            }

            if (num == 0)
            {
                return "000000";
            }
            return answer;
        }

        public static void Array(double[] arr)
        {
            //виводить на екран нев'язку (або будь-який інший одновимірний масив)
            foreach (double i in arr)
            {
                Console.Write(Number(i) + " ");
            }
            Console.WriteLine();
        }
    }
}
