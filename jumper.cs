using System;
using System.Collections.Generic;

namespace Jumper_Game
{
    /// <summary>
    /// Draw the jumper 
    /// </summary>
    public class Jumper 
    {
        private List<string> jumper = new List<string>();

        public Jumper()
        {
            jumper.Add(@"  ___  ");
            jumper.Add(@"/_____\");
            jumper.Add(@"\     /");
            jumper.Add(@" \   / ");
            jumper.Add(@"   o   ");
            jumper.Add(@"  /|\  ");
            jumper.Add(@"  / \  ");
        }

        /// <summary>
        /// display the jumper 
        /// </summary>
        public void DisplayJumper()
        {
            string jump = string.Join("\n", jumper);
            Console.WriteLine(jump);
        }

        /// <summary>
        /// update the jumper 
        /// </summary>
        public void UpdateJumper(char guess, string answer)
        {
            if (answer.Contains(guess))
            {
                return;
            }
            else
            {
                jumper.RemoveAt(0);
            }
        }

        /// <summary>
        /// Check if user lost the game
        /// </summary>
        public bool youLost()
        {
            if (jumper.Count <= 3)
            {
                jumper[0] = "   x   ";
                return true;
            }
            else{
                return false;
            }
        }
    }
}