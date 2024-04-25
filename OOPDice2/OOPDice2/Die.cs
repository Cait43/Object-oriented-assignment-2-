using OOPDice2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPDice2
{
    internal class Die 
    {

        //Property

        public int Value = 0;               // this is the value of the dice 

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
