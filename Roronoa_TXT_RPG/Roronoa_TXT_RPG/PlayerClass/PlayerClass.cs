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

enum PLAYER_ACTION_TYPE { ATTACK = 1, SKILL }
namespace Roronoa_TXT_RPG
{
    
    internal class Player : Character
    {
        int level = 1;
        string name;
        string job;
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
            public void Skill()
            {
                Console.WriteLine("스킬을 사용했습니다.");
            } 

        public void AddGold(int getGold)
        {
            gold += getGold;
        }

        
        public override void PrintCharactorInfo()
        {
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{level} {name} {job}");
            Console.WriteLine($"HP: {curHealthPoint}/{maxHealthPoint}");
        }
       

        string[] battlePlayerSelectType = { "공격" };

        void BattlePlayerSelect(Queue<int> selectQueue)
        {
            Attack();
            Skill();

            for(int i = 0; i < battlePlayerSelectType.Length; i++)
            {
                int playerSelectNum = i + 1;
                Console.WriteLine($"{playerSelectNum}.{battlePlayerSelectType[i]}");
            }
            Console.WriteLine($"");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine(">>");

            Program.KeyInputCheck(out int _selectPlayerAction, battlePlayerSelectType.Length);

            selectQueue.Enqueue(_selectPlayerAction);
        }

        
        void BattlePlayerAction(Queue<int> selectQueue, List<Monster> monstersList)
        {
            PLAYER_ACTION_TYPE playerAction = (PLAYER_ACTION_TYPE)selectQueue.Dequeue();
            switch(playerAction)
            {
                case PLAYER_ACTION_TYPE.ATTACK:
                int selectMonster = selectQueue.Dequeue();
                    AttackOpponent(monstersList[selectMonster], attackPower);
                    break;
            }
             

        }
    }
    class Worrior : Player
    {                    
        string Name = "Yaman";
        int AttackPower = 20;
        int Defense = 10;
        public void Skill()
        {
            Console.WriteLine("스킬 강타를 사용했습니다.");
        }

    }
    class Wizard : Player
    {
        string Name = "Zud";
        int AttackPower = 23;
        int Defense = 8;
        public void Skill()
        {
            Console.WriteLine("스킬 파이어볼을 사용했습니다.");
        }
    }
    class Assassin : Player
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
