using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Football
{
    class Offense
    {
        public int run()
        {
            int yardsGained = 0;

            Random random = new Random();
            yardsGained = random.Next(-10, 100);

            return yardsGained;
        }

        public int shortPass()
        {
            int yardsGained = 0;

            return yardsGained;
        }

        public int longPass()
        {
            int yardsGained = 0;

            return yardsGained;
        }

        public void fieldGoal()
        {

        }

        public void punt()
        {

        }
    }
}
