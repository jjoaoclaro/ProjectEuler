using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    public static class Problems
    {
        public static int Problem1()
        {
            int sum = 0;
            var i = 1;
            var i3 = 3;
            var i5 = 5;

            while (i3 < 1000)
            {
                if (i5 < 1000)
                {
                    sum += i5;
                }

                if (i % 5 != 0)
                {
                    sum += i3;
                }

                i = (i + 1) % 5;
                i3 += 3;
                i5 += 5;
            }

            return sum;
        }

        public static int Problem2()
        {
            int sum = 0;
            int i0 = 1;
            int i1 = 1;
            int i2 = 2;
            int limit = 4000000;

            while (i2 < limit)
            {
                sum += i2;
                i0 = i1 + i2;
                i1 = i2 + i0;
                i2 = i0 + i1;
            }
            return sum;
        }

        public static long Problem3()
        {
            long[] primes = Helpers.PrimesBelow(295);
            long lastPrime = 2;
            long index = 0;
            long target = 600851475143;

            while (target != 1)
            {
                if (target % primes[index] != 0)
                {
                    index++;
                    lastPrime = primes[index];
                }
                else
                {
                    target = target / primes[index];
                }
            }

            return lastPrime;
        }

        public static int Problem4()
        {
            int left = 999;
            int right = 999;
            int max = 0;
            int leftMax = 0;
            int rightMax = 0;
            while (left != 0)
            {
                right = 999;
                while (right != 0)
                {
                    var temp = left * right;
                    if (Helpers.CheckPalindrome(temp))
                    {
                        if (max < temp)
                        {
                            max = temp;
                            leftMax = left;
                            rightMax = right;
                            Console.WriteLine("Left: " + leftMax + " Right: " + rightMax + " Product: " + max);
                        }
                    }
                    right--;

                }
                left--;
            }



            return max;
        }

        public static long Problem5(int limit)
        {
            List<long> numbers = new List<long>();
            for (int i = 1; i <= limit; i++)
            {
                numbers.Add(i);
            }

            return Helpers.MinimumCommonMultiple(numbers);
        }

        public static long Problem6(int limit)
        {
            long sqrtSum = (long)Math.Pow(Helpers.SumAll(limit), 2);
            long sumSqrt = Helpers.Squaring(limit);
            Console.Write("sqrtSum: " + sqrtSum + " sumSqrt: " + sumSqrt + " ");
            return sqrtSum - sumSqrt;
        }

        public static long Problem7()
        {
            return Helpers.PrimeNumber(10001);
        }

        public static long Problem8()
        {

            System.IO.StreamReader file =
    new System.IO.StreamReader(@"C:\Users\FelipeCarvalho\source\repos\ConsoleApp2\ConsoleApp2\test.txt");
            List<int> numbers = new List<int>();
            var x = Convert.ToInt32(file.Read() - 48);
            while (x >= 0)
            {
                numbers.Add(x);
                x = file.Read() - 48;

            }

            long result = 0;
            long temp = 1;
            for (int i = 0; i < numbers.Count - 13; i++)
            {
                temp = 1;
                for (int y = 0; y < 13; y++)
                {
                    temp = temp * numbers[i + y];

                }
                if (temp > result)
                {
                    result = temp;
                }
            }

            return result;
        }
    }
}
