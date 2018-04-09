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

        public static long Problem3(long target)
        {
            long[] primes = Helpers.PrimesBelow(Convert.ToInt64(Math.Sqrt(target))).ToArray();
            long lastPrime = 2;
            long index = 0;

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
    new System.IO.StreamReader(@"../../Problem8.txt");
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

        public static int Problem9()
        {
            int a = 0;
            int b = 0;
            int c = 0;

            for (c = 998; c > 0; c--)
            {
                for (b = c; b > 0; b--)
                {
                    for (a = b; a > 0; a--)
                    {
                        if (a + b + c != 1000)
                            continue;

                        if (a * a + b * b == c * c)
                        {
                            Console.WriteLine("A=" + a + " B=" + b + " C=" + c);
                            return a * b * c;
                        }
                    }
                }
            }

            return 0;
        }

        public static long Problem10()
        {
            long[] primes = Helpers.PrimesBelow(2000000).ToArray();

            long sum = 0;
            for (int i = 0; i < primes.Length; i++)
            {
                sum += primes[i];
            }

            return sum;
        }

        public static int Problem11()
        {
            System.IO.StreamReader file =
        new System.IO.StreamReader(@"../../Problem11.txt");


            int[,] grid = new int[20,20];

            for(int i = 0; i<20; i++)
            {
                var line = file.ReadLine();
                var splited = line.Split(' ');
                for(int j = 0; j < 20; j++)
                {
                    grid[j, i] = Convert.ToInt32(splited[j]);
                }
            }

            int x = 0;
            int y = 0;

            int max = 0;
            int temp = 0;
            while(y < 16)
            {
                x = 0;
                while(x < 4)
                {
                    temp = grid[x, y] * grid[x, y + 1] * grid[x, y + 2] * grid[x, y + 3];
                    if(temp > max)
                    {
                        max = temp;
                    }
                    temp = grid[x, y] * grid[x+1, y + 1] * grid[x+2, y + 2] * grid[x+3, y + 3];
                    if (temp > max)
                    {
                        max = temp;
                    }
                    temp = grid[x, y] * grid[x + 1, y] * grid[x + 2, y] * grid[x + 3, y];
                    if (temp > max)
                    {
                        max = temp;
                    }
                    x++;
                }
                while(x < 16)
                {
                    temp = grid[x, y] * grid[x-1, y + 1] * grid[x-2, y + 2] * grid[x-3, y + 3];
                    if (temp > max)
                    {
                        max = temp;
                    }

                    temp = grid[x, y] * grid[x, y + 1] * grid[x, y + 2] * grid[x, y + 3];
                    if(temp > max)
                    {
                        max = temp;
                    }
                    temp = grid[x, y] * grid[x+1, y + 1] * grid[x+2, y + 2] * grid[x+3, y + 3];
                    if (temp > max)
                    {
                        max = temp;
                    }
                    temp = grid[x, y] * grid[x + 1, y] * grid[x + 2, y] * grid[x + 3, y];
                    if (temp > max)
                    {
                        max = temp;
                    }
                    x++;
                }
                while (x < 20)
                {
                    temp = grid[x, y] * grid[x - 1, y + 1] * grid[x - 2, y + 2] * grid[x - 3, y + 3];
                    if (temp > max)
                    {
                        max = temp;
                    }

                    temp = grid[x, y] * grid[x, y + 1] * grid[x, y + 2] * grid[x, y + 3];
                    if (temp > max)
                    {
                        max = temp;
                    }
                    x++;
                }
                y++;
            }

            while(y < 20)
            {
                x = 0;
                while (x < 4)
                {
                    temp = grid[x, y] * grid[x + 1, y] * grid[x + 2, y] * grid[x + 3, y];
                    if (temp > max)
                    {
                        max = temp;
                    }
                    x++;
                }
                while (x < 16)
                {
                    temp = grid[x, y] * grid[x + 1, y] * grid[x + 2, y] * grid[x + 3, y];
                    if (temp > max)
                    {
                        max = temp;
                    }
                    x++;
                }
                y++;
            }

            return max;
        }

        public static long Problem12()
        {
            int i = 1;
            int sum = 0;
            List<int> divisors;
            bool found = false;
            while (!found)
            {
                sum += i;
                divisors = Helpers.AllDivisors(sum);
                if(divisors.Count > 500)
                {
                    found = true;
                }
                i++;
            }

            return sum;
        }

        public static long Problem13()
        {
            System.IO.StreamReader file =
        new System.IO.StreamReader(@"../../Problem13.txt");
            long sum = 0;
            
            for (int i = 0; i < 100; i++)
            {
                var line = file.ReadLine();
                var helper = line.Take(13).ToArray();
                var helpstring = new string(helper);
                var number = Convert.ToInt64(helpstring);
                sum += number;
            }

            return Convert.ToInt64(new string(sum.ToString().Take(10).ToArray()));
        }

        public static long Problem14()
        {
            int value = 1;
            int size = 1;
            int hvalue;
            int hsize;
            

            List<Pair> list = new List<Pair>();
            list.Add(new Pair(value, size));
            int h = 2;
            for(h = 2; h< 1000000; h++)
            {
                hvalue = h;
                hsize = 1;
                while(hvalue != 1)
                {
                    
                }
            }

            return 0;
        }

        public static int Problem622()
        {
            List<int> list = new List<int>();
            List<int> temp = new List<int>();
            int size = 86;
            for(int i = 0; i< size; i++)
            {
                list.Add(i);
            }

            foreach(int i in list){
                Console.Write(i + " ");
            }
            Console.WriteLine();
            temp = Helpers.RifleShuffler(list);
            int x = 1;
            int shuffles = 1;
            bool ordered = true;
            while(x < temp.Count && ordered)
            {
                ordered = temp[x] > temp[x - 1];
                x++;
            }

            Console.WriteLine("Stuff");
            while (!ordered)
            {
                temp = Helpers.RifleShuffler(temp);
                shuffles++;
                x = 1;
                ordered = true;
                while (x < temp.Count && ordered)
                {
                    ordered = temp[x] > temp[x - 1];
                    x++;
                }
            }
            return shuffles ;
        }
    }
}
