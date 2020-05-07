using System;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork._02._05
{
    public static class Async
    {
        public static async void WriteToFileAsync(string[] array)
        {
            using (FileStream f = new FileStream("1.txt", FileMode.Append))
            {
                using (StreamWriter writer = new StreamWriter(f))
                {
                    for (int i = 0; i < array.Length; i++)
                        await writer.WriteAsync(array[i] + " ");
                }
            }
        }
    }
}