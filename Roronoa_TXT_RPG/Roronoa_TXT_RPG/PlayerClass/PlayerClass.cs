using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Roronoa_TXT_RPG;
using static System.Formats.Asn1.AsnWriter;
using static Roronoa_TXT_RPG.Program;

namespace Roronoa_TXT_RPG
{
    
    internal class Player : Character
    {
        int level = 1;
        string name;
        int attackPower;
        int defense;
        int maxHealthPoint = 100;
        int curHealthPoint = 100;
        int maxManaPoint = 50;
        int curManaPoint = 50;
        int gold = 0;
            
            public void Attack()
            {
                Console.WriteLine("공격했습니다.");
            }
        public void AddGold(int getGold)
        {
            gold += getGold;
        }
    }
    internal class Worrior : Player
    {                    
        string Name = "Yaman";
        int AttackPower = 20;
        int Defense = 10;
        public void Skill()
        {
            Console.WriteLine("스킬 강타를 사용했습니다.");
        }

    }
    internal class Wizard : Player
    {
        string Name = "Zud";
        int AttackPower = 23;
        int Defense = 8;
        public void Skill()
        {
            Console.WriteLine("스킬 파이어볼을 사용했습니다.");
        }
    }
    internal class Assassin : Player
    {
        string Name = "sin";
        int AttackPower = 25;
        int Defense = 7;
        public void Skill()
        {
            Console.WriteLine("스킬 수리던지기를 사용했습니다.");
        }
    }


}
