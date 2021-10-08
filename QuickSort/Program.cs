using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        //https://www.youtube.com/watch?v=wygsfgtpApI&list=LLRzTSMMeZbXdVkiZrY4gF1A&index=3&t=124s
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr">array to be sorted</param>
        /// <param name="left">beginning of the array</param>
        /// <param name="right">end of the array</param>

        private static void QuickSort(int[]arr, int left, int right)
        {
            //i -index in red 
            int i = left;
            //j -index in blue  
            int j = right;
            //x -index of central element
            int x = arr[(left + right) / 2];
            while (i <=j)
            {
                while (arr[i] < x )
                {
                    i++;
                }
                while (arr[j] > x)
                {
                    j--;
                }
                if (i <= j)
                {
                    // Swap( i, j);
                  int temp = 0;
                    temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = arr[j];
                    arr[i] = temp;

                    i++;
                    j--;
                }
            }
            if (left < j)            
                QuickSort(arr, left, j);
            if (i < right)
                QuickSort(arr, i, right);           
        }

        static void Main(string[] args)
        {

            int[] arr = { 6, 2, 9, 3, 7, 1, 8, 5, 4 };
            Print(arr);
           
            QuickSort(arr, 0, arr.Length - 1);
            Print(arr);           
            Console.ReadKey();
        }       

        private static void Print(int[] arr)
        {
            foreach (Object number in arr)
                Console.Write("  " + number);
            Console.WriteLine();
        }
    }
}
