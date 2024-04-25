using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDice2
{
    internal class Testing
    { 
        int Total = 0;                                      // this is used to total the values of the three or more bounds dice rolls 

        ///<summary>
        /// This runs the checks for the game and prints successful test if it works 
        ///</summary>

        //Method
        public int RunningTest()      
        {
            // to keep orgonised im keeping all the classes at the top so i dont recall them by accident 

            Die trialDie = new Die();                       // this calls the die class 
            ThreeOrMore test = new ThreeOrMore();           // this calls the three or more class 
            SevenOut testing = new SevenOut();              // this calls the seven out class 

            //--------------------------------------------------------------------------------------//

            // this is testing that the rolls in die class are not unexpected 
            Console.WriteLine("Begin testing ");  
            //Die trialDie = new Die();                        this shows where that class is being used 
            trialDie.Roll();                                // this runs the method to roll the dice 
            Console.WriteLine("testing the dice");


            Debug.Assert(trialDie.Roll() > 0);              // this checks that the value is above 0 
            Debug.Assert(trialDie.Roll() < 7);              // this checks that the value is below 7 

            Console.WriteLine("Successful Test");           // informs the user the test was completed

            //--------------------------------------------------------------------------------------//

            //this is testing that the multiple rolls in three or more are withing the expected ranges 

            //ThreeOrMore test = new ThreeOrMore();            this showes where the class is being used 
            test.Die15();                                   // this runs the dice rolls for player 1 in three or more to check the total value 
            Console.WriteLine("testing bounds 3 or more");

            foreach (int i in test.Die15())                 // because it returns a list the foreach will put the value of each of the numbers in the list in to total 
            {
                // Display list 
                Total += i;                                 // this contains the total value of all the numbers in the list 
            }

            Debug.Assert(Total > 5);                        // this checks that the total is above 5 (minimum for 6 dice is 6)
            Debug.Assert(Total < 37);                       // this checks that the total is below (not equal to) 37 (maximum total for 5 dice)

            Console.WriteLine("Successful Test");           // informs the user the test was completed

            //--------------------------------------------------------------------------------------//

            // this is testing that the multiple rolls in seven out  are withing the expected ranges

            //SevenOut testing = new SevenOut();               this shows where the class is being used
            Console.WriteLine("testing bounds 7 out");
            testing.Die2();                                 // this calls the method from seven out to test the dice rolls are in bounds 

            Debug.Assert(testing.sumOfDice > 1);            // this checks the value is higher than 1 (2 dice)
            Debug.Assert(testing.sumOfDice < 13);           // this checks the value is less than 13 

            Console.WriteLine("Successful Test");           // informs the user the test was completed

            //--------------------------------------------------------------------------------------//

            // this is going to test that the game stops at 7 

            //SevenOut testing = new SevenOut();               this shows where the class is being used 

            Console.WriteLine("testing seven out ends on a 7 ");
            testing.TestSeven();                            // this calls the testing method from seven out this is a section of code that runs without input 

            // successful test shows in the method 
            //--------------------------------------------------------------------------------------//

            //ThreeOrMore test = new ThreeOrMore();            this showes where the class is being used 
            
            Console.WriteLine("testing 3 or more ends at 20 ");
            Console.WriteLine("Please be paitient this may take a miunet");
            test.testThree();

            return 0;
        }


    }
}
