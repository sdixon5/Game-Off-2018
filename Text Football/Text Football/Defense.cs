﻿using System;
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
            yardsDefended = random.Next(0, 26);

            return yardsDefended;
        }

        public int man()
        {
            int yardsDefended = 0;

            Random random = new Random();
            yardsDefended = random.Next(0, 16);

            return yardsDefended;
        }

        public int zone()
        {
            int yardsDefended = 0;

            Random random = new Random();
            yardsDefended = random.Next(15, 56);

            return yardsDefended;
        }

        public int fieldGoalBlock()
        {
            int yardsDefended = 0;

            Random random = new Random();
            yardsDefended = random.Next(0, 11);

            return yardsDefended;
        }

        public int puntReturn()
        {
            int yardsDefended = 0;

            Random random = new Random();
            yardsDefended = random.Next(0, 51);

            return yardsDefended;
        }
    }
}
