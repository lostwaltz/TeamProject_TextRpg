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
    
    public class Player
    {
        int Level = 1;
        string Name;
        int AttackPower;
        int Defense;
        int HealthPoint = 100;
        int MP = 50;
        bool isDead => HealthPoint <= 0;
            
            public void Attack()
            {
                Console.WriteLine("공격했습니다.");
            }
    }
    public class Worrior : Player
    {                    
        string Name = "Yaman";
        int AttackPower = 20;
        int Defense = 10;
        public void Skill()
        {
            Console.WriteLine("스킬 강타를 사용했습니다.");
        }

    }
    public class Wizard : Player
    {
        string Name = "Zud";
        int AttackPower = 23;
        int Defense = 8;
        public void Skill()
        {
            Console.WriteLine("스킬 파이어볼을 사용했습니다.");
        }
    }
    public class Assassin : Player
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
