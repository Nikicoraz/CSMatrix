using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMatrix
{
    static class Alphabet
    {
        private static readonly Random rd = new Random();
        public static char[] l_alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'w', 'v', 'x', 'y', 'z' };
        public static char[] u_alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'W', 'V', 'X', 'Y', 'Z' };
        public static char[] simbols = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '.', '/', '-', '_', ' ', '?', ';', ':', '\'', '"', '\\', ',', '=', '+', '[', ']', '{', '}', '|', '~', '`' };
        public static char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static char[] fullAlphabet = l_alphabet.Concat(u_alphabet).Concat(simbols).Concat(numbers).ToArray();
        public static char GetRandomLetter()
        {
            return fullAlphabet[rd.Next(0, fullAlphabet.Length)];
        }
    }
    class Word
    {
        public List<Letter> letters = new List<Letter>();
        public Word()
        {
            int toCreate = new Random().Next(5, 9);
            for(int i = 0; i < toCreate; i++)
            {
                letters.Add(new Letter(0 - i));
            }
        }
    }
    class Letter
    {
        public int y { get; set; }
        public char letter;

        public Letter(int y)
        {
            SetXY(y);
            letter = Alphabet.GetRandomLetter();
        }
        public void SetXY(int y)
        {
            this.y = y;
        }
        public void setXY(Letter l)
        {
            this.y = l.y;
        }
    }
}
