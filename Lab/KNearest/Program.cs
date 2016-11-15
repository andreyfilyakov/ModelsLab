using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knearest
{
    public class Point
    {
        public double X;
        public double Y;
        public int Type;

        public Point(double x, double y, int type = 0)
        {
            this.X = x;
            this.Y = y;
            this.Type = type;
        }
    }

    public class Program
    {
        public static int k = 3;
        public static List<Point> A = new List<Point> { new Point(2, 3, -1), new Point(1, 3, -1), new Point(3, 3, -1), new Point(7, 7, 1), new Point(7, 6, 1), new Point(7, 8, 1) };

        static void Main(string[] args)
        {
            while (true)
            {
                double x = 0, y = 0;
                Console.Write("Enter X of point: ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Y of point: ");
                y = Convert.ToDouble(Console.ReadLine());

                Point point = new Point(x, y);
                A.Sort(delegate (Point p1, Point p2)
                {
                    double e1 = E(p1, point), e2 = E(p2, point);
                    if (e1 > e2)
                    {
                        return 1;
                    }
                    else if (e1 == e2)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                });

                int res = 0;
                for (int i = 0; i < (k > A.Count ? A.Count : k); i++)
                {
                    if (A[i].Type == 1)
                    {
                        res++;
                    }
                    else
                    {
                        res--;
                    }
                }

                Console.WriteLine("Point type: {0}\n", Math.Sign(res));
            }
        }

        private static double E(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
