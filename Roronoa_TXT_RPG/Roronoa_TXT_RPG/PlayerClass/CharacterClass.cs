﻿using System;
namespace Roronoa_TXT_RPG
{
    internal class Character
	{
        public int level { get; protected set; }
        public int experience { get; protected set; }
        public string name { get; protected set; }
        public string job { get; protected set; }
        public int attackPower { get; protected set; }
        public int skillPower { get; set; }
        public int defense { get; protected set; }
        public int maxHealthPoint { get; protected set; }
        public int curHealthPoint { get; protected set; }
        public int maxManaPoint { get; protected set; }
        public int curManaPoint { get; protected set; }
        public int gold { get; protected set; }
        public bool isDead => curHealthPoint <= 0;

        public virtual void OnDie()
        {

        }

        public void SetDefense(int inputDefense)
        {
            defense = inputDefense;
        }

        public void SetCurHealthPoint(int inputCurHealthPoint)
        {
            curHealthPoint = inputCurHealthPoint;
        }
        public void TakeDamage(int damage)
        {
            int trueDamage = damage - defense;
            if (trueDamage < 0)
            {
                trueDamage = 0;
            }
            int _takeDamageHealthPoint = curHealthPoint - (trueDamage);
            if ((curHealthPoint - (trueDamage)) > maxHealthPoint)
            {
                _takeDamageHealthPoint = maxHealthPoint;
            }
            
            if(_takeDamageHealthPoint <= 0)
            {
                Console.WriteLine($"Lv.{level} [{name}]의 방어! [방어력: {defense}]");
                Console.WriteLine($"Lv.{level} [{name}]이(가){trueDamage}만큼 데미지를 받아 사망했습니다. " +
                    $"HP {curHealthPoint} -> Dead");

                
                
                _takeDamageHealthPoint = 0;
            }
            else
            {
                Console.WriteLine($"Lv.{level} [{name}]의 방어! [방어력: {defense}]");
                Console.WriteLine($"Lv.{level} [{name}]이(가) {trueDamage}만큼 데미지를 받았습니다. " +
                    $"HP {curHealthPoint} -> {_takeDamageHealthPoint}");

            }
            curHealthPoint = _takeDamageHealthPoint;
        }

        public void AttackOpponent(Character opponent, int damage)
        {
            Console.WriteLine($"[{name}]의 공격!");
            Console.WriteLine($"[{opponent.name}]을(를) 공격했습니다. [데미지: {damage}]");
            Console.WriteLine();
            opponent.TakeDamage(damage);
            if (opponent.isDead)
            {
                opponent.OnDie();
                if (this is Player) { 
                    
                    Program.player.GetExp(opponent.experience);
                    Program.player.GetGold(opponent.gold);
                    Console.WriteLine();
                    Program.player.CheckLevel();
                }
            }
        }

        public virtual void PrintCharacterInfo()    
        {

        }

        public virtual void PrintCharacterInfo(int beforeBattlePlayerHealthPoint)
        {
            if(curHealthPoint > 0)
            {
                Console.WriteLine($"Lv.{level} {name}");
                Console.WriteLine($"HP {beforeBattlePlayerHealthPoint}-> {curHealthPoint}");
            }
            else
            {
                Console.WriteLine($"Lv.{level} {name}");
                Console.WriteLine($"HP {beforeBattlePlayerHealthPoint}-> Dead");
            }
        }

        public virtual void PrintCharacterInfo(int beforeBattlePlayerHealthPoint, int beforeBattlePlayerLevel)
        {
            if (curHealthPoint > 0)
            {
                Console.WriteLine($"Lv.{level} {name}");
                Console.WriteLine($"Lv {beforeBattlePlayerLevel}-> {level}");
                Console.WriteLine($"HP {beforeBattlePlayerHealthPoint}-> {curHealthPoint}");
            }
            else
            {
                Console.WriteLine($"Lv.{level} {name}");
                Console.WriteLine($"HP {beforeBattlePlayerHealthPoint}-> Dead");
            }
        }

        public virtual void PrintCharacterInfo(int beforeBattlePlayerHealthPoint, int beforeBattlePlayerLevel, int beforeBattlePlayerGold)
        {
            if (curHealthPoint > 0)
            {
                Console.WriteLine($"Lv.{level} {name}");
                Console.WriteLine($"Lv {beforeBattlePlayerLevel}-> {level}");
                Console.WriteLine($"HP {beforeBattlePlayerHealthPoint}-> {curHealthPoint}");
                Console.WriteLine($"Gold {beforeBattlePlayerGold}-> {gold}");
            }
            else
            {
                Console.WriteLine($"Lv.{level} {name}");
                Console.WriteLine($"HP {beforeBattlePlayerHealthPoint}-> Dead");
            }
        }
    }
    
}

