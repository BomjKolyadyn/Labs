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

            string str = "asd as  w aw we r t  t we w w qqqw wer"; 
            string[] words = str.Split(new[] { '.', ',', '\'', '\"', ':', ';', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var uniqueWordsSet = new HashSet<string>();

            foreach (var word in words)
            {
                if (!uniqueWordsSet.Contains(word))
                {
                    uniqueWordsSet.Add(word);
                }
            }

            foreach (var uniqueWord in uniqueWordsSet)
            {
                Console.WriteLine(uniqueWord);
            }

            Console.WriteLine("------------------------------");

            var uniqueWords = new List<string>();
            
            for (int i = 0; i < words.Length; i++)
            {
                var isRepeated = false;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (words[i] == words[j])
                    {
                        isRepeated = true;
                        break;
                    }
                }

                if (!isRepeated)
                {
                    uniqueWords.Add(words[i]);
                }
            }

            foreach (var uniqueWord in uniqueWords)
            {
                Console.WriteLine(uniqueWord);
            }

            Console.WriteLine("------------------------------");

            int counter = words.Length;
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if ((words[i] == words[j]) && (i != j))
                    {
                        words[i] = null;
                    }
                }
            }

            foreach (string q in words)
            {
                if (q == null)
                {
                    repeatCounter--;
                }
            }

            counter = counter - Math.Abs(repeatCounter);
            foreach (string a in words)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("Counter = {0} , Length = {1} ", counter, words.Length);
            Console.ReadKey();
        }
    }
}
