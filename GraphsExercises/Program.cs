using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GraphsExercises
{
    public class Graph

    {
        //РАБОТЕЩ
        
        static int[,] adjMatrix = { { 0,1,1,0,0,1,},
                                     { 1,0,0,1,1,0},
                                     { 1,0,0,0,0,1 },
                                     { 0,1,0,0,0,0 },
                                     { 0,1,0,0,0,1 },
                                     { 1,0,1,0,1,0 }
                                     };
        // static int[,] adjMatrix = new int[,] { };
        //   static int[,] arr = new int[,] { };
        public static int n = 4;
        //public static int[,] arr = Graph.RandomMatrix(n);

        public static int[,] edgeList;
        //generating random Adjacency Matrix NxN 
        public static int[,] RandomMatrix(int n)
        {
            Console.WriteLine("Random Matrix:");
            Random rand = new Random();

            int[,] arr = new int[n, n];
            int[,] arr2 = new int[n, n];
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {

                    arr[i, j] = rand.Next(2);
                    arr2[j, i] = arr[i, j];

                }
            }
            PrintAdjMatrix(arr);

            return arr;
        }
        //printing Adjacency Matrix NxN 
        public static int[,] PrintAdjMatrix(int[,] adjMatrix)

        {
            // n = 6;
            int n = (int)Math.Sqrt(adjMatrix.Length);
            Console.Write("\nThe matrix is : \n");
            for (int i = 0; i < n; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < n; j++)
                    Console.Write("{0}\t", adjMatrix[i, j]);
            }
            Console.Write("\n\n");
            //Console.WriteLine();
            return adjMatrix;
        }
        //reading and printing Adjacency Matrix NxN from external file
        public static int[,] ReadAdjMatrixFromFile()
        {


            String input = File.ReadAllText(@"D:\AdjadencyMatrix.txt");

            n = 0;
            foreach (var row in input.Split('\n'))
            {
                n++;
            }
            int i = 0, j = 0;
            int[,] myMatrix = new int[n, n];
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    myMatrix[i, j] = int.Parse(col.Trim());
                    j++;
                }
                i++;
            }
            PrintAdjMatrix(myMatrix);
            return myMatrix;
        }


        /// <summary>
        /// Reading and printing List of Edges of the matrix from external file 
        /// </summary>
        public static void ReadEdgeList()
        {
            // String input = File.ReadAllText(@"D:\MURSHATA\Mursha.txt");
            String input = File.ReadAllText(@"D:\ListOfEdges.txt");

            int i = 0, j = 0;
            int v = 0, e = 0;
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    if (i == 0 && j == 0)
                    {
                        v = int.Parse(col.Trim());
                        j++;
                    }
                    else if ((i == 0 && j == 1))
                    {
                        e = int.Parse(col.Trim());
                        j++;
                        edgeList = new int[e, 2];

                    }
                    else
                    {
                        edgeList[i - 1, j] = int.Parse(col.Trim());
                        j++;
                    }
                }
                i++;
            }
            PrintEdgesList(edgeList);
            ConvertELtoAdjM(edgeList, v, e);
        }

        /// <summary>
        /// Printing Matrix , representing List of Edges of a Graph
        /// </summary>
        /// <param name="edgeList"></param>
        public static void PrintEdgesList(int[,] edgeList)
        {
            Console.WriteLine("Edge list from file:");
            int n = edgeList.Length / 2;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(" {0} ", edgeList[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Saving Adjacency Matrix NxN in external file
        /// </summary>
        /// <param name="arr">matrix to be saved</param>
        /// <returns>saved matrix</returns>
        public static int[,] SaveAdjMatrixInFile(int[,] arr)

        {
            string path = @"D:\AdjadencyMatrix.txt";
            if (File.Exists(path))
            {
                Console.WriteLine("File Exists");
            }
            else
            {// Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    //  string yes = GenerateMatrix().ToString();
                    //string[] s = PrintMatrix(arr).ToArr();
                    // string s = arr.ToString();
                    int[,] yes = Graph.PrintAdjMatrix(arr);


                    Console.Write("\nAdjacency Matrix in file : \n");
                    for (int i = 0; i < n; i++)
                    {

                        for (int j = 0; j < n; j++)
                            sw.Write(arr[i, j] + " ");
                        if (i != n - 1)

                            sw.Write("\n");

                    }
                    Console.Write("\n\n");
                    arr = yes;
                    /* foreach (object s in yes)
                     {
                         sw.WriteLine(s);
                     }*/
                    // GenerateMatrix();
                    //  RandomMatrix(n);*/
                }
            }
            return arr;
        }
        /// <summary>
        /// Saving Incidence Matrix N x NumOfOnesIn in external file
        /// </summary>
        /// <param name="IncM">Incidence matrix</param>
        /// <param name="arr">The Adjacery Matrix, which has been converted</param>
        /// <returns>saved incidence matrix</returns>
        public static int[,] SaveIncidenceMatrixInFile(int[,] IncM, int[,] arr)
        {
            string path = @"D:\IncedenceMatrix.txt";
            if (File.Exists(path))
            {
                Console.WriteLine("File Exists");
            }
            else
            {// Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {

                    int numOfEdges = Graph.Count1sInAM(arr);
                    Console.WriteLine(numOfEdges);

                    Console.Write("\nIncidence Matrix in file : \n");
                    for (int i = 0; i < n; i++)
                    {

                        for (int j = 0; j < numOfEdges; j++)
                            sw.Write(IncM[j, i] + " ");
                        if (i != n - 1)
                            sw.Write("\n");
                    }
                    Console.Write("\n");

                }
            }
            return IncM;
        }
        /// <summary>
        /// Saving List of Edges of the graph in external file
        /// </summary>
        /// <param name="arr">The Adjacery Matrix,which has been converted</param>
        /// <returns></returns>
        public static int[,] SaveListOfEdgesInFile(int[,] arr)
        {

            string path = @"D:\ListOfEdges.txt";
            int[,] strArr = new int[,] { };
            if (File.Exists(path))
            {
                Console.WriteLine("File Exists");
            }
            else
            {// Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {

                    Console.Write("\nList of Edges in file : \n");
                    adjMatrix = new int[n, n];
                    int numOfEdges = Count1sInAM(arr);
                    sw.Write(n + " " + numOfEdges);
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            int arrr = adjMatrix[i, j];
                            // int arr = adjMatrix[i, j];
                            if (arr[i, j] == 1)
                                sw.Write("\n{0} {1} ", i + 1, j + 1);
                        }
                    }
                }
            }

            return strArr;
        }

        /// <summary>
        /// Convert Adjacency Matrix to Incidence matrix 
        /// </summary>
        /// <param name="n">number of N</param>
        /// <returns></returns>
        /// 
        public static int[,] AdjMatToIncidenceMatr(int[,] arr)
        {
            int m = 0;
            //number of edges = number of 1ns in the adj m                      
            int numOfEdges = Count1sInAM(arr);
            // Console.WriteLine(numOfEdges);
            int[,] incMatr = new int[numOfEdges, n];


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        incMatr[m, i] = 1;
                        incMatr[m, j] = -1;
                        if (i == j)
                            incMatr[m, i] = 2;
                        m++;
                    }
                }
            }

            //transponing
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < numOfEdges; j++)
                {
                    Console.Write(incMatr[j, i] + "\t");
                }
                Console.WriteLine();
            }
            return incMatr;
        }
        /// <summary>
        /// Counting number of 1-s in a matrix NxN
        /// </summary>
        /// <param name="adjMatrix">adjacency matrix</param>
        /// <returns>number of 1s</returns>
        public static int Count1sInAM(int[,] adjMatrix)
        {

            int[] numOf1s = new int[] { };
            int edges = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (adjMatrix[i, j] == 1)
                    {

                        edges++;

                    }
                }
            }
            return edges;
        }

        /// <summary>
        /// Converting List of Edges of graph to its Adjacency Matrix
        /// </summary>
        /// <param name="edgeList">list of edges/links/nodes</param>
        /// <param name="v"> number of vertices</param>
        /// <param name="e">number of edges</param>
        public static void ConvertELtoAdjM(int[,] edgeList, int v, int e)
        {
            Console.WriteLine("Converting edge list to adjacency matrix...");
            int[,] adj2Matrix = new int[v, v];
            for (int i = 0; i < e; i++)
            {
                adj2Matrix[edgeList[i, 0] - 1, edgeList[i, 1] - 1] = 1;

            }
            PrintAdjMatrix(adj2Matrix);
        }
        /// <summary>
        /// Reading and printing Incidence Matrix  from the console
        /// </summary>
        /// <returns></returns>
        public static int[,] ReadIncMatrix()
        {


            String input = File.ReadAllText(@"D:\IncedenceMatrix.txt");
            int countRow = 0;
            int countCol = 0;
            int i = 0, j = 0;
            int numOfEdges = Graph.Count1sInAM(adjMatrix);
            // Console.WriteLine(n);

            foreach (var row in input.Split('\n'))
            {
                countCol = 0;

                foreach (var col in row.Trim().Split(' '))
                {

                    countCol++;
                }
                countRow++;
            }
            Console.WriteLine(countRow);
            Console.WriteLine(countCol);
            int[,] myMatrix = new int[countRow, countCol];
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    myMatrix[i, j] = int.Parse(col.Trim());
                    j++;
                }
                i++;
            }


            PrintIncMatrix(myMatrix, countRow, countCol);
            TransponedMat(myMatrix, countRow, countCol);

            return myMatrix;
            // int[,] myMatrix ;
            // Graph.PrintMatrix(myMatrix);
        }

        /// <summary>
        /// Printing Incidence Matrix
        /// </summary>
        /// <param name="incMatrix"></param>
        /// <param name="countRow">number of rows</param>      
        public static void PrintIncMatrix(int[,] incMatrix, int countRow, int countCol)
        {
            for (int i = 0; i < countRow; i++)
            {
                for (int j = 0; j < countCol; j++)
                {
                    Console.Write(" {0} ", incMatrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Convert Adjacency Matrix to List of Edges
        /// </summary>
        /// <param name="adjMatrix"></param>

        public static void ConvAdjMToRe(int[,] arr)
        {


            int numOfEdges = Count1sInAM(arr);
            Console.WriteLine(" List of edges of random adjacency matrix : ");
            Console.WriteLine(n + " " + numOfEdges);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    if (arr[i, j] == 1)
                        Console.WriteLine("{0} {1} ", i + 1, j + 1);
                }
            }
            //PrintEdgesList(edgeList);


        }

        /// <summary>
        /// Transposing a matrix countRow x countCol
        /// </summary>
        /// <param name="arr">matrix to be transposed</param>
        /// <param name="countRow">vertes</param>
        /// <param name="countCol">edges</param>
        /// <returns>the matrix in transposed kind</returns>
        public static int[,] TransponedMat(int[,] arr, int countRow, int countCol)
        {
            int[,] transponedArr = new int[countCol, countRow];
            // int[,] myArray = new int[countRow, countRow];
            //транспониране и принтиране на матрицата на инцидентност
            for (int i = 0; i < countCol; i++)
            {
                for (int j = 0; j < countRow; j++)
                {
                    transponedArr[i, j] = arr[j, i];
                }

            }

            Graph.PrintIncMatrix(transponedArr, countCol, countRow);
            ConvertIncMatToAdjM(transponedArr, countCol, countRow);
            return transponedArr;

        }
        /// <summary>
        /// Converting Incidence matrix to Adj M.
        /// </summary>
        /// <param name="transponedArr"></param>
        /// <param name="countCol"></param>
        /// <param name="countRow"></param>
        public static void ConvertIncMatToAdjM(int[,] transponedArr, int countCol, int countRow)
        {
            int a = 0, b = 0, primka = 0;
            for (int i = 0; i < countCol; i++)
            {
                for (int j = 0; j < countRow; j++)
                {
                    if (transponedArr[i, j] == 1)
                    {
                        a = j;
                    }
                    if (transponedArr[i, j] == -1)
                    {
                        b = j;
                    }
                    //if its a primka
                    if (transponedArr[i, j] == 2)
                    {
                        primka = j;
                        adjMatrix[primka, primka] = 1;
                    }
                }
                adjMatrix[a, b] = 1;
            }
            PrintAdjMatrix(adjMatrix);
        }

    }

    class Program
    {
        /*  static int[,] adjMatrix = { { 0,1,1,0,0,1,},
                                      { 1,0,0,1,1,0},
                                      { 1,0,0,0,0,1 },
                                      { 0,1,0,0,0,0 },
                                      { 0,1,0,0,0,1 },
                                      { 1,0,1,0,1,0 }
                                      };*/
        public static int n = 4;
        public static int[,] arr = Graph.RandomMatrix(n);
        public static int[,] myMatrix = new int[,] { };




        static void Main(string[] args)
        {

            // Console.WriteLine(" List of edges of random adjacency matrix : ");

            Graph.ConvAdjMToRe(arr);
            Console.WriteLine(" Incidence Matrix of the random matrix /Матрица на инцидентност : ");

            int[,] IncM = Graph.AdjMatToIncidenceMatr(arr);

            Graph.SaveIncidenceMatrixInFile(IncM, arr);

            Graph.SaveAdjMatrixInFile(arr);
            Graph.ReadAdjMatrixFromFile();
            Graph.SaveListOfEdgesInFile(arr);

            //int l = Graph.Count1sInAM(arr);

            Graph.ReadEdgeList();
            //Graph.ReadAdjMatrixFromFile();
            //  Graph.AdjMatToIncidenceMatr(myMatrix);
            Console.WriteLine("List of Edges in file: ");
            Graph.ReadEdgeList();
            Console.WriteLine("Incidence matrix in file: ");
            Graph.ReadIncMatrix();
        }

    }
}
