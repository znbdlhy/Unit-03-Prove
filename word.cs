using System;
using System.Collections.Generic;
using System.IO;

namespace Jumper_Game
{
    /// <summary>
    /// display the word, the blank word, and update
    /// </summary>
    public class Word
    {
        private List<char> word = new List<char>();
        private string answer;
        private TerminalService t = new TerminalService();
        /// <summary>
        /// Get a word
        /// </summary>
        public Word()
        {
            Random random = new Random();
            List<string> randomWord = new List<string>(File.ReadLines("words.txt"));
            int randomIndex = random.Next(0, randomWord.Count);
            answer = randomWord[randomIndex];

            foreach(char i in answer)
            {
                word.Add('_');
            }
        }

        /// <summary>
        /// Display the word
        /// </summary>
        public void DisplayWord()
        {
            foreach(char i in word)
            {
               t.WriteText($"{i}");
            }
        }

        /// <summary>
        /// Update the word.
        /// </summary>
        public void UpdateWord(char guess)
        {
            int i = 0;
            foreach(char a in answer)
            {
                if (a == guess)
                {
                    word[i] = guess;
                }
                i += 1;
            }
        }

        /// <summary>
        /// Check if user win the game
        /// </summary>
        public string getAnswer()
        {
            return answer;
        }
        public bool youWin()
        {
            foreach(char a in word)
            {
                if (a == '_')
                {
                    return false;
                }
            }
            return true;
        }
    }
}