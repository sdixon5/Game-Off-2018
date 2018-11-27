using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Football
{
    class Defense
    {
        public int blitz()
        {
            int yardsDefended = 0;

            Random random = new Random();
            yardsDefended = random.Next(-15, 25);

            return yardsDefended;
        }

        public void man()
        {

        }

        public void zone()
        {

        }

        public void fieldGoalBlock()
        {

        }

        public void puntReturn()
        {

        }
    }
}
