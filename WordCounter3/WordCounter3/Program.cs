using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter3
{
    class Program
    {
        static void Main(string[] args)
        {
            int repeatCounter = 0;
            Console.Write("Введите текст : ");
            string str = Convert.ToString(Console.ReadLine());
            string[] words = str.Split(' ');
            int counter = words.Length;
            for (int i = 0; i < words.Length; i++)
                for (int j = 0; j < words.Length; j++)
                    if ((words[i] == words[j]) && (i != j)) words[i] = null;
            for (int q = 0; q < words.Length; q++)
                if (words[q] == null) repeatCounter--;
            counter = counter - Math.Abs(repeatCounter);
            foreach (string a in words) Console.WriteLine(a);
            Console.WriteLine("Counter = {0} , Length = {1} ", counter, words.Length);
            Console.ReadKey();
        }
    }
}
