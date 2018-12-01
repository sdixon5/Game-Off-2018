using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Football
{
    class Play
    {
        public int yardDifference = 0;
        public int determineOutcome(Player p1, Player p2)
        {
            //offensive advantage
            if(p1.hasBall == true)
            {
                //run advantage
                if (p1.selectedPlay == 1 && p2.selectedPlay == 2 || p1.selectedPlay == 1 && p2.selectedPlay == 3)
                {
                    yardDifference = p1.yards - (p2.yards / 2);
                }
                //short pass advantage
                else if(p1.selectedPlay == 2 && p2.selectedPlay == 1 || p1.selectedPlay == 2 && p2.selectedPlay == 3)
                {
                    yardDifference = p1.yards - (p2.yards / 2);
                }
                //long pass advantage
                else if(p1.selectedPlay == 3 && p2.selectedPlay == 2)
                {
                    yardDifference = p1.yards - (p2.yards / 2);
                }
            }
            else if(p2.hasBall == true)
            {
                //run advantage
                if (p2.selectedPlay == 1 && p1.selectedPlay == 2 || p2.selectedPlay == 1 && p1.selectedPlay == 3)
                {
                    yardDifference = p2.yards - (p1.yards / 2);
                }
                //short pass advantage
                else if (p2.selectedPlay == 2 && p1.selectedPlay == 1 || p2.selectedPlay == 2 && p1.selectedPlay == 3)
                {
                    yardDifference = p2.yards - (p1.yards / 2);
                }
                //long pass advantage
                else if (p2.selectedPlay == 3 && p1.selectedPlay == 2)
                {
                    yardDifference = p2.yards - (p1.yards / 2);
                }
            }
            //defensive advantage
            else if(p1.hasBall == false)
            {
                //blitz advantage
                if(p1.selectedPlay == 1 && p2.selectedPlay == 1 || p1.selectedPlay == 1 && p2.selectedPlay == 3)
                {
                    yardDifference = p2.yards - (p1.yards * 2);
                }
                //zone advantage
                else if(p1.selectedPlay == 2 && p2.selectedPlay == 2)
                {
                    yardDifference = p2.yards - (p1.yards * 2);
                }
                //man advantage
                else if(p1.selectedPlay == 3 && p2.selectedPlay == 3)
                {
                    yardDifference = p2.yards - (p1.yards * 2);
                }
            }
            else if(p2.hasBall == false)
            {
                //blitz advantage
                if (p2.selectedPlay == 1 && p1.selectedPlay == 1 || p2.selectedPlay == 1 && p1.selectedPlay == 3)
                {
                    yardDifference = p1.yards - (p2.yards * 2);
                }
                //zone advantage
                else if (p2.selectedPlay == 2 && p1.selectedPlay == 2)
                {
                    yardDifference = p1.yards - (p2.yards * 2);
                }
                //man advantage
                else if (p2.selectedPlay == 3 && p1.selectedPlay == 3)
                {
                    yardDifference = p1.yards - (p2.yards * 2);
                }
            }

            return yardDifference;
        }

        public void reportOutcome(Player p1, Player p2, int yardsToGo)
        {
            if (yardDifference >= yardsToGo)
            {
                yardDifference = yardsToGo;
            }

            if (p1.hasBall == true)
            {
                if(p1.selectedPlay == 1)
                {
                    Console.WriteLine(p1.teamName + " ran the ball for " + yardDifference +" yards \n");
                }
                else if(p1.selectedPlay == 2 || p1.selectedPlay == 3)
                {
                    Console.WriteLine(p1.teamName + " threw the ball for " + yardDifference + " yards \n");
                }
            }
            else
            {
                if (p2.hasBall == true)
                {
                    if (p2.selectedPlay == 1)
                    {
                        Console.WriteLine(p2.teamName + " ran the ball for " + yardDifference + " yards \n");
                    }
                    else if (p2.selectedPlay == 2 || p2.selectedPlay == 3)
                    {
                        Console.WriteLine(p2.teamName + " threw the ball for " + yardDifference + " yards \n");
                    }
                }
            }
        }

        public int kickoff(Player player1, Player player2)
        {
            if (player1.hasBall == true)
            {
                Console.WriteLine(player1.teamName + " has kicked off to " + player2.teamName);
            }
            else
            {
                Console.WriteLine(player2.teamName + " has kicked off to " + player1.teamName);
            }
            switchBall(player1, player2);

            Random random = new Random();

            int distanceKicked = random.Next(50, 86);
            int yardsReturned = random.Next(0, 26);
            int luck = random.Next(0, 101);

            int yards = 0;

            int yardsKicked = 75 - distanceKicked;

            if (yardsReturned == luck)
            {
                yardsReturned = 100;
            }

            yards = yardsKicked + yardsReturned;

            if (yards >= 100)
            {
                yards = 100;
            }

            int ballKickedTo = 75 - distanceKicked;
            Console.WriteLine("The kick was " + distanceKicked + " yards to the " + ballKickedTo + " yard line");
            Console.WriteLine("The return was for " + yardsReturned + " yards \n");

            return yards;
        }

        public void touchdown(Player player1, Player player2)
        {
            Console.WriteLine(" = = = = = =     = = = =     =         =     = = = =     =         =   = = = = =        = = = =     =             =   =        =      ");
            Console.WriteLine("      =         =       =    =         =    =        =   =         =   =         =     =       =    =      =      =   = =      =      ");
            Console.WriteLine("      =        =         =   =         =   =             =         =   =          =   =         =   =     = =     =   =  =     =      ");
            Console.WriteLine("      =        =         =   =         =   =             = = = = = =   =          =   =         =   =     = =     =   =   =    =      ");
            Console.WriteLine("      =        =         =   =         =   =             =         =   =          =   =         =   =    =   =    =   =    =   =      ");
            Console.WriteLine("      =         =       =    =         =    =        =   =         =   =         =     =       =    =    =   =    =   =     =  =      ");
            Console.WriteLine("      =          = = = =       = = = =       = = = =     =         =   = = = = =        = = = =       = =     = =     =      = =       ");

            if (player1.hasBall == true)
            {
                Console.WriteLine(player1.teamName + "  has scored a Touchdown! \n");
                player1.score += 7;
            }
            else
            {
                Console.WriteLine(player2.teamName + "  has scored a Touchdown! \n");
                player2.score += 7;
            }
        }

        public bool fieldGoal(Player p1, Player p2, int totalYardsToGo)
        {
            Console.WriteLine(" = = = = = =   =    = = = = =     =            = = = = =              = = = =         = = = =           =          =                     ");
            Console.WriteLine(" =             =    =             =            =         =          =         =      =       =         = =         =                     ");
            Console.WriteLine(" =             =    =             =            =          =         =               =         =       =   =        =                     ");
            Console.WriteLine(" = = = = =     =    = = =         =            =          =         =               =         =      =     =       =                     ");
            Console.WriteLine(" =             =    =             =            =          =         =      = = =    =         =     = = = = =      =                     ");
            Console.WriteLine(" =             =    =             =            =         =           =        =      =       =     =         =     =                     ");
            Console.WriteLine(" =             =    = = = = =     = = = = =    = = = = =               = = = =        = = = =     =           =    = = = = =             ");

            bool fieldGoalIsGood = false;
            if (p1.hasBall == true)
            {
                if (p1.yards >= totalYardsToGo)
                {
                    fieldGoalIsGood = true;
                }
            }
            else
            {
                if (p2.yards >= totalYardsToGo)
                {
                    fieldGoalIsGood = true;
                }
            }

            return fieldGoalIsGood;
        }

        public void punt(Player player1, Player player2, Down d)
        {
            if (player1.hasBall == true)
            {
                yardDifference = player1.yards - player2.yards;
                Console.WriteLine(player1.teamName + " has punted the ball to " + player2.teamName);
                Console.WriteLine("The punt was " + player1.yards + " yards. With a return of " + player2.yards + "\n");
            }
            else
            {
                yardDifference = player2.yards = player1.yards;
                Console.WriteLine(player2.teamName + " has punted the ball to " + player1.teamName + "\n");
                Console.WriteLine("The punt was " + player2.yards + " yards. With a return of " + player1.yards + "\n");
            }

            d.down = 1;
            d.toGo = 10;
            d.ballOn = 100 - (d.ballOn + yardDifference);
            d.totalYardsToGo = 100 - d.ballOn;
            touchback(d);
            switchBall(player1, player2);
        }

        public void touchback(Down d)
        {
            if (d.totalYardsToGo >= 100)
            {
                d.ballOn = 25;
                d.totalYardsToGo = 75;
            }
        }

        public int turnOver()
        {
            int turnOver = 0;

            Random random = new Random();
            turnOver = random.Next(-10, 101);

            return turnOver;
        }

        public void switchBall(Player player1, Player player2)
        {
            if (player1.hasBall == true)
            {
                player1.hasBall = false;
                player2.hasBall = true;
                Console.WriteLine(player2.teamName + " has the ball now. \n");
            }
            else
            {
                player1.hasBall = true;
                player2.hasBall = false;
                Console.WriteLine(player1.teamName + " has the ball now. \n");
            }
        }
    }
}
