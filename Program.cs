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

        static void Main(string[] args)
        {
            int[] arr = new int[] { 7, 21, 3, 6, 5, 2, 9, 12, 4, 8 };

            int[] NewArr = BubbleSort(arr);
            Console.WriteLine(string.Join(", ", NewArr));
        }
    }
}
