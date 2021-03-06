﻿using System;

namespace createFolder
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello! this is from devnuggets!!");
            // creating a name for the top-level folder.
            string folderName = @"~/home/Documents/topFolder";

            // pathstring specifies the path to a subfolder            
            string pathString = System.IO.Path.Combine(folderName, "subStream");

            // pathstring can be written out directly instead of using the Combine
            // method. Combine just makes the process easier.
            string pathString2 = @"c:\home\Documents\topFolder\subStream";           
           
            System.IO.Directory.CreateDirectory(pathString);

            //add a file to the folder. 
            // creating file name
            string fileName = System.IO.Path.GetRandomFileName();

            //OR
            string newFileName = "newfile.txt";

            //Combine file name to pathstring.
            pathString = System.IO.Path.Combine(pathString, newFileName);

            
            Console.WriteLine("Path to my file: {0}\n", pathString);

            // Check that the file doesn't already exist. If it doesn't exist, create
            // the file and write integers 0 - 99 to it.
            // DANGER: System.IO.File.Create will overwrite the file if it already exists.
            // This could happen even with random file names, although it is unlikely.
            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }

            // Read and display the data from your file.
            try
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
                foreach (byte b in readBuffer)
                {
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
        // Sample output:

        // Path to my file: ~/home/Documents/topFolder/subStream/newfile.txt

        //0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29
        //30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56
        // 57 58 59 60 61 62 63 64 65 66 67 68 69 70 71 72 73 74 75 76 77 78 79 80 81 82 8
        //3 84 85 86 87 88 89 90 91 92 93 94 95 96 97 98 99
    }
}
