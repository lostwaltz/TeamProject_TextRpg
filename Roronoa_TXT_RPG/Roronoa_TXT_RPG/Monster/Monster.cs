using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG
{
    internal class Monster : Character
    {
        public override void PrintCharactorInfo() //몬스터 정보 출력 함수
        {
            Console.WriteLine($"Lv. {level} \t {name} \t HP {curHealthPoint} \t MP {curManaPoint}");
        }

        public virtual void Attack(Character name)
        {
            SkillProbability();
            AttackOpponent(name, attackPower);
        }

        public int lucky;

        public void SkillProbability()
        {
            Random random = new Random();
            lucky = random.Next(1, 11);
        }

        public float skillPower;


        public void Skill(Character name)
        {
            AttackOpponent(name, (int) skillPower);
        }
    }


    internal class Goblin : Monster
    {
        public Goblin(int randomLevel, int randomHealthPoint, int randomManaPoint, int randomAttackPower, int randomDefense)
        {
            level = randomLevel;

            curHealthPoint = randomHealthPoint;

            curManaPoint = randomManaPoint;

            attackPower = randomAttackPower;

            defense = randomDefense;

            name = "고블린";

            if (maxHealthPoint > 47 && attackPower > 18)
            {
                name = "고블린족의 장";
            }

            Randomstatus();

            if (lucky < 4)
            {
                skillPower = attackPower * 1.5f;
            }
        }

        public void Randomstatus()
        {
            Random random = new Random();

            int randomLevel = random.Next(1, 5);

            int randomHealthPoint = random.Next(30, 50);

            int randomManaPoint = random.Next(5, 20);

            int randomAttackPower = random.Next(15, 20);

            int randomDefense = random.Next(3, 6);
        }

        public void SkillProbability()
        {

        }
    }
    internal class Elf : Monster
    {
        public Elf(int randomLevel, int randomHealthPoint, int randomManaPoint, int randomAttackPower, int randomDefense)
        {
            level = randomLevel;

            curHealthPoint = randomHealthPoint;

            curManaPoint = randomManaPoint;

            attackPower = randomAttackPower;

            defense = randomDefense;

            name = "엘프";

            if (maxHealthPoint > 100 && attackPower > 40)
            {
                name = "하이 엘프";
            }

            Randomstatus();

            if (lucky > 0)
            {
                skillPower = attackPower * 2f;
            }
        }

        public override void Attack(Character name)
        {
            AttackOpponent(name, attackPower);
        }

        public void Randomstatus()
        {
            Random random = new Random();

            level = random.Next(3, 6);

            int randomHealthPoint = random.Next(80, 120);

            int randomManaPoint = random.Next(100, 150);

            int randomAttackPower = random.Next(30, 50);

            int randomDefense = random.Next(8, 13);
        }
    }
    internal class Orc : Monster
    {
        public Orc(int randomLevel, int randomHealthPoint, int randomManaPoint, int randomAttackPower, int randomDefense)
        {
            level = randomLevel;

            curHealthPoint = randomHealthPoint;

            curManaPoint = randomManaPoint;

            attackPower = randomAttackPower;

            defense = randomDefense;

            name = "오크";

            if (maxHealthPoint > 140 && attackPower > 50)
            {
                name = "오크족의 장";
            }

            //Randomstatus();

            //if (maxHealthPoint * 0.5f > curHealthPoint)
            //{
            //    attackPower = float.Parse(attackPower) * 1.5f;
            //}
        }

        public void Randomstatus()
        {
            Random random = new Random();

            int randomLevel = random.Next(3, 8);

            int randomHealthPoint = random.Next(130, 150);

            int randomManaPoint = random.Next(10, 25);

            int randomAttackPower = random.Next(40, 60);

            int randomDefense = random.Next(13, 16);
        }
    }

    internal class Dragon : Monster
    {
        public Dragon(int randomLevel, int randomHealthPoint, int randomManaPoint, int randomAttackPower, int randomDefense)
        {
            level = randomLevel;

            curHealthPoint = randomHealthPoint;

            curManaPoint = randomManaPoint;

            attackPower = randomAttackPower;

            defense = randomDefense;

            name = "드래곤";

            if (maxHealthPoint > 1790)
            {
                name = "신격 드래곤";
            }

            Randomstatus();
        }

        public void Randomstatus()
        {
            Random random = new Random();

            int randomLevel = random.Next(18, 20);

            int randomHealthPoint = random.Next(1500, 1800);

            int randomManaPoint = random.Next(500, 1000);

            int randomAttackPower = random.Next(130, 150);

            int randomDefense = random.Next(30, 35);
        }
    }
    internal class Slime : Monster
    {
        public Slime(int randomLevel, int randomHealthPoint, int randomManaPoint, int randomAttackPower, int randomDefense)
        {
            level = randomLevel;

            curHealthPoint = randomHealthPoint;

            curManaPoint = randomManaPoint;

            attackPower = randomAttackPower;

            defense = randomDefense;

            name = "슬라임";

            if (curHealthPoint < 15)
            {
                name = "하찮은 슬라임";
            }

            if (maxHealthPoint > 28)
            {
                name = "킹슬라임";
            }

            Randomstatus();

            if (lucky > 6)
            {
                skillPower = attackPower * 1.5f;
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
        }
    }
}
