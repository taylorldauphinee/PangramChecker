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

        // checks if each letter's value is more than zero, returns the replay choice
        static bool CheckValues()
        {
            foreach (KeyValuePair<char, int> letter in alphabetCount)
            {
                Console.WriteLine("There are " + letter.Value + " instances of the letter " + letter.Key);

                if (letter.Value <= 0)
                {
                    Console.WriteLine("This sentence is not a pangram.\n");
                    return Replay();
                }
            }
            Console.WriteLine("Your sentence is a pangram!\n");
            return Replay();
        }

        // asks the player if they want to check another sentence, returns the choice
        static bool Replay()
        {
            Console.WriteLine("Do you want to check another sentence? Y/N");
            string choice = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();

            if (choice.ToLower() == "y") return true;
            else if (choice.ToLower() == "n") return false;
            else
            {
                Console.WriteLine("Invalid answer. Please try again.\n");
                return Replay();
            }
        }

        // resets the dictionary values for a replay
        static void ResetValues()
        {
            alphabetCount.Clear();
            BaseAlphabet();
        }

        static void Main(string[] args)
        {
            bool checkWords = true;
            BaseAlphabet();

            do
            {
                // ask for a sentence to be input
                Console.WriteLine("Enter your sentence: ");
                string sentence = Console.ReadLine();
                sentence = sentence.ToLower();

                // check through all of the characters
                foreach (char letter in sentence.ToCharArray())
                {
                    if (alphabetCount.TryGetValue(letter, out int numInstances))
                    {
                        alphabetCount[letter] = numInstances + 1;
                    }
                }

                checkWords = CheckValues();

                // ensure the values of the dictionary are set to zero
                ResetValues();
            }
            while (checkWords);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }
    }
}
