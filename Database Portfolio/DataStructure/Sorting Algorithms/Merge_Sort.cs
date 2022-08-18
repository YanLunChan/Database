/*
 * Author: Yan Lun Chan
 * Date: Auguest 2022
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms 
{ 
    public class Merge_Sort
    {
        /// <summary>
        /// Goal: complete Merge Sort
        /// What is Merge Sort?: 
        /// O(nlog(n))
        /// -Merge sort first divides the array into equal halves and then combines them in a sorted manner.
        /// 
        /// ---Pseudo Code---
        /// (MergeSort(array, left, right))
        /// if left < right
        ///     mid = left + right . truncate
        ///     Mergesort(array,left, mid)
        ///     Mergesort(array, mid+1, right)
        ///     Merge(array, left, mid , right)
        ///     
        /// (Merge(array, left, mid, right))
        /// num1 = mid - left + 1
        /// num2 = right - mid;
        /// Left array = length of num1
        /// Right array = length of num2
        /// 
        /// for i < num1
        /// set left array from array[0] to left+i
        /// 
        /// for i < num2
        /// set right array from array[mid + j + i]
        /// 
        /// create x variable to track left index
        /// create y variable to track right index
        /// for k = left, left <= right
        /// if left[k] < right[x]
        ///     array[k] = left[x++]
        /// else
        ///     array[k] = right[y++]
        /// ---Pseudo Code---
        /// 
        /// </summary>
        /// <typeparam name="T">can be any type</typeparam>
        /// <param name="array">parameter to be sorted</param>
        public static void MergeSort<T>(T[] array, int left, int right) where T : IComparable
        {
            //Find size of sub arrays
            if(left < right) 
            {
                int mid = (left + right) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        public static void Merge<T>(T[] array, int left, int mid, int right) where T: IComparable 
        {
            int num1 = mid - left + 1;
            int num2 = right - mid;
            T[] Left = new T[num1 + 1];
            T[] Right = new T[num2 + 1];

            for (int i = 0; i < num1; i++) 
                Left[i] = array[left + i];

            for (int j = 0; j < num2; j++)
                Right[j] = array[mid + j + 1];

            Left[num1] = (dynamic)int.MaxValue; // used to prevent error when sorting
            Right[num2] = (dynamic)int.MaxValue; // used to prevent error when sorting

            int x = 0;
            int y = 0;

            for(int k = left; k <= right; k++) 
            {
                //Console.WriteLine($"------ITERATION {k}-----");
                if (Left[x].CompareTo(Right[y]) <= 0)
                {
                    array[k] = Left[x++];
                }
                else
                {
                    array[k] = Right[y++];
                }
                //Console.Write("\nL[");
                //foreach (T a in Left)
                //    Console.Write($" {a},");
                //Console.WriteLine("]\n");
                //Console.Write("\nR[");
                //foreach (T a in Right)
                //    Console.Write($" {a},");
                //Console.WriteLine("]\n");
                //Console.Write("\nA[");
                //foreach (T a in array)
                //    Console.Write($" {a},");
                //Console.WriteLine("]\n");
            }
        }
    }
}
