using System;
using System.Collections.Generic;

namespace Jumper_Game
{
    /// <summary>
    /// Direct the game
    /// </sumary>
    public class Director
    {
        public Word word = new Word();
        private Jumper jumper = new Jumper();
        private TerminalService terminalService = new TerminalService();
        private List<char> guessed = new List<char>();
        private bool isPLaying = true;
        public char guess;
 
        /// <summary>
        /// constructs a new instance of director
        /// </summary>
        public Director()
        {
        }

        ///<summary>
        /// Start the game
        /// </summary>
        public void StartGame()
        {
            while (isPLaying)
            {
                DoOutputs();
                GetInputs();
                while (guessed.Contains(guess))
                {
                    terminalService.WriteText($"You have already guess this, try a different one.");
                    GetInputs();
                }
                DoUpdates(guess);
            }
        }

        /// <summary>
        /// Get user's input
        /// </summary>
        private void GetInputs()
        {
            string userInput = terminalService.ReadText("\nGuess a letter [a-z]: ");
            char[] guessA = userInput.ToCharArray();
            guess = guessA[0];
        }

        /// <summary>
        /// Update the jumper
        /// </summary>
        private void DoUpdates(char guess)
        {
            guessed.Add(guess);
            jumper.UpdateJumper(guess, word.answer);
            word.UpdateWord(guess);

            if (word.youWin())
            {
                endGame();
                terminalService.WriteText("\nYou won the game!");
            }

            else if (jumper.youLost())
            {
                endGame();
                terminalService.WriteText("\nYou lost :(");
            }
        }

        /// <summary>
        /// Display the jumper and the word
        /// </summmary>
        private void DoOutputs()
        {
            jumper.DisplayJumper();
            word.DisplayWord();
        }

        /// <summary>
        /// End the game
        /// </summmary>
        private void endGame()
        {
            isPLaying = false;
            jumper.DisplayJumper();
            word.DisplayWord();
        }
    }
}