using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Generators.GenerateRandom(10, 0, 100);

            SortingAlgorithms.InsertionSort(arr);

            PrintArray(arr);

        }

        static void PrintArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }


    }
}
