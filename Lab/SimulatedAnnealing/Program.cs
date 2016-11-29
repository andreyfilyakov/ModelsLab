using System;
using System.Collections.Generic;

namespace SimulatedAnnealing
{
    class City
    {
        public int X;
        public int Y;
        public int Id;

        public City(int x, int y, int id)
        {
            X = x;
            Y = y;
            Id = id;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();
            Console.Write("Min route lenght: ");
            double min = Convert.ToDouble(Console.ReadLine());

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Coordinates of city #{0}: ", i + 1);
                int x = Convert.ToInt32(Console.ReadLine());
                int y = Convert.ToInt32(Console.ReadLine());
                cities.Add(new City(x, y, i + 1));
            }

            double len = CalculateRoutLength(cities);
            while (len > min)
            {
                int changeCity = (new Random()).Next(0, 5);

                List<City> nextCities = new List<City>(cities);
                City city = nextCities[changeCity];
                nextCities.Remove(city);
                nextCities.Add(city);

                double nextLen = CalculateRoutLength(nextCities);
                double dLen = nextLen - len;
                if (dLen <= 0)
                {
                    cities = nextCities;
                    len = nextLen;
                }
            }

            Console.Write("\nOptimal order of cities: ");
            for (int i = 0; i < cities.Count; i++)
            {
                Console.Write("{0} -> ", cities[i].Id);
            }
            Console.WriteLine("{0}", cities[0].Id);
            Console.WriteLine("Distance: {0}", Math.Round(CalculateRoutLength(cities),2));

            Console.ReadKey();
        }

        static double CalculateRoutLength(List<City> cities)
        {
            double res = 0;
            for (int i = 0; i < cities.Count - 1; i++)
            {
                res += Distance(cities[i], cities[i + 1]);
            }

            res += Distance(cities[0], cities[cities.Count - 1]);
            return res;
        }

        static double Distance(City first, City second)
        {
            return Math.Sqrt(Math.Pow(second.X - first.X, 2) + Math.Pow(second.Y - first.Y, 2));
        }
    }
}
