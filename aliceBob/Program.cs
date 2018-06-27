using System;
using System.IO;

namespace aliceBob
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
/* 
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true); */

            //int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

            //int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), bTemp => Convert.ToInt32(bTemp));

            int[] a = {4, 2, 8};
            int[] b = {2, 1, 10};

            int[] result = solve(a, b);

            Console.WriteLine(string.Join(" ", result));

            /* textWriter.Flush();
            textWriter.Close(); */
        }

        static int[] solve(int[] a, int[] b)
        {
            int alicePoint = 0;
            int bobPoint = 0;

            for(int i = 0; i < 3; i++)
            {
                if(a[i] > b[i])
                {
                    alicePoint += 1;
                }
                else if(a[i] < b[i])
                {
                    bobPoint += 1;
                }
                else{
                    alicePoint = alicePoint;
                    bobPoint = bobPoint;
                }
            }

            int[] result = {alicePoint, bobPoint};
            return result;
        }
    }
}
