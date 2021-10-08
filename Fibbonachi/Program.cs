using System;



class CacheRecursiveFibonacciMemoization

{

    public static long[] my_memo;
    static long copies;
    static long [] memorizedCopies;

    static void Main()

    {

        Console.WriteLine("n = ");
        long n = int.Parse(Console.ReadLine());
         memorizedCopies = new long[n+1];
        
        copies = 0;
        Console.WriteLine(" Number of copies in the stack = " + Copies(n));
     //long result = Copies(n);
      // Console.WriteLine("fib({0}) = {1}", n, result);

    }



    static long Copies(long copiesInside, bool with_memo = true)

    {
        if (with_memo)
        {
            if (memorizedCopies[copiesInside] != 0) return memorizedCopies[copiesInside];
        }

        if (copiesInside == 1)
                return 1;
        if (copiesInside == 0)
            return 0;

        else
            memorizedCopies[copiesInside] = Copies(copiesInside - 1, with_memo) + Copies(copiesInside - 2, with_memo);

        return memorizedCopies[copiesInside];

    }

}