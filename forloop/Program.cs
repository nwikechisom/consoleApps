using System;

namespace forloop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nHello! from all of us @devnuggets \n");
            Console.WriteLine("\nWe are just exploring some basic forloop usage... \n");
            Console.WriteLine("\nWriting 0 to 100");
            Console.WriteLine("---------------\n");
            for (int i = 0; i <= 100; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\n\nWriting Letters A to Z");
            Console.WriteLine("-----------------------\n");
            for (char c = 'A'; c <= 'Z'; c++)
            {
                Console.Write(c + " ");
            }
            //for (int i = 0; i < 26; i++)
            //{
            //    Console.Write(Convert.ToChar(i + (int)'a') + " ");
            //}

            Console.WriteLine("\n\nWriting an Alphabet with stars");      
            Console.WriteLine("---------------------------\n");
            int row, column;

            for (row = 0; row <= 6; row++)
            {
                for (column = 0; column <= 6; column++)
                {
                    if (((row == 0 || row == 6) && column >= 0 && column <= 6) || row + column == 6)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.Write("\n");
            }
            Console.WriteLine("\nTask Ended\n");
        }
    }
}
