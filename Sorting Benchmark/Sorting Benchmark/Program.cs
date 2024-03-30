using System.Reflection;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Benchmark
{


    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }



        public class Benchmark
        {
            [Params(10, 100, 1000, 100000)]
            public int arraySize;
            public int[]? random;
            public int[]? sorted;
            public int[]? reversed;
            public int[]? almostSorted;
            public int[]? fewUniques;

            [GlobalSetup]
            public void Setup()
            {
                random = Generators.GenerateRandom(arraySize, 0, 100);
                sorted = Generators.GenerateSorted(arraySize, 0, 100);
                reversed = Generators.GenerateReversed(arraySize, 0, 100);
                almostSorted = Generators.GenerateAlmostSorted(arraySize, 0, 100, 0.1);
                fewUniques = Generators.GenerateRandom(arraySize, 0, 10);
            }

            //Insertion sort
            [Benchmark] public void InsertionSortRandom() { SortingAlgorithms.InsertionSort(random!); }
            [Benchmark] public void InsertionSortSorted() { SortingAlgorithms.InsertionSort(sorted!); }
            [Benchmark] public void InsertionSortReversed() { SortingAlgorithms.InsertionSort(reversed!); }
            [Benchmark] public void InsertionSortAlmostSorted() { SortingAlgorithms.InsertionSort(almostSorted!); }
            [Benchmark] public void InsertionSortFewUniques() { SortingAlgorithms.InsertionSort(fewUniques!); }

            //Merge sort
            [Benchmark] public void MergeSortRandom() { SortingAlgorithms.MergeSort(random!); }
            [Benchmark] public void MergeSortReversed() { SortingAlgorithms.MergeSort(sorted!); }
            [Benchmark] public void MergeSortSorted() { SortingAlgorithms.MergeSort(reversed!); }
            [Benchmark] public void MergeSortAlmostSorted() { SortingAlgorithms.MergeSort(almostSorted!); }
            [Benchmark] public void MergeSortFewUniques() { SortingAlgorithms.MergeSort(fewUniques!); }

            //Quick sort classical
            [Benchmark] public void QuickSortClassicRandom() { SortingAlgorithms.QuickSortClassic(random!); }
            [Benchmark] public void QuickSortClassicReversed() { SortingAlgorithms.QuickSortClassic(reversed!); }
            [Benchmark] public void QuickSortClassicSorted() { SortingAlgorithms.QuickSortClassic(sorted!); }
            [Benchmark] public void QuickSortClassicAlmostSorted() { SortingAlgorithms.QuickSortClassic(almostSorted!); }
            [Benchmark] public void QuickSortClassicFewUniques() { SortingAlgorithms.QuickSortClassic(fewUniques!); }

            //Quick sort heuristic, c# lib
            [Benchmark] public void QuickSortCLibRandom() { Array.Sort(random!); }
            [Benchmark] public void QuickSortCLibReversed() { Array.Sort(reversed!); }
            [Benchmark] public void QuickSortCLibSorted() { Array.Sort(sorted!); }
            [Benchmark] public void QuickSortCLibAlmostSorted() { Array.Sort(almostSorted!); }
            [Benchmark] public void QuickSortCLibFewUniques() { Array.Sort(fewUniques!); }

        }



        static void PrintArray(int[] arr)
        {
            StringBuilder sb = new StringBuilder("[ ");
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                sb.Append(arr[i] + ", ");
            sb.Length -= 2;
            sb.Append(" ]");
            Console.WriteLine(sb.ToString());

        }
    }
}
