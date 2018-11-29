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

            int combinedScore = player1.score + player2.score;

            while(combinedScore < 50)
            {
                d.ballOn = kickoff(player1, player2);
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
            }
            else
            {
                Console.WriteLine(player2.teamName + " has kicked off to " + player1.teamName);
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

            Console.WriteLine("The kick was " + yardsKicked + " yards");
            Console.WriteLine("The return was for " + yardsReturned + " yards");

            //should return where the ball is on the field after the kickoff
            return yards;
        }

        public bool touchdown()
        {
            bool touchdown = false;

            return touchdown;
        }
    }
}
