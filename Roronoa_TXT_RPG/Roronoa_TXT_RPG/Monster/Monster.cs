using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Roronoa_TXT_RPG.Monster;

namespace Roronoa_TXT_RPG
{

    internal class Monster : Character
    {
        public MonsterSkill skill;

        public override void PrintCharacterInfo()
        {
            if (curHealthPoint > 0)
            {
                Console.WriteLine($"Lv. {level}  {Program.PadRightForKorean( name , 20)}"+
                    $" HP {curHealthPoint}/{maxHealthPoint}".PadRight(14)+ $"MP {curManaPoint}/{maxManaPoint}".PadRight(10) + $" ATK {attackPower,-3} DEF {defense,-3}");
            }
            else
            {
                Console.WriteLine($"Lv. {level}  {Program.PadRightForKorean(name, 20)} Dead");
            }
        }
        public override void OnDie()
        {

        }
        public void Attack(Character character)
        {
            AttackOpponent(character, attackPower);
        }

        public void Skill(Character character)
        {
            AttackOpponent(character, skillPower);
        }
    }

    internal class Slime : Monster
    {
        public Slime()
        {
            Randomstatus();
            name = "슬라임";
            experience = 3;

            if (curHealthPoint < 15)
            {
                name = "하찮은 슬라임";
                experience = 2;
                gold = 7;
            }

            if (curHealthPoint > 28)
            {
                name = "킹슬라임";
                experience = 5;
                gold = 13;
            }

        }

        public void Randomstatus()
        {
            Random random = new Random();

            int randomLevel = random.Next(1, 2);
            int randomHealthPoint = random.Next(10, 30);
            int randomManaPoint = random.Next(0, 0);
            int randomAttackPower = random.Next(5, 10);
            int randomDefense = random.Next(1, 3);
            int randomGold = random.Next(7, 12);

            level = randomLevel;
            maxHealthPoint = randomHealthPoint;
            curHealthPoint = maxHealthPoint;
            maxManaPoint = randomManaPoint;
            curManaPoint = maxManaPoint;
            attackPower = randomAttackPower;
            defense = randomDefense;
            gold = randomGold;
        }

        public override void OnDie()
        {
            EventManager.instance?.Publish<MonsterKillEventArgs>(new MonsterKillEventArgs(MONSTER_TYPE.SLIME));
        }
    }
    internal class Goblin : Monster
    {
        public Goblin()
        {
            Randomstatus();
            name = "고블린";
            experience = 7;

            if (curHealthPoint > 47 && attackPower > 18)
            {
                name = "고블린족의 장";
                experience = 10;
                gold = 27;
            }

            skillPower = (int)(attackPower * 1.5f);

            skill = new GoblinSkill(this);
        }

        public void Randomstatus()
        {
            Random random = new Random();

            int randomLevel = random.Next(1, 5);
            int randomHealthPoint = random.Next(30, 50);
            int randomManaPoint = random.Next(5, 20);
            int randomAttackPower = random.Next(15, 20);
            int randomDefense = random.Next(4, 8);
            int randomGold = random.Next(17, 25);

            level = randomLevel;
            maxHealthPoint = randomHealthPoint;
            curHealthPoint = maxHealthPoint;
            maxManaPoint = randomManaPoint;
            curManaPoint = maxManaPoint;
            attackPower = randomAttackPower;
            defense = randomDefense;
            gold = randomGold;
        }
    }
    internal class Elf : Monster
    {
        public Elf()
        {
            Randomstatus();
            name = "엘프";
            experience = 15;

            if (curHealthPoint > 100 && attackPower > 40)
            {
                name = "하이 엘프";
                experience = 25;
                gold = 35;
            }


            skill = new ElfSkill(this);
        }

        public void Randomstatus()
        {
            Random random = new Random();

            int randomLevel = random.Next(3, 6);
            int randomHealthPoint = random.Next(80, 120);
            int randomManaPoint = random.Next(100, 150);
            int randomAttackPower = random.Next(30, 50);
            int randomDefense = random.Next(8, 12);
            int randomGold = random.Next(25, 34);

            level = randomLevel;
            maxHealthPoint = randomHealthPoint;
            curHealthPoint = maxHealthPoint;
            maxManaPoint = randomManaPoint;
            curManaPoint = maxManaPoint;
            attackPower = randomAttackPower;
            defense = randomDefense;
            gold = randomGold;
        }
    }
    internal class Orc : Monster
    {
        public Orc()
        {
            Randomstatus();
            name = "오크";
            experience = 40;

            if (curHealthPoint > 140 && attackPower > 50)
            {
                name = "오크족의 장";
                experience = 54;
            }
        }

        public void Randomstatus()
        {
            Random random = new Random();

            int randomLevel = random.Next(3, 8);
            int randomHealthPoint = random.Next(130, 150);
            int randomManaPoint = random.Next(10, 25);
            int randomAttackPower = random.Next(40, 60);
            int randomDefense = random.Next(12, 15);
            int randomGold = random.Next(35, 54);

            level = randomLevel;
            maxHealthPoint = randomHealthPoint;
            curHealthPoint = maxHealthPoint;
            maxManaPoint = randomManaPoint;
            curManaPoint = maxManaPoint;
            attackPower = randomAttackPower;
            defense = randomDefense;
            gold = randomGold;
        }
    }

    internal class Dragon : Monster
    {
        public Dragon()
        {
            Randomstatus();
            name = "드래곤";

            if (curHealthPoint > 1790)
            {
                name = "신격 드래곤";
            }
        }

        public void Randomstatus()
        {
            Random random = new Random();

            int randomLevel = random.Next(18, 20);
            int randomHealthPoint = random.Next(1500, 1800);
            int randomManaPoint = random.Next(500, 1000);
            int randomAttackPower = random.Next(130, 150);
            int randomDefense = random.Next(50, 60);
            int randomGold = random.Next(1000, 2000);

            level = randomLevel;
            maxHealthPoint = randomHealthPoint;
            curHealthPoint = maxHealthPoint;
            maxManaPoint = randomManaPoint;
            curManaPoint = maxManaPoint;
            attackPower = randomAttackPower;
            defense = randomDefense;
            gold = randomGold;
        }
    }




}