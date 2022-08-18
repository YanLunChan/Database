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
    public class Selection_Sort
    {
        /// <summary>
        /// Goal: complete Selection Sort
        /// What is Selection Sort?: 
        /// O(n^2)
        /// - a nested loop where 
        /// - contains a variable that is the min value, every iteration goes through the array to find the smallest variable then swap if needed
        /// ---Pseudo Code---
        ///     for(i = 0; i < length - 1; i++)
        ///         int minIndex = i
        ///         for(j = i + 1; j < n; j++)
        ///             if(array[j]<array[minIndex])
        ///                 min_idx = j;
        ///         swap array[minIndex] and array[i]
        /// ---Pseudo Code---
        /// 
        /// </summary>
        /// <typeparam name="T">can be any type</typeparam>
        /// <param name="array">parameter to be sorted</param>
        public static void InsertionSort<T>(T[] array) where T : IComparable
        {
            for(int i = 0; i < array.Length - 1; i++) 
            {
                int minIndex = i;
                for(int j = i + 1; j < array.Length; j++) 
                {
                    if (array[j].CompareTo(array[minIndex]) < 0) 
                        minIndex = j;
                }

                //swapping
                T temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }
    }
}
