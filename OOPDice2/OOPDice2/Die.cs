using OOPDice2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOPDice2
{
    internal class Die
    {

        //Property

        public int Value = 0;

        ///<summary>
        /// This generates the random number for my dice between 1 and 6 
        ///</summary>
        //Method
        public int Roll()
        {

            Random r = new Random();         // this will generate the random number for my dice 
            Value = r.Next(1, 7);            // this will ensure that the number is 1- 6 
                                             // next generates random positive numbers 
            return Value;
        }



    }
}
//if (die1.Value == pair2)
//{

//    Score2 = Score2 + 3;        // this addss the points if the reroll makes 3 
//    winner2 = Score2;


//}

//if (die1.Value == pair)
//{
//    Score = Score + 3;   // this may be why there getting 3 points what is this ??????/
//    winner = Score;
//    // think this is giving the points if the new roll makes 3 matching 

//}