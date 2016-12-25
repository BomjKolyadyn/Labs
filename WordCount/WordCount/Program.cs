using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            Console.Write("Введите текст : ");
            string str = Convert.ToString(Console.ReadLine());
            string[] words = str.Split(' ');
            for (int i = 0; i < words.Length; i++)
                for (int j = 0; j <words.Length-1; j++)
                {
                    if (words[i] != words[j + 1])
                    {
                        //if (j == words.Length - 2)
                        {
                            counter++;
                        }
                        Console.WriteLine("Counter = {0}, Length = {1}, i = {2}, (j+1) = {3}, j = {4} ", counter, words.Length, i, j + 1,j);
                    }
                    else if (i != j)
                    {
                        counter--;
                        Console.WriteLine("Else Counter  = " + counter);
                    }
                    else Console.WriteLine(counter);
                }
            Console.WriteLine(counter);
            Console.ReadKey();
        }
    }
}
