using System;
namespace Roronoa_TXT_RPG
{
    internal class Character
	{
        public int level { get; protected set; }
        public string name { get; protected set; }
        public string job { get; protected set; }
        public int attackPower { get; protected set; }
        public int defense { get; protected set; }
        public int maxHealthPoint { get; protected set; }
        public int curHealthPoint { get; protected set; }
        public int maxManaPoint { get; protected set; }
        public int curManaPoint { get; protected set; }
        public int gold { get; protected set; }
        public bool isDead => curHealthPoint <= 0;

        public void DisplayInfo()
        {
            Console.WriteLine($"Lv.{level}");
            Console.WriteLine($"{name} ({job})");
            Console.WriteLine($"공격력: {attackPower}");
            Console.WriteLine($"방어력: {defense}");
            Console.WriteLine($"체력: {curHealthPoint}/{maxHealthPoint}");
            Console.WriteLine($"Gold: {gold}G");
            Console.WriteLine($" ");
            Console.WriteLine($"0.나가기");
            Console.WriteLine($" ");
            Console.WriteLine($"원하시는 행동을 입력해주세요.");
            Console.WriteLine($">>");
        }

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

