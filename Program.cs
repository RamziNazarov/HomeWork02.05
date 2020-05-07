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
            int b = new Random().Next(7, 35);
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
                promezh.Add(new Random().Next(3, 5));
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
        static void Summ(int a,int b)
        {
            System.Console.WriteLine(a+b);
        }
        static void Main(string[] args)
        {
            #region Parallel
            Parallel.Invoke(()=>{Summ(1,2);},()=>{Summ(5,14);},()=>{Summ(-123,2154);});
            #endregion
            #region Async
            // пример использования асинхронного программирования
            Async.WriteToFileAsync(arrayOfSymbols);
            #endregion
            #region Thread
            ThreadingEx.DoSomething();
            #endregion
            Console.SetWindowSize(71,40);
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
                for (int i = 0; i < 29; i++)
                {
                    for (int j = 0; j < widthes2.Count; j++)
                    {
                        wr = ShowSecAsync(widthes2[j],height2[j],i);
                        wr.Wait();
                        Thread.Sleep(10);
                    }
                    for (int j = 0; j < widthes1.Count; j++)
                    {
                        wr = ShowWriteAsync(widthes1[j], height1[j],i);
                        wr.Wait();
                        Thread.Sleep(10);
                    }
                }
            }
        }
        async static Task ShowSecAsync(int posX,int height,int startingPosi)
        {
            await Task.Run(() => 
            {
                int startingPos = 0;
                for(int i = 0; i < widthes2.Count;i++)
                {
                    if(widthes2[i] == posX)
                    {
                        startingPos += height2[i];
                    }
                }
                int prom = 0;
                for(int i = 0; i < startPos.Count;i++)
                {
                    if(posX == i)
                    {
                        startingPos += promezh[i];
                        prom = promezh[i];
                        startingPos += startPos[i];
                    }
                }
                startingPos += startingPosi;
                while (startingPos < 0)
                {
                    startingPos++; height--;
                }
                int a = height;
                for (int i = height + startingPos - 1; i > startingPos - 1 && i < 22; i--)
                {
                    a--;
                    Console.SetCursorPosition(posX, i);
                    Console.ForegroundColor = ( i == height + startingPos-2) ? ConsoleColor.Green : (i == height + startingPos - 1) ? ConsoleColor.White : ConsoleColor.DarkGreen;
                    Console.Write(arrayOfSymbols[new Random().Next(0, arrayOfSymbols.Length)]);
                }
                if (startingPos > 0)
                {
                    for (int i = startingPos - 1; i > startingPos-prom; i--)
                    {
                        Console.SetCursorPosition(posX, i);
                        Console.Write(" ");
                    }
                }
            });
        }
        async static Task ShowWriteAsync(int posX, int heightOfFirst, int startingPosi)
        {
            await Task.Run(() =>
            {
                int startingPos = 0;
                for(int i = 0; i < startPos.Count;i++)
                {
                    if(i == posX)
                    startingPos += startPos[i];
                }
                startingPos += startingPosi; 
                while (startingPos < 0)
                {
                    startingPos++; heightOfFirst--;
                }
                int a = heightOfFirst;
                for (int i = heightOfFirst + startingPos - 1; i > startingPos - 1 && i < 22; i--)
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
        }
    }
}
