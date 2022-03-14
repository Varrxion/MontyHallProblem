//This program is created with the intention of proving whether it is truly better to switch your door/choice in the monty hall problem, statistically.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHallProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int NUMTESTS = 10000;
            const int NUMDOORS = 3;

            Random random = new Random();

            int randnum;
            int winningnum;
            int counter = 1;
            bool validchoice = false;

            //Win counter
            int wins = 0;

            int choice = 0;

            Console.WriteLine($"There are {NUMDOORS} doors.");

            while (validchoice == false)
            {
                Console.Write("Enter 1 for initial choice, enter 2 for door-switch, all tests will be done in the manner chosen: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if(choice == 1 || choice == 2)
                    {
                        validchoice = true;
                    }
                }
            }

            if (choice == 1)
            {
                while (counter <= NUMTESTS)
                {
                    randnum = random.Next(NUMDOORS);
                    winningnum = random.Next(NUMDOORS);

                    if (randnum == winningnum) //keep our choice and see if it wins
                    {
                        wins++;
                    }

                    counter++;
                }
            }
            else if(choice == 2)
            {
                int goatnum;
                int firstnum;
                while (counter <= NUMTESTS)
                {
                    randnum = random.Next(NUMDOORS);
                    winningnum = random.Next(NUMDOORS);
                    firstnum = randnum; //The number initially picked

                    while ((randnum == firstnum) || randnum==winningnum) //keep rolling randnum until it isn't the same as the first choice, and isn't the same number as the winning door (Monty showing one of the goats)
                    {
                        randnum=random.Next(NUMDOORS);
                    }

                    goatnum = randnum; //mark this as known goat door

                    while ((randnum == firstnum) || randnum == goatnum) //keep rolling randnum until it isn't the same as the first choice, and isn't the same number as the goat door (Player switching their choice)
                    {
                        randnum = random.Next(NUMDOORS);
                    }

                    if (randnum == winningnum) //When different number found, see if that number matches the winning number
                    {
                        wins++;
                    }

                    counter++;
                }
            }
            else
            {
                Console.WriteLine("Something has gone terribly wrong");
            }
            Console.WriteLine($"{wins} total wins out of {NUMTESTS} games");
            bool waitflag = false;
            string waitcheck;
            var winpercent = 0.00M;
            winpercent = (decimal)wins / NUMTESTS;

            Console.WriteLine($"{winpercent}% winrate");

            Console.WriteLine("Press Enter to continue");
            while (waitflag == false)
            {
                waitcheck=Console.ReadLine();
                if (waitcheck == "")
                {
                    waitflag = true;
                }
            }
        }
    }
}
