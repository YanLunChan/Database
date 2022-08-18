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
    public class Insertion_Sort
    {
        /// <summary>
        /// Goal: complete Insertion Sort
        /// What is Insertion Sort?: 
        /// O(n^2)
        /// -Split into two category: sorted and unsorted parts.
        /// -Left side is sorted and right side is unsorted
        /// ---Pseudo Code---
        /// (array is an array that contains 0 to n)
        /// for(i = 1; i < length; i++)
        ///     T selected = array[i]
        ///     j = i-1
        ///     while(j >= 0 && array[j] > selected)
        ///         array[j+1] = array[j]
        ///         j--;
        ///     array[j+1] = selected
        ///     
        /// ---Pseudo Code---
        /// 
        /// </summary>
        /// <typeparam name="T">can be any type</typeparam>
        /// <param name="array">parameter to be sorted</param>
        public static void InsertionSort<T>(T[] array) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                //cache selection to compare to j
                T selected = array[i];
                int j = i - 1;
                while (j >= 0 && array[j].CompareTo(selected) > 0) 
                {
                    //swapping action
                    array[j + 1] = array[j--];
                }
                //if array[j] is smaller than selected then place it at j+1
                array[j + 1] = selected;
            }
        }
    }
}

