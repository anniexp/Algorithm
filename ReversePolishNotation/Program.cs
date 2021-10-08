using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotation
{
    class Program
    {
        static int Priority(string c)
        {
            /* if (c == "^")
             {
                 return 3;
             }*/
            if (c == "*" || c == "/")
            {
                return 2;
            }
            else if (c == "+" || c == "-")
            {
                return 1;
            }

            else
            {
                return 0;
            }
        }
        static ArrayList ToRPN(string equation)
        {

            string[] symbols = equation.Split();

            Stack<string> stack = new Stack<string>();
            ArrayList result = new ArrayList();
            int n = 0;
            foreach (string c in symbols)
            {
                //if the symbol is a number, it is added to the final result
                if (int.TryParse(c.ToString(), out n))
                {
                    result.Add(c);
                }
                //of the symbol is "(", its added to the stack 
                if (c == "(")
                {
                    stack.Push(c);
                }
                //if the symbol is ")", all of the operations until a "(" symbol, stored in the stack are being moved to the final result  
                if (c == ")")
                {
                    //while (stack.Count != 0 && stack.Peek() != "(")
                    while (stack.Peek() != "(")
                    {
                        result.Add(stack.Pop());
                    }
                    //the symbol "(" is being removed from the stack
                    stack.Pop();

                }

                if (c == "+" || c == "-" || c == "*" || c == "/")
                {
                    while (stack.Count != 0 && Priority(stack.Peek()) >= Priority(c))
                    {
                        result.Add(stack.Pop());
                    }
                    stack.Push(c);
                }
            }
            //if any operators remain in the stack, pop all & add to output list until stack is empty 
            while (stack.Count != 0)
            {
                result.Add(stack.Pop());
            }
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write(result[i] + " ");
            }

            return result;
        }
        //static double SolveRPN(ArrayList equation)
        static double SolveRPN(string equation)

        {
            string[] sdata = equation.Split();
            //string[] symbols = equation.Split(' ');
            Stack<double> stack = new Stack<double>();

            double n = 0;
            foreach (string c in sdata)
            {
                //if the symbol is a number, it is added to the final result
                if (double.TryParse(c, out n))
                {
                    stack.Push(n);
                }
                else
                {
                    //fabric dp 
                    switch (c)
                    {                       
                        case "+":
                            {
                               
                                stack.Push(stack.Pop() + stack.Pop());
                                break;
                            }
                        case "-":
                            {

                                n = stack.Pop();
                                stack.Push(stack.Pop() - n);
                                break;
                            }
                        case "*":
                            {
                                n = stack.Pop();
                                double m = stack.Pop();
                                stack.Push(m * n);
                                break;
                            }
                        case "/":
                            {
                                n = stack.Pop();
                                stack.Push(stack.Pop() / n);
                                break;
                            }
                        default:
                            Console.WriteLine("Error!");
                             break;
                            //continue;
                    }
                }

                /*if (c == "+" || c == "-" || c == "*" || c == "/")
               {
                   int y = int.Parse(stack.Pop());
                   int x = int.Parse(stack.Pop());

                   if (c == "+") x += y;
                   else if (c == "-") x -= y;
                   else if (c == "*") x *= y;
                   else if (c == "/") x /= y;
                   stack.Push(x.ToString());
               }*/

            }
            
            return stack.Pop();
        }

        private static void PrintArray(Stack<double> stack)
        {
            double[] myArray = stack.ToArray();
            /*for (int i = myArray.Length - 1; i >= 0; i--)
            {
                Console.Write("{0} ", myArray[i]);
            }*/
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write("{0} ", myArray[i]);
            }
            Console.WriteLine();

        }

        static void Main(string[] args)

        {
              string equation = "9 * 2 + ( 11 - ( 3 * 2 ) ) / 2";
            //string equation = "( 3 * 2 ) / 2 ";
            // string infix = "(9 / ( 5 - 6 / 2 ) - 1 ) * 2 + 8 / ( 7 - 3 )";
            //  string exercise = "3 + ( 2 - 3 ) * (-  5 ) - 22";
            ToRPN(equation);
            Console.WriteLine();
            //  ArrayList equation = ToRPN(infix);
            string rpn = "9 2 * 11 3 2 * - 2 / +";
            /*
            Console.WriteLine("Enter number of symbols: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter symbols with space between them: ");
            String rpn = Console.ReadLine();
            //to make sure elements are the right quantity
            if (rpn.Length > n)
                Console.WriteLine("You've typed more elements than limited");
            else
            {
                while (rpn.Length < n)
                {
                    rpn += Console.ReadLine();

                }*/
            //string rpn = ToRPN(equation).ToString();
            SolveRPN(rpn);


            // double result = SolveRPN(equation);
            double result = SolveRPN(rpn);

            Console.WriteLine("Result is : " + result);

            SolveRPN(rpn);




            Console.ReadLine();
        
    }
    }
    
}
