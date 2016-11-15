using System;

namespace Decisions
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] ABCD = { { 1, 3, 7, 9 }, { 1.0 / 3.0, 1, 5, 7 }, { 1.0 / 7.0, 1.0 / 5.0, 1, 3 }, { 1.0 / 9.0, 1.0 / 7.0, 1.0 / 3.0, 1 } };
            double[,] xyzA = { { 1, 1, 7 }, { 1, 1, 3 }, { 1.0 / 7.0, 1.0 / 3.0, 1 } };
            double[,] xyzB = { { 1, 0.2, 0.5 }, { 5, 1, 5 }, { 2, 1.0 / 5.0, 1 } };
            double[,] xyzC = { { 1, 1.0 / 6.0, 1.0 / 3.0 }, { 6, 1, 4 }, { 3, 1.0 / 4.0, 1 } };
            double[,] xyzD = { { 1, 1.0 / 3.0, 1.0 / 7.0 }, { 3, 1, 5 }, { 7, 1.0 / 5.0, 1 } };

            Console.Write("ABCD: ");
            double[] resABCD = GetVector(ABCD);

            Console.Write("\nresA: ");
            double[] resA = GetVector(xyzA);
            Console.Write("resB: ");
            double[] resB = GetVector(xyzB);
            Console.Write("resC: ");
            double[] resC = GetVector(xyzC);
            Console.Write("resD: ");
            double[] resD = GetVector(xyzD);

            double[][] res = { resA, resB, resC, resD };

            Console.Write("\nX: ");
            Console.WriteLine("{0}", Result(resABCD, 0, res));
            Console.Write("Y: ");
            Console.WriteLine("{0}", Result(resABCD, 1, res));
            Console.Write("Z: ");
            Console.WriteLine("{0}", Result(resABCD, 2, res));

            Console.ReadLine();
        }

        static double Result(double[] resABCD, int index, double[][] res)
        {
            double sum = 0;
            for (int i = 0; i < resABCD.Length; i++)
            {
                sum += resABCD[i] * res[i][index];
            }
            return Math.Round(sum / 100.0, 2);
        }

        static double[] GetVector(double[,] matrix)
        {
            double[] sum = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum[i] += matrix[j, i];
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[j, i] /= sum[i];
                }
            }

            double[] result = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double row = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row += matrix[i, j];
                }
                result[i] = row * 100 / matrix.GetLength(0);
                Console.Write("{0}\t", Math.Round(result[i], 2));
            }
            Console.WriteLine();
            return result;
        }
    }
}
