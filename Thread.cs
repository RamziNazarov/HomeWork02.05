using System;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace HomeWork._02._05
{
    public static class ThreadingEx
    {
        public static void DoSomething()
        {
            Thread thread = new Thread(() =>
            {
                using (FileStream f = new FileStream("1.txt", FileMode.Append))
                {
                    using (StreamWriter writer = new StreamWriter(f))
                    {
                        for (int i = 0; i < 500; i++)
                        {
                            writer.Write(i + " ");
                            Thread.Sleep(10);
                        }
                    }
                }
                Process.Start("notepad");
            });
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.AboveNormal;
            thread.Start();
        }
    }
}
