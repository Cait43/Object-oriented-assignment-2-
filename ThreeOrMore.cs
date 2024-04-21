using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace OOPDice2
{
    internal class ThreeOrMore
    {
        List<int> listOfRolls = new List<int>();        // this is a list i will append the rolls to to check if they are the same number or not 
        List<int> listOfRolls2 = new List<int>();       // this is a list i will append the rolls to to check if they are the same number or not for player 2 
        List<int> points = new List<int>();             // this will check weather or not you can reroll
        List<int> points2 = new List<int>();            // this will check weather or not you can reroll for player 2 
        int Score = 0;
        int Score2 = 0;
        int Count = 0;
        int winner = 0;                                 // making a variable called winner if it gets to 20 will show a winner 
        int winner2 = 0;
        bool loop = true;
        bool pick = false;



        Die die1 = new Die();       // this creates 5 dice 
        Die die2 = new Die();
        Die die3 = new Die();
        Die die4 = new Die();
        Die die5 = new Die();


        public int ThreePlusGame()
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


                        int pair = 0;
                        bool input = false;


                        die1.Roll();
                        listOfRolls.Add(die1.Value);
                        Thread.Sleep(1);                        // this will add a delay of 1 milliseconds to  the dice roll and allow them to be more random
                        die2.Roll();                            // this will asign a number to each of the dice 
                        listOfRolls.Add(die2.Value);            // this will add the dice values to the list 
                        Thread.Sleep(1);
                        die3.Roll();
                        listOfRolls.Add(die3.Value);
                        Thread.Sleep(1);
                        die4.Roll();
                        listOfRolls.Add(die4.Value);
                        Thread.Sleep(1);
                        die5.Roll();
                        listOfRolls.Add(die5.Value);

                        Console.WriteLine("Player 1: ");
                        Console.ReadLine();
                        Console.WriteLine("Rolls: ");            // this is text that will be shown to help users know what the numbers are 
                        Console.WriteLine(die1.Value);           // this prints the dice values 
                        Console.WriteLine(die2.Value);
                        Console.WriteLine(die3.Value);
                        Console.WriteLine(die4.Value);
                        Console.WriteLine(die5.Value);
                        Console.WriteLine();


                        int[] array = listOfRolls.ToArray();            // try resetting arrays and lists by emptying them 

                        
                        listOfRolls.Clear();                                // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it  

                        foreach (int rolls in array)
                        {
                            Count = 0;
                            for (int i = 0; i < array.Length; i++)          // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)
                            {

                                if (rolls == array[i])
                                {
                                    Count++;                                // this will increase the counter 

                                }

                            }
                            points.Add(Count);                              // this will add the counter to a list so that i can see which dice are duplicates
                                                                            

                        }
                        bool rerollbool = false;
                        foreach (int rolls in points)
                        {
                            if (rolls == 2)
                            {
                                rerollbool = true;
                            }
                            if (rolls == 3)
                            {
                                rerollbool = false;
                                break;
                            }
                        }
                        if (rerollbool == true)                                     // this isn't running for some reason runs for each a second time for no reason???
                        {

                            while (input == false)
                            {
                                Console.Write("Would you like to re-roll all (1) or just non doubbles (2)? ");
                                string answer = Console.ReadLine();

                                if (answer == "1")
                                {
                                    input = true;

                                    die1.Roll();
                                    listOfRolls.Add(die1.Value);
                                    Thread.Sleep(1);                        // this will add a delay of 1 milliseconds to  the dice roll and allow them to be more random
                                    die2.Roll();                            // this will asign a number to each of the dice 
                                    listOfRolls.Add(die2.Value);            // this will add the dice values to the list 
                                    Thread.Sleep(1);
                                    die3.Roll();
                                    listOfRolls.Add(die3.Value);
                                    Thread.Sleep(1);
                                    die4.Roll();
                                    listOfRolls.Add(die4.Value);
                                    Thread.Sleep(1);
                                    die5.Roll();
                                    listOfRolls.Add(die5.Value);


                                    Console.WriteLine("Rolls: ");            // this is text that will be shown to help users know what the numbers are 
                                    Console.WriteLine(die1.Value);           // this prints the dice values 
                                    Console.WriteLine(die2.Value);
                                    Console.WriteLine(die3.Value);
                                    Console.WriteLine(die4.Value);
                                    Console.WriteLine(die5.Value);

                                    listOfRolls.Clear();                                // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it
                                }
                                else if (answer == "2")
                                {
                                    input = true;

                                    int[] reroll = points.ToArray();
                                    points.Clear();     /// does points need clearing before here // this should stop the check for doubles appearing twice in points 

                                    for (int i = 0; i < reroll.Length; i++)
                                    {
                                        if (reroll[i] == 2)
                                        {
                                            pair = reroll[i];
                                        }
                                        else if (reroll[i] == 1)
                                        {
                                            Thread.Sleep(1);
                                            array[i] = die1.Roll();
                                            Console.WriteLine(die1.Value);

                                        }


                                    }
                                    Array.Clear(reroll, 0, reroll.Length);

                                }
                                else
                                {
                                    Console.WriteLine("invalid input ");
                                    input = false;
                                }
                            }

                            points.Clear();     /// this will clear the points if there isn't a double  // this should stop the check for doubles appearing twice in points 
                            foreach (int rolls in array)
                            {
                                Count = 0;
                                for (int i = 0; i < array.Length; i++)          // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)
                                {

                                    if (rolls == array[i])
                                    {
                                        Count++;

                                    }

                                }
                                points.Add(Count);                              // this will add the counter to a list so that i can see which dice are duplicates
                                

                            }
                            Array.Clear(array, 0, array.Length);                // this will clean the array so past uses wont mess with what should be in the array now 
                        }

                        foreach (int number in points)
                        {

                            if (number == 3)
                            {
                                Score = Score + 3;
                                winner = Score;
                                Console.WriteLine("Score: " + winner);
                                break;
                            }
                            else if (number == 4)
                            {
                                Score = Score + 6;
                                winner = Score;
                                Console.WriteLine("Score: " + winner);
                                break;
                            }
                            else if (number == 5)
                            {
                                Score = Score + 12;
                                winner = Score;
                                Console.WriteLine("Score: " + winner);
                                break;
                            }
                            else
                            {

                            }
                        }

                            if (winner >= 20)
                            {
                                Console.WriteLine("player 1 wins!!");
                                loop = false;
                            break;
                            }
                            else if (winner2 >= 20)
                            {
                                Console.WriteLine("player 2 wins!!");
                                loop = false;
                                break;
                            }
                            else
                            {
                                loop = true;
                            }

                        


                        /// <summary>
                        /// This runs for player 2's turn 
                        /// </summary>
                        /// <returns></returns>

                        
                        int pair2 = 0;
                        bool input2 = false;


                        die1.Roll();
                        listOfRolls2.Add(die1.Value);
                        Thread.Sleep(1);                        // this will add a delay of 1 milliseconds to  the dice roll and allow them to be more random
                        die2.Roll();                            // this will asign a number to each of the dice 
                        listOfRolls2.Add(die2.Value);           // this will add the dice values to the list 
                        Thread.Sleep(1);
                        die3.Roll();
                        listOfRolls2.Add(die3.Value);
                        Thread.Sleep(1);
                        die4.Roll();
                        listOfRolls2.Add(die4.Value);
                        Thread.Sleep(1);
                        die5.Roll();
                        listOfRolls2.Add(die5.Value);

                        Console.WriteLine("Player 2: ");
                        Console.ReadLine();
                        Console.WriteLine("Rolls: ");            // this is text that will be shown to help users know what the numbers are 
                        Console.WriteLine(die1.Value);           // this prints the dice values 
                        Console.WriteLine(die2.Value);
                        Console.WriteLine(die3.Value);
                        Console.WriteLine(die4.Value);
                        Console.WriteLine(die5.Value);
                        Console.WriteLine();


                        int[] array2 = listOfRolls2.ToArray();

                        listOfRolls2.Clear();                                // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it

                        foreach (int rolls2 in array2)
                        {
                            int Count2 = 0;
                            for (int i = 0; i < array2.Length; i++)          // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)
                            {

                                if (rolls2 == array2[i])
                                {
                                    Count2++;                                // this will put a mark for every number in the list if it appears twice it will get 2 if 3 times 3 ext

                                }

                            }
                            points2.Add(Count2);                              // this will add the counter to a list so that i can see which dice are duplicates
                                                                              

                        }
                        bool rerollbool2 = false;
                        foreach (int rolls2 in points2)
                        {
                            if (rolls2 == 2)
                            {
                                rerollbool2 = true;
                            }
                            if (rolls2 == 3)
                            {
                                rerollbool2 = false;
                                break;
                            }
                        }
                        if (rerollbool2 == true)                                                        // if points finds doubles it will run this code 
                        {
                            while (input2 == false)
                            {
                                Console.Write("Would you like to re-roll all (1) or just non doubbles (2)? ");      // this asks if the player wants to reroll just non doubles or all dice 
                                string answer2 = Console.ReadLine();

                                if (answer2 == "1")                                     // if all dice are to be re-rolled this runs 
                                {
                                    input2 = true;                                      // this tells the code that a correct input was given and the loop can close 
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

                                    Console.WriteLine("Rolls: ");                       // this is text that will be shown to help users know what the numbers are 
                                    Console.WriteLine(die1.Value);                      // this prints the dice values 
                                    Console.WriteLine(die2.Value);
                                    Console.WriteLine(die3.Value);
                                    Console.WriteLine(die4.Value);
                                    Console.WriteLine(die5.Value);

                                    listOfRolls2.Clear();                                // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it
                                }
                                else if (answer2 == "2")
                                {
                                    input2 = true;                                      // this tells the code that a correct input was given and the loop can close 

                                    int[] reroll2 = points2.ToArray();
                                    points2.Clear();                                    // this stops the check for doubles appearing twice in points list

                                    for (int i = 0; i < reroll2.Length; i++)            // for every number in re-roll array run this code 
                                    {
                                        if (reroll2[i] == 2)
                                        {
                                            pair2 = reroll2[i];                         // this checks if the dice was a double 
                                        }
                                        else if (reroll2[i] == 1)
                                        {
                                            Thread.Sleep(1);                            // this re-rolls the dice that arent doubles 
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
                            if (number2 == 3)
                            {
                                Score2 = Score2 + 3;                                    // this adds the players points to the score 
                                winner2 = Score2;                                       // score is moved to winning this will be checked to see if it is past/ equal 20 
                                Console.WriteLine("Score: " + winner2);                 // this writes the new score so it can be seen by the player 
                                break;
                            }
                            else if (number2 == 4)
                            {
                                Score2 = Score2 + 6;                                    // this adds more points because they have 4 of a kind 
                                winner2 = Score2;                                       // score is moved to winning this will be checked to see if it is past/ equal 20 
                                Console.WriteLine("Score: " + winner2);                 // this writes the new score so it can be seen by the player
                                break;
                            }
                            else if (number2 == 5)
                            {
                                Score2 = Score2 + 12;                                   // this adds more points because they have all the same 
                                winner2 = Score2;                                       // score is moved to winning this will be checked to see if it is past/ equal 20 
                                Console.WriteLine("Score: " + winner2);                 // this writes the new score so it can be seen by the player
                                break;
                            }
                            else
                            {

                            }
                        }

                            if (winner >= 20)                                           // this checks if player 1's score is 20 or above 
                            {
                                Console.WriteLine("player 1 wins!!");                   // if it is then player 1 has won 
                                loop = false;                                           // this breakes the while loop because someone has won 
                                break;                                                  // this stops it running anymore 
                            }
                            else if (winner2 >= 20)                                     // this checks player 2's score 
                            {
                                Console.WriteLine("player 2 wins!!");                   // this shows if player 2 has won 
                                loop = false;                                           // this breakes the while loop because someone has won 
                                break;                                                  // this stops it running anymore 
                            }
                            else
                            {
                                loop = true;
                            }

                        

                        
                    }
                    

                }
                else if (choice == "y")                                                 // this runs if you chose to play against the computer 
                {
                    pick = true;                                                        // this sets the pick to true so the loop knows that a correct input was choses and the loop can stop 

                    Console.WriteLine("Playing Three or more against the computer ");

                    while (loop == true)
                    {
                        listOfRolls.Clear();                            // this will empty the list for when it loops so it wont be messed up by the past numbers 
                        listOfRolls2.Clear();                           // this will do the same for player 2 
                        points.Clear();                                 // this will empty the list for when it loops so it wont be messed up by the past numbers
                        points2.Clear();                                // this will do the same for player 2


                        int pair = 0;
                        bool input = false;


                        die1.Roll();
                        listOfRolls.Add(die1.Value);
                        Thread.Sleep(1);                        // this will add a delay of 1 milliseconds to  the dice roll and allow them to be more random
                        die2.Roll();                            // this will asign a number to each of the dice 
                        listOfRolls.Add(die2.Value);            // this will add the dice values to the list 
                        Thread.Sleep(1);
                        die3.Roll();
                        listOfRolls.Add(die3.Value);
                        Thread.Sleep(1);
                        die4.Roll();
                        listOfRolls.Add(die4.Value);
                        Thread.Sleep(1);
                        die5.Roll();
                        listOfRolls.Add(die5.Value);

                        Console.WriteLine("Player 1: ");
                        Console.ReadLine();
                        Console.WriteLine("Rolls: ");            // this is text that will be shown to help users know what the numbers are 
                        Console.WriteLine(die1.Value);           // this prints the dice values 
                        Console.WriteLine(die2.Value);
                        Console.WriteLine(die3.Value);
                        Console.WriteLine(die4.Value);
                        Console.WriteLine(die5.Value);
                        Console.WriteLine();


                        int[] array = listOfRolls.ToArray();                // try resetting arrays and lists by emptying them 


                        listOfRolls.Clear();                                // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it  

                        foreach (int rolls in array)
                        {
                            Count = 0;
                            for (int i = 0; i < array.Length; i++)          // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)
                            {

                                if (rolls == array[i])
                                {
                                    Count++;                                // this will increase the counter 

                                }

                            }
                            points.Add(Count);                              // this will add the counter to a list so that i can see which dice are duplicates
                                                                            

                        }
                        bool rerollbool = false;
                        foreach (int rolls in points)
                        {
                            if (rolls == 2)
                            {
                                rerollbool = true;
                            }
                            if (rolls == 3)
                            {
                                rerollbool = false;
                                break;
                            }
                        }
                        if (rerollbool == true)                                     // this isn't running for some reason runs for each a second time for no reason???
                        {

                            while (input == false)
                            {
                                Console.Write("Would you like to re-roll all (1) or just non doubbles (2)? ");
                                string answer = Console.ReadLine();

                                if (answer == "1")
                                {
                                    input = true;

                                    die1.Roll();
                                    listOfRolls.Add(die1.Value);
                                    Thread.Sleep(1);                        // this will add a delay of 1 milliseconds to  the dice roll and allow them to be more random
                                    die2.Roll();                            // this will asign a number to each of the dice 
                                    listOfRolls.Add(die2.Value);            // this will add the dice values to the list 
                                    Thread.Sleep(1);
                                    die3.Roll();
                                    listOfRolls.Add(die3.Value);
                                    Thread.Sleep(1);
                                    die4.Roll();
                                    listOfRolls.Add(die4.Value);
                                    Thread.Sleep(1);
                                    die5.Roll();
                                    listOfRolls.Add(die5.Value);


                                    Console.WriteLine("Rolls: ");            // this is text that will be shown to help users know what the numbers are 
                                    Console.WriteLine(die1.Value);           // this prints the dice values 
                                    Console.WriteLine(die2.Value);
                                    Console.WriteLine(die3.Value);
                                    Console.WriteLine(die4.Value);
                                    Console.WriteLine(die5.Value);

                                    listOfRolls.Clear();                                // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it
                                }
                                else if (answer == "2")
                                {
                                    input = true;

                                    int[] reroll = points.ToArray();
                                    points.Clear();     /// does points need clearing before here // this should stop the check for doubles appearing twice in points 

                                    for (int i = 0; i < reroll.Length; i++)
                                    {
                                        if (reroll[i] == 2)
                                        {
                                            pair = reroll[i];
                                        }
                                        else if (reroll[i] == 1)
                                        {
                                            Thread.Sleep(1);
                                            array[i] = die1.Roll();
                                            Console.WriteLine(die1.Value);

                                        }


                                    }
                                    Array.Clear(reroll, 0, reroll.Length);

                                }
                                else
                                {
                                    Console.WriteLine("invalid input ");
                                    input = false;
                                }
                            }

                            points.Clear();                                     // this stops the check for doubles numbers appearing twice in points 
                            foreach (int rolls in array)
                            {
                                Count = 0;
                                for (int i = 0; i < array.Length; i++)          // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)
                                {

                                    if (rolls == array[i])
                                    {
                                        Count++;

                                    }

                                }
                                points.Add(Count);                              // this will add the counter to a list so that i can see which dice are duplicates


                            }
                            Array.Clear(array, 0, array.Length);                // this will clean the array so past uses wont mess with what should be in the array now 
                        }

                        foreach (int number in points)
                        {

                            if (number == 3)
                            {
                                Score = Score + 3;
                                winner = Score;
                                Console.WriteLine("Score: " + winner);
                                break;
                            }
                            else if (number == 4)
                            {
                                Score = Score + 6;
                                winner = Score;
                                Console.WriteLine("Score: " + winner);
                                break;
                            }
                            else if (number == 5)
                            {
                                Score = Score + 12;
                                winner = Score;
                                Console.WriteLine("Score: " + winner);
                                break;
                            }
                            else
                            {

                            }
                        }

                        if (winner >= 20)
                        {
                            Console.WriteLine("player 1 wins!!");
                            loop = false;
                            break;
                        }
                        else if (winner2 >= 20)
                        {
                            Console.WriteLine("computer wins!!");
                            loop = false;
                            break;
                        }
                        else
                        {
                            loop = true;
                        }




                        /// <summary>
                        /// This runs the computers turn  
                        /// </summary>
                        /// <returns></returns>


                        int pair2 = 0;
                        bool input2 = false;


                        die1.Roll();
                        listOfRolls2.Add(die1.Value);
                        Thread.Sleep(1);                        // this will add a delay of 1 milliseconds to  the dice roll and allow them to be more random
                        die2.Roll();                            // this will asign a number to each of the dice 
                        listOfRolls2.Add(die2.Value);           // this will add the dice values to the list 
                        Thread.Sleep(1);
                        die3.Roll();
                        listOfRolls2.Add(die3.Value);
                        Thread.Sleep(1);
                        die4.Roll();
                        listOfRolls2.Add(die4.Value);
                        Thread.Sleep(1);
                        die5.Roll();
                        listOfRolls2.Add(die5.Value);

                        Console.WriteLine("computer: ");
                        Console.WriteLine("Rolls: ");            // this is text that will be shown to help users know what the numbers are 
                        Console.WriteLine(die1.Value);           // this prints the dice values 
                        Console.WriteLine(die2.Value);
                        Console.WriteLine(die3.Value);
                        Console.WriteLine(die4.Value);
                        Console.WriteLine(die5.Value);
                        Console.WriteLine();


                        int[] array2 = listOfRolls2.ToArray();

                        listOfRolls2.Clear();                                // the contents of the list are now in the array so i'm emptying the list so i wont get error of the list being too long next time i use it

                        foreach (int rolls2 in array2)
                        {
                            int Count2 = 0;
                            for (int i = 0; i < array2.Length; i++)          // this will add a point to the counter every time the same number is fount (2 2s 3 1s ext)
                            {

                                if (rolls2 == array2[i])
                                {
                                    Count2++;                                // this will put a mark for every number in the list if it appears twice it will get 2 if 3 times 3 ext

                                }

                            }
                            points2.Add(Count2);                              // this will add the counter to a list so that i can see which dice are duplicates


                        }
                        bool rerollbool2 = false;
                        foreach (int rolls2 in points2)
                        {
                            if (rolls2 == 2)
                            {
                                rerollbool2 = true;
                            }
                            if (rolls2 == 3)
                            {
                                rerollbool2 = false;
                                break;
                            }
                        }
                        if (rerollbool2 == true)                                                        // if points finds doubles it will run this code 
                        {
                            while (input2 == false)
                            {
                                Console.WriteLine("Would you like to re-roll all (1) or just non doubbles (2)? ");      // this asks if the player wants to reroll just non doubles or all dice 
                                Thread.Sleep(1);                                        // because the computer can't pick this will add a delay so it doesn't just all appear on the screen at once 

                                // this is the same as option 2 for player 1 because this is the most likely option to get points the computer will always run this 
                                
                                input2 = true;                                      // this tells the code that a correct input was given and the loop can close 

                                int[] reroll2 = points2.ToArray();
                                points2.Clear();                                    // this stops the check for doubles appearing twice in points list

                                for (int i = 0; i < reroll2.Length; i++)            // for every number in re-roll array run this code 
                                {
                                    if (reroll2[i] == 2)
                                    {
                                       pair2 = reroll2[i];                          // this checks if the dice was a double 
                                    }
                                    else if (reroll2[i] == 1)
                                    {
                                        Thread.Sleep(1);                            // this re-rolls the dice that arent doubles 
                                        array2[i] = die1.Roll();
                                        Console.WriteLine(die1.Value);              // this displays the new dice number 


                                    }
                                }

                                Array.Clear(reroll2, 0, reroll2.Length);            // this clears the re-roll array so that when the code loops for the plays turn again there aren't old number still in there to cause issues 

                                
                                
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
                            if (number2 == 3)
                            {
                                Score2 = Score2 + 3;                                    // this adds the players points to the score 
                                winner2 = Score2;                                       // score is moved to winning this will be checked to see if it is past/ equal 20 
                                Console.WriteLine("Score: " + winner2);                 // this writes the new score so it can be seen by the player 
                                break;
                            }
                            else if (number2 == 4)
                            {
                                Score2 = Score2 + 6;                                    // this adds more points because they have 4 of a kind 
                                winner2 = Score2;                                       // score is moved to winning this will be checked to see if it is past/ equal 20 
                                Console.WriteLine("Score: " + winner2);                 // this writes the new score so it can be seen by the player
                                break;
                            }
                            else if (number2 == 5)
                            {
                                Score2 = Score2 + 12;                                   // this adds more points because they have all the same 
                                winner2 = Score2;                                       // score is moved to winning this will be checked to see if it is past/ equal 20 
                                Console.WriteLine("Score: " + winner2);                 // this writes the new score so it can be seen by the player
                                break;
                            }
                            else
                            {

                            }
                        }

                        if (winner >= 20)                                           // this checks if player 1's score is 20 or above 
                        {
                            Console.WriteLine("player 1 wins!!");                   // if it is then player 1 has won 
                            loop = false;                                           // this breakes the while loop because someone has won 
                            break;                                                  // this stops it running anymore 
                        }
                        else if (winner2 >= 20)                                     // this checks player 2's score 
                        {
                            Console.WriteLine("computer wins!!");                   // this shows if player 2 has won 
                            loop = false;                                           // this breakes the while loop because someone has won 
                            break;                                                  // this stops it running anymore 
                        }
                        else
                        {
                            loop = true;
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
    }
}
