using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace OOPDice2
{
    class SevenOut : Statistics                     // inheritance 
    {
        public int P1Wins7 = 0;                     // this is used to see how manny times player 1 has won 
        public int P2Wins7 = 0;                     // this is used to see how manny times player 2 has won 
        public int numOfPlays = 0;                  // this is used to see how many times the game has been played 
        public int sumOfDice = 0;                   // this is the total of the dice rolls 
        Die die1 = new Die();
        Die die2 = new Die();


        /// <summary>
        /// This is my seven out game i will roll 2 dice and add the scores together and add it to the total if its a double i add double if its a 7 i add nothing 
        /// </summary>
        /// <returns></returns>
        /// 

        public int SevenGame(Game g)
        {
            bool player1 = true;                     // this runs the game and loops player 1 and 2's turns  
            bool correctInput = false;               // this loops if you want to play against the computer (if incorrect input given you'll get a chance to trya again)
            
            

            while (correctInput == false)            // while correct input is false run this 
            {
                Console.WriteLine("Would you like to play against the computer? (y,n) ");
                string play = Console.ReadLine();                                           // this is the variable used to pick to play against the computer or not 

                if (play == "n")                                                            // if the input is n (no) then run this ...
                {
                    Console.WriteLine("Playing Seven out");
                    correctInput = true;

                    
                    int P1Total = 0;                                                        // this sets the player 1 total to 0
                    int P2Total = 0;                                                        // this sest the player 2 total to 0 
                    bool Stop = false;                                                      // this sets stop (the while loop for the game) 
                   


                    while (Stop == false)                                                   // while stop is false loop the player turns
                    {

                        if (player1 == true)                                                // if player 1 is true run player 1's turn 
                        {

                            while (sumOfDice != 7)                                          // while the total of the dice isn't 7 run this ...
                            {

                                Console.WriteLine();                                        // this is used to add a space between the player and the last thing on the terminal to make it easier to see 
                                Console.WriteLine("Player 1:");                             // this prints to show who turn it is 
                                Console.ReadLine();                                         // this stops the code just running all at once without player input (click to roll dice)

                                Die2();                                                     // this calls the die2 method to roll 2 dice 

                                Console.WriteLine("Rolls: ");                               // this is text that will be shown to help users know what the numbers are 
                                Console.WriteLine(die1.Value);                              // this prints the dice values 
                                Console.WriteLine(die2.Value);
                                

                                if (die1.Value == die2.Value)                               // this will run if the dice values are the same (doubles)
                                {
                                    
                                    P1Total = die1.Value + die1.Value + die2.Value + die2.Value + P1Total;         // double the score rolled is added to the total score for player 1 

                                }
                                else                                                        // if the score isn't a double then the total is just added to the score 
                                {
                                    P1Total = die1.Value + die2.Value + P1Total;            // the score is added to the total 

                                }

                            }
                            Console.WriteLine("Total: " + P1Total);                         // this prints the total at the end of the player turn 
                            
                            Highscores.Add(P1Total);                                        // this adds the scores to the highscores list to be shown in statistics 
                            sumOfDice = 0;                                                  // this resets sumOfDie to 0 so it wont interfere with player 2's scores 
                            player1 = false;                                                // this sets player 1 to false to end player 1's turn 

                            

                        }
                        else if (player1 == false)                                          // because player 1 is false its player 2's turn 
                        {
                            while (sumOfDice != 7)                                          // while it's not 7 run this ...
                            {

                                Console.WriteLine();                                        // this is used to add a space between the player and the last thing on the terminal to make it easier to see 
                                Console.WriteLine("Player 2:");                             // this tells the user whos turn it is 
                                Console.ReadLine();                                         // this is used for player input (theu need to click to continue) so that the code doesn't just run on its own without player input 

                                Die2();                                                     // this calls the Die2 method to roll the dice 

                                Console.WriteLine("Rolls: ");                               // this is text that will be shown to help users know what the numbers are 
                                Console.WriteLine(die1.Value);                              // this prints the dice values 
                                Console.WriteLine(die2.Value);


                                if (die1.Value == die2.Value)                               // this will run if the dice values are the same (doubles)
                                {

                                    P2Total = die1.Value + die1.Value + die2.Value + die2.Value + P2Total;         // double the score rolled is added to the total score for player 2 

                                }
                                else                                                        // if the score isn't a double then the total is just added to the score 
                                {
                                    P2Total = die1.Value + die2.Value + P2Total;            // the score is added to the total 

                                }

                            }
                            Stop = true;                                                    // this ends the while loop because both players have finished their turns 
                            Console.WriteLine("Total: " + P2Total);                         // player 2's score is then printed 
                            Highscores.Add(P2Total);                                        // this adds player 2's score to the highscore chart 
                            sumOfDice = 0;                                                  // this resets the sumOfDice to 0 so there wont be errors 
                        }
                        else
                        {
                            
                        }
                        
                    }
                    if (P1Total > P2Total)                                                  // if player 1's score is higher run this ... 
                    {
                        Console.WriteLine("Gameover player 1 wins!");                       // this prints so that the players know who won 
                        Console.WriteLine("Player 1: " + P1Total + " Player 2: " + P2Total);       // this will show both player scores 
                        numOfPlays++;                                                       // this will add 1 to the number of times the game has been played 
                        P1Wins7++;                                                          // this adds 1 to the number of times player 1 has won 

                        Console.WriteLine("---Main menu--- ");                              // this will print to show a separation between the seven out game and main menu 
                        
                        g.StartMenu(g);                                                     // this calls the method for the start menu from the game class 
                        
                    }
                    else if (P1Total < P2Total)                                             // this will run if player 2's score is higher than player 1's score 
                    {
                        Console.WriteLine("Gameover player 2 wins!");                       // this runs to show the users whos won 
                        Console.WriteLine("Player 2: " + P2Total + " Player 1: " + P1Total);       // this will show both players scores 
                        numOfPlays++;                                                       // this will increase the number of times the game has been played 
                        P2Wins7++;                                                          // this adds 1 to the number of times player 2 has won 


                        Console.WriteLine("---Main menu---");                               // this will print to show a separation between the seven out game and main menu 


                        g.StartMenu(g);                                                     // this calls the method for the start menu from the game class
                        

                    }
                    else                                                                    // this runs if neither of the players have the higher score 
                    {
                        Console.WriteLine("It's a tie !");                                  // this tells the players that there's a tie 
                        Console.WriteLine("Player 1 & Player 2: " + P1Total);               // this will show if both scores are the same 
                        numOfPlays++;                                                       // this adds 1 to the number of games played 
                        P1Wins7++;                                                          // this adds one to the number of wins for both players 
                        P2Wins7++;

                        
                        Console.WriteLine("---Main menu---");                               // this will print to show a separation between the seven out game and main menu

                        g.StartMenu(g);                                                     // this calls the method for the start menu from the game class

                    }

                }
                if (play == "y")                                                            // this will run if the player wnats to play against the computer 
                {
                    Console.WriteLine("Playing Seven out against the computer");            // this will print to remind the user that they are playing against the computer 
                    Console.WriteLine("You are player 1 ");                                 // this prints to tell the user that player 1 is them and noth the computer because player 1 goes first
                    correctInput = true;                                                    // this sets correct input to true to stop the loop running (incorrect input play computer)

                    int P1Total = 0;                                                        // this sets player 1's total to 0
                    int P2Total = 0;                                                        // this sest player 2's total to 0
                    bool Stop = false;                                                      // this sets stop to false 


                    while (Stop == false)                                                   // while stop is false run the loop (play the game for player 1 and computer)
                    {
                            if (player1 == true)                                            // player 1 is set to treu at the start so the if will run player 1's turn 
                            {
                                while (sumOfDice != 7)                                      // as long as the roll isn't equal to 7 run this ...
                                {

                                    Console.WriteLine();                                    // this is used to add a space between the player and the last thing on the terminal to make it easier to see 
                                    Console.WriteLine("Player 1:");                         // this prints to show whos turn it is 
                                    Console.ReadLine();                                     // this stops the game to allow for player input (click to roll)

                                    Die2();                                                 // this calls the die2 methord to roll the dice

                                    Console.WriteLine("Rolls: ");                           // this is text that will be shown to help users know what the numbers are 
                                    Console.WriteLine(die1.Value);                          // this prints the dice values 
                                    Console.WriteLine(die2.Value);


                                    if (die1.Value == die2.Value)                           // this will run if the dice values are the same (doubles)
                                    {
    
                                        P1Total = die1.Value + die1.Value + die2.Value + die2.Value + P1Total;         // double the score rolled is added to the total score for player 1 
    
                                    }
                                    else                                                    // if the score isn't a double then the total is just added to the score 
                                    {
                                        P1Total = die1.Value + die2.Value + P1Total;        // the score is added to the total 
    
                                    }

                                }
                                Console.WriteLine("Total: " + P1Total);                     // this shows player 1's total 
                                Highscores.Add(P1Total);                                    // this adds palyer 1's score to the highscores list 
                                sumOfDice = 0;                                              // this re-sets sumOfDie to 0 
                                player1 = false;                                            // this sets player 1 to false so player 2 (the computers) turn will run



                            }
                            else if (player1 == false)                                      // this runs the computers turn 
                            {
                                while (sumOfDice != 7)                                      // while the roll isn't 7 run this ...
                                {

                                    Console.WriteLine();                                    // this is used to add a space between the player and the last thing on the terminal to make it easier to see 
                                    Console.WriteLine("computer:");                         // this shows whos turn it is 

                                    Die2();                                                 // this calls the dice method to roll the dice 

                                    Console.WriteLine("Rolls: ");                           // this is text that will be shown to help users know what the numbers are 
                                    Console.WriteLine(die1.Value);                          // this prints the dice values 
                                    Console.WriteLine(die2.Value);

                                    if (die1.Value == die2.Value)                           // this will run if the dice values are the same (doubles)
                                    {

                                        P2Total = die1.Value + die1.Value + die2.Value + die2.Value + P2Total;         // double the score rolled is added to the total score for player 2 

                                    }
                                    else                                                    // if the score isn't a double then the total is just added to the score 
                                    {
                                        P2Total = die1.Value + die2.Value + P2Total;        // the score is added to the total 

                                    }

                                }
                                Stop = true;                                                // this sest stop to true because both players turns are complete
                                Console.WriteLine("Total: " + P2Total);                     // this shows player 2 (computers) score 
                                sumOfDice = 0;                                              // this re-sets sumOfDice to 0 
                                // this score isn't added to the highscores because its scored by the computer and only player scores count 


                            }
                            else
                            {

                            }
                        
                    }
                    if (P1Total > P2Total)                                                  // if player 1's score is higher run this ... 
                    {
                        Console.WriteLine("Gameover player 1 wins!");                       // this prints so that the players know who won 
                        Console.WriteLine("Player 1: " + P1Total + " Player 2: " + P2Total);       // this will show both player scores 
                        numOfPlays++;                                                       // this will add 1 to the number of times the game has been played 
                        P1Wins7++;                                                          // this adds 1 to the number of times player 1 has won 

                        Console.WriteLine("---Main menu--- ");                              // this will print to show a separation between the seven out game and main menu 

                        g.StartMenu(g);                                                     // this calls the method for the start menu from the game class 

                    }
                    else if (P1Total < P2Total)                                             // this will run if player 2's score is higher than player 1's score 
                    {
                        Console.WriteLine("Gameover player 2 wins!");                       // this runs to show the users whos won 
                        Console.WriteLine("Player 2: " + P2Total + " Player 1: " + P1Total);       // this will show both players scores 
                        numOfPlays++;                                                       // this will increase the number of times the game has been played 
                        P2Wins7++;                                                          // this adds 1 to the number of times player 2 has won 


                        Console.WriteLine("---Main menu---");                               // this will print to show a separation between the seven out game and main menu 


                        g.StartMenu(g);                                                     // this calls the method for the start menu from the game class


                    }
                    else                                                                    // this runs if neither of the players have the higher score 
                    {
                        Console.WriteLine("It's a tie !");                                  // this tells the players that there's a tie 
                        Console.WriteLine("Player 1 & Player 2: " + P1Total);               // this will show if both scores are the same 
                        numOfPlays++;                                                       // this adds 1 to the number of games played 
                        P1Wins7++;                                                          // this adds one to the number of wins for both players 
                        P2Wins7++;


                        Console.WriteLine("---Main menu---");                               // this will print to show a separation between the seven out game and main menu

                        g.StartMenu(g);                                                     // this calls the method for the start menu from the game class

                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");                                     // this will tell the user if there input is not one of the options the loop will allow them to try again 
                    correctInput = false;                                                   // this sets corretc input to false so the loop continues until y or n have been selected 
                }
            }


            return sumOfDice;
        }


        /// <summary>
        /// This is a section of the seven game used to test that the seven game stops when you get a 7 
        /// </summary>
        /// <returns></returns>
        public int TestSeven()
        {
            //they all have T in front of them for test and so they don't mess with the other variables in the class 

            int TsumOfDice = 0;                                                             // this is the total of the dice rolls 
            int TP1Total = 0;                                                               // this is the total of the test players score 
            
                    while (TsumOfDice != 7)                                                 // this runs if the roll total isn't 7
                    {

                        Die2();                                                             // this calls the dice method to roll the dice                                // this will asign a number to each of the dice 


                        TsumOfDice = die1.Value + die2.Value;                               // this adds the values of the dice together to ctreate the sumOfDice

                        if (die1.Value == die2.Value)                                       // this will run if the dice values are the same (doubles)
                        {

                            TP1Total = die1.Value + die1.Value + die2.Value + die2.Value +TP1Total;         // double the score rolled is added to the total score for player 2 

                        }
                        else                                                                // if the score isn't a double then the total is just added to the score 
                        {
                            TP1Total = die1.Value + die2.Value + TP1Total;                  // the score is added to the total 

                        }

                    }
                    Console.WriteLine("successful Test");                                   // this prints to tell the user the test was successful because the loop was exited after getting a 7 
                    TsumOfDice = 0;                                                         // this resets TsumOfDice to 0 
                    
            return TsumOfDice;                                                           
        }


        /// <summary>
        /// this rolls 2 dice for the seven out class and returns the sum of dice 
        /// </summary>
        /// <returns></returns>
        public int Die2()                                                                   // 5 dice rolls for player 2 
        {
            sumOfDice = 0;                                                                  // this zeros off sumOfDice 

            die1.Roll();
            Thread.Sleep(1);                                                                // this will add a delay of 1 milliseconds to  the dice roll and allow them to be more random
            die2.Roll();                                                                    // this will asign a number to each of the dice 


            sumOfDice = die1.Value + die2.Value;                                            // this adds the values of the dice together to ctreate the sumOfDice

            return sumOfDice;                                                               // this returns the total of all the dice 
        }
    }       
}
