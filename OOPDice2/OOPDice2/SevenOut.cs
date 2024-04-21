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
    class SevenOut
    {
        /// <summary>
        /// This is my seven out game i will roll 2 dice and add the scores together and add it to the total if its a double i add double if its a 7 i add nothing 
        /// </summary>
        /// <returns></returns>
        /// 
        bool player1 = true;
        string play = "playing?";
        bool correctInput = false;
        public int P1Wins7 = 0;
        public int P2Wins7 = 0;
        public int SevenWinsTotal = 0;
        public int num = 0;
        int sumOfDice = 0;
        string quit = "quit";
        public int numOfPlays = 1;


        // i don't know how to gwt the data made in seven game in to statistics inheritance??
        public int SevenGame()
        {

            while (correctInput == false)
            {
                Console.WriteLine("Would you like to play against the computer? (y,n) ");
                play = Console.ReadLine();

                if (play == "n")
                {
                    Console.WriteLine("Playing Seven out");
                    correctInput = true;

                    int P1Total = 0;
                    int P2Total = 0;
                    bool Stop = false;
                    

                    Die die1 = new Die();
                    Die die2 = new Die();


                    while (Stop == false)
                    {

                        if (player1 == true)
                        {

                            while (sumOfDice != 7)
                            {

                                Console.WriteLine();                    // this is used to add a space between the player and the last thing on the terminal to make it easier to see 
                                Console.WriteLine("Player 1:");
                                Console.ReadLine();

                                die1.Roll();
                                Thread.Sleep(1);            // this will add a delay of 1 milliseconds to  the dice roll and allow them to be more random 
                                die2.Roll();                // this will asign a number to each of the dice 

                                Console.WriteLine("Rolls: ");            // this is text that will be shown to help users know what the numbers are 
                                Console.WriteLine(die1.Value);           // this prints the dice values 
                                Console.WriteLine(die2.Value);

                                sumOfDice = die1.Value + die2.Value;        // this adds the values of the dice together to ctreate the sumOfDice

                                if (die1.Value == die2.Value)
                                {
                                    //Console.WriteLine("DOUBLE");                                // this will print if the player gets a double 
                                    P1Total = die1.Value + die1.Value + die2.Value + die2.Value + P1Total;            // double the score rolled is added to the total score 

                                }
                                else
                                {
                                    P1Total = die1.Value + die2.Value + P1Total;                                  // the score is added to the total 

                                }

                            }
                            Console.WriteLine("Total: " + P1Total);
                            sumOfDice = 0;
                            player1 = false;

                            // this should add the scores of the player to the highscores list 
                            try
                            {

                                StreamWriter sw = new StreamWriter("C:\\Users\\Caitlin Mitchell\\source\\repos\\OOPDice2\\OOPDice2\\bin\\Debug\\highscores.txt");
                                Console.Write("Highscore: ");
                                sw.WriteLine(P1Total);
                                sw.Close();


                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception: " + e.Message);
                            }
                            //add p1total to highscores !!!!!!!!

                        }
                        else if (player1 == false)
                        {
                            while (sumOfDice != 7)
                            {

                                Console.WriteLine();                    // this is used to add a space between the player and the last thing on the terminal to make it easier to see 
                                Console.WriteLine("Player 2:");
                                Console.ReadLine();

                                die1.Roll();
                                Thread.Sleep(1);            // this will add a delay of 1 milliseconds to  the dice roll and allow them to be more random 
                                die2.Roll();                // this will asign a number to each of the dice 

                                Console.WriteLine("Rolls: ");            // this is text that will be shown to help users know what the numbers are 
                                Console.WriteLine(die1.Value);           // this prints the dice values 
                                Console.WriteLine(die2.Value);

                                sumOfDice = die1.Value + die2.Value;        // this adds the values of the dice together to ctreate the sumOfDice

                                if (die1.Value == die2.Value)
                                {
                                    //Console.WriteLine("DOUBLE");                                // this will print if the player gets a double 
                                    P2Total = die1.Value + die1.Value + die2.Value + die2.Value + P2Total;            // double the score rolled is added to the total score 

                                }
                                else
                                {
                                    P2Total = die1.Value + die2.Value + P2Total;                                  // the score is added to the total 

                                }

                            }
                            Stop = true;
                            Console.WriteLine("Total: " + P2Total);


                            // this should add the scores of player 2 to the highscores list 
                            try
                            {

                                StreamWriter sw = new StreamWriter("C:\\Users\\Caitlin Mitchell\\source\\repos\\OOPDice2\\OOPDice2\\bin\\Debug\\highscores.txt");
                                Console.Write("Highscore: ");
                                sw.WriteLine(P2Total);
                                sw.Close();


                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception: " + e.Message);
                            }


                        }
                        else
                        {
                            
                        }
                        
                    }
                    if (P1Total > P2Total)
                    {
                        Console.WriteLine("Gameover player 1 wins!");
                        Console.WriteLine("Player 1: " + P1Total + " Player 2: " + P2Total);       // this will show if player 1 wins 
                        numOfPlays++;
                        Console.WriteLine("quit (q) Main menu (click)");
                        quit = Console.ReadLine();
                        if (quit == "q")
                        {
                            break;
                        }
                        else
                        {
                            Game g = new Game();
                            g.StartMenu();
                        }
                        //break;
                    }
                    else if (P1Total < P2Total)
                    {
                        Console.WriteLine("Gameover player 2 wins!");
                        Console.WriteLine("Player 2: " + P2Total + " Player 1: " + P1Total);       // this will show if player 2 wins 
                        numOfPlays++;
                        Console.WriteLine("quit (q) Main menu (click)");
                        quit = Console.ReadLine();
                        if (quit == "q")
                        {
                            break;
                        }
                        else
                        {
                            Game g = new Game();
                            g.StartMenu();
                        }

                    }
                    else
                    {
                        Console.WriteLine("It's a tie !");
                        Console.WriteLine("Player 1 & Player 2: " + P1Total);               // this will show if both scores are the same 
                        numOfPlays++;

                        Console.WriteLine("quit (q) Main menu (click)");
                        quit = Console.ReadLine();
                        if (quit == "q")
                        {
                            break;
                        }
                        else
                        {
                            Game g = new Game();
                            g.StartMenu();
                        }
                    }

                }
                if (play == "y")
                {
                    Console.WriteLine("Playing Seven out against the computer");
                    Console.WriteLine("You are player 1 ");
                    correctInput = true;

                    int P1Total = 0;
                    int P2Total = 0;
                    bool Stop = false;

                    Die die1 = new Die();
                    Die die2 = new Die();


                    while (Stop == false)
                    {
                            if (player1 == true)
                            {
                                while (sumOfDice != 7)
                                {

                                    Console.WriteLine();                    // this is used to add a space between the player and the last thing on the terminal to make it easier to see 
                                    Console.WriteLine("Player 1:");
                                    Console.ReadLine();

                                    die1.Roll();
                                    Thread.Sleep(1);            // this will add a delay of 1 milliseconds to  the dice roll and allow them to be more random 
                                    die2.Roll();                // this will asign a number to each of the dice 

                                    Console.WriteLine("Rolls: ");            // this is text that will be shown to help users know what the numbers are 
                                    Console.WriteLine(die1.Value);           // this prints the dice values 
                                    Console.WriteLine(die2.Value);

                                    sumOfDice = die1.Value + die2.Value;        // this adds the values of the dice together to ctreate the sumOfDice

                                    if (die1.Value == die2.Value)
                                    {
                                        //Console.WriteLine("DOUBLE");                                // this will print if the player gets a double 
                                        P1Total = die1.Value + die1.Value + die2.Value + die2.Value + P1Total;            // double the score rolled is added to the total score 

                                    }
                                    else
                                    {
                                        P1Total = die1.Value + die2.Value + P1Total;                                  // the score is added to the total 

                                    }

                                }
                                Console.WriteLine("Total: " + P1Total);
                                sumOfDice = 0;
                                player1 = false;

                                // this will add player 1's score to the highscores list 
                                try
                                {

                                    StreamWriter sw = new StreamWriter("C:\\Users\\Caitlin Mitchell\\source\\repos\\OOPDice2\\OOPDice2\\bin\\Debug\\highscores.txt");
                                    Console.Write("Highscore: ");
                                    sw.WriteLine(P1Total);
                                    sw.Close();


                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Exception: " + e.Message);
                                }


                            }
                            else if (player1 == false)
                            {
                                while (sumOfDice != 7)
                                {

                                    Console.WriteLine();                    // this is used to add a space between the player and the last thing on the terminal to make it easier to see 
                                    Console.WriteLine("computer:");

                                    die1.Roll();
                                    Thread.Sleep(1);            // this will add a delay of 1 milliseconds to  the dice roll and allow them to be more random 
                                    die2.Roll();                // this will asign a number to each of the dice 

                                    Console.WriteLine("Rolls: ");            // this is text that will be shown to help users know what the numbers are 
                                    Console.WriteLine(die1.Value);           // this prints the dice values 
                                    Console.WriteLine(die2.Value);

                                    sumOfDice = die1.Value + die2.Value;        // this adds the values of the dice together to ctreate the sumOfDice

                                    if (die1.Value == die2.Value)
                                    {
                                        //Console.WriteLine("DOUBLE");                                // this will print if the player gets a double 
                                        P2Total = die1.Value + die1.Value + die2.Value + die2.Value + P2Total;            // double the score rolled is added to the total score 

                                    }
                                    else
                                    {
                                        P2Total = die1.Value + die2.Value + P2Total;                                  // the score is added to the total 

                                    }

                                }
                                Stop = true;
                                Console.WriteLine("Total: " + P2Total);

                                // this will add player 2's scores to highscores 
                                try
                                {

                                    StreamWriter sw = new StreamWriter("C:\\Users\\Caitlin Mitchell\\source\\repos\\OOPDice2\\OOPDice2\\bin\\Debug\\highscores.txt");
                                    Console.Write("Highscore: ");
                                    sw.WriteLine(P2Total);
                                    sw.Close();


                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Exception: " + e.Message);
                                }

                            }
                            else
                            {

                            }
                        
                    }
                    if (P1Total > P2Total)
                    {
                        Console.WriteLine("Gameover player 1 wins!");
                        Console.WriteLine("Player 1: " + P1Total + " Computer: " + P2Total);       // this will show if player 1 wins
                        numOfPlays++;

                        Console.WriteLine("quit (q) Main menu (click)");
                        quit = Console.ReadLine();
                        if (quit == "q")
                        {
                            break;
                        }
                        else
                        {
                            Game g = new Game();
                            g.StartMenu();
                        }
                    }
                    else if (P1Total < P2Total)
                    {
                        Console.WriteLine("Gameover Computer wins!");
                        Console.WriteLine("Computer: " + P2Total + " Player 1: " + P1Total);       // this will show if player 2 wins
                        numOfPlays++;

                        Console.WriteLine("quit (q) Main menu (click)");
                        quit = Console.ReadLine();
                        if (quit == "q")
                        {
                            break;
                        }
                        else
                        {
                            Game g = new Game();
                            g.StartMenu();
                        }

                    }
                    else
                    {
                        Console.WriteLine("It's a tie !");
                        Console.WriteLine("Player 1 & Computer: " + P1Total);               // this will show if both scores are the same
                        numOfPlays++;

                        Console.WriteLine("quit (q) Main menu (click)");
                        quit = Console.ReadLine();
                        if (quit == "q")
                        {
                            break;
                        }
                        else
                        {
                            Game g = new Game();
                            g.StartMenu();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");            // this will tell the user if there input is not one of the options the loop will allow them to try again 
                    correctInput = false;
                }
            }


            return num;
        }
    }       
}
