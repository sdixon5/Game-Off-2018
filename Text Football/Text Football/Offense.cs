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
            yardsGained = random.Next(0, 30);

            return yardsGained;
        }

        public int shortPass()
        {
            int yardsGained = 0;

            Random random = new Random();
            yardsGained = random.Next(0, 20);

            return yardsGained;
        }

        public int longPass()
        {
            int yardsGained = 0;

            Random random = new Random();
            yardsGained = random.Next(20, 60);

            return yardsGained;
        }

        public int fieldGoal()
        {
            int yardsGained = 0;

            Random random = new Random();
            yardsGained = random.Next(0, 65);

            return yardsGained;
        }

        public int punt()
        {
            int yardsGained = 0;

            Random random = new Random();
            yardsGained = random.Next(15, 65);

            return yardsGained;
        }
    }
}
