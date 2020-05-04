using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork._02._05
{
    class Program
    {
        static List<int> widthes1 = new List<int>();
        static List<int> widthes2 = new List<int>();
        static List<int> prover = new List<int>();
        static List<int> promezh = new List<int>();
        static List<int> startPos = new List<int>();
        static List<int> height1 = new List<int>();
        static List<int> height2 = new List<int>();
        static void AddNumberToList()
        {
            prover.RemoveRange(0,prover.Count);
            for (int i = 0; i < 71; i++)
            {
                prover.Add(i);
            }
        }
        static void AddNumber(List<int> list)
        {
            list.RemoveRange(0,list.Count);
            int b = new Random().Next(7, 70);
            for (int i = 0; i < b; i++)
            {
                int a = prover[new Random().Next(0, prover.Count)];
                list.Add(a);
                prover.Remove(a);
            }
            prover.RemoveRange(0, prover.Count);
        }
        static void AddHeights(List<int> list, int count)
        {
            list.RemoveRange(0,list.Count);
            for (int i = 0; i < count; i++)
            {
                list.Add(new Random().Next(3, 9));
            }
        }
        static void AddPromezh()
        {
            for (int i = 0; i < 71; i++)
            {
                promezh.Add(new Random().Next(2, 5));
            }
        }
        static void AddStartPos()
        {
            startPos.RemoveRange(0,startPos.Count);
            for (int i = 0; i < 71; i++)
            {
                startPos.Add(new Random().Next(-2, 5));
            }
        }
        static void Show(List<int> list)
        {
            foreach (var s in list)
            {
                System.Console.Write(s + " ");
            }
            System.Console.WriteLine();
            System.Console.WriteLine(list.Count);
            Console.WriteLine("\n\n\n");
        }
        static string[] arrayOfSymbols = { "A", "X", "Z", "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "S", "D", "F", "G", "H", "J", "K", "L", "C", "V", "B", "N", "M", "!", "#", "@", "$", "%", "^", "&", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "~" };
        static void Main(string[] args)
        {
            while(true)
            {
                AddStartPos();
                AddNumberToList();
                AddNumber(widthes1);
                AddNumberToList();
                AddNumber(widthes2);
                AddHeights(height1, widthes1.Count);
                AddHeights(height2, widthes2.Count);
                AddPromezh();
                Task wr;
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < widthes1.Count; j++)
                    {
                        wr = ShowWrite(widthes1[j], height1[j], startPos[j] + i);
                        wr.Wait();
                        Thread.Sleep(1);
                    }
                }
            }
            Console.ReadKey();
        }
        async static Task ShowWrite(int posX, int heightOfFirst, int startingPos)
        {
            await Task.Run(() =>
            {
                while (startingPos < 0)
                {
                    startingPos++; heightOfFirst--;
                }
                int a = heightOfFirst;
                for (int i = heightOfFirst + startingPos - 1; i > startingPos - 1 && i < 25; i--)
                {
                    a--;
                    Console.SetCursorPosition(posX, i);
                    Console.ForegroundColor = ( i == heightOfFirst + startingPos-2) ? ConsoleColor.Green : (i == heightOfFirst + startingPos - 1) ? ConsoleColor.White : ConsoleColor.DarkGreen;
                    Console.Write(arrayOfSymbols[new Random().Next(0, arrayOfSymbols.Length)]);
                }
                if (startingPos > 0)
                {
                    for (int i = startingPos - 1; i > -1; i--)
                    {
                        Console.SetCursorPosition(posX, i);
                        Console.Write(" ");
                    }
                }
            });
            // if(a == 0)
            // {
            // }
            // else
            // {
            //     if(g < heightOfFirst-1)
            //     {
            //         if(startingPos >0)
            //         {
            //             for(int i = startingPos; i >g-1; i--)
            //             {
            //                 Console.SetCursorPosition(posX,i);
            //                 Console.Write(" ");
            //             }
            //         }
            //         for(int i = g; i > -1;i--)
            //         {
            //             Console.SetCursorPosition(posX,i);
            //             Console.Write(arrayOfSymbols[new Random().Next(0,arrayOfSymbols.Length)]);
            //         }
            //     }
            //     g++;
            // }
        }
    }
}
