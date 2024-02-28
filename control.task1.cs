using System;
namespace Con_t1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr1 = new double[15];
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write("Введите число x: ");
                arr1[i] = Convert.ToDouble(Console.ReadLine());
            }
            double[,] arr2 = new double[15, 2];
            for (int i = 0; i < 15; i++) 
            { 
                for (int j = 0; j < 2; j+=2)
                {
                    arr2[i, j] = arr1[i];
                    arr2[i, j + 1] = F(arr1[i]);
                }
            }
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"{arr2[i, j]}  ");
                }
                Console.WriteLine();
            }
            Console.Write("Введите а: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Количество чисел, не лежащих в интервале: {Cnt(arr2, a, b)}");
            Console.WriteLine($"Количество точек в заштрихованной области: {Risnk(arr2)}");
        }
        static double F(double x)
        {
            if (x < -1)
            {
                return Math.Cos(x) * Math.Cos(x) * (x * x + 2);
            }
            else if (x < 3 * Math.PI && x != -2 && x != -1)
            {
                return ((Math.Pow(x, 3) + 3.0)/(2 * x - (1 / (x + 2.0)))) * (x/(1.0 + x));
            }
            else
            {
                return 68.0 / 9.0;
            }
        }
        static int Cnt(double[,] array, double a, double b)
        {
            int cnt = 0;
            int rows = array.GetUpperBound(0) + 1;
            for (int i = 0; i < rows; i++)
            {
                if (array[i, 1] < a || array[i, 1] > b)
                    {
                        cnt++;
                    }
            }
            return cnt;
        }
        static int Risnk(double[,] array)
        {
            int cnt = 0;
            int rows = array.GetUpperBound(0) + 1;
            for (int i = 0; i < rows; i++)
            {
                double x = array[i, 0];
                double y = array[i, 1];
                if ((x >= 0 && x * x + y * y <= 36.0 && y >= x - 6) || (x <= 0 && y <= (2 * x + 6) && x >= -3 && y >= -6))
                {
                    cnt++;
                }
            }
            return cnt;
        }
    }
}
