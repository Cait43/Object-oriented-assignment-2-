using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDice2
{
    internal class Testing
    {                                   //-----------------this needs changing to test the seven out and three or more -----------

        ///<summary>
        /// This checks to make sure the dice are between 1 and 7 
        ///</summary>

        //Method
        public int RunningTest()       // void stops it from returning a value 
        {
                      
            Console.WriteLine("testing the game");  
            Die trialDie = new Die();
            trialDie.Roll();                    
            Console.WriteLine("testing the dice");


            Debug.Assert(trialDie.Roll() > 0);
            Debug.Assert(trialDie.Roll() < 7);

            Console.WriteLine("Successful Test");       // informs the user the test was completed


            return 0;
        }


    }
}
