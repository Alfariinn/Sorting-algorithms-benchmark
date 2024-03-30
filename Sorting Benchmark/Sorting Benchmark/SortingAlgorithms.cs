using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Benchmark
{
     public static class SortingAlgorithms
    {

        #region InsertionSort
        // Function to sort array
        // using insertion sort
        public static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1],
                // that are greater than key,
                // to one position ahead of
                // their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
        #endregion

        #region MergeSort
        // Merges two subarrays of []arr.
        // First subarray is arr[l..m]
        // Second subarray is arr[m+1..r]
        private static void Merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that
        // sorts arr[l..r] using
        // merge()
        public static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {

                // Find the middle point
                int m = l + (r - l) / 2;

                // Sort first and second halves
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);

                // Merge the sorted halves
                Merge(arr, l, m, r);
            }
        }
        #endregion

        #region QuickSortClassical

        // A utility function to swap two elements
        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // This function takes last element as pivot,
        // places the pivot element at its correct position
        // in sorted array, and places all smaller to left
        // of pivot and all greater elements to right of pivot
        private static int Partition(int[] arr, int low, int high)
        {
            // Choosing the pivot
            int pivot = arr[high];

            // Index of smaller element and indicates
            // the right position of pivot found so far
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {

                // If current element is smaller than the pivot
                if (arr[j] < pivot)
                {

                    // Increment index of smaller element
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);
            return (i + 1);
        }

        // The main function that implements QuickSort
        // arr[] --> Array to be sorted,
        // low --> Starting index,
        // high --> Ending index
        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                // pi is partitioning index, arr[p]
                // is now at right place
                int pi = Partition(arr, low, high);

                // Separately sort elements before
                // and after partition index
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }

        }
            #endregion
        
    }
}