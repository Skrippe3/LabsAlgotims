using System;

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

        // Сортировка вставками 
        public static int[] InsertionSort(int[] array)
        {
            int len = array.Length;

            for (int i = 1; i < len; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
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

            int[] bubbleSortedArr = BubbleSort((int[])arr.Clone());
            Console.WriteLine("Сортировка пузырьком: " + string.Join(", ", bubbleSortedArr));

            int[] insertionSortedArr = InsertionSort((int[])arr.Clone());
            Console.WriteLine("Сортировка вставками: " + string.Join(", ", insertionSortedArr));

            int[] quickSortedArr = (int[])arr.Clone();
            QuickSort(quickSortedArr, 0, quickSortedArr.Length - 1);
            Console.WriteLine("Быстрая сортировка: " + string.Join(", ", quickSortedArr));


            //Выполнение алгоритма машины Тьюринга
            int x = 10;
            int y = 5;
            Console.WriteLine(Class1.LABS2(x, y)); 
        }
    }
}
