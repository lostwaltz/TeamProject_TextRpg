using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

enum MONSTER_TYPE { SLIME = 1, GOBLIN, ELF, ORC, DRAGON }
namespace Roronoa_TXT_RPG
{
    internal class Stage
    {
        public int level { get; protected set; }
        internal Stage()
        {
            level = 1;
        }
        List<Monster> monsters = new List<Monster> { new Monster(), new Monster(), new Monster() };//고블린, 엘프, 오크 등등으로 바꾸면된다.

        List<List<MONSTER_TYPE>> stage = new List<List<MONSTER_TYPE>> {
            new List<MONSTER_TYPE> { MONSTER_TYPE.SLIME, MONSTER_TYPE.SLIME, MONSTER_TYPE.SLIME },   // Stage 1
            new List<MONSTER_TYPE> { MONSTER_TYPE.SLIME, MONSTER_TYPE.SLIME, MONSTER_TYPE.GOBLIN },  // Stage 2
            new List<MONSTER_TYPE> { MONSTER_TYPE.SLIME, MONSTER_TYPE.GOBLIN, MONSTER_TYPE.GOBLIN }, // Stage 3
            new List<MONSTER_TYPE> { MONSTER_TYPE.GOBLIN, MONSTER_TYPE.GOBLIN, MONSTER_TYPE.ELF },   // Stage 4
            new List<MONSTER_TYPE> { MONSTER_TYPE.GOBLIN, MONSTER_TYPE.ELF, MONSTER_TYPE.ELF },      // Stage 5
            new List<MONSTER_TYPE> { MONSTER_TYPE.ELF, MONSTER_TYPE.ELF, MONSTER_TYPE.ELF },         // Stage 6
            new List<MONSTER_TYPE> { MONSTER_TYPE.ELF, MONSTER_TYPE.ELF, MONSTER_TYPE.ORC },         // Stage 7
            new List<MONSTER_TYPE> { MONSTER_TYPE.ELF, MONSTER_TYPE.ORC, MONSTER_TYPE.ORC },         // Stage 8
            new List<MONSTER_TYPE> { MONSTER_TYPE.ORC, MONSTER_TYPE.ORC, MONSTER_TYPE.ORC },         // Stage 9
            new List<MONSTER_TYPE> { MONSTER_TYPE.DRAGON },                                          // Stage 10
            };

        public void PrintStageInfo()
        {
            Console.WriteLine($"Stage {level}");
        }
        public void StageUp()
        {
            level++;
        }
        public List<MONSTER_TYPE> TakeMostersTypeForStage()
        {
            return stage[level - 1];
        }
    }
}
