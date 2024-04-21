using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OOPDice2
{
    class Statistics : SevenOut 
    {
        int P1Wins3 = 0; 
        int P2Wins3 = 0;
        string[] File = { };
        List<int> MainList = new List<int>();
        int len = 0;





        public int Stats7()
        {
            SevenOut s = new SevenOut();
            int num = s.numOfPlays;

            Console.WriteLine("Statistics7");               // for testing purposes 

            Console.WriteLine("Player vs Player stats");
            //Console.WriteLine("Number of wins Player 1: ");
            //Console.WriteLine(P1Wins7);
            //Console.WriteLine("Number of wins Player 2: ");
            //Console.WriteLine(P2Wins7);
            //Console.WriteLine("Total wins in seven out by a player: ");
            //Console.WriteLine(SevenWinsTotal);

            try
            {
                while (len < num)
                {
                    StreamWriter sw = new StreamWriter("C:\\Users\\Caitlin Mitchell\\source\\repos\\OOPDice2\\OOPDice2\\bin\\Debug\\test.txt");
                    sw.WriteLine("1");
                    sw.Close();
                    len++;
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }


            string filepath = "C:\\Users\\Caitlin Mitchell\\source\\repos\\OOPDice2\\OOPDice2\\bin\\Debug\\test.txt";      // this is the file its getting the data from 
            File = ReadFile(filepath);                       // this puts the result of the method in the array

            foreach (string item in File)
            {
                int toInt = Int32.Parse(item);                      // this sets all the numbers in the file to integers
                MainList.Add(toInt);                                // this adds the integers to MainList
            }

            Console.WriteLine($"Number of plays: {MainList.Count}");    // this prints how many high scores it has saved (how many times the game has been played)
            //Console.WriteLine($"highscore: {MainList[-1]}");            // this will show the last number added to the list (the highscore) will need to order the list 


            // this is for adding to the txt file for highscores exists in seven out where the totals are shown 
            try
            {

                StreamWriter sw = new StreamWriter("C:\\Users\\Caitlin Mitchell\\source\\repos\\OOPDice2\\OOPDice2\\bin\\Debug\\highscores.txt");
                Console.Write("Highscore: ");
                sw.WriteLine(" top number of sorted list ");
                sw.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }


            // bubble sort to orgonise the high scores so the highest is at the top

            //List<int> SortedList = new List<int>();
            //List<int> sorted(List<int> b, int n)
            //{
            //    bool swap = true;
            //    while (swap == true)                                                // biggest to smallest (deccending)
            //    {
            //        swap = false;                                                   // this bool will allows the code to exit the loop once its finished 
            //        for (int i = 0; i < n - 1; i++)                                 // for as long as i is less than n - 1 keep running the loop 
            //        {


            //            if (b[i + 1] > b[i])
            //            {
            //                int temp = b[i];                                        // this puts the number in to temporary storage 
            //                b[i] = b[i + 1];                                        // this puts the next number in its place 
            //                b[i + 1] = temp;                                        // this moves the next number in to temporary storage 

            //                swap = true;                                            // this will keep the loop going 
            //            }

            //        }
            //        return b;


            //    }
            //}

            

            // this will show high scores, number of game plays for seven up 

            return 0;
        }

        

        public string[] ReadFile(string filepath)
        {
            StreamReader reader = new StreamReader(filepath);
            string Number = reader.ReadLine();
            List<string> Data = new List<string>();           // this is my list 

            while (Number != null)                              // while statement to add the numbers to my list 
            {
                Data.Add(Number);
                Number = reader.ReadLine();                     // this checks the next line in the file 
            }


            return Data.ToArray();

        }

        

        public int Stats3()
        {
            Console.WriteLine("Statistics3");

            // this will show high scores, number of game plays for three or more  

            return 0;
        }

    }
}
