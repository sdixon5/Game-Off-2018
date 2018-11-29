using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Football
{
    class Player
    {
        public string playerName = "";
        public string teamName = "";
        public int score = 0;
        public bool hasBall = false;
        public int selectedPlay = 0;
        public int yards = 0;

        public void playSelection()
        {
            //int selectedPlay = 0;
            //int yards = 0;

            //for the cpu just have a random here, and if teamName == "CPU" then have the random number used instead of the console logs
            if(this.playerName == "CPU" && this.hasBall == true)
            {
                Random r = new Random();
                selectedPlay = r.Next(0, 6);
                yards = callOffense();
            }
            else if(this.playerName == "CPU" && this.hasBall == false)
            {
                Random r = new Random();
                selectedPlay = r.Next(0, 6);
                yards = callDefense();
            }
            else if(this.hasBall == true)
            {
                Console.WriteLine(teamName + " are on offense. Please pick from the following options.");
                Console.WriteLine("1. Run");
                Console.WriteLine("2. Short Pass");
                Console.WriteLine("3. Long Pass");
                Console.WriteLine("4. Field Goal");
                Console.WriteLine("5. Punt");

                selectedPlay = inputForSelection();
                //call offense object?
                //change the return to a yardsgained, from the offense object?
                yards = callOffense();
            }
            else if(this.hasBall == false)
            {
                Console.WriteLine(teamName + " are on defense. Please pick from the following options.");
                Console.WriteLine("1. Blitz");
                Console.WriteLine("2. Zone");
                Console.WriteLine("3. Man");
                Console.WriteLine("4. Field Goal Block");
                Console.WriteLine("5. Punt Return");

                selectedPlay = inputForSelection();

                yards = callDefense();
            }

            //return yards;
        }

        public int inputForSelection()
        {
            bool unsuccessful = true;
            int value = 0;

            while (unsuccessful)
            {
                Console.WriteLine("Please enter the number for the play you would like to select:");
                //need to hide the input... readline wont work, neither will readkey or read, but look inside windows screenshots, might have a way to do it
                string input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    if(value == 1|| value == 2 || value == 3 || value == 4 || value == 5)
                    {
                        Console.WriteLine("You have selected: " + value);
                        unsuccessful = false;
                    }
                    else
                    {
                        Console.WriteLine("Your input needs to be one of the options available to you.");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Your input needs to be a number. Please try again.");
                }
            }

            return value;
        }

        public int callOffense()
        {
            int yardsGained = 0;
            Offense off = new Offense();
            if (selectedPlay == 1)
            {
                yardsGained = off.run();
            }
            else if (selectedPlay == 2)
            {
                yardsGained = off.shortPass();
            }
            else if (selectedPlay == 3)
            {
                yardsGained = off.longPass();
            }
            else if (selectedPlay == 4)
            {
                yardsGained = off.fieldGoal();
            }
            else
            {
                yardsGained = off.punt();
            }

            return yardsGained;
        }

        public int callDefense()
        {
            int yardsDefended = 0;
            Defense def = new Defense();
            if (selectedPlay == 1)
            {
                yardsDefended = def.blitz();
            }
            else if (selectedPlay == 2)
            {
                yardsDefended = def.zone();
            }
            else if (selectedPlay == 3)
            {
                yardsDefended = def.man();
            }
            else if (selectedPlay == 4)
            {
                yardsDefended = def.fieldGoalBlock();
            }
            else
            {
                yardsDefended = def.puntReturn();
            }

            return yardsDefended;
        }
    }
}
