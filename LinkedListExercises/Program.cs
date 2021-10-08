using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListExercises
{
    class Program
    {
        public static LinkedList<int> myList = new LinkedList<int>();
        public static LinkedList<int> B = new LinkedList<int>();


        /// <summary>
        /// 1.	Да се създаде свързан списък от цели числа и да се 
        /// изведе на екрана. Да се намери и изведе средното 
        /// аритметично на елементите на списъка (обозначаваме
        /// това число с х). Да се изтрият всички елементи на 
        /// списъка със стойност, по-малка от х и списъка да 
        /// се изведе отново. 
        /// </summary>
        public static void Task1()
        {
            // LinkedList<int> myList = new LinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter an element: ");
                int val = int.Parse(Console.ReadLine());
                myList.AddLast(val);
            }
            double x = myList.Average();
            var node = myList.First;
            while (node != null)
            {
                var nextNode = node.Next;
                if (node.Value < x)
                {
                    myList.Remove(node);
                }
                node = nextNode;
            }

            foreach (int num in myList)
            {
                Console.Write("{0} ", num);
            }
        }
        /// <summary>
        /// 2.	Да се създаде свързан списък от 10 цели числа. Да се
        /// сортира списъка чрез метода на мехурчето и да се изведе 
        /// на екрана. Да се въведе цифра от клавиатурата и да се 
        /// изведат на екрана всички елементи на списъка, съдържащи
        /// тази цифра.
        /// </summary>
        /// 
        public static bool ContainsDigit(int val, int d)
        {
            while (val != 0)
            {
                if (val % myList.Count == d)

                    return true;
                val /= 10;
            }
            return false;
        }

        /*   public static void Swap<T>(IList<T> list, int indexA, int indexB)
       {
           T tmp = list[indexA];
           list[indexA] = list[indexB];
           list[indexB] = tmp;
       }*/
        /*public static void BubbleSort()
        {
            int len = myList.Count;
         List<int> myArray =   myList.ToList;
            int temp = 0;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len - 1; j++)
                {
                    if (myList[j] > myList[j + 1])

                    {
                        temp = myList[j + 1];
                        myList[j + 1] = myList[j];
                        myList[j] = temp;
                        //Swap(j-1,j);
                    }
                }

            }

        }*/

        public static void Task2()
        {
            //LinkedList<int> myList = new LinkedList<int>();
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Enter an element: ");
                int val = int.Parse(Console.ReadLine());
                myList.AddLast(val);
            }
            int x = int.Parse(Console.ReadLine());
            var node = myList.First;
            while (node != null)
            {
                var nextNode = node.Next;
                if (ContainsDigit(node.Value, x))
                {

                }
                else
                {
                    myList.Remove(node);
                }
                node = nextNode;
            }

            foreach (int num in myList)
            {
                Console.Write("{0} ", num);
            }
        }

        /// <summary>
        /// 1.	Да се създаде свързан списък от цели положителни числа, чрез добавяне в края. 
        /// Готовият списък да се изведе на екрана. Да се въведе от клавиатурата цяло положително 
        /// число х, да се изтрият от списъка всички елементи, по-големи от x и след последния 
        /// елемент в списъка със стойност х да се добави елемент със стойност 10. Промененият 
        /// списък да се изведе на екрана.
        /// </summary>
        /// 
        public static void Task3()
        {
            Console.WriteLine("Enter number of elements: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter an element: ");
            int val = int.Parse(Console.ReadLine());
            myList.AddLast(val);

            while (myList.Count < n)
            {
                Console.Write("Enter an element: ");
                val = int.Parse(Console.ReadLine());
                myList.AddLast(val);
            }

            Display(myList);
            InputX(myList);


        }
        private static void InputX(LinkedList<int> myList)
        {
            Console.Write("Enter x: ");
            int x = int.Parse(Console.ReadLine());
            if (x > 0)
            {
                var node = myList.First;
                while (node != null)
                {
                    var nextNode = node.Next;
                    if (node.Value > x)
                    {
                        myList.Remove(node);
                    }
                    node = nextNode;
                }
                Put10(myList, x);
                Display(myList);
            }
            else
            {
                Console.Write("Enter an element > 0: ");
            }

        }
        public static void Put10(LinkedList<int> myList, int x)
        {
            var node = myList.First;

            while (node != null)
            {
                if (node.Value == x)
                {
                    node = myList.FindLast(x);
                    myList.AddAfter(node, 10);

                }
                node = node.Next;
            }
        }
        private static void Display(LinkedList<int> myList)
        {
            foreach (int word in myList)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// 4.	Да се създаде свързан списък от 30 случайни естествени числа и да се изведе на екрана.
        /// Да се въведат от клавиатурата 2 естествени числа х и y (х < у).
        /// Да се изтрият от списъка елементите със стойности между х и y (ако има такива).
        /// Да се запишат в масив елементите, които се делят на х или на y. Промененият списък
        /// и елементите на масива и да се изведат на екрана.
        /// </summary>
        public static void Task4()
        {

            const int N = 5;
            RandomList(N);
            Display(myList);
            Console.Write("Enter x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Enter y: ");
            int y = int.Parse(Console.ReadLine());
            if (x < y)
            {
                var node = myList.First;
                while (node != null)
                {
                    var nextNode = node.Next;
                    if ((node.Value > x) && (node.Value < y))
                    {
                        myList.Remove(node);
                    }
                    node = nextNode;
                }
                Display(myList);

                DividendsOfXAndY(myList, x, y);

                //Display(myList);

                int[] arr = new int[myList.Count];
                myList.CopyTo(arr, 0);

                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write("{0} ", arr[i]);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("x must be < y!");
            }




        }
        public static void RandomList(int size)
        {
            Console.WriteLine("Random List:");
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                int val = rand.Next(0, 100);
                myList.AddLast(val);
            }

        }
        public static void DividendsOfXAndY(LinkedList<int> myList, int x, int y)
        {
            var node = myList.First;

            while (node != null)
            {
                var nextNode = node.Next;
                if (!((node.
Value % x == 0) || (node.Value % y == 0)))
                {
                    myList.Remove(node);
                }
                node = nextNode;
            }
            // Display(myList);


        }

        /// <summary>
        /// 3.	Да се създадат два свързани списъка А и В от цели положителни числа,
        /// до въвеждане на 0. Да се обединят двата списъка в трети списък С, като 
        /// общите за двата списъка елементи се записват в С еднократно. Да се 
        /// сортира списъкът С и да се изведе на екрана.
        /// </summary>
        public static void Task5()
        {
            InputList(myList);
            Console.WriteLine(" A: ");
            Display(myList);
            InputList(B);
            Console.WriteLine(" B: ");
            Display(B);
            LinkedList<int> C = new LinkedList<int>();

            int[] cc = myList.Union(B).ToArray();
            // int[] dd = myList.Intersect(B).ToArray();
            // int[] ee = cc.Except(dd).ToArray();
            Console.WriteLine(" C: ");

            for (int i = 0; i < cc.Length; i++)
            {
                Console.Write("{0} ", cc[i]);
            }
            Console.WriteLine();
            Array.Sort(cc);
            foreach (int item in cc)
            {
                C.AddLast(item);
            }

            Console.WriteLine(" C sorted: ");
            Display(C);


        }
        public static void InputList(LinkedList<int> myList)
        {
            int n = 1;
            while (n != 0)
            {
                Console.WriteLine("Enter number in list! Enter 0 to stop!");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 0)
                {
                    break;
                }
                else
                {
                    if (input > 0)
                    {
                        myList.AddLast(input);
                        n++;
                    }
                    else
                        Console.WriteLine("Element must be > 0! ");
                }

            }
        }

        static void Main(string[] args)
        {

            //Task1();
            // Task2();
            //Task3();
            //Task4();
            //Task5();
            Console.ReadKey();

        }

    }
}
