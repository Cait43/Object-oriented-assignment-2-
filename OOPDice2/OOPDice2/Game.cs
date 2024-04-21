using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPDice2
{
    class Game                        
    {
        
        ///<summary>
        /// This will be a menu for players to pick which game they are going to play/ see score / test the game 
        ///</summary>

        //Methods
        string input = "no input given";
        string testingInput = "test?";
        string statsInput = "stats";
        bool statBool = false;
        bool testBool = false;
        bool inputBool = false;

        static void Main(string[] args)             // this is the first thing that runs 
        {

            // testing object 
            Game g = new Game();
            g.StartMenu();                          // this calls my start menu class to ask what game you would like to play 

            Console.ReadLine();         // this reads the code so it can run 
        }
        public int StartMenu()            
        {
            while (inputBool == false)
            {
                Console.WriteLine("Which game would you like to play? (7,3)");
                input = Console.ReadLine();

                if (input == "7")
                {
                    inputBool = true;

                    while (statBool == false)
                    {
                        Console.WriteLine("Would you like to see the statistics? (y, n)");      //# this is showing when the game finisheds not before ?
                        statsInput = Console.ReadLine();

                        if (statsInput == "y")
                        {
                            Statistics s = new Statistics();
                            s.Stats7();
                            statBool = true;
                        }
                        else if (statsInput == "n")
                        {
                            statBool = true;
                        }
                        else
                        {
                            Console.WriteLine("incorrect input");
                            statBool = false;
                        }
                    }
                    while (testBool == false)
                    {
                        Console.WriteLine("Would you like to test the game? (y, n)");
                        testingInput = Console.ReadLine();

                        if (testingInput == "y")
                        {
                            Testing t = new Testing();
                            t.RunningTest();
                            testBool = true;
                        }
                        else if (testingInput == "n")
                        {
                            testBool = true;
                        }
                        else
                        {
                            Console.WriteLine("incorrect input");
                            testBool = false;
                        }
                    }

                    SevenOut seven = new SevenOut();

                    seven.SevenGame();
                    
                }
                else if (input == "3")
                {
                    inputBool = true;

                    while (statBool == false)
                    {
                        Console.WriteLine("Would you like to see the statistics? (y, n)");
                        statsInput = Console.ReadLine();

                        if (statsInput == "y")
                        {
                            Statistics s = new Statistics();
                            s.Stats3();
                            statBool = true;
                        }
                        else if (statsInput == "n")
                        {
                            statBool = true;
                        }
                        else
                        {
                            Console.WriteLine("incorrect input");
                            statBool = false;
                        }
                    }
                    while (testBool == false)
                    {
                        Console.WriteLine("Would you like to test the game? (y, n)");
                        testingInput = Console.ReadLine();

                        if (testingInput == "y")
                        {
                            Testing t = new Testing();
                            t.RunningTest();
                            testBool = true;
                        }
                        else if (testingInput == "n")
                        {
                            testBool = true;
                        }
                        else
                        {
                            Console.WriteLine("incorrect input");
                            testBool = false;
                        }
                    }
                    ThreeOrMore three = new ThreeOrMore();

                    three.ThreePlusGame();
                }
                else
                {
                    inputBool = false;
                    Console.WriteLine("incorrect input");
                }
            }

            return 0;
        }


    }
}
