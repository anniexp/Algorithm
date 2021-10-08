using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephusProblem
{
    class Program
    {
        public static void Main()
        {
            int n = 15;
            int k = 5;
            Console.WriteLine("There are {0} jews in the circle with positions from 1 to {1}.", n,n);
            Console.WriteLine("Every jew has to kill the person {0} positions from him", k - 1);
            Console.WriteLine(GetLastPersonsPosition(n, k));

            Console.ReadKey();
        }

        public static int GetLastPersonsPosition(int n, int k)
        {
            //creating a loop tail
            Queue<int> q = new Queue<int>(n);
           // Console.WriteLine();
           //inserting values into it
            int i = 1;
            while (i <= n)
            {

                q.Enqueue(i);
               // Console.Write(i);
                i++;
            }
            
            int lastOne = 0;

            while (q.Count != 0)
            {
                //when the number of jews become k-1, their positions are being printed 
                if (q.Count == k - 1)
                {
                    Console.WriteLine("Last k-1 jews standing are at positions:");

                    foreach (int el in q)
                    {
                        Console.WriteLine(el);
                    }
                }
                //when only one is left, his position is being returned as the winner, and the loops ends
                if (q.Count == 1)
                {
                    lastOne = q.Peek();
                    break;
                }
                //every other scenario, first positon becomes last with a loop and after the loop ends, 
                //the first position is being removed
                for (int j = 1; j < k; j++)
                {
                    q.Enqueue(q.Dequeue());

                }
                q.Dequeue();
            }
            Console.WriteLine("The last one standing is the jew at position :");
            return lastOne;
        }
    }
}




