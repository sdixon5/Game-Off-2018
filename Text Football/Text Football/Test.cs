using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Football
{
    class Test
    {
        public void test()
        {
            test_player_playSelection();
            //testing_off_run_returnNeg();
            //testing_random();
        }
        public void test_player_playSelection()
        {
            Player p1 = new Player();
            int count = 0;
            while(count < 10)
            {
                p1.playSelection();
                Console.WriteLine("yards: " + p1.yards);
            }
            //int yards = p1.playSelection();
            
            Console.Read();
            //Console.WriteLine("The yards defended is " + yards);
            //Console.ReadLine();
            Console.WriteLine(p1.selectedPlay);
            Console.Read();
        }

        public void testing_off_run_returnNeg()
        {
            Offense off = new Offense();
            Console.WriteLine(off.run());
            Console.ReadLine();
        }

        public void testing_random()
        {
            int count = 0;
            Random r = new Random();
            while(count < 100)
            {
                //.Next(inclusive, exclusive ie not included)
                Console.WriteLine(r.Next(0, 2));
                count++;
            }
            Console.ReadLine();
        }
    }
}
