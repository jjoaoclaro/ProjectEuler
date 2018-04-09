using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    public static class Helpers
    {


        public static List<long> PrimesBelow(long number)
        {
            long[] allNumbers = new long[number];
            long[] primes = new long[number];
            for (long i = 0; i < number; i++)
            {
                allNumbers[i] = i + 1;
            }
            allNumbers[0] = 0;
            long index = 1;
            long primesIndex = 0;
            long auxIndex = 0;
            while (index < number)
            {
                if (allNumbers[index] != 0)
                {
                    primes[primesIndex] = allNumbers[index];
                    auxIndex = index + allNumbers[index];
                    while (auxIndex < number)
                    {
                        if (allNumbers[auxIndex] == 0)
                            auxIndex += allNumbers[index];
                        else
                        {
                            allNumbers[auxIndex] = 0;
                            auxIndex += allNumbers[index];
                        }
                    }
                    index++;
                    primesIndex++;
                }
                else
                {
                    index++;
                }
            }
            List<long> ToReturn = new List<long>();
            long z = 0;
            bool end = false;
            while (!end)
            {
                ToReturn.Add(primes[z]);
                z++;
                if (primes[z] == 0)
                {
                    end = true;
                }
            }


            return ToReturn;
        }

        public static bool CheckPalindrome(long number)
        {
            List<int> numberDigits = new List<int>();

            long toGetDigis = number;
            while (toGetDigis != 0)
            {
                numberDigits.Add((Int32)(toGetDigis % 10));
                toGetDigis = toGetDigis / 10;
            }
            int l = numberDigits.Count;

            for (int i = 0; i <= l / 2; i++)
            {
                if (numberDigits[i] != numberDigits[l - 1 - i])
                    return false;
            }



            return true;
        }

        public static long MinimumCommonMultiple(List<long> numbers)
        {
            long result = 0;
            long a, b = 0;
            long x, y = 0;
            long mdc = 0;
            List<long> temp = numbers;

            if (temp.Count > 2)
            {

                a = temp.Last();
                temp.RemoveAt(temp.Count - 1);

                x = a;
                y = MinimumCommonMultiple(temp);
                b = y;

                while (b != a)
                {
                    if (b > a)
                    {
                        b = b - a;
                    }
                    else
                    {
                        a = a - b;
                    }
                }

                result = x * y / a;


            }
            else
            {
                a = temp.Last();
                b = temp.First();

                x = a;
                y = b;

                while (b != a)
                {
                    if (b > a)
                    {
                        b = b - a;
                    }
                    else
                    {
                        a = a - b;
                    }
                }

                result = x * y / a;
            }

            return result;
        }

        public static long SumAll(int limit)
        {
            if (limit % 2 == 0)
                return (1 + limit) * (limit / 2);
            else
                return limit * (limit / 2) + limit;
        }

        public static long Squaring(int limit)
        {
            int x = 0;
            int y = 1;
            int sum = 0;
            for (int i = 1; i <= limit; i++)
            {
                x += y;
                sum += x;

                y += 2;

            }
            return sum;
        }

        public static long PrimeNumber(int number)
        {
            List<long> primes = new List<long>();
            var i = 5;
            primes.Add(2); primes.Add(3);

            while (primes.Count < number)
            {
                if (i % 2 == 0 || i % 3 == 0)
                {
                    i += 2;
                }
                else
                {
                    var found = false;
                    var x = 5;
                    while (x * x <= i && !found)
                    {
                        if (i % x == 0 || i % (x + 2) == 0)
                            found = true;

                        x += 6;
                    }
                    if (!found)
                        primes.Add(i);
                    i += 2;
                }
            }

            return primes[number - 1];

        }

        public static long PrimeAfter(List<long> primes)
        {
            long i = primes.Last();
            i += 2;

            while (primes.Count < primes.Count+1)
            {
                if (i % 2 == 0 || i % 3 == 0)
                {
                    i += 2;
                }
                else
                {
                    var found = false;
                    var x = 5;
                    while (x * x <= i && !found)
                    {
                        if (i % x == 0 || i % (x + 2) == 0)
                            found = true;

                        x += 6;
                    }
                    if (!found)
                        primes.Add(i);
                    i += 2;
                }
            }

            return i;
        }

        public static List<int> RifleShuffler(List<int> deck)
        {
            List<int> up = new List<int>();
            List<int> down = new List<int>();
            int length = deck.Count;
            up.AddRange(deck.Take(length / 2));
            down.AddRange(deck.Skip(length / 2).Take(length / 2));
            List<int> result = new List<int>();
            int i = 0;
            while(i < length / 2)
            {
                result.Add(up[i]);
                result.Add(down[i]);
                i++;
            }

            return result;
        }

        public static List<int> AllDivisors(int number)
        {
            List<int> result = new List<int>();
            var helper = 0;
            for(int i = 1; i*i < number; i++)
            {
                if(number % i == 0)
                {
                    result.Add(i);
                    helper = number / i;
                    if (helper != i)
                        result.Add(helper);
                }
            }

            return result;
        }

        public static void
    }

    public class Pair
    {
        public object x, y;
        public Pair(object x, object y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
