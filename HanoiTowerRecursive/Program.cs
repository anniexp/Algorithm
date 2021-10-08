using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTowerRecursive
{/// <summary>
/// Съставете програма, съдържаща рекурсивна реализация на задачата за Ханойската кула
/// </summary>
    class Program
    {

        // C# recursive function to solve  
        // tower of hanoi puzzle 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">number of discs</param>
        /// <param name="from_rod">the current position of the disc</param>
        /// <param name="to_rod">the position the disc will be moved to</param>
        /// <param name="other_rod">the remaining rod</param>
        static void towerOfHanoi(int n, char from_rod,
                                 char to_rod, char other_rod)
        {
            if (n == 1)
            {
                Console.WriteLine("Move disk 1 from rod " + from_rod
                                               + " to rod " + to_rod);
                return;
            }
            towerOfHanoi(n - 1, from_rod, other_rod, to_rod);
            Console.WriteLine("Move disk " + n + " from rod "
                              + from_rod + " to rod " + to_rod);
            towerOfHanoi(n - 1, other_rod, to_rod, from_rod);
        }

        // Driver method 
        public static void Main()
        {
            // Number of disks 

            int n = 3;


            // A, B and C are names of rods 
            towerOfHanoi(n, 'A', 'C', 'B');

        }
    }
}

