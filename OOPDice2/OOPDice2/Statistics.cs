using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace OOPDice2
{
    class Statistics 
    {
        public List<int> Highscores = new List<int>();                                          // this is my list of highscores 
        
        /// <summary>
        /// this shows the statistics for the seven out game 
        /// </summary>
        /// <param name="seven"></param>
        /// <returns></returns>

        public int Stats7(SevenOut seven)
        {
            int length = Highscores.Count();                                                    // this gives me the length of the highscores list 
            Highscores.Sort();                                                                  // this sorts the high scores so they are in order smallest to largest 
            Highscores.Reverse();                                                               // this swaps the list to that the largest (highscore) is at the top  

            Console.WriteLine("Statistics for seven out ");                                     // this says which statistics are being shown 

            Console.WriteLine("Number of wins Player 1: " + seven.P1Wins7);                     // this prints the number of times player 1 has won a game of 7 out 
            Console.WriteLine("Number of wins Player 2: " + seven.P2Wins7);                     // this prints the number of times player 2 has won a game of 7 out
            int total7 = seven.P1Wins7 + seven.P2Wins7;                                         // this works out the total of wins in seven out by a player (computer not included)
            Console.WriteLine("Total wins in seven out (computer wins not added): " + total7);  // this prints the number of wins 
            Console.WriteLine($"Number of plays: {seven.numOfPlays}");                          // this prints how many times the game has been played
            if (length > 0)                                                                     // this checks to see if the highscores list is empty 
            {
                Console.WriteLine($"Player Highscore: {Highscores[0]}");                        // if the list isn't empty it prints the first number in the list (the biggest)
            }
            else
            {
                Console.WriteLine($"Player Highscore: *no data yet*");                          // if the list is empty it will show no data yet to avoid crashing printing a list with nothing in it 
            }
            Console.WriteLine();                                                                // this will leave a blank line in the terminal just to separate things a bit more making it easier to see 
            
            

            return 0;
        }

        /// <summary>
        /// this shows the statistics for the three or more game 
        /// </summary>
        /// <param name="three"></param>
        /// <returns></returns>

        public int Stats3(ThreeOrMore three)
        {
            

            Console.WriteLine("Statistics for three or more ");                                 // this says which statistics are being shown 

            Console.WriteLine("Number of wins Player 1: " + three.P1Wins3);                     // this prints the number of times player 1 has won a game of 3 or more 
            Console.WriteLine("Number of wins Player 2: " + three.P2Wins3);                     // this prints the number of times player 2 has won a game of 3 or more 
            int total3 = three.P1Wins3 + three.P2Wins3;                                         // this adds the total number of wins 
            Console.WriteLine("Total wins in seven out (computer wins not added): " + total3);  // this prints the number of wins
            Console.WriteLine($"Number of plays: {three.numOfPlays3}");                         // this prints how many times the game has been played
            
            Console.WriteLine();                                                                // this will leave a blank line in the terminal just to separate things a bit more making it easier to see 


            return 0;
        }

    }
}
