using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG
{
    internal class Monster : Character
    {
        public override void PrintCharactorInfo() //몬스터 정보 출력 함수
        {
            Console.WriteLine($"Lv. {level} \t {name} \t HP {curHealthPoint} \t MP {curManaPoint}");


            //MP {마나} (마나가 있다면)	
        }

        public void Attack(Character character)//기본공격
        {
            AttackOpponent(character, attackPower);
        }
        /*
        public void Skill()//스킬 이름별로 설정하면 될 듯
        {
            AttackOpponent(SkillPower);
        }
        */
        internal class Goblin : Monster
        {
            internal Goblin()
            {

            }

            public void Randomstatus()
            {
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int randomValue = random.Next(30, 50);
                    Console.WriteLine(randomValue);
                }
            }
        }
    }
}
