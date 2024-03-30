using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Benchmark
{
    public static class Generators
    {
        public static int[] GenerateRandom(int size, int minVal, int maxVal)
        {
            int[] a = new int[size];

            for (int i = 0; i < size; i++)
            {
                a[i] = new Random().Next(minVal, maxVal);
            }
                
            return a;
        }

        public static int[] GenerateSorted(int size, int minVal, int maxVal)
        {
            int[] a = GenerateRandom(size, minVal, maxVal);
            Array.Sort(a);
            return a;
        }

        public static int[] GenerateReversed(int size, int minVal, int maxVal)
        {
            int[] a = GenerateSorted(size, minVal, maxVal);
            Array.Reverse(a);
            return a;
        }

        public static int[] GenerateAlmostSorted(int size, int minVal, int maxVal, double shuffledPercentAmount)
        {
            int[] a = GenerateSorted(size, minVal, maxVal);
            Array.Sort(a);

            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                if (rand.NextDouble() < shuffledPercentAmount)
                {
                    int randomIndex = rand.Next(size);
                    int temp = a[i];
                    a[i] = a[randomIndex];
                    a[randomIndex] = temp;
                }
            }

            return a;
        }
    }
}
