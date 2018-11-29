using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Football
{
    class Game
    {
        public void runGame(Player player1, Player player2)
        {
            Down d = new Down();
            Play p = new Play();

            bool not_A_Score = true;

            //could be put into a score class! - maybe?
            int combinedScore = player1.score + player2.score;

            while(combinedScore < 50)
            {
                d.ballOn = kickoff(player1, player2);
                not_A_Score = true;

                while (not_A_Score)
                {
                    d.totalYardsToGo = 100 - d.ballOn;

                    Console.WriteLine(d.down + " down. " + d.toGo + " yards til first.");
                    Console.WriteLine("The ball is on the " + d.ballOn + " yard line. There are " + d.totalYardsToGo + " yards to go to score.");

                    //if play outcome < down to go then down++

                    //need to loop the play selection process and always check for a touchdown

                    player1.playSelection();
                    //if player2.playerName = "CPU" call cpu.play selection
                    //else call player2.playSelection(); and remove the cpu code to its own file
                    if (player2.playerName == "CPU")
                    {
                        CPU cpu = new CPU();
                        cpu.pickPlay(player2);
                    }
                    else
                    {
                        player2.playSelection();
                    }
                    

                    if (player1.hasBall == true && player1.selectedPlay == 4 || player2.hasBall == true && player2.selectedPlay == 4)
                    {
                        //call field goal
                        bool itsGood = fieldGoal(player1, player2, d.totalYardsToGo);
                        if (itsGood == true)
                        {
                            not_A_Score = false;
                            if (player1.hasBall == true)
                            {
                                Console.WriteLine(player1.teamName + "  has scored a Field Goal!");
                                player1.score += 3;
                            }
                            else
                            {
                                Console.WriteLine(player2.teamName + "  has scored a Field Goal!");
                                player2.score += 3;
                            }
                            //need to call kickoff - is done by not a score boolean and set all down settings for kickoff
                            d.down = 1;
                            d.toGo = 10;
                            d.ballOn = 25;
                            d.totalYardsToGo = 75;
                        }
                        else
                        {
                            switchBall(player1, player2);
                            d.down = 1;
                            d.toGo = 10;
                            d.ballOn = 100 - d.ballOn;
                            d.totalYardsToGo = 100 - d.totalYardsToGo;
                        }
                        //if return of 0 = good, then trigger not a score
                            //call kickoff!
                            //set all down settings for kickoff
                        //else if return of 1 = bad, 
                            //just flip who has ball and down info to flip the field
                    }
                    else if(player1.hasBall == true && player1.selectedPlay == 5 || player2.hasBall == true && player2.selectedPlay == 5)
                    {
                        //call punt
                    }
                    else
                    {
                        p.determineOutcome(player1, player2);
                        p.reportOutcome(player1, player2);

                        int t = turnOver();

                        if (t == p.yardDifference)
                        {
                            Console.WriteLine("Turnover!");
                            switchBall(player1, player2);
                            d.down = 1;
                            d.toGo = 10;
                            d.ballOn = 100 - d.ballOn;
                            d.totalYardsToGo = 100 - d.totalYardsToGo;
                        }
                        else if (p.yardDifference >= d.toGo)
                        {
                            d.down = 1;
                            d.toGo = 10;
                            d.ballOn += p.yardDifference;
                            d.totalYardsToGo -= p.yardDifference;
                        }
                        else if (p.yardDifference + d.ballOn >= 100)
                        {
                            //this is calling a touchdown!
                            not_A_Score = false;
                            touchdown(player1, player2);
                            //need to call kickoff - is done by not a score boolean and set all down settings for kickoff
                            d.down = 1;
                            d.toGo = 10;
                            d.ballOn = 25;
                            d.totalYardsToGo = 75;
                        }
                        else if (d.down == 4)
                        {
                            switchBall(player1, player2);
                            d.down = 1;
                            d.toGo = 10;
                            d.ballOn = 100 - d.ballOn;
                            d.totalYardsToGo = 100 - d.totalYardsToGo;
                        }
                        else
                        {
                            d.down++;
                            d.toGo -= p.yardDifference;
                            d.ballOn += p.yardDifference;
                            d.totalYardsToGo -= p.yardDifference;
                        }

                    }    
                    
                }

            }

        }

        public int kickoff(Player player1, Player player2)
        {
            //this should be called after a touchdown or field Goal

            if(player1.hasBall == true)
            {
                Console.WriteLine(player1.teamName + " has kicked off to " + player2.teamName);
            }
            else
            {
                Console.WriteLine(player2.teamName + " has kicked off to " + player1.teamName);
            }
            switchBall(player1, player2);

            Random random = new Random();

            int distanceKicked = random.Next(50, 76);
            int yardsReturned = random.Next(0, 26);
            int luck = random.Next(0, 101);
            //ran num for yards kicked
            //ran num for yards returned

            int yards = 0;

            int yardsKicked = 75 - distanceKicked;

            //to account for chance of touchdown on kickoff
            if (yardsReturned == luck)
            {
                yardsReturned = 100;
            }

            yards = yardsKicked + yardsReturned;

            if(yards > 100)
            {
                yards = 100;
            }

            int ballKickedTo = 75 - distanceKicked;
            Console.WriteLine("The kick was " + distanceKicked + " yards to the " + ballKickedTo + " yard line");
            Console.WriteLine("The return was for " + yardsReturned + " yards");

            //should return where the ball is on the field after the kickoff
            return yards;
        }

        //could be put into a score class! - maybe?
        public void touchdown(Player player1, Player player2)
        {
            if (player1.hasBall == true)
            {
                Console.WriteLine(player1.teamName + "  has scored a Touchdown!");
                player1.score += 7;
            }
            else
            {
                Console.WriteLine(player2.teamName + "  has scored a Touchdown!");
                player2.score += 7;
            }
        }

        public int turnOver()
        {
            int turnOver = 0;

            Random random = new Random();
            turnOver = random.Next(-10, 101);

            return turnOver;
        }

        //could be put into a score class! - maybe?
        public bool fieldGoal(Player p1, Player p2, int totalYardsToGo)
        {
            bool fieldGoalIsGood = false;
            if(p1.hasBall == true)
            {
                if(p1.yards >= totalYardsToGo)
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
            //check if fieldGoal distance is longer than reported outcome?
            //if good, set score
            //if not, switch who has ball
            //need to trigger the score if it is good, can be done with a return of 0 or 1,
            return fieldGoalIsGood;
        }

        public void punt(Player p1, Player p2)
        {
            //how long of a punt?
            //where is ball on field
            //switch who has ball
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
