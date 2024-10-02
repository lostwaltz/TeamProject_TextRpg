using System;
namespace Roronoa_TXT_RPG
{
    internal class Character
	{
        protected int level { get; set; }
        protected string name { get; set; }
        protected string job { get; set; }
        protected int attackPower { get; set; }
        protected int defense { get; set; }
        protected int maxHealthPoint { get; set; }
        public int curHealthPoint { get; private set; }
        protected int maxManaPoint { get; set; }
        protected int curManaPoint { get; set; }
        protected int gold { get; set; }
        public bool isDead => curHealthPoint <= 0;

        public int TakeDamage(int damage)
        {
            int _takeDamageHealthPoint = curHealthPoint - damage;
            if(_takeDamageHealthPoint < 0)
            {
                Console.WriteLine($"{name}이(가){damage}만큼 데미지를 받아 사망했습니다. 현재체력: {_takeDamageHealthPoint}");
            }
            else
            {
                Console.WriteLine($"{name}이(가){damage}만큼 데미지를 받았습니다. 현재체력: {_takeDamageHealthPoint}");
            }
            curHealthPoint = _takeDamageHealthPoint;
            return curHealthPoint;
        }

        public void AttackOpponent(Character opponent, int damage)
        {
            Console.WriteLine($"{name}의 공격!");
            Console.WriteLine($"{opponent}을(를) 공격했습니다. [데미지: {damage}]");

            opponent.TakeDamage(damage);
        }

        public virtual void PrintCharactorInfo()    
        {

        }

        public virtual void PrintCharactorInfo(int befireBattlePlayerHealthPoint)
        {
            if(curHealthPoint > 0)
            {
                Console.WriteLine($"{level} {name}");
                Console.WriteLine($"HP {beforeBattlePlayerHealthPoint}-> {curHealthPoint}");
            }
            else
            {
                Console.WriteLine($"{level} {name}");
                Console.WriteLine($"HP {beforeBattlePlayerHealthPoint}-> Dead");
            }
        }
	}
    
}

