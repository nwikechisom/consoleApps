using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the solve function below.
    static int[] solve(int[] a, int[] b) {
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

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
        ;

        int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), bTemp => Convert.ToInt32(bTemp))
        ;
        int[] result = solve(a, b);

        textWriter.WriteLine(string.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
