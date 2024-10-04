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
        List<MONSTER_TYPE> stageMonsters = new List<MONSTER_TYPE>();//스테이지 몬스터

        //임의로 몬스터 지정
        List<List<MONSTER_TYPE>> allStageMonsters = new List<List<MONSTER_TYPE>> {
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

        //Stage별 몬스터 나올 확률: 순서대로 {몬스터 수, Slime, Goblin, Elf, Orc, Dragon}
        private List<List<int>> probabilityPerStage = new List<List<int>> {
            new List<int>{ 3, 100, 0, 0, 0, 0 },    // Stage 1
            new List<int>{ 2, 60, 40, 0, 0, 0 },    // Stage 2
            new List<int>{ 2, 40, 60, 0, 0, 0 },    // Stage 3
            new List<int>{ 2, 20, 80, 0, 0, 0 },    // Stage 4
            new List<int>{ 2, 5, 65, 30, 0, 0 },    // Stage 5
            new List<int>{ 2, 0, 40, 60, 0, 0 },    // Stage 6
            new List<int>{ 2, 0, 10, 60, 30, 0 },   // Stage 7
            new List<int>{ 2, 0, 0, 40, 60, 0 },    // Stage 8
            new List<int>{ 2, 0, 0, 20, 80, 0 },    // Stage 9
            new List<int>{ 1, 0, 0, 0, 0, 100 }     // Stage 10

        };
        List<int> probability = new List<int>();
        public void probablityCurculate()
        {
            probability.Clear();
            int prob = 0;
            for (int i = 1; i < probabilityPerStage[level].Count; i++)
            {
                prob += probabilityPerStage[level][i];
                probability.Add(prob);
            }
        }


        public void CreateStageMonsters()
        {
            stageMonsters.Clear();
            probablityCurculate();
            Random random = new Random();
            for (int i = 0; i < probabilityPerStage[level - 1][0]; i++)
            {
                int randNum = random.Next(0, 100);
                if (randNum < probability[(int)MONSTER_TYPE.SLIME])
                {
                    stageMonsters.Add(MONSTER_TYPE.SLIME);
                }
                else if (randNum < probability[(int)MONSTER_TYPE.GOBLIN])
                {
                    stageMonsters.Add(MONSTER_TYPE.GOBLIN);
                }
                else if (randNum < probability[(int)MONSTER_TYPE.ELF])
                {
                    stageMonsters.Add(MONSTER_TYPE.ELF);
                }
                else if (randNum < probability[(int)MONSTER_TYPE.ORC])
                {
                    stageMonsters.Add(MONSTER_TYPE.ORC);
                }
                else if (randNum < probability[(int)MONSTER_TYPE.DRAGON])
                {
                    stageMonsters.Add(MONSTER_TYPE.DRAGON);
                }
            }

        }

        public void PrintStageInfo()
        {
            Console.WriteLine($"Stage {level}");
        }
        public void StageUp()
        {
            level = Program.player.level;
        }
        public List<MONSTER_TYPE> TakeMostersTypeForEachStage()
        {
            CreateStageMonsters();
            return stageMonsters;
        }

        public void PrintStage()
        {
            Console.Write($"Stage {level}");
        }
    }
}
