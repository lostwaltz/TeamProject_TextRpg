

namespace Roronoa_TXT_RPG
{

    internal abstract class MonsterSkill
    {
        protected Monster monster;
        internal MonsterSkill(Monster InputMonster)
        {
            monster = InputMonster;
        }

        public abstract void MonsterSkillInvocation();
    }

    internal class SlaimSkill : MonsterSkill
    {
        internal SlaimSkill(Monster InputMonster) : base(InputMonster)
        {

        }

        public override void MonsterSkillInvocation()
        {
            Random random = new Random();
            int lucky = random.Next(1, 11);

            if (lucky < 6)
            {
                monster.SetCurHealthPoint((int)(monster.curHealthPoint * 1.4));
            }
        }
    }
    internal class GoblinSkill : MonsterSkill
    {
        internal GoblinSkill(Monster InputMonster) : base(InputMonster)
        {

        }

        public override void MonsterSkillInvocation()
        {
            Random random = new Random();
            int lucky = random.Next(1, 11);

            if (lucky < 4)
            {
                monster.skillPower = (int)(monster.attackPower * 1.5f);
            }
        }
    }

    internal class ElfSkill : MonsterSkill
    {
        internal ElfSkill(Monster InputMonster) : base(InputMonster)
        {

        }

        bool ActiveOnce = false;

        public override void MonsterSkillInvocation()
        {
            if (ActiveOnce == false)
            {
                monster.skillPower = (int)(monster.attackPower * 2);
                ActiveOnce = true;
            }
        }
    }
    internal class OrkSkill : MonsterSkill
    {
        internal OrkSkill(Monster InputMonster) : base(InputMonster)
        {

        }

        public override void MonsterSkillInvocation()
        {
            if (monster.maxHealthPoint * 0.5 > monster.curHealthPoint)
            {
                monster.SetDefense((int)(monster.defense * 1.5f));
            }
        }
    }
    internal class DragonSkill : MonsterSkill
    {
        internal DragonSkill(Monster InputMonster) : base(InputMonster)
        {

        }

        public override void MonsterSkillInvocation()
        {
            Random random = new Random();
            int lucky = random.Next(1, 11);

            if (lucky < 4)
            {
                monster.skillPower = (int)(Program.player.maxHealthPoint * 1.5f);
            }
        }
    }

}