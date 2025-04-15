using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Words
    {
        public static void DoWords()
        {
            int rows = int.Parse(Console.ReadLine());

            string[] words = new string[rows];
            List<string> correctWords = new List<string>();

            string mainWord, mainWordBw = "";

            for (int i = 0; i < rows; i++)
            {
                words[i] = Console.ReadLine();
            }

            mainWord = Console.ReadLine();

            foreach (var c in mainWord.Reverse().ToArray())
            {
                mainWordBw += c;
            }

            for (int i = 0; i < words.Length; i++)
            {
                string editedWord = words[i].Replace(" ", "");
                if (editedWord.Contains(mainWord))
                {
                    correctWords.Add(words[i]);
                }
                else if (editedWord.Contains(mainWordBw))
                {
                    correctWords.Add(words[i]);
                }
            }

            correctWords.Sort();

            foreach (var word in correctWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
