using System;

class Program
{
    public static int[] myArray = { 3,2,1 };

    public static int[] C = new int[myArray.Length];

    public static void PrintArray()
    {
        for (int i = 0; i < myArray.Length; i++)
        {
            Console.Write("{0} ", myArray[i]);
        }
        Console.WriteLine();
    }

    public static void Merge(int left, int mid, int right)
    {
        int i = left, j = mid + 1, k =0;
        while (i <= mid && j <= right)
            if (myArray[i] < myArray[j])
                C[k++] = myArray[i++];
            else
                C[k++] = myArray[j++];
        if (i > mid )
            while (j <= right)
                C[k++] = myArray[j++];
        else
            while (i <= mid)
                C[k++] = myArray[i++];
        for (i = 0; i < k; i++)
        {
          myArray[left + i] = C[i];
        }
    }
    /// <summary>
    /// merge sort from left to right
    /// </summary>
    public static void MergeSort(int left, int right)
    {
        if (left < right)
        {
            int med = (left + right) / 2;
            MergeSort(left, med);
            MergeSort(med + 1, right);
            Merge(left, med, right);
        }
    }

    /// <summary>
    /// merge sort from right to left
    /// </summary>
    public static void MergeSortRL(int right, int left)
    {
        if ( right > left )
        {
            int c = (right + left) / 2;
            MergeSortRL(right, c+1);
            MergeSortRL(c, left);          
            Merge(left ,c, right);
        }
    }
    

    static void Main(string[] args)
    {
        PrintArray();
        MergeSort(0,myArray.Length - 1);
        MergeSortRL( myArray.Length -1,0);
        PrintArray();
    }
}
