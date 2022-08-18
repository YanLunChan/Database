using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    public class Heap_Sort
    {
        /// <summary>
        /// Goal: complete Heap Sort
        /// What is Selection Sort?: 
        /// O(nlog(n))
        /// - a nested loop where 
        /// - contains a variable that is the min value, every iteration goes through the array to find the smallest variable then swap if needed
        /// ---Pseudo Code---
        /// HeapSort(array)
        /// BuildMaxHeap(Array)
        /// heapSize = array.length
        /// for(i = array.length - 1, i >= 1 , i--)
        ///     swap array[0] with array[i]
        ///     heapsort--;
        ///     MaxHeapify(array, 0, heapsize)
        ///
        /// 
        /// BuildMaxHeap(array)
        /// for(i = arraylength / 2, i >= 0, i--)
        ///     MaxHeapify(arry, i , array.length)
        ///     
        /// MaxHeapify(array, i, size)
        /// left index cache
        /// right index cache
        /// largest index cache
        /// if(left < size && array[left] > array[i])
        ///     largest = left
        /// else
        ///     largest = i
        ///     
        /// if(right < size && array[right] > array[largest])
        ///     largest = right
        ///     
        /// if(largest != i)
        ///     swap array[largest] with array[i]
        ///     MaxHeapify(array, largest, size)
        ///     
        /// Left(i)
        /// return i*2 + 1
        /// 
        /// Right(i)
        /// return i*2 + 2
        /// ---Pseudo Code---
        /// 
        /// </summary>
        /// <typeparam name="T">can be any type</typeparam>
        /// <param name="array">parameter to be sorted</param>
        public static void HeapSort<T>(T[] Array) where T : IComparable
        {
            BuildMaxHeap(Array);
            int heapSize = Array.Length;
            for (int i = Array.Length - 1; i >= 1; i--)
            {
                T temp = Array[0];
                Array[0] = Array[i];
                Array[i] = temp;
                heapSize--;
                MaxHeapify(Array, 0, heapSize);
            }
        }
        private static void BuildMaxHeap<T>(T[] Array) where T : IComparable
        {
            for (int i = (Array.Length) / 2; i >= 0; i--)
            {
                MaxHeapify(Array, i, Array.Length);
            }
        }

        private static void MaxHeapify<T>(T[] Array, int i, int Size) where T : IComparable
        {
            int left = Left(i);
            int right = Right(i);
            int largest;
            if (left < Size && Array[left].CompareTo(Array[i]) > 0)
            {
                largest = left;
            }
            else
            {
                largest = i;
            }
            if (right < Size && Array[right].CompareTo(Array[largest]) > 0)
            {
                largest = right;
            }
            if (largest != i)
            {
                T temp = Array[largest];
                Array[largest] = Array[i];
                Array[i] = temp;
                MaxHeapify(Array, largest, Size);
            }
        }

        static int Left(int i)
        {
            return (i * 2) + 1;
        }

        static int Right(int i)
        {
            return (i * 2) + 2;
        }
    }
}
