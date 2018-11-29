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
            //if offense and defense numbers add up to the turnover number then a turnover will occur

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

        public void reportOutcome(Player p1, Player p2)
        {
            int t = turnOver();
            if(t == yardDifference)
            {
                Console.WriteLine("Turnover!");
                if(p1.hasBall == true)
                {
                    p1.hasBall = false;
                    p2.hasBall = true;
                }
                else
                {
                    p1.hasBall = true;
                    p2.hasBall = false;
                }
                yardDifference = -2000;
                return;
            }
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
