using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG
{
    internal class Stage
    {
        int level = 1;
        public Stage() { }
        List<Monster> monsters = new List<Monster> { new Monster(), new Monster(), new Monster() };//고블린, 엘프, 오크 등등으로 바꾸면된다.
        public void PrintStageInfo()
        {
            Console.WriteLine($"Stage {level}");
        }

    }
}
