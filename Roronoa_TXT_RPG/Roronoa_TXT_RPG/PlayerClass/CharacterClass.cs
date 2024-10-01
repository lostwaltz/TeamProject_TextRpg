using System;
namespace Roronoa_TXT_RPG
{
    internal class Character
	{
        int level;
        string name;
        string job;
        int attackPower;
        int defense;
        int maxHealthPoint;
        int curHealthPoint;
        int maxmanaPoint;
        int curManaPoint;
        int gold;
        bool isDead => curHealthPoint <= 0;

        public int TakeDamage(int damage)
        {
            int takeDamageHealthPoint = curHealthPoint - damage;
            if(takeDamageHealthPoint < 0)
            {
                Console.WriteLine($"{name}이(가){damage}만큼 데미지를 받아 사망했습니다. 현재체력: {takeDamageHealthPoint}");
            }
            else
            {
                Console.WriteLine($"{name}이(가){damage}만큼 데미지를 받았습니다. 현재체력: {takeDamageHealthPoint}");
            }
            curHealthPoint = takeDamageHealthPoint;
            return curHealthPoint;
        }

        public void AttackOpponent(Character opponent, int damage)
        {
            Console.WriteLine($"{name}의 공격!");
            Console.WriteLine($"{opponent}을(를) 공격했습니다. [데미지: {damage}]");
        }

        public virtual void PrintCharaterInfo(int befireBattlePlayerHealthPoint)
        {
            if(curHealthPoint > 0)
            {
                Console.WriteLine($"{level} {name}");
                Console.WriteLine($"HP {befireBattlePlayerHealthPoint}-> {curHealthPoint}");
            }
            else
            {
                Console.WriteLine($"{level} {name}");
                Console.WriteLine($"HP {befireBattlePlayerHealthPoint}-> Dead");
            }
        }
	}
    
}

