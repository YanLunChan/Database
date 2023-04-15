/*
 * Author: Yan Lun Chan
 * Date: Auguest 2022
 */
using System;

namespace Sorting_Algorithms
{
    class Sort_Main
    {
        public static void RunSorting()
        {
            ////create list to test
            //Linked_List.LinkedList<int> nums = new Linked_List.LinkedList<int>(100);
            //nums.Append(200);
            //nums.Append(300);
            //nums.Append(400);
            //nums.Append(500);
            //nums.Append(600);
            //nums.Remove(0);

            //for (int i = 0; i < nums.GetSize(); i++)
            //    Console.WriteLine(nums.Get(i));
            ////Create List of sorting algorithms here

            //Player Input
            string input = "";
            bool validInput = false;
            //Generate Array
            const int size = 10;
            const int MAX_INT = 500;
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
                array[i] = RandomGeneration.GetInstance.Next(-1 * MAX_INT, MAX_INT);

            Console.WriteLine("Select the Following:\n" +
                              "1. Bubble Sort\n" +
                              "2. Insertion Sort\n" +
                              "3. Selection Sort\n" +
                              "4. Merge Sort\n" +
                              "5. Quick Sort\n" +
                              "6. Heap Sort");
            do
            {
                input = Console.ReadLine();
                validInput= Int32.TryParse(input, out int selection);

                if (validInput && selection > 0 && selection < 7)
                {
                    PrintArray(array, "Before Sorting");
                    //cache time
                    long time = DateTime.Now.Ticks;
                    switch (selection)
                    {
                        case 1:
                            //Bubble Sort Goes here
                            Bubble_Sort.BubbleSort(array);
                            break;
                        case 2:
                            //Insertion Sort Goes here
                            Insertion_Sort.InsertionSort(array);
                            break;
                        case 3:
                            Selection_Sort.InsertionSort(array);
                            break;
                        case 4:
                            Merge_Sort.MergeSort(array, 0, array.Length - 1);
                            break;
                        case 5:
                            Quick_Sort.QuickSortRandomized(array, 0, array.Length - 1);
                            break;
                        case 6:
                            Heap_Sort.HeapSort(array);
                            break;
                    }
                    PrintArray(array, "After Sorting");
                    time = DateTime.Now.Ticks - time;
                    //convert tick to total seconds
                    Console.WriteLine("----------SORTING----------");
                    Console.WriteLine($"Time it took to sort: {TimeSpan.FromTicks(time).TotalSeconds} Seconds");
                    Console.WriteLine("----------SORTING----------");
                }
                else
                    Console.WriteLine("Please enter correct input");
            } while (!validInput);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
        public static void PrintArray<T>(T[] array, string title) 
        {
            Console.WriteLine($"----{title}----");
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                    Console.Write(" , ");
            }
            Console.WriteLine("]");
        }
    }

}
