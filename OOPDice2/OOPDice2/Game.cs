using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPDice2
{
    class Game : Statistics                                                 // this class inherits the statistics class 
    {
        
        
        string input = "no input given";                                    // this is used to store the input chosen for wich game to play 
        string testingInput = "test?";                                      // this is used to store the input for running the testing class or not  
        string statsInput = "stats";                                        // this is used to store the input for running statistics class or not 
        bool statBool = false;                                              // this is used to loop the run statistics question incase of incorrect input 
        bool testBool = false;                                              // this is used to loop the run tests question incase of incorrect input
        bool inputBool = false;                                             // this is used to loop the wich game would you like to play question incase of incorrect input 
       

        SevenOut seven = new SevenOut();                                    // this calls my seven out class 
        ThreeOrMore three = new ThreeOrMore();                              // this calls my thre eor more class 
        Testing t = new Testing();                                          // this calls my testing class

        /// <summary>
        /// this is the first thing to run and calls my menu 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            Game g = new Game();                                            // this callls the game class so i can go back to the menu when the game is finished
            g.StartMenu(g);                                                 // this calls my start menu class to ask what game you would like to play 

            Console.ReadLine();                                             // this reads the code so it can run 
        }

        ///<summary>
        /// This is a menu for players to pick which game they are going to play/ see score / test the game 
        ///</summary>
        public int StartMenu(Game g)            
        {
            inputBool = false;                                              // this makes sure the value of inputbool is re-set to false every time so the loop still runs 

            while (inputBool == false)                                      // if inoutbool is false run this 
            {
                Console.WriteLine("Which game would you like to play? (7,3)");
                input = Console.ReadLine();                                 // this asigns the player input to input 

                if (input == "7")                                           // if the input is 7 it will run the questions for the seven out game 
                {
                    inputBool = true;                                       // this sest inputbool to true to close the loop 
                    
                    statBool = false;                                       // this makes sure the value of statbool is re-set to false every time so the loop still runs

                    while (statBool == false)                               // if statbool is false this runs 
                    {
                        Console.WriteLine("Would you like to see the statistics? (y, n)");      
                        statsInput = Console.ReadLine();                    // this asigns the player input to stats input 

                        if (statsInput == "y")                              // if statsinput is y (yes) it runs calls the statistics method for seven out 
                        {
                            
                            seven.Stats7(seven);                            // this calls the statistics method for seven out 
                            statBool = true;                                // this sets statsbool to true to break the loop 
                        }
                        else if (statsInput == "n")                         // if the statsinput is n (no) noting runs 
                        {
                            statBool = true;                                // statbool is set to true to break the loop 
                        }
                        else                                                // if neither option was chosen its an incorrect input
                        {
                            Console.WriteLine("incorrect input");           // this prints to tell the user whats happened  
                            statBool = false;                               // this makes sure statbool stays false so the loop runs 
                        }

                    }
                    testBool = false;                                       // this makes sure testbool is false 

                    while (testBool == false)                               // if testbool is false run the loop 
                    {
                        Console.WriteLine("Would you like to test the game? (y, n)");
                        testingInput = Console.ReadLine();                  // this takes the user input for testing game question and asigns it testinginput

                        if (testingInput == "y")                            // if testinginput is y (yes) testing class is called 
                        {
                            t.RunningTest();                                // this calls the method for testing the game 
                            testBool = true;                                // this sets testbool to true so the loop stop running
                        }
                        else if (testingInput == "n")                       // if testinginput is n (no) nothing runs 
                        {
                            testBool = true;                                // the loop is set to true so it stops running 
                        }
                        else                                                // if its neither then its an incorrect input 
                        {
                            Console.WriteLine("incorrect input");           // this shows to tell the user whats happened 
                            testBool = false;                               // this keeps the loop as false so it runs again 
                        }
                    }


                    seven.SevenGame(g);                                     // after all that the seven game runs (thats what was selected first)
                    
                }
                else if (input == "3")                                      // this runs if 3 was chosen 
                {
                    inputBool = true;                                       // this sest inputbool to true to close the loop 

                    statBool = false;                                       // this makes sure the value of statbool is re-set to false every time so the loop still runs

                    while (statBool == false)                               // if statbool is false this runs 
                    {
                        Console.WriteLine("Would you like to see the statistics? (y, n)");
                        statsInput = Console.ReadLine();                    // this asigns the player input to stats input 

                        if (statsInput == "y")                              // if statsinput is y (yes) it runs calls the statistics method for three or more  
                        {

                            seven.Stats3(three);                            // this calls the statistics method for three or more  
                            statBool = true;                                // this sets statsbool to true to break the loop 
                        }
                        else if (statsInput == "n")                         // if the statsinput is n (no) noting runs 
                        {
                            statBool = true;                                // statbool is set to true to break the loop 
                        }
                        else                                                // if neither option was chosen its an incorrect input
                        {
                            Console.WriteLine("incorrect input");           // this prints to tell the user whats happened  
                            statBool = false;                               // this makes sure statbool stays false so the loop runs 
                        }

                    }
                    testBool = false;                                       // this makes sure testbool is false 

                    while (testBool == false)                               // if testbool is false run the loop 
                    {
                        Console.WriteLine("Would you like to test the game? (y, n)");
                        testingInput = Console.ReadLine();                  // this takes the user input for testing game question and asigns it testinginput

                        if (testingInput == "y")                            // if testinginput is y (yes) testing class is called 
                        {
                            t.RunningTest();                                // this calls the method for testing the game 
                            testBool = true;                                // this sets testbool to true so the loop stop running
                        }
                        else if (testingInput == "n")                       // if testinginput is n (no) nothing runs 
                        {
                            testBool = true;                                // the loop is set to true so it stops running 
                        }
                        else                                                // if its neither then its an incorrect input 
                        {
                            Console.WriteLine("incorrect input");           // this shows to tell the user whats happened 
                            testBool = false;                               // this keeps the loop as false so it runs again 
                        }
                    }

                    three.ThreePlusGame(g);                                 // after eveythings run the three or more game runs (thats what was originally chosen)
                }
                else                                                        // if neither option was chosen (3/7) tihs runs
                {
                    inputBool = false;                                      // input bool is set to false to make sure the loop still runs 
                    Console.WriteLine("incorrect input");                   // incorrect input is shown to the user to say whats happened 
                }
            }

            return 0;
        }


    }
}
