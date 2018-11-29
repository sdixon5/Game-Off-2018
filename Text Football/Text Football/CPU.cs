using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Football
{
    class CPU
    {
        public void pickPlay(Player cpu)
        {
            if (cpu.hasBall == true)
            {
                Random r = new Random();
                cpu.selectedPlay = r.Next(0, 6);
                cpu.yards = cpu.callOffense();
            }
            else if (cpu.hasBall == false)
            {
                Random r = new Random();
                cpu.selectedPlay = r.Next(0, 6);
                cpu.yards = cpu.callDefense();
            }
        }
    }
}
