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
    public static class Bubble_Sort
    {
        /// <summary>
        /// Goal: complete Bubble sort
        /// What is Bubble Sort?: 
        /// O(n^2)
        /// -Repeat Swapping adjacent elements if they are in the wrong order.
        /// ---Pseudo Code---
        /// (array is an array that contains 0 to n)
        /// for( i < length -1 ; i++)
        ///     for(j < length - i - length)
        ///         if(array[j+1] < array[j])
        ///             swap array[j+1] and array[j]
        /// ---Pseudo Code---
        /// 
        /// </summary>
        /// <typeparam name="T">can be any type</typeparam>
        /// <param name="array">parameter to be sorted</param>
        public static void BubbleSort<T>(T[] array) where T : IComparable
        {
            //cache time
            long time = DateTime.Now.Ticks;
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j+1].CompareTo(array[j]) < 0)
                    {
                        T temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                    }
                }
            time = DateTime.Now.Ticks - time;
            //convert tick to total seconds
            Console.WriteLine("----------SORTING----------");
            Console.WriteLine($"Time it took to sort: {TimeSpan.FromTicks(time).TotalSeconds} Seconds");
            Console.WriteLine("----------SORTING----------");
        }
    }
}
