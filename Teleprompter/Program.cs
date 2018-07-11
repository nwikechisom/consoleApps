using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Teleprompter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /* var lines = ReadFrom("SampleText.txt");
            foreach (var line in lines)
            {
                //Console.WriteLine(line);

                Console.Write(line);
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var pause = Task.Delay(300);
                    //obviously this is an anti-pattern because we are synchronously waiting on a task.
                    pause.Wait();
                }
            } */

            //ShowTelePrompter().Wait();
            RunTelePrompter().Wait();
        }

        private static async Task RunTelePrompter()
        {
            var config = new TelePrompterConfig();
            var displayTask = ShowTelePrompter(config);

            var speedTask = GetInput(config);
            await Task.WhenAny(displayTask, speedTask);
        }

        private static async Task ShowTelePrompter(TelePrompterConfig config)
        {
            var words = ReadFrom("SampleText.txt");
            foreach (var word in words)
            {
                Console.Write(word);
                if (!string.IsNullOrWhiteSpace(word))
                {
                    await Task.Delay(config.DelayinMilliseconds);
                }
                config.Setdone();
            }
        }

        private static async Task GetInput(TelePrompterConfig config)
        {
            //var delay = 300;
            Action work = () => 
            {
                do
                {
                    var key = Console.ReadKey(true);
                    if (key.KeyChar == '>')
                    {
                        config.UpdateDelay(-10);
                    }
                    else if(key.KeyChar == '<')
                    {
                        config.UpdateDelay(10);
                    }
                } while (!config.Done);
            };
            await Task.Run(work);
        }

        static IEnumerable<string> ReadFrom(string file)
        {
            string line;
            using(var reader = File.OpenText(file))
            {
                while((line = reader.ReadLine()) != null)
                {
                    //uncomment the next line and comment block 38 to 51
                    //yield return line;
                    var words = line.Split(' ');
                    var linelength = 0;

                    foreach (var word in words)
                    {
                        yield return word +  " ";
                        linelength = linelength += word.Length + 1;
                        if (linelength > 70)
                        {
                            yield return Environment.NewLine;
                            linelength = 0;
                        }
                    }
                    yield return Environment.NewLine;
                }
            }
        }
    }
}
