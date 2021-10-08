using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factor_GCD_Power
{/// <summary>
/// Напишете програма, съдържаща рекурсивна реализация на пресмятане на факториел, повдигане на число на степен и алгоритъм на Евклид
/// </summary>
    class Program
    {


        /// <summary>
        /// Factorializing an integer number using recursion
        /// </summary>
        /// <param name="number">The integer number to be factored</param>
        /// <returns>Factorial of Integer Number</returns>
        /// 
        public static int factor_Recursion(int number)
        {
            if (number == 1)
                return 1;
            else
                return number * factor_Recursion(number - 1);
        }
        

        public double factorial_WhileLoop(int number)
        {
            double result = 1;
            while (number != 1)
            {
                result = result * number;
                number = number - 1;
            }
            return result;
        }
        /// <summary>  
        /// Greatest Common Divisor using recursion 
        /// </summary>  
        /// <param name="a">Integer A</param>  
        /// <param name="b">Integer B</param>  
        /// <returns>Greatest Common Divisor Between Integer A and Integer B</returns>  
        public static int GCD_Recursion(int a, int b)
        {
            if (0 == b)
                return a;
            else
                return GCD_Recursion(b, a % b);
        }

        /// <summary>
        /// Grading a number using recursion - number ^grade
        /// </summary>
        /// <param name="number">Integer number to be graded</param>
        /// <param name="grade">Integer value of the grading</param>
        /// <returns></returns>
        public static double gradingNumber_Recursion(double number, double grade)
        {
            /* if (0 > number)
             {
                 if (grade % 2 == 0)
                 {
                     number = number * (-1);
                 }
                 else
                 {
                     number = number;
                     return 
                 }
             }*/
            //when we grade a number with an negative grade, the result is always
            // a number between 0 and 1, but because this set is infinite, which is 
            //more digits than any data type can handle, given their powerset is < infinity,
            //with the increasing of the values of either number or grade, the result approaches 0,
            //so we can either round it to 0 or 1.- either  if (0 > grade) return 0 or if (0 >= grade)  return 1
            /*if(0 > grade)
                 return 0;
             if (0 = grade)           
                 return 1;*/
                 //or
            if (0 >= grade)
                return 1; 

            if (1 == grade)
                return number;
            else
                // return Math.Pow(number,grade);
                return number * gradingNumber_Recursion(number, grade - 1);
        }

        static void Main(string[] args)
        {
            /*
            //factoring without recursion, with integration
              int i, number, fact;
              Console.WriteLine("Enter the Number");
              number = int.Parse(Console.ReadLine());
              fact = number;
              for (i = number - 1; i >= 1; i--)
              {
                  fact = fact * i;
              }
              Console.WriteLine("\nFactorial of Given Number is: " + fact);

              Console.ReadLine();*/
           // Console.WriteLine(factor_Recursion(10));
            Console.WriteLine(GCD_Recursion(10,6));
           // Console.WriteLine(gradingNumber_Recursion(3.5,-3));
            Console.WriteLine("press any Key");
            Console.ReadLine();
        }
    }
}
