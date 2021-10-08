using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Set of Ruler Function Non Recursive with Stack 
/// </summary>
namespace SetOfRulerFunctionNonRecursive
{
    class Program
    {
        public static void Main()
        {
            int k = 6;
            RulerFunctionIterative(k);
            Console.ReadKey();


        }

        private static void RulerFunctionIterative(int k)
        {
            Stack<int> stack = new Stack<int>(k);
            ArrayList result = new ArrayList();
            //filling stack with numbers from 1 to k in descending order
            int s;
            for (s = k; s > 0; s--)
            {
                stack.Push(s);
            }
            //printing last element into result sequence and deleting it from the stack
            while (stack.Count != 0)
            {
                int m = stack.Pop();
                result.Add(m);
                //if element m is greater than 1, adding numbers from 1 to m-1 into the stack, using a while loop
                if (m > 1)
                {
                    int j = 0;
                    while (0 < m)
                    {
                        stack.Push(m - 1);
                        j++;
                        m--;
                        //removing the zeroz from Thomae's func to get the wanted sequence
                        int kp = stack.Peek();
                        if (kp == 0)
                        {
                            stack.Pop();
                        }
                    }                    
                }
            }
            foreach (object el in result)
            {
                Console.Write(el);
            }

        }
    }
}
