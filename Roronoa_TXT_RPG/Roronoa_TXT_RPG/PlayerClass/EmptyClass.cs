using System;
namespace Roronoa_TXT_RPG
{
    class Player
    {
        public int Level { get; }
        public string Name { get; }
        public string Job { get; }
        public int Attack { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; private set; }

        public int ExtraAtk { get; private set; }
        public int ExtraDef { get; private set; }

        public Player(int level, string name, string job, int atk, int def, int hp, int gold)
        {
            Level = level;
            Name = name;
            Job = job;
            Attack = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }

}

