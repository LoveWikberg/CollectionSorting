using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämninguppgift1.Extensions
{
    static class SortExtensions
    {
        public static void BubbleSort(this int[] numbers, bool isAnimate)
        {
            int temp = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int sort = 0; sort < numbers.Length - 1; sort++)
                {
                    if (numbers[sort] > numbers[sort + 1])
                    {
                        temp = numbers[sort];
                        numbers[sort] = numbers[sort + 1];
                        numbers[sort + 1] = temp;
                        if (isAnimate)
                            BubbleAnimate(numbers, sort);
                    }
                }
            }
            if (!isAnimate)
                foreach (var number in numbers)
                {
                    Console.Write(number + ", ");
                }
        }
        static void BubbleAnimate(int[] numbers, int sort)
        {
            System.Threading.Thread.Sleep(400);
            Console.Clear();
            foreach (var number in numbers)
            {
                if (number == numbers[sort])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(number + ", ");
                    Console.ResetColor();
                }
                else
                    Console.Write(number + ", ");
            }
        }

        public static void MergeSort(this int[] array)
        {
            if (array.Length < 2)
            {
                // We consider the array already sorted, no change is done
                return;
            }
            // The size of the sub-arrays . Constantly changing .
            int step = 1;
            // startL - start index for left sub-array
            // startR - start index for the right sub-array
            int startL, startR;

            while (step < array.Length)
            {
                startL = 0;
                startR = step;
                while (startR + step <= array.Length)
                {
                    array.Merge(startL, startL + step, startR, startR + step);
                    startL = startR + step;
                    startR = startL + step;
                }
                if (startR < array.Length)
                {
                    array.Merge(startL, startL + step, startR, array.Length);
                }
                step *= 2;
            }
        }

        // Merge to already sorted blocks
        public static void Merge(this int[] array, int startL, int stopL,
            int startR, int stopR)
        {
            // Additional arrays needed for merging
            int[] right = new int[stopR - startR + 1];
            int[] left = new int[stopL - startL + 1];

            // Copy the elements to the additional arrays
            for (int i = 0, k = startR; i < (right.Length - 1); ++i, ++k)
            {
                right[i] = array[k];
            }
            for (int i = 0, k = startL; i < (left.Length - 1); ++i, ++k)
            {
                left[i] = array[k];
            }

            // Adding sentinel values
            right[right.Length - 1] = int.MaxValue;
            left[left.Length - 1] = int.MaxValue;

            // Merging the two sorted arrays into the initial one
            for (int k = startL, m = 0, n = 0; k < stopR; ++k)
            {
                if (left[m] <= right[n])
                {
                    array[k] = left[m];
                    m++;
                }
                else
                {
                    array[k] = right[n];
                    n++;
                }
            }
        }


        public static void QuickSort()
        {

        }
    }
}
