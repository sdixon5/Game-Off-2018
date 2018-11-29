using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Football
{
    class Play
    {
        public void determineOutcome()
        {
            //if offense and defense numbers add up to the turnover number then a turnover will occur

            
        }

        public void reportOutcome()
        {

        }

        public int turnOver()
        {
            int turnOver = 0;

            Random random = new Random();
            turnOver = random.Next(0, 101);

            return turnOver;
        }
    }
}
