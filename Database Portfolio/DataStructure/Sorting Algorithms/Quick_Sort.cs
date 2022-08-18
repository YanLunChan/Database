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
    //random generation singleton
    public class RandomGeneration : Random
    {
        private static RandomGeneration instance = new RandomGeneration();
        private RandomGeneration():base(){}
        public static RandomGeneration GetInstance 
        {
            get { return instance; }
        }
    }

    /// <summary>
    /// Goal: complete Quick Sort
    /// What is Quick Sort?: 
    /// O(nlog(n))
    /// It picks an element as a pivot and partitions the given array around the picked pivot. There are many different versions of quickSort that pick pivot in different ways. 
    /// ---Pseudo Code---
    /// QuickSortRandom(array, left right)
    /// if(left< right)
    ///     q = PartitionRandom(array, left, right)
    ///     QuickSort(array, left, pivot -1)
    ///     QuickSort(array, pivot + 1, right)
    ///     
    /// PartitionRandom(array, left, right)
    /// i = random number between [left, right]
    /// swap array[right] with array[i]
    /// return Partition(array, left, right);

    /// Partition(array, left, right)
    /// x = array[right]
    /// i = left - 1
    /// for(j = left, j <= right - 1)
    ///     if(array[j] <= array[right])
    ///         swap array[j] and array[right]
    ///
    /// swap array[i + 1] with array[right]
    /// return i + 1
    /// 
    /// ---Pseudo Code---

    /// </summary>
    /// <typeparam name="T">can be any type</typeparam>
    /// <param name="array">parameter to be sorted</param>

    public class Quick_Sort
    {
        public static void QuickSortRandomized<T>(T[] Array, int Left, int Right) where T : IComparable
        {
            if (Left < Right)
            {
                int q = PartitionRadomized(Array, Left, Right);
                QuickSortRandomized(Array, Left, q - 1);
                QuickSortRandomized(Array, q + 1, Right);
            }
        }

        static int PartitionRadomized<T>(T[] Array, int Left, int Right) where T : IComparable
        {
            int i = RandomGeneration.GetInstance.Next(Left, Right);
            T temp = Array[Right];
            Array[Right] = Array[i];
            Array[i] = temp;
            return Partition(Array, Left, Right);
        }

        static int Partition<T>(T[] Array, int Left, int Right) where T : IComparable
        {
            T x = Array[Right];
            int i = Left - 1;
            for (int j = Left; j <= Right - 1; j++)
            {
                if (Array[j].CompareTo(x) <= 0)
                {
                    i++;
                    T temp2 = Array[j];
                    Array[j] = Array[i];
                    Array[i] = temp2;
                }
            }
            T temp = Array[i + 1];
            Array[i + 1] = Array[Right];
            Array[Right] = temp;
            return i + 1;
        }
    }
}
