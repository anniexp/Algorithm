using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetOfTheRulerFunction
{
    class Program
    {
        /// <summary>
        /// Recursive construction of the sequence,generated by the Ruler Function
        /// </summary>
        /// <param name="k">paramether of the function G</param>
        /// <returns>set of numbers of kind  G(k) = {G(k-1), k, G(k-1)}, for k > 1</returns>
        public static string SetOfTheRulerFunctionRecursive(int k)
        {

            if (k <= 0)
                return null;

            if (k == 1)
                return "1";

            //we convert int k to string because the method is supposed to return a string 
            return (SetOfTheRulerFunctionRecursive(k - 1) + " , " + Convert.ToString(k) + " , " + SetOfTheRulerFunctionRecursive(k - 1));


        }

        /// <summary>
        /// Iterative construction of the sequence,generated by the Ruler Function
        /// </summary>
        /// <param name="k">paramether of the function G</param>
        public static void SetOfTheRulerFunctionNonRecursive(int k)
        {
            //s - length of array,
            //j -  index of el in the set,
            // i - value of index of el;
            int s = Convert.ToInt32(Math.Pow(2, k) - 1);
            int[] set = new int[s];

            //purvonachalno obhojdame cikul s vujmojnite stoinosti na 
            // elementite na redicata, koyato shte poluchim. Vseki
            //element prisvoyava edna ot tezi stoinisti, taka che 
            //vurtim vtori cikul s tyah. Veche na vsyaka poziciya koyato e 
            //kratna na nyakoya ot vuzmojnite stoinosti prisvoyavame 
            // stoinostta, kakto sa po uslovie chlenovete na reda.
            int i;
            for (i = 1; i <= k; i++)
            {

                for (int j = 0; j <= set.Length - 1; j++)
                {


                    if ((j + 1) % (Math.Pow(2, (i - 1))) == 0)
                    {
                        set[j] = i;
                    }
                }

            }

            foreach (Object obj in set)
                Console.Write("{0}   ", obj);
            Console.WriteLine();

        }


        static void Main(string[] args)
        {

            // Console.WriteLine(GrayCodeRecursive(k-1) + " , " + k + " , " + GrayCodeRecursive(k - 1));*/
            Console.WriteLine(SetOfTheRulerFunctionRecursive(4));
            SetOfTheRulerFunctionNonRecursive(4);

        }
    }

}
