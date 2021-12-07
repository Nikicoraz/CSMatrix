using System;
using System.IO;
using System.Text;
using System.Threading;

namespace CMatrix
{
    class Program
    {
        static readonly Random rd = new Random();
        static void DetectKey(Word[] currentWords, ref int wordNumber)
        {
            if (wordNumber == currentWords.Length) return;
            int x;
            do
            {
                x = rd.Next(0, currentWords.Length);
            } while (currentWords[x] != null);
            currentWords[x] = new Word();
            wordNumber++;
        }
        static void Render(Word[] currentWords, ref int wordNumber, int height)
        {
            for(int i = 0; i < currentWords.Length; i++)
            {
                if (currentWords[i] == null) continue;
                if (currentWords[i].letters[currentWords[i].letters.Count - 1].y - 1 >= 0) Console.SetCursorPosition(i, currentWords[i].letters[currentWords[i].letters.Count - 1].y - 1);
                Console.Write(" ");
                if (currentWords[i].letters[currentWords[i].letters.Count - 1].y >= height)
                {
                    currentWords[i] = null;
                    wordNumber -= 1;
                    continue;
                }
                for(int j = 0; j < currentWords[i].letters.Count; j++)
                {
                    if (currentWords[i].letters[j].y < 0) break;
                    if (currentWords[i].letters[j].y >= height) continue;
                    Console.SetCursorPosition(i, currentWords[i].letters[j].y);
                    Console.Write(currentWords[i].letters[j].letter);
                }
            }

            for(int i = 0; i < currentWords.Length; i++)
            {
                if (currentWords[i] == null) continue;
                for(int j = 0; j < currentWords[i].letters.Count; j++)
                {
                    currentWords[i].letters[j].y += 1;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WindowHeight = 30;
            int heigth = Console.WindowHeight;
            int width = Console.WindowWidth;
            int wordNumber = 0;


            Word[] currentWords = new Word[width];
            for(int i = 0; i < currentWords.Length; i++)
            {
                currentWords[i] = null;
            }
            new Thread(() =>
            {
                while (true)
                {
                    Render(currentWords, ref wordNumber, heigth);
                    Thread.Sleep(10);
                }
            }).Start();

            new Thread(() =>
            {
                while (true)
                {
                    DetectKey(currentWords, ref wordNumber);
                    Thread.Sleep(40);
                }
            }).Start();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "Matrix";
        }
    }
}
