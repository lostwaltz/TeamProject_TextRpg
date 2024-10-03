using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG
{
    internal class MonsterKillEventArgs : EventArgs
    {
        public MonsterKillEventArgs(MONSTER_TYPE monsterType)
        {
            MonsterType = monsterType;
        }
        
        public MONSTER_TYPE MonsterType { get; set; }
    }

    internal class MonsterDamageEventArgs : EventArgs
    {
        public MonsterDamageEventArgs(int monsterDamage)
        {
            MonsterDamage = monsterDamage;
        }

        public int MonsterDamage { get; set; }
    }
}
