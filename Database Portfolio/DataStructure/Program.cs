/*
 * Author: Yan Lun Chan
 * Date: Auguest 2022
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting_Algorithms;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
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
            const int size = 5;
            const int MAX_INT = 500;
            int[] array = new int[size];
            Random RanGen = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = RanGen.Next(-1 * MAX_INT, MAX_INT);

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

                            break;
                        case 5:

                            break;
                        case 6:

                            break;
                    }
                    PrintArray(array, "After Sorting");
                }
                else
                    Console.WriteLine("Please enter correct input");
            } while (!validInput);
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
