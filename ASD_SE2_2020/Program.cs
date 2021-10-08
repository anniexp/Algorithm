using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_SE2_2020
{
    class Program
    {
        //making a pole so ne go vikame na mnogo messta
        public static  int[] myArray;

        public static void EnterArray(int size)
        {
            myArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter an element: ");
                myArray[i] = int.Parse(Console.ReadLine());

            }
        }
        //осигуряваме вход
        public static void RandomArray(int size)
        {
            Console.WriteLine("Random array:");
            myArray = new int[size];
            Random rand = new Random();
            for (int i = 0;i<size;i++)
            {
                myArray[i] = rand.Next(3*size);
            }

        }
        //осигуряваме изход

        public static void PrintArray()
        {
            
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write("{0} ",myArray[i]);
            }
            Console.WriteLine();
        }

       

        public static void  StraightSort()
        {
            Console.WriteLine("Sorted array contains: ");
            int len = myArray.Length;
            // traverse 0 to array length 
            for (int i = 0;i<len - 1;i++)
            {
                // traverse i+1 to array length 
                int min = myArray[i], pos = i;
                for (int j = i+1;j<len;j++) {
                    if (myArray[j] < min)
                    {
                        min = myArray[j];
                        pos = j;
                    }
                    if (pos !=i)
                    {
                        int temp = myArray[pos];
                        myArray[pos] = myArray[i];
                        myArray[i] = temp;

                    }
                }
            }
           

        }
        public static void BubbleSort()
        {
            int len = myArray.Length;
            int temp = 0;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0;j<len - 1;j++)
                {
                    if (myArray[j]>myArray[j+1])

                    {
                          temp = myArray[j + 1];
                         myArray[j+1] = myArray[j];
                         myArray[j] = temp;
                        //Swap(j-1,j);
                    }
                }

            }

        }
        /* public static void Swap(int i,int j)

         {
           int  temp = 0;
             myArray[j + 1] = myArray[j];
             myArray[j] = temp;
         }*/

       public static void Swap(int i, int j)
        {
            int temp = 0;
            temp = myArray[j];
            myArray[j] = myArray[i];
            myArray[i] = myArray[j];
            myArray[i] = temp;
        }
        
        public static void InsertionSort()

        {
            int len = myArray.Length;
            for (int i = 1;i<len;i++)
            {
                int x = myArray[i], pos = i;
                while (pos > 0 && myArray[pos-1]>x)
                {
                    myArray[pos] = myArray[pos - 1];
                    pos--;
                }
                myArray[pos] = x;
            }
        }
        public static void CloneArray()
        {

            int[] dublicatedArr = (int[])myArray.Clone();
            int i = 0;
            Console.WriteLine("The clone array contains", dublicatedArr[i]);

        }
        public static bool BinarySearch( int[] myArray , int key)
        {
           
                int min = 0;
                int max = myArray.Length - 1;

                while (min <= max)
                {
                    int mid = (min + max) / 2;
                    if (key == myArray[mid])
                    {
                        return true;
                    }
                    else if (key < myArray[mid])
                    {
                     max = mid - 1;
                }
                    else
                    {
                        min = mid + 1;
                    }
                }
                return false;
            }
        
        public static bool BinSearch(int key)
        {
            int left = 0, rigth = myArray.Length - 1;
            while (left <=rigth)
            {
                int mid = (left + rigth) / 2;
                if (myArray[mid] == key)

                {
                    return true;
                }
                else 
                {
                    if (myArray[mid] < key)
                    {
                        rigth = mid - 1;
                    }
                    else{
                        left = mid + 1;
                    }
                }
            }
            return false;
        }
        public static bool Search(int key)

        {
            for (int i = 0; i < myArray.Length; i++)
            {

                if (myArray[i] == key)
                {
                    return true;
                }
            }
                
                return false;
            
        }
        //pyramidal sorting -consists of both Sift() and HeapSort() 
        public static void Sift(int v, int r)
        {
            int i = v, j = 2 * v + 1;
            int x = myArray[i];
            if (j < r && myArray[j] < myArray[j + 1])
                j++;
            while (j <= r && myArray[j] > x)
            {
                myArray[i] = myArray[j];
                i = j; j = 2 * i + 1;
                if (j < r && myArray[j] < myArray[j + 1])
                    j++;
            }
            myArray[i] = x;
        }

        public static void HeapSort()
        {
            int n = myArray.Length;
            for (int i = n / 2; i >= 0; i--)
                Sift(i, n - 1);
            int vol = n - 1;
            while (vol > 0)
            {
                Swap(0, vol);
                vol--;
                Sift(0, vol);
            }
        }


        static void Main(string[] args)
        {
            int key = 5;
            const int N = 500;
          
            RandomArray(N);
           //  PrintArray();
            //StraightSort();
           //  InsertionSort();
          //  BubbleSort();
            //BinSearch(key);
           // Console.WriteLine(BinSearch(5));
           
            // Array.Sort(myArray);


            //PrintArray();
             //  CloneArray();
              // PrintArray();
  
            
             Stopwatch stw = new Stopwatch();
              stw.Start();

           // InsertionSort();
           
           HeapSort();

            // StraightSort();
            //Array.Sort(myArray);
            //BubbleSort();
            // InsertionSort();
            // BinSearch(-1);

            stw.Stop();
            Console.WriteLine("Time: " +  stw.ElapsedMilliseconds);
             //PrintArray();

            Console.ReadKey();
            
        }

    }
}
