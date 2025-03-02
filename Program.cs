using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsAlgotims
{
    internal class Program
    {
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        public static int[] BubbleSort(int[] array)
        {
            int len = array.Length;

            for (int i = 1; i < len; i++) 
            {
                for (int j = 0; j < len - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
            return array;
        }


        // Быстрая сортировка
        static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }
            Swap(ref array[i + 1], ref array[right]);
            return i + 1;
        }


        static void Main(string[] args)
        {
            int[] arr = new int[] { 7, 21, 3, 6, 5, 2, 9, 12, 4, 8 };

            int[] sortedArr = BubbleSort((int[])arr.Clone());
            Console.WriteLine(string.Join(", ", NewArr));

            int[] sortedArr = (int[])arr.Clone();
            QuickSort(sortedArr, 0, sortedArr.Length - 1);
            Console.WriteLine("Отсортированный массив: " + string.Join(", ", sortedArr));
        }
    }
}
