/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    class Program
    {
        ///<summary>
        /// A recursive method of showing all posible permutations of a k elemented string
        /// </summary>
        /// <param name="str">string to be permutated</param>
        /// <param name="k">index of last position in string </param>
        private static void PermutationsRecursive(String str, int k)
        {
            //base case, if there are none elements in the string, return the empty string
            if (k == 0)
                Console.WriteLine(str);
            else
            {
                //else, go around the indexes i and k of the chars,
                //foreach position of the chars, we swap them, then we call the function, 
                //which permutes the substring with  k - 1 chars, which calls it for k - 2
                //chars, until the base case is accessed . This is done, because the main 
                //string is being broken down intosmaller and smaller substrings, until a 
                //string of 2 elements is being held. It's elements are being swapped, 
                //then the new copy is being swapped with the next element and so one, until
                //all possible swaps of the elements of the string havr been done.
                for (int i = 0; i <= k; i++)
                {
                    str = Swap(str, i, k);
                    PermutationsRecursive(str, k - 1);
                    str = Swap(str, i, k);
                }


            }
        }

        private static void PermutationsIterative()
        {

        }

        /// <summary>
        ///  swaps the lements in a string
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i">position 1</param>
        /// <param name="k">position 2</param>
        /// <returns> a string</returns>       
        public static String Swap(String a, int i, int k)
        {
            char temp;  //used for temporary copy of a char
            char[] myString = a.ToCharArray(); //gets elements of a
            temp = myString[i]; // becomes a temporary copy of i
            myString[i] = myString[k];  //gets value    
            myString[k] = temp;
            string b = new string(myString);
            return b;
        }


        static void Main(string[] args)
        {
            String str = "ABCD";
            int n = str.Length;
            Console.Write("\n The Permutations with a combination of {0} digits are : \n", n);
            PermutationsRecursive(str, n - 1);
            Console.ReadKey();



        }
    }
}*/

using System;
using System.Linq;

namespace Permutations
{
    class Program
    {
        ///<summary>
        /// A recursive method of showing all posible permutations of a k elemented string
        /// </summary>
        /// <param name="str">string to be permutated</param>
        /// <param name="k">index of last position in string </param>
        private static void PermutationsRecursive(String str, int k)
        {
            int i;
            //base case, if there are none elements in the string, return the empty string
            if (k == 0)
                Console.WriteLine(str);

            else
            {
                //else, go around the indexes i and k of the chars,
                //foreach position of the chars, we swap them, then we call the function, 
                //which permutes the substring with  k - 1 chars, which calls it for k - 2
                //chars, until the base case is accessed . This is done, because the main 
                //string is being broken down intosmaller and smaller substrings, until a 
                //string of 2 elements is being held. It's elements are being swapped, 
                //then the new copy is being swapped with the next element and so one, until
                //all possible swaps of the elements of the string havr been done.
                for (i = 0; i <= k; i++)
                {
                    str = Swap(str, i, k);
                    PermutationsRecursive(str, k - 1);
                    str = Swap(str, i, k);
                }
            }
        }
        private static void PermutationsIterative(char[] arr)
        {
            //initializing variable for number of permutations
            var numberOfPerm = 1;
            //initializing number if permutations to be done left
            var workArr = Enumerable.Range(0, arr.Length + 1).ToArray();
            //integer of the num of elements in the collection/string  of permutations
            //while its less than the overall length, the permutes to be done get less, till =1                 
            // we're starting at the last base case and continuing until we reach our target

            var i = 1;
            while (i < arr.Length)
            {


                workArr[i]--;
                //value of the i element in a single permutation
                var j = 0;
                //if the value of the element is odd, then  the value of the el assigns
                //element i, and then  we swap them so we can move positions of the values
                if (i % 2 == 1)
                {
                    j = workArr[i];
                }
                //swap them
                SwapChars(ref arr[j], ref arr[i]);

                //assignimg i back to base case, so we can work with every el 
                i = 1;
                //we make sure there aren't elements with value 0, given
                //its not part of the integers to be permutated 
                while (workArr[i] == 0)
                {
                    workArr[i] = i;
                    i++;
                }

                numberOfPerm++;
                //calling the func to print all permutations of the initial print
                PrintPerm(arr);
            }
        }

        /// <summary>
        ///  swaps the lements in a string
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i">position 1</param>
        /// <param name="k">position 2</param>
        /// <returns> a string</returns>       
        public static String Swap(String a, int i, int k)
        {
            char temp;  //used for temporary copy of a char
            char[] myString = a.ToCharArray(); //gets elements of a
            temp = myString[i]; // becomes a temporary copy of i
            myString[i] = myString[k];  //gets value    
            myString[k] = temp;
            string b = new string(myString);
            return b;
        }
        //had to make a second method, so we can work with chars
        public static void SwapChars(ref char i, ref char j)
        {
            char temp;
            temp = j;
            j = i;
            i = j;
            i = temp;
        }

        /// <summary>
        /// gets the inputted string, breaks it down and combines the lements to a char[]array 
        /// </summary>
        /// <returns>char[]array</returns>
        public static char[] ReadInput()
        {
            String str = Console.ReadLine();
            String[] strArr = str.Split(' ');
            char[] arr = new char[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                arr[i] = Convert.ToChar(strArr[i]);
            }
            return arr;
        }

        /// <summary>
        /// gets the elements of the arr and coverts them to a string with ,
        /// </summary>
        /// <param name="elements">array with elements in it</param>
        private static void PrintPerm(char[] elements)
        {
            Console.WriteLine(string.Join(", ", elements));
        }



        static void Main(string[] args)
        {
            //recursion calling
            // String str = "ABCD";
            Console.WriteLine("Enter number of elements: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter elements without space: ");
            String str = Console.ReadLine();
            //to make sure elements are the right quantity
            if (str.Length > n)
                Console.WriteLine("You've typed more elements than limited");
            else
            {
                while (str.Length < n)
                {
                    str += Console.ReadLine();

                }
                //public string Substring(int startIndex, int length)
                String substr = str.Substring(0, n);
                Console.Write("\n The Permutations with a combination of {0} digits are : \n", n);
                //calling the func 
                PermutationsRecursive(str, n - 1);
            }
            
            //iterative                      
            
            Console.WriteLine("Enter number of elements: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter elements with space: ");
            //initializing an array, which elements are the elements to be permuted
            char[] elements = ReadInput();

            if (elements.Length != m)
            {

                Console.WriteLine("You've typed more or less elements than needed!");
            }
            
            else
            {                              
                Console.Write("\n The Permutations with a combination of {0} digits are : \n", m);
                //calling function to print it in the right format
                PrintPerm(elements);
                //calling fuction
                PermutationsIterative(elements);                             
            }
            //  Console.WriteLine($"Total permutations: {numberOfPerm}");
            Console.ReadLine();
        }                   
    }
}

    
        
            
        
    

    
    
