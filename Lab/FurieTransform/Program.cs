using System;

namespace FurieTransform
{
    class Complex
    {
        public double Re;
        public double Im;

        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }
    }

    class Program
    {
        static double[] y = { 8, 4, 8, 0 };

        static void Main(string[] args)
        {
            Console.WriteLine("Re\tIm\n");
            Console.WriteLine(Math.Round(X(0).Re, 2) + "\t" + Math.Round(X(0).Im, 2));
            Console.WriteLine(Math.Round(X(1).Re, 2) + "\t" + Math.Round(X(1).Im, 2));
            Console.WriteLine(Math.Round(X(2).Re, 2) + "\t" + Math.Round(X(2).Im, 2));
            Console.WriteLine(Math.Round(X(3).Re, 2) + "\t" + Math.Round(X(3).Im, 2));
            Console.ReadKey();
        }

        public static Complex exp(double t)
        {
            return new Complex(Math.Cos(t), Math.Sin(t));
        }

        public static Complex X(int index)
        {
            Complex res = new Complex(0, 0);

            for (int i = 0; i < 4 - 1; i++)
            {
                res.Re = res.Re + y[i] * exp(2 * Math.PI * i * index / 4).Re;
                res.Im = res.Im + y[i] * exp(2 * Math.PI * i * index / 4).Im;
            }

            return res;
        }
    }
}
