using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int rpwordcount = 0;
            int a = 0;
            //string repeatwords;
            //string [] rparray = new string []
            //int sum = 0;
            //int[,] chek = new int [0,255];
            //int [,] jchek = new int [0,255];
            Console.Write("Введите текст : ");
            string str = Convert.ToString(Console.ReadLine());
            string[] words = str.Split(' ');
            string[] repeatword = new string[words.Length];
            string[] rparray = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
                for (int j = 0; j < words.Length; j++)
                {
                    if ((words[i] == words[j]) && (i != j))
                    {
                        repeatword[i] = words[i];
                        rparray[i] = repeatword[i];
                        a--;
                        for (int q = 0; q < words.Length; q++)
                            if ((repeatword[q] == rparray[i]) && (q != i))
                                rpwordcount++;
                        Console.WriteLine("i = {0} , j = {1}, a = {2} ", i, j, a);
                        Console.WriteLine("RepeatWord = {0}", repeatword[i]);

                    }
                }
            //for (int q = 0; q < words.Length; q++)
            //	for (int w = 0; w < words.Length; w++)
            //	{
            //		if ((repeatword[q] == words[w]) && (q != w))
            //		{
            //			a--;
            //			Console.WriteLine("a= {0}, q = {1}, w = {2}", a, q, w);
            //		}

            //	}
            count = (words.Length - Math.Abs(a));
            count = (count + rpwordcount);
            Console.WriteLine("Count = {0} , Length = {1} ", count, words.Length);
            Console.ReadKey();
        }
    }
}
