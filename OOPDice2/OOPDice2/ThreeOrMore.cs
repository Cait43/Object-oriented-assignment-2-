using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace OOPDice2
{
    internal class ThreeOrMore : Statistics             // added inheritance 
    {
        List<int> listOfRolls = new List<int>();        // this is a list i will append the rolls to to check if they are the same number or not 
        List<int> listOfRolls2 = new List<int>();       // this is a list i will append the rolls to to check if they are the same number or not for player 2 
        List<int> points = new List<int>();             // this will check weather or not you can reroll
        List<int> points2 = new List<int>();            // this will check weather or not you can reroll for player 2 
        int Score = 0;                                  // this is the variable for player 1's score 
        int Score2 = 0;                                 // this is the varivble for player 2's score 
        int Count = 0;                                  // this varibale adds wheather the number is a double or not to the points list  
        int winner = 0;                                 // making a variable called winner if it gets to 20 will show a winner 
        int winner2 = 0;                                // making a variable called winner if it gets to 20 will show a winner 
        bool loop = true;                               // this will loop 
        bool pick = false;
        public int P1Wins3 = 0;                         // this is used to see how manny times player 1 has won 
        public int P2Wins3 = 0;                         // this is used to see how manny times player 2 has won
        public int numOfPlays3 = 0;
        //public int Total = 0;



        Die die1 = new Die();       // this creates 5 dice 
        Die die2 = new Die();
        Die die3 = new Die();
        Die die4 = new Die();
        Die die5 = new Die();


        public int ThreePlusGame(Game g )
        {
            while (pick == false)
            {

                Console.WriteLine("would you like to play against the computer? (y, n)");
                string choice = Console.ReadLine();

                if (choice == "n")
                {

                    pick = true;
                    Console.WriteLine("Playing Three or more ");

                    while (loop == true)
                    {
                        listOfRolls.Clear();                            // this will empty the list for when it loops so it wont be messed up by the past numbers 
                        listOfRolls2.Clear();                           // this will do the same for player 2 
                        points.Clear();                                 // this will empty the list for when it loops so it wont be messed up by the past numbers
                        points2.Clear();                                // this will do the same for player 2


                        int pair = 0;                                   // this will reset pairs to 0 so i don't get errors 
                        bool input = false;                             // this re-sets input to false so i don't get erros and the choce to re-roll will run  


                        Die15();                                        // this calls my die15 method to roll 5 dice 

                        Console.WriteLine("Player 1: ");                // this tells the user whos turn it is 
                        Console.ReadLine();                             // this allows player input 
                        Console.WriteLine("Rolls: ");                   // this is text that will be shown to help users know what the numbers are 
                        Console.WriteLine(die1.Value);                  // this prints the dice values 
                        Console.WriteLine(die2.Value);
                        Console.WriteLine(die3.Value);
                        Console.WriteLine(die4.Value);
                        Console.WriteLine(die5.Value);
                        Console.WriteLine();


                        int[] array = listOfRolls.ToArray();                            // this will reset arrays and lists by emptying them 

                        
                        listOfRolls.Clear();                                            // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it  

                        foreach (int rolls in array)                                    // for each of the rolls in my array (collection of dice rolls) do this ...
                        {
                            Count = 0;                                                  // this makes sure the counter is re-set to 0 for every run-through of the for loop 
                            for (int i = 0; i < array.Length; i++)                      // this will run though 5 times one for every roll so each number is being cheecked against everything in the list 
                            {

                                if (rolls == array[i])                                  // if the number your checking is the same as another number in the array do this ... 
                                {
                                    Count++;                                            // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)

                                }

                            }
                            points.Add(Count);                                          // this will add the counter to a list so that i can see which dice are duplicates
                                                                            

                        }
                        bool rerollbool = false;                                        // then sets rerollbool to false so avoid errors 
                        foreach (int rolls in points)                                   // this will run for every number in points (the list of doubles or not) 
                        {
                            if (rolls == 2)                                             // if there is a 2 the number appears twice ...
                            {
                                rerollbool = true;                                      // this sets rerollbool to true (don't exit yet could have a tribble and not need to reroll)
                            }
                            if (rolls == 3)                                             // this will run if there is a triple ...
                            {
                                rerollbool = false;                                     // rerollbool is set to false because you do not need to reroll
                                break;                                                  // this then stops the loop 
                            }
                            if (rolls == 4)                                             // this runs if ther eis 4 of the same number ...
                            {
                                rerollbool = false;                                     // rerollbool is set to false because you do not need to reroll
                                break;                                                  // this then stops the loop 
                            }
                            if (rolls == 5 )                                            // this will run if all the numbers are the same ...
                            {
                                rerollbool = false;                                     // rerollbool is set to false because you do not need to reroll
                                break;                                                  // this then stops the loop 
                            }

                        }
                        if (rerollbool == true)                                         // this runs if rerollbool is true (only if there is a double)
                        {

                            while (input == false)                                      // while input is false loop this ...
                            {
                                Console.Write("Would you like to re-roll all (1) or just non doubbles (2)? ");      // this asks the player if they want to reroll all dice or not 
                                string answer = Console.ReadLine();                     // this will asign player input to answer 

                                if (answer == "1")                                      // if they pick 1 (reroll all) this code runs ...
                                {
                                    input = true;                                       // input is set to true a correct input was given 

                                    Die15();                                            // this runs to roll 5 dice 


                                    Console.WriteLine("Rolls: ");                       // this is text that will be shown to help users know what the numbers are 
                                    Console.WriteLine(die1.Value);                      // this prints the dice values 
                                    Console.WriteLine(die2.Value);
                                    Console.WriteLine(die3.Value);
                                    Console.WriteLine(die4.Value);
                                    Console.WriteLine(die5.Value);

                                    

                                    listOfRolls.Clear();                                // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it
                                }
                                else if (answer == "2")                                 // if they pick 2 (reroll doubles) this code runs...
                                {
                                    input = true;                                       // input is set to true a correct input was given 

                                    int[] reroll = points.ToArray();                    // this transers the list of doubles or not to an array called reroll
                                    points.Clear();                                     // this clears points, this stops the check for doubles appearing twice in points 

                                    for (int i = 0; i < reroll.Length; i++)             // this runs for the length of reroll (5)
                                    {
                                        if (reroll[i] == 2)                             // if theres a 2 (double) do this ...
                                        {
                                            pair = reroll[i];                           // this sets pair to the the program is up to 
                                        }
                                        else if (reroll[i] == 1)                        // if the number is 1 (not doubel) do this ...
                                        {
                                            Thread.Sleep(1);                            // this rolls 1 dice 
                                            array[i] = die1.Roll();
                                            Console.WriteLine(die1.Value);              // this prints the dice value 

                                        }


                                    }
                                    Array.Clear(reroll, 0, reroll.Length);              // this cleares reroll (all that need to be reroled have) to prevent errors 

                                }
                                else                                                    // if 1 or 2 werent chosen run this 
                                {
                                    Console.WriteLine("invalid input ");                // this tells the user whats happened 
                                    input = false;                                      // this makes sure input is sest to false to keep running the loop 
                                }
                            }

                            points.Clear();                                             // this stops the check for doubles appearing twice in points 
                            foreach (int rolls in array)                                // this is the same as before to rechech for doubles or tripples ext
                            {
                                Count = 0;
                                for (int i = 0; i < array.Length; i++)                  // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)
                                {

                                    if (rolls == array[i])                              // if the number your checking is the same as another number in the array do this ... 
                                    {
                                        Count++;                                        // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)

                                    }

                                }
                                points.Add(Count);                                      // this will add the counter to a list so that i can see which dice are duplicates
                                

                            }
                            Array.Clear(array, 0, array.Length);                        // this will clear the array so past uses wont mess with what should be in the array now 
                        }

                        foreach (int number in points)                                  // this runs through all the numbers in the points list 
                        {

                            if (number == 3)                                            // if theres a 3 (triple)...
                            {
                                Score = Score + 3;                                      // adds 3 points to the score 
                                winner = Score;                                         // winner is score so i can use this to see whos won
                                Console.WriteLine("Score: " + winner);                  // this prints player points 
                                break;                                                  // this stops looping for all numbers 
                            }
                            else if (number == 4)                                       // if theres a 4 (quadruple)...
                            {
                                Score = Score + 6;                                      // 6 points are added to the score 
                                winner = Score;                                         // winner is score so i can use this to see whos won
                                Console.WriteLine("Score: " + winner);                  // this prints player points 
                                break;                                                  // this stops looping for all numbers 
                            }
                            else if (number == 5)                                       // if theres a 5...
                            {
                                Score = Score + 12;                                     // 12 points are adde to the score 
                                winner = Score;                                         // winner is score so i can use this to see whos won
                                Console.WriteLine("Score: " + winner);                  // this prints player points 
                                break;                                                  // this stops looping for all numbers 
                            }
                            else                                                        // if nothing then do nothing 
                            {

                            }
                        }

                            if (winner >= 20)                                           // if player 1's points are higher than 20 run this ...
                            {
                                Console.WriteLine("player 1 wins!!");                   // this shows the user whos won
                                Console.WriteLine("Player 1: " + winner + " Player 2: " + winner2);       // this will show both player scores
                                P1Wins3++;                                              // this increases how many times player 1 has won 
                                numOfPlays3++;                                          // this increases the number of times the game has ben made 

                                Console.WriteLine("---Main menu---");                   // this separates the scores and the main menu 

                                g.StartMenu(g);                                         // this calls the main menu 
                                loop = false;                                           // this breakes the while loop because someone has won 
                                break;                                                  // this stops it running anymore
                            }
                            else if (winner2 >= 20)                                     // this runs if player 2 has more than 20 
                            {
                                Console.WriteLine("player 2 wins!!");                   // if it is then player 1 has won 
                                Console.WriteLine("Player 2: " + winner2 + " Player 1: " + winner);       // this will show both player scores
                                P2Wins3++;                                              // this increases the number of wins for player 2 
                                numOfPlays3++;                                          // this increases the number of times the game has been played 

                                Console.WriteLine("---Main menu---");                   // this separates the scores and the main menu 

                                g.StartMenu(g);                                         // this calls the main menu 
                                loop = false;                                           // this breakes the while loop because someone has won 
                                break;                                                  // this stops it running anymore
                            }
                            else                                                        // if neither have won run this ...
                            {
                                loop = true;                                            // this keeps the game running 
                            }




                        /// <summary>
                        /// This runs for player 2's turn 
                        /// </summary>
                        /// <returns></returns>


                        int pair2 = 0;                                                  // this will reset pairs to 0 so i don't get errors 
                        bool input2 = false;                                            // this re-sets input to false so i don't get erros and the choce to re-roll will run 


                        Die25();                                                        // this calls the dice method 

                        Console.WriteLine("Player 2: ");                                // this says whos turn it is 
                        Console.ReadLine();
                        Console.WriteLine("Rolls: ");                                   // this is text that will be shown to help users know what the numbers are 
                        Console.WriteLine(die1.Value);                                  // this prints the dice values 
                        Console.WriteLine(die2.Value);
                        Console.WriteLine(die3.Value);
                        Console.WriteLine(die4.Value);
                        Console.WriteLine(die5.Value);
                        Console.WriteLine();


                        int[] array2 = listOfRolls2.ToArray();                          // this will reset arrays and lists by emptying them 

                        listOfRolls2.Clear();                                           // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it

                        foreach (int rolls2 in array2)
                        {
                            int Count2 = 0;
                            for (int i = 0; i < array2.Length; i++)                     // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)
                            {

                                if (rolls2 == array2[i])                                // if the number in the array is the same as the number the foreach is currently checcking do this ...
                                {
                                    Count2++;                                           // this will put a mark for every number in the list if it appears twice it will get 2 if 3 times 3 ext

                                }

                            }
                            points2.Add(Count2);                                        // this will add the counter to a list so that i can see which dice are duplicates
                                                                              

                        }
                        bool rerollbool2 = false;                                       // this sets rerollbool to false to prevent errors 
                        foreach (int rolls2 in points2)
                        {
                            if (rolls2 == 2)                                            // if there is a 2 the number appears twice ...
                            {
                                rerollbool2 = true;                                      // this sets rerollbool to true (don't exit yet could have a tribble and not need to reroll)
                            }
                            if (rolls2 == 3)                                            // this will run if there is a triple ...
                            {
                                rerollbool2 = false;                                     // rerollbool is set to false because you do not need to reroll
                                break;                                                  // this then stops the loop 
                            }
                            if (rolls2 == 4)                                            // this runs if there is 4 of the same number ...
                            {
                                rerollbool2 = false;                                     // rerollbool is set to false because you do not need to reroll
                                break;                                                  // this then stops the loop 
                            }
                            if (rolls2 == 5)                                            // this will run if all the numbers are the same ...
                            {
                                rerollbool2 = false;                                     // rerollbool is set to false because you do not need to reroll
                                break;                                                  // this then stops the loop 
                            }
                        }
                        if (rerollbool2 == true)                                        // if points finds doubles it will run this code 
                        {
                            while (input2 == false)                                     // while input2 is flase loop reroll all or not 
                            {
                                Console.Write("Would you like to re-roll all (1) or just non doubbles (2)? ");      // this asks if the player wants to reroll just non doubles or all dice 
                                string answer2 = Console.ReadLine();                    // this takes the players answer

                                if (answer2 == "1")                                     // if all dice are to be re-rolled this runs 
                                {
                                    input2 = true;                                      // this tells the code that a correct input was given and the loop can close 

                                    Die25();                                            // this calls the method to roll player 2's dice 

                                    Console.WriteLine("Rolls: ");                       // this is text that will be shown to help users know what the numbers are 
                                    Console.WriteLine(die1.Value);                      // this prints the dice values 
                                    Console.WriteLine(die2.Value);
                                    Console.WriteLine(die3.Value);
                                    Console.WriteLine(die4.Value);
                                    Console.WriteLine(die5.Value);

                                    listOfRolls2.Clear();                               // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it
                                }
                                else if (answer2 == "2")                                // if option 2 is picked run this ...
                                {
                                    input2 = true;                                      // this tells the code that a correct input was given and the loop can close 

                                    int[] reroll2 = points2.ToArray();                  // this transers the list of doubles or not to an array called reroll
                                    points2.Clear();                                    // this stops the check for doubles appearing twice in points list

                                    for (int i = 0; i < reroll2.Length; i++)            // for every number in re-roll array run this code 
                                    {
                                        if (reroll2[i] == 2)
                                        {
                                            pair2 = reroll2[i];                         // this checks if the dice was a double 
                                        }
                                        else if (reroll2[i] == 1)
                                        {
                                            Thread.Sleep(1);                            // this re-rolls the dice that aren't doubles 
                                            array2[i] = die1.Roll();
                                            Console.WriteLine(die1.Value);              // this displays the new dice number 


                                        }
                                    }

                                    Array.Clear(reroll2, 0, reroll2.Length);            // this clears the re-roll array so that when the code loops for the plays turn again there aren't old number still in there to cause issues 

                                }
                                else
                                {
                                    Console.WriteLine("invalid input ");                // this shows if n or y was not given then the code loops to give them another chance 
                                    input2 = false;                                     // this tells the code that an incorrect input was given and the loop still needs to run 
                                }
                            }

                            points2.Clear();                                            // this will clear if there isn't a double 
                            foreach (int rolls2 in array2)
                            {
                                int Count2 = 0;                                         // this sets the counter to 0 so numbers don't gets messed up (2 becomes a 3 and they get points ext)
                                for (int i = 0; i < array2.Length; i++)                 // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)
                                {

                                    if (rolls2 == array2[i])
                                    {
                                        Count2++;                                       // this adds to the counter 

                                    }

                                }
                                points2.Add(Count2);                                    // this will add the counter to a list so that i can see which dice are duplicates
                                                                                

                            }
                            Array.Clear(array2, 0, array2.Length);                      // this will clean the array so past uses wont mess with what should be in the array now 
                        }

                        foreach (int number2 in points2)
                        {
                            if (number2 == 3)                                           // if theres a 3 run this ...
                            {
                                Score2 = Score2 + 3;                                    // this adds the players points to the score 
                                winner2 = Score2;                                       // score is moved to winning this will be checked to see if it is past/ equal 20 
                                Console.WriteLine("Score: " + winner2);                 // this writes the new score so it can be seen by the player 
                                break;
                            }
                            else if (number2 == 4)                                      // if theres a 4 do this...
                            {
                                Score2 = Score2 + 6;                                    // this adds more points because they have 4 of a kind 
                                winner2 = Score2;                                       // score is moved to winning this will be checked to see if it is past/ equal 20 
                                Console.WriteLine("Score: " + winner2);                 // this writes the new score so it can be seen by the player
                                break;
                            }
                            else if (number2 == 5)                                      // if there is 5 of a kind run this ...
                            {
                                Score2 = Score2 + 12;                                   // this adds more points because they have all the same 
                                winner2 = Score2;                                       // score is moved to winning this will be checked to see if it is past/ equal 20 
                                Console.WriteLine("Score: " + winner2);                 // this writes the new score so it can be seen by the player
                                break;
                            }
                            else                                                        // if there are non do nothing / no points  
                            {

                            }
                        }

                            if (winner >= 20)                                           // this checks if player 1's score is 20 or above 
                            {
                                Console.WriteLine("player 1 wins!!");                   // if it is then player 1 has won 
                                Console.WriteLine("Player 1: " + winner + " Player 2: " + winner2);       // this will show both player scores
                                P1Wins3++;                                              // this adds 1 to player 1 's wins 
                                numOfPlays3++;                                          // this increases the number of times the game has been played 

                                Console.WriteLine("---Main menu---");                   // this tells the player that this is the main menu now 

                                g.StartMenu(g);                                         // this calls my main menu 
                                loop = false;                                           // this breakes the while loop because someone has won 
                                break;                                                  // this stops it running anymore 
                            }
                            else if (winner2 >= 20)                                     // this checks player 2's score 
                            {
                                Console.WriteLine("player 2 wins!!");                   // this shows if player 2 has won 
                                Console.WriteLine("Player 2: " + winner2 + " Player 1: " + winner);       // this will show both player scores
                                P2Wins3++;                                              // this adds 1 to player 1 's wins 
                                numOfPlays3++;                                          // this increases the number of times the game has been played 

                                Console.WriteLine("---Main menu---");                   // this tells the player that this is the main menu now 

                                g.StartMenu(g);                                         // this calls my main menu 
                                loop = false;                                           // this breakes the while loop because someone has won
                                break;                                                  // this stops it running anymore 
                            }
                            else                                                        // if known has won run this ...
                            {
                                loop = true;                                            // this keeps the loop running 
                            }

                    }
                    

                }
                else if (choice == "y")                                                 // this runs if you chose to play against the computer 
                {
                    pick = true;                                                        // this sets the pick to true so the loop knows that a correct input was choses and the loop can stop 

                    Console.WriteLine("Playing Three or more against the computer ");   // this tells the player they are playing against the computer  

                    while (loop == true)
                    {
                        listOfRolls.Clear();                                            // this will empty the list for when it loops so it wont be messed up by the past numbers 
                        listOfRolls2.Clear();                                           // this will do the same for player 2 
                        points.Clear();                                                 // this will empty the list for when it loops so it wont be messed up by the past numbers
                        points2.Clear();                                                // this will do the same for player 2


                        int pair = 0;                                                   // this will reset pairs to 0 so i don't get errors 
                        bool input = false;                                             // this re-sets input to false so i don't get erros and the choce to re-roll will run  


                        Die15();                                                        // this calls my die15 method to roll 5 dice 

                        Console.WriteLine("Player 1: ");                                // this says its player 1's turn 
                        Console.ReadLine();                                             // the player clicks to roll dice 
                        Console.WriteLine("Rolls: ");                                   // this is text that will be shown to help users know what the numbers are 
                        Console.WriteLine(die1.Value);                                  // this prints the dice values 
                        Console.WriteLine(die2.Value);
                        Console.WriteLine(die3.Value);
                        Console.WriteLine(die4.Value);
                        Console.WriteLine(die5.Value);
                        Console.WriteLine();                                            // this adds space between the rolls and the rest of the game 


                        int[] array = listOfRolls.ToArray();                            // try resetting arrays and lists by emptying them 


                        listOfRolls.Clear();                                            // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it  

                        foreach (int rolls in array)
                        {
                            Count = 0;                                                  // this rests the counter to 0 
                            for (int i = 0; i < array.Length; i++)                      // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)
                            {

                                if (rolls == array[i])
                                {
                                    Count++;                                            // this will increase the counter 

                                }

                            }
                            points.Add(Count);                                          // this will add the counter to a list so that i can see which dice are duplicates
                                                                            

                        }
                        bool rerollbool = false;
                        foreach (int rolls in points)
                        {
                            if (rolls == 2)                                             // if there is a 2 the number appears twice ...
                            {
                                rerollbool = true;                                      // this sets rerollbool to true (don't exit yet could have a tribble and not need to reroll)
                            }
                            if (rolls == 3)                                             // this will run if there is a triple ...
                            {
                                rerollbool = false;                                     // rerollbool is set to false because you do not need to reroll
                                break;                                                  // this then stops the loop 
                            }
                            if (rolls == 4)                                             // this runs if there is 4 of the same number ...
                            {
                                rerollbool = false;                                     // rerollbool is set to false because you do not need to reroll
                                break;                                                  // this then stops the loop 
                            }
                            if (rolls == 5)                                             // this will run if all the numbers are the same ...
                            {
                                rerollbool = false;                                     // rerollbool is set to false because you do not need to reroll
                                break;                                                  // this then stops the loop 
                            }
                        }
                        if (rerollbool == true)                                         // if rerollbool is true run this ...
                        {

                            while (input == false)                                      // while input is false ask if they want to reroll all or not 
                            {
                                Console.Write("Would you like to re-roll all (1) or just non doubbles (2)? ");
                                string answer = Console.ReadLine();                     // this takes the players input 

                                if (answer == "1")                                      // if the answer is 1 run this ...
                                {
                                    input = true;                                       // sets input to true to send the loop 

                                    Die15();                                            // this calls the dice to roll 


                                    Console.WriteLine("Rolls: ");                       // this is text that will be shown to help users know what the numbers are 
                                    Console.WriteLine(die1.Value);                      // this prints the dice values 
                                    Console.WriteLine(die2.Value);
                                    Console.WriteLine(die3.Value);
                                    Console.WriteLine(die4.Value);
                                    Console.WriteLine(die5.Value);

                                    listOfRolls.Clear();                                // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it
                                }
                                else if (answer == "2")                                 // if answer is 2 run this ...
                                {
                                    input = true;                                       // sets input to true to stop the loop 

                                    int[] reroll = points.ToArray();
                                    points.Clear();                                     // this stops the check for doubles appearing twice in points 

                                    for (int i = 0; i < reroll.Length; i++)             // this runs for the length of reroll (5)
                                    {
                                        if (reroll[i] == 2)                             // if theres a 2 (double) do this ...
                                        {
                                            pair = reroll[i];                           // this sets pair to the the program is up to 
                                        }
                                        else if (reroll[i] == 1)                        // if the number is 1 (not doubel) do this ...
                                        {
                                            Thread.Sleep(1);                            // this rolls 1 dice 
                                            array[i] = die1.Roll();
                                            Console.WriteLine(die1.Value);              // this prints the dice value 

                                        }


                                    }
                                    Array.Clear(reroll, 0, reroll.Length);              // this will clear the array so past uses wont mess with what should be in the array now 

                                }
                                else
                                {
                                    Console.WriteLine("invalid input ");                // this prints to tell the user the input is not accepted 
                                    input = false;                                      // this will keep the loop running so they can try again 
                                }
                            }

                            points.Clear();                                             // this stops the check for doubles numbers appearing twice in points 
                            foreach (int rolls in array)
                            {
                                Count = 0;                                              // this makes sure the counter is re-set to 0 for every run-through of the for loop 
                                for (int i = 0; i < array.Length; i++)                  // this will run though 5 times one for every roll so each number is being cheecked against everything in the list 
                                {

                                    if (rolls == array[i])                              // if the number your checking is the same as another number in the array do this ... 
                                    {
                                        Count++;                                        // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)

                                    }

                                }
                                points.Add(Count);                                      // this will add the counter to a list so that i can see which dice are duplicates


                            }
                            Array.Clear(array, 0, array.Length);                        // this will clean the array so past uses wont mess with what should be in the array now 
                        }

                        foreach (int number in points)
                        {

                            if (number == 3)                                            // if theres a 3 (triple)...
                            {
                                Score = Score + 3;                                      // adds 3 points to the score 
                                winner = Score;                                         // winner is score so i can use this to see whos won
                                Console.WriteLine("Score: " + winner);                  // this prints player points 
                                break;                                                  // this stops looping for all numbers 
                            }
                            else if (number == 4)                                       // if theres a 4 (quadruple)...
                            {
                                Score = Score + 6;                                      // 6 points are added to the score 
                                winner = Score;                                         // winner is score so i can use this to see whos won
                                Console.WriteLine("Score: " + winner);                  // this prints player points 
                                break;                                                  // this stops looping for all numbers 
                            }
                            else if (number == 5)                                       // if theres a 5...
                            {
                                Score = Score + 12;                                     // 12 points are adde to the score 
                                winner = Score;                                         // winner is score so i can use this to see whos won
                                Console.WriteLine("Score: " + winner);                  // this prints player points 
                                break;                                                  // this stops looping for all numbers 
                            }
                            else                                                        // if nothing then do nothing 
                            {

                            }
                        }

                        if (winner >= 20)                                               // this checks if player 1's score is 20 or above 
                        {
                            Console.WriteLine("player 1 wins!!");                       // if it is then player 1 has won 
                            Console.WriteLine("Player 1: " + winner + " computer: " + winner2);       // this will show both player scores
                            P1Wins3++;                                                  // this adds 1 to player 1 's wins 
                            numOfPlays3++;                                              // this increases the number of times the game has been played 

                            Console.WriteLine("---Main menu---");                       // this tells the player that this is the main menu now 

                            g.StartMenu(g);                                             // this calls my main menu 
                            loop = false;                                               // this breakes the while loop because someone has won 
                            break;                                                      // this stops it running anymore 
                        }
                        else if (winner2 >= 20)
                        {
                            Console.WriteLine("computer wins!!");
                            Console.WriteLine("computer: " + winner2 + " Player 1: " + winner);       // this will show both player scores
                            numOfPlays3++;

                            Console.WriteLine("---Main menu---");                       // this tells the player that this is the main menu now 

                            g.StartMenu(g);                                             // this calls my main menu 
                            loop = false;                                               // this breakes the while loop because someone has won 
                            break;                                                      // this stops it running anymore 
                        }
                        else
                        {
                            loop = true;                                                // if no one has won the loop continues 
                        }




                        /// <summary>
                        /// This runs the computers turn  
                        /// </summary>
                        /// <returns></returns>


                        int pair2 = 0;                                                  // this will reset pairs to 0 so i don't get errors 
                        bool input2 = false;                                            // this re-sets input to false so i don't get erros and the choce to re-roll will run


                        Die25();                                                        // this calls the dice to roll 

                        Console.WriteLine("computer: ");
                        Console.WriteLine("Rolls: ");                                   // this is text that will be shown to help users know what the numbers are 
                        Console.WriteLine(die1.Value);                                  // this prints the dice values 
                        Console.WriteLine(die2.Value);
                        Console.WriteLine(die3.Value);
                        Console.WriteLine(die4.Value);
                        Console.WriteLine(die5.Value);
                        Console.WriteLine();


                        int[] array2 = listOfRolls2.ToArray();

                        listOfRolls2.Clear();                                           // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it

                        foreach (int rolls2 in array2)
                        {
                            int Count2 = 0;                                             // this resets the counter2 to 0 
                            for (int i = 0; i < array2.Length; i++)                     // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)
                            {

                                if (rolls2 == array2[i])
                                {
                                    Count2++;                                           // this will put a mark for every number in the list if it appears twice it will get 2 if 3 times 3 ext

                                }

                            }
                            points2.Add(Count2);                                        // this will add the counter to a list so that i can see which dice are duplicates


                        }
                        bool rerollbool2 = false;
                        foreach (int rolls2 in points2)
                        {
                            if (rolls2 == 2)                                            // if there is a 2 the number appears twice ...
                            {
                                rerollbool2 = true;                                      // this sets rerollbool to true (don't exit yet could have a tribble and not need to reroll)
                            }
                            if (rolls2 == 3)                                            // this will run if there is a triple ...
                            {
                                rerollbool2 = false;                                     // rerollbool is set to false because you do not need to reroll
                                break;                                                  // this then stops the loop 
                            }
                            if (rolls2 == 4)                                            // this runs if there is 4 of the same number ...
                            {
                                rerollbool2 = false;                                     // rerollbool is set to false because you do not need to reroll
                                break;                                                  // this then stops the loop 
                            }
                            if (rolls2 == 5)                                            // this will run if all the numbers are the same ...
                            {
                                rerollbool2 = false;                                     // rerollbool is set to false because you do not need to reroll
                                break;                                                  // this then stops the loop 
                            }
                        }
                        if (rerollbool2 == true)                                        // if points finds doubles it will run this code 
                        {
                            while (input2 == false)
                            {
                                Console.WriteLine("Would you like to re-roll all (1) or just non doubbles (2)? ");      // this asks if the player wants to reroll just non doubles or all dice 
                                Thread.Sleep(1);                                        // because the computer can't pick this will add a delay so it doesn't just all appear on the screen at once 

                                // this is the same as option 2 for player 1 because this is the most likely option to get points the computer will always run this 
                                
                                input2 = true;                                          // this tells the code that a correct input was given and the loop can close 

                                int[] reroll2 = points2.ToArray();
                                points2.Clear();                                        // this stops the check for doubles appearing twice in points list

                                for (int i = 0; i < reroll2.Length; i++)                // for every number in re-roll array run this code 
                                {
                                    if (reroll2[i] == 2)
                                    {
                                       pair2 = reroll2[i];                              // this checks if the dice was a double 
                                    }
                                    else if (reroll2[i] == 1)
                                    {
                                        Thread.Sleep(1);                                // this re-rolls the dice that arent doubles 
                                        array2[i] = die1.Roll();
                                        Console.WriteLine(die1.Value);                  // this displays the new dice number 


                                    }
                                }

                                Array.Clear(reroll2, 0, reroll2.Length);                // this clears the re-roll array so that when the code loops for the plays turn again there aren't old number still in there to cause issues 

                                
                                
                            }

                            points2.Clear();                                            // this will clear if there isn't a double 
                            foreach (int rolls2 in array2)
                            {
                                int Count2 = 0;                                         // this sets the counter to 0 so numbers don't gets messed up (2 becomes a 3 and they get points ext)
                                for (int i = 0; i < array2.Length; i++)                 // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)
                                {

                                    if (rolls2 == array2[i])
                                    {
                                        Count2++;                                       // this adds to the counter 

                                    }

                                }
                                points2.Add(Count2);                                    // this will add the counter to a list so that i can see which dice are duplicates


                            }
                            Array.Clear(array2, 0, array2.Length);                      // this will clean the array so past uses wont mess with what should be in the array now 
                        }

                        foreach (int number2 in points2)
                        {
                            if (number2 == 3)                                           // if theres 3 ...
                            {
                                Score2 = Score2 + 3;                                    // this adds the players points to the score 
                                winner2 = Score2;                                       // score is moved to winning this will be checked to see if it is past/ equal 20 
                                Console.WriteLine("Score: " + winner2);                 // this writes the new score so it can be seen by the player 
                                break;
                            }
                            else if (number2 == 4)                                      // if theres 4 ...
                            {
                                Score2 = Score2 + 6;                                    // this adds more points because they have 4 of a kind 
                                winner2 = Score2;                                       // score is moved to winning this will be checked to see if it is past/ equal 20 
                                Console.WriteLine("Score: " + winner2);                 // this writes the new score so it can be seen by the player
                                break;
                            }
                            else if (number2 == 5)                                      // if theres 5 ...
                            {
                                Score2 = Score2 + 12;                                   // this adds more points because they have all the same 
                                winner2 = Score2;                                       // score is moved to winning this will be checked to see if it is past/ equal 20 
                                Console.WriteLine("Score: " + winner2);                 // this writes the new score so it can be seen by the player
                                break;
                            }
                            else                                                        // if theres non do nothing 
                            {

                            }
                        }

                        if (winner >= 20)                                               // this checks if player 1's score is 20 or above 
                        {
                            Console.WriteLine("player 1 wins!!");                       // if it is then player 1 has won 
                            Console.WriteLine("Player 1: " + winner + " computer: " + winner2);       // this will show both player scores
                            P1Wins3++;                                                  // this adds 1 to player 1 's wins 
                            numOfPlays3++;                                              // this increases the number of times the game has been played 

                            Console.WriteLine("---Main menu---");                       // this tells the player that this is the main menu now 

                            g.StartMenu(g);                                             // this calls my main menu 
                            loop = false;                                               // this breakes the while loop because someone has won 
                            break;                                                      // this stops it running anymore 
                        }
                        else if (winner2 >= 20)
                        {
                            Console.WriteLine("computer wins!!");
                            Console.WriteLine("computer: " + winner2 + " Player 1: " + winner);       // this will show both player scores
                            numOfPlays3++;

                            Console.WriteLine("---Main menu---");                       // this tells the player that this is the main menu now 

                            g.StartMenu(g);                                             // this calls my main menu 
                            loop = false;                                               // this breakes the while loop because someone has won 
                            break;                                                      // this stops it running anymore 
                        }
                        else
                        {
                            loop = true;                                                // if no one has won the loop continues 
                        }


                    }
                }
                else
                {
                    Console.WriteLine("invalid input");                                 // this prints to tell the user why it has looped again 
                    pick = false;                                                       // this sets the loop to false so it will loop back round and ask do you want to play against the computer again 
                }
                
                
            }

            return Score;
        }
        /// <summary>
        /// this is used to roll 5 dice for player 2 for three or more 
        /// </summary>
        /// <returns></returns>
        public List<int> Die25()                                // 5 dice rolls for player 2 
        {
            listOfRolls2.Clear();

            die1.Roll();
            listOfRolls2.Add(die1.Value);
            Thread.Sleep(1);                                    // this will add a delay of 1 milliseconds to  the dice roll and allow them to be more random
            die2.Roll();                                        // this will asign a number to each of the dice 
            listOfRolls2.Add(die2.Value);                       // this will add the dice values to the list 
            Thread.Sleep(1);
            die3.Roll();
            listOfRolls2.Add(die3.Value);
            Thread.Sleep(1);
            die4.Roll();
            listOfRolls2.Add(die4.Value);
            Thread.Sleep(1);
            die5.Roll();
            listOfRolls2.Add(die5.Value);

            return listOfRolls2;
        }
        /// <summary>
        /// this is used to roll 5 dice for player 1 for three or more 
        /// </summary>
        /// <returns></returns>
        public List<int> Die15()                               // 5 dice rolls for player 2 
        {
            listOfRolls.Clear();

            die1.Roll();
            listOfRolls.Add(die1.Value);
            Thread.Sleep(1);                                   // this will add a delay of 1 milliseconds to  the dice roll and allow them to be more random
            die2.Roll();                                       // this will asign a number to each of the dice 
            listOfRolls.Add(die2.Value);                       // this will add the dice values to the list 
            Thread.Sleep(1);
            die3.Roll();
            listOfRolls.Add(die3.Value);
            Thread.Sleep(1);
            die4.Roll();
            listOfRolls.Add(die4.Value);
            Thread.Sleep(1);
            die5.Roll();
            listOfRolls.Add(die5.Value);

            return listOfRolls;
        }

        public int testThree()
        {
            // they all have T in from of them because they are part of the testing method so they don't mess with the game

            List<int> TlistOfRolls2 = new List<int>();                                  // this is a list i will append the rolls to to check if they are the same number or not for player 2 
            List<int> Tpoints2 = new List<int>();                                       // this will check weather or not you can reroll for player 2 
            int TScore2 = 0;                                                            // this is the varivble for player 2's score 
            int TCount2 = 0;                                                            // this varibale adds wheather the number is a double or not to the points list  
            int Twinner2 = 0;                                                           // making a variable called winner if it gets to 20 will show a winner 
            bool Trerollbool2 = false;

            while (Twinner2 < 20)
            {

                Tpoints2.Clear();
                int Tpair2 = 0;                                                         // this will reset pairs to 0 so i don't get errors 


                die1.Roll();
                TlistOfRolls2.Add(die1.Value);
                Thread.Sleep(1);                                                        // this will add a delay of 1 milliseconds to  the dice roll and allow them to be more random
                die2.Roll();                                                            // this will asign a number to each of the dice 
                TlistOfRolls2.Add(die2.Value);                                          // this will add the dice values to the list 
                Thread.Sleep(1);
                die3.Roll();
                TlistOfRolls2.Add(die3.Value);
                Thread.Sleep(1);
                die4.Roll();
                TlistOfRolls2.Add(die4.Value);
                Thread.Sleep(1);
                die5.Roll();
                TlistOfRolls2.Add(die5.Value);

                int[] Tarray2 = TlistOfRolls2.ToArray();

                TlistOfRolls2.Clear();                                                  // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it

                foreach (int Trolls2 in Tarray2)   
                {
                    TCount2 = 0;                                                        // this resets the Tcounter2 to 0 
                    for (int i = 0; i < Tarray2.Length; i++)                            // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)
                    {

                        if (Trolls2 == Tarray2[i])
                        {
                            TCount2++;                                                  // this will put a mark for every number in the list if it appears twice it will get 2 if 3 times 3 ext

                        }

                    }
                    Tpoints2.Add(TCount2);                                              // this will add the counter to a list so that i can see which dice are duplicates


                }
                
                foreach (int Trolls2 in Tpoints2)
                {
                    if (Trolls2 == 2)                                                   // if there is a 2 the number appears twice ...
                    {
                        Trerollbool2 = true;                                            // this sets rerollbool to true (don't exit yet could have a tribble and not need to reroll)
                    }
                    if (Trolls2 == 3)                                                   // this will run if there is a triple ...
                    {
                        Trerollbool2 = false;                                           // rerollbool is set to false because you do not need to reroll
                        break;                                                          // this then stops the loop 
                    }
                    if (Trolls2 == 4)                                                   // this runs if there is 4 of the same number ...
                    {
                        Trerollbool2 = false;                                           // rerollbool is set to false because you do not need to reroll
                        break;                                                          // this then stops the loop 
                    }
                    if (Trolls2 == 5)                                                   // this will run if all the numbers are the same ...
                    {   
                        Trerollbool2 = false;                                           // rerollbool is set to false because you do not need to reroll
                        break;                                                          // this then stops the loop 
                    }
                }
                if (Trerollbool2 == true)                                               // if points finds doubles it will run this code 
                {
                        // reroll 

                        // this is the same as option 2 for player 1 because this is the most likely option to get points the computer will always run this 


                        int[] Treroll2 = Tpoints2.ToArray();
                        Tpoints2.Clear();                                               // this stops the check for doubles appearing twice in points list

                        for (int i = 0; i < Treroll2.Length; i++)                       // for every number in re-roll array run this code 
                        {
                            if (Treroll2[i] == 2)
                            {
                                Tpair2 = Treroll2[i];                                   // this checks if the dice was a double 
                            }
                            else if (Treroll2[i] == 1)
                            {
                                Thread.Sleep(1);                                        // this re-rolls the dice that arent doubles 
                                Tarray2[i] = die1.Roll();


                            }
                        }

                        Array.Clear(Treroll2, 0, Treroll2.Length);                      // this clears the re-roll array so that when the code loops for the plays turn again there aren't old number still in there to cause issues 

                    

                    Tpoints2.Clear();                                                   // this will clear if there isn't a double 
                    foreach (int rolls2 in Tarray2)
                    {
                        TCount2 = 0;                                                    // this sets the counter to 0 so numbers don't gets messed up (2 becomes a 3 and they get points ext)
                        for (int i = 0; i < Tarray2.Length; i++)                        // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)
                        {

                            if (rolls2 == Tarray2[i])
                            {
                                TCount2++;                                              // this adds to the counter 

                            }

                        }
                        Tpoints2.Add(TCount2);                                          // this will add the counter to a list so that i can see which dice are duplicates


                    }
                    Array.Clear(Tarray2, 0, Tarray2.Length);                            // this will clean the array so past uses wont mess with what should be in the array now 
                }

                foreach (int Tnumber2 in Tpoints2)
                {
                    if (Tnumber2 == 3)                                                  // if theres 3 ...
                    {
                        TScore2 = TScore2 + 3;                                          // this adds the players points to the score 
                        Twinner2 = TScore2;                                             // score is moved to winning this will be checked to see if it is past/ equal 20 
                                                                                
                        break;
                    }
                    else if (Tnumber2 == 4)                                             // if theres 4 ...
                    {
                        TScore2 = TScore2 + 6;                                          // this adds more points because they have 4 of a kind 
                        Twinner2 = TScore2;                                             // score is moved to winning this will be checked to see if it is past/ equal 20 
                                                                                
                        break;
                    }
                    else if (Tnumber2 == 5)                                             // if theres 5 ...
                    {
                        TScore2 = TScore2 + 12;                                         // this adds more points because they have all the same 
                        Twinner2 = TScore2;                                             // score is moved to winning this will be checked to see if it is past/ equal 20 
                        break;
                    }
                    else                                                                // if theres non do nothing 
                    {

                    }
                }
            }

            Console.WriteLine("successful test");                                       // this will show if the game stops at 20
            return Twinner2;
             
        }
    }
}
