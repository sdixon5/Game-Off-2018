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
                d.ballOn = p.kickoff(player1, player2, d);
                not_A_Score = true;

                while (not_A_Score)
                {
                    d.totalYardsToGo = 100 - d.ballOn;

                    Console.WriteLine("============================================================================================================");
                    Console.WriteLine(d.down + " down. " + d.toGo + " yards til first.");
                    Console.WriteLine("The ball is on the " + d.ballOn + " yard line. There are " + d.totalYardsToGo + " yards to go to score. \n");

                    player1.playSelection();
                    if (player2.playerName == "CPU")
                    {
                        CPU cpu = new CPU();
                        cpu.pickPlay(player2, d);
                    }
                    else
                    {
                        player2.playSelection();
                    }
                    
                    if(d.totalYardsToGo > 100)
                    {
                        p.safety(player1, player2);
                        not_A_Score = false;
                        d.down = 1;
                        d.toGo = 10;
                        d.ballOn = 25;
                        d.totalYardsToGo = 75;
                        showScore(player1, player2);
                    }
                    else if (player1.hasBall == true && player1.selectedPlay == 4 || player2.hasBall == true && player2.selectedPlay == 4)
                    {
                        bool itsGood = p.fieldGoal(player1, player2, d.totalYardsToGo);
                        if (itsGood == true)
                        {
                            not_A_Score = false;
                            if (player1.hasBall == true)
                            {
                                Console.WriteLine(player1.teamName + "  has scored a Field Goal! \n");
                                player1.score += 3;
                            }
                            else
                            {
                                Console.WriteLine(player2.teamName + "  has scored a Field Goal! \n");
                                player2.score += 3;
                            }
                            d.down = 1;
                            d.toGo = 10;
                            d.ballOn = 25;
                            d.totalYardsToGo = 75;
                        }
                        else
                        {
                            if(player1.hasBall == true)
                            { 
                                Console.WriteLine(player1.teamName + " missed the field goal \n");
                            }
                            else
                            {
                                Console.WriteLine(player2.teamName + " missed the field goal \n");
                            }
                            p.switchBall(player1, player2);
                            d.down = 1;
                            d.toGo = 10;
                            d.ballOn = 100 - d.ballOn;
                            d.totalYardsToGo = 100 - d.totalYardsToGo;
                        }

                        showScore(player1, player2);
                    }
                    else if(player1.hasBall == true && player1.selectedPlay == 5 || player2.hasBall == true && player2.selectedPlay == 5)
                    {
                        p.punt(player1, player2, d);
                    }
                    else
                    {
                        p.determineOutcome(player1, player2);
                        p.reportOutcome(player1, player2, d.totalYardsToGo);

                        int t = p.turnOver();

                        if (t == p.yardDifference)
                        {
                            Console.WriteLine("Turnover!");
                            p.switchBall(player1, player2);
                            d.down = 1;
                            d.toGo = 10;
                            d.ballOn = 100 - (d.ballOn + p.yardDifference);
                            d.totalYardsToGo = 100 - d.ballOn;
                        }
                        else if (p.yardDifference >= d.totalYardsToGo)
                        {
                            not_A_Score = false;
                            p.touchdown(player1, player2);
                            d.down = 1;
                            d.toGo = 10;
                            d.ballOn = 25;
                            d.totalYardsToGo = 75;
                            showScore(player1, player2);
                        }
                        else if (p.yardDifference >= d.toGo)
                        {
                            d.down = 1;
                            d.toGo = 10;
                            d.ballOn += p.yardDifference;
                            d.totalYardsToGo -= p.yardDifference;
                        }
                        else if (d.down == 4)
                        {
                            p.switchBall(player1, player2);
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

                combinedScore = player1.score + player2.score;

            }

            Console.WriteLine("Final Score!");
            showScore(player1, player2);
            Console.WriteLine("\n\n Thanks For Playing!");


            if (playAgain())
            {
                Start s = new Start();
                s.startSetUp();
            }
            else
            {
                Console.WriteLine("\n\n Thanks For Playing! \n Hope you enjoyed your time");
                Environment.Exit(0);
            }
            

        }

        public void showScore(Player p1, Player p2)
        {
            Console.WriteLine("The current score: ");
            Console.WriteLine(p1.teamName + " has a score of: " + p1.score);
            Console.WriteLine(p2.teamName + " has a score of: " + p2.score + "\n");
        }

        public bool playAgain()
        {
            bool playAgain = false;
            
            Console.WriteLine("Would you like to play again? Press Any Key Play Again or Type 'Quit': \n\n\n");
            string response = Console.ReadLine();
            response = response.ToUpper();
            if (response == "QUIT")
            {
                Console.WriteLine("\n\n Thanks For Playing! \n Hope you enjoyed your time");
                Environment.Exit(0);
            }
            else
            {
                playAgain = true;
            }
            

            return playAgain;
        }

        
    }
}
