using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Football
{
    class CPU
    {
        public void pickPlay(Player cpu, Down d)
        {
            if(cpu.hasBall == true && d.down == 4 && d.totalYardsToGo > 55)
            {
                cpu.selectedPlay = 5;
                cpu.yards = cpu.callOffense();
            }
            else if(cpu.hasBall == true && d.down == 4 && d.totalYardsToGo <= 55)
            {
                cpu.selectedPlay = 4;
                cpu.yards = cpu.callOffense();
            }
            else if (cpu.hasBall == false && d.down == 4 && d.totalYardsToGo > 55)
            {
                cpu.selectedPlay = 5;
                cpu.yards = cpu.callDefense();
            }
            else if (cpu.hasBall == false && d.down == 4 && d.totalYardsToGo <= 55)
            {
                cpu.selectedPlay = 4;
                cpu.yards = cpu.callDefense();
            }
            else if (cpu.hasBall == true)
            {
                Random r = new Random();
                cpu.selectedPlay = r.Next(0, 4);
                cpu.yards = cpu.callOffense();
            }
            else if (cpu.hasBall == false)
            {
                Random r = new Random();
                cpu.selectedPlay = r.Next(0, 4);
                cpu.yards = cpu.callDefense();
            }
        }
    }
}
