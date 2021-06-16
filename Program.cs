using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Program.cs
/// June 16, 2021
/// Written by Taylor Dauphinee
/// A script to determine if a sentence is a pangram (contains every letter at least once)
/// </summary>

namespace PangramChecker
{
    class Program
    {
        static Dictionary<char, int> alphabetCount = new Dictionary<char, int>();

        // set up the counter
        static void BaseAlphabet()
        {
            alphabetCount.Add('a', 0);
            alphabetCount.Add('b', 0);
            alphabetCount.Add('c', 0);
            alphabetCount.Add('d', 0);
            alphabetCount.Add('e', 0);
            alphabetCount.Add('f', 0);
            alphabetCount.Add('g', 0);
            alphabetCount.Add('h', 0);
            alphabetCount.Add('i', 0);
            alphabetCount.Add('j', 0);
            alphabetCount.Add('k', 0);
            alphabetCount.Add('l', 0);
            alphabetCount.Add('m', 0);
            alphabetCount.Add('n', 0);
            alphabetCount.Add('o', 0);
            alphabetCount.Add('p', 0);
            alphabetCount.Add('q', 0);
            alphabetCount.Add('r', 0);
            alphabetCount.Add('s', 0);
            alphabetCount.Add('t', 0);
            alphabetCount.Add('u', 0);
            alphabetCount.Add('v', 0);
            alphabetCount.Add('w', 0);
            alphabetCount.Add('x', 0);
            alphabetCount.Add('y', 0);
            alphabetCount.Add('z', 0);
        }

        static void ResetValues()
        {
            foreach(KeyValuePair<char, int> letter in alphabetCount)
            {
                alphabetCount[letter.Key] = 0;
            }
        }

        static void Main(string[] args)
        {
            BaseAlphabet();

            // ask for a sentence to be input
            Console.WriteLine("Enter your sentence: ");
            string sentence = Console.ReadLine();
            sentence = sentence.ToLower();

            // check through all of the characters
            foreach(char letter in sentence.ToCharArray())
            {
                if (alphabetCount.TryGetValue(letter, out int numInstances))
                {
                    //Console.WriteLine("Found letter " + Char.ToLower(letter));
                    alphabetCount[letter] = numInstances + 1;
                }
            }

            // check if every character's value is more than zero
            foreach(KeyValuePair<char, int> letter in alphabetCount)
            {
                Console.WriteLine("There are " + letter.Value + " instances of the letter " + letter.Key);

                if (letter.Value <= 0)
                {
                    Console.WriteLine("This sentence is not a pangram.");
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey(true);
                    return;
                }
            }
            Console.WriteLine("Your sentence is a pangram!");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }
    }
}
