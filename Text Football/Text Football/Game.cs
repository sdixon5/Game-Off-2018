﻿using System;
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
                    player2.playSelection();
                    p.determineOutcome(player1, player2);
                    p.reportOutcome(player1, player2); //-- > how to handle punt and field goals?

                    int t = turnOver();

                    if (t == p.yardDifference)
                    {
                        Console.WriteLine("Turnover!");
                        if (player1.hasBall == true)
                        {
                            player1.hasBall = false;
                            player2.hasBall = true;
                        }
                        else
                        {
                            player1.hasBall = true;
                            player2.hasBall = false;
                        }
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
                    else if(p.yardDifference + d.ballOn >= 100)
                    {
                        //Console.WriteLine("Touchdown!");
                        not_A_Score = false;
                        if(player1.hasBall == true)
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
                    else if(d.down == 4)
                    {
                        if(player1.hasBall == true)
                        {
                            player1.hasBall = false;
                            player2.hasBall = true;
                        }
                        else
                        {
                            player1.hasBall = true;
                            player2.hasBall = false;
                        }
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
                    //check for touchdown
                    //update down info
                }

            }

            //need to loop this somehow

            //how to implement the down stuff?

            //while combined score < 60?
                //p1.playSelection
                //p2.playSelection
                //play.determineOutcome --> will call report outcome
                //
                //ball should start where the kickoff returned int says to
                //if playOutcome yards > down to go, first down
        }

        public int kickoff(Player player1, Player player2)
        {
            //this should be called after a touchdown or field Goal

            if(player1.hasBall == true)
            {
                Console.WriteLine(player1.teamName + " has kicked off to " + player2.teamName);
                player1.hasBall = false;
                player2.hasBall = true;
            }
            else
            {
                Console.WriteLine(player2.teamName + " has kicked off to " + player1.teamName);
                player1.hasBall = true;
                player2.hasBall = false;
            }

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

        public bool touchdown()
        {
            bool touchdown = false;

            return touchdown;
        }

        public int turnOver()
        {
            int turnOver = 0;

            Random random = new Random();
            turnOver = random.Next(-10, 101);

            return turnOver;
        }
    }
}
