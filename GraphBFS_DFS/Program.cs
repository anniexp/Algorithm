using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBFS_DFS
{
    class Program
    {
        public const int numV = 9;
        static int[,] adjMatrix = { { 0,1,1,0,0,1,0,0,0 },
                                    { 1,0,0,1,1,0,0,0,0 },
                                    { 1,0,0,0,0,1,1,0,1 },
                                    { 0,1,0,0,0,0,0,1,0 },
                                    { 0,1,0,0,0,1,0,1,1 },
                                    { 1,0,1,0,1,0,1,0,0 },
                                    { 0,0,1,0,0,1,0,1,1 },
                                    { 0,0,0,1,1,0,1,0,0 },
                                    { 0,0,1,0,1,0,1,0,0  } };
        static int[] used = new int[numV];
        public static void DFS(int v)
        {
            used[v - 1] = 1;
            Console.Write("{0} ", v);
            for (int i = 0; i < numV; i++)
            {
                if (adjMatrix[v - 1, i] > 0 && used[i] == 0)
                    DFS(i + 1);
            }
        }
        public static void BFS(int v)
        {
            used[v - 1] = 1;
            Queue<int> q = new Queue<int>();
            q.Enqueue(v);
            while (q.Count > 0)
            {
                int key = q.Dequeue();
                Console.Write("{0} ", key);
                for (int i = 0; i < numV; i++)
                {
                    if (adjMatrix[key - 1, i] > 0 && used[i] == 0)
                    {
                        used[i] = 1;
                        q.Enqueue(i + 1);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            BFS(1);
            Console.WriteLine();
            for (int i = 0; i < numV; i++)
                used[i] = 0;
            DFS(1);
        }
    }
}
