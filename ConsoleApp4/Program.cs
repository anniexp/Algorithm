using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
   
    {
        public static void Main()
        {
            List<string> list = new List<string>() { "Josephus", "Mark", "Gladiator", "Coward", "Twice" };

            Console.WriteLine(GetJosephusPosition(list, 3));
        }

        public static string GetJosephusPosition(List<string> list, int m)
        {
            Queue<string> q = new Queue<string>(list);
            List<string> eliminated = new List<string>();
            string winner = string.Empty;

            while (q.Count != 0)
            {
                if (q.Count == m - 1)
                {
                    //winner = q.Peek();
                    foreach (string el in q)
                    {
                        Console.WriteLine(el);
                    }
                   
                }
                if (q.Count == 1)
                {
                    winner = q.Peek();
                    break;
                }

                for (int j = 1; j < m; j++)
                {
                    q.Enqueue(q.Dequeue());
                }
                eliminated.Add(q.Dequeue());
            }

            return winner;
        }
    }

}
