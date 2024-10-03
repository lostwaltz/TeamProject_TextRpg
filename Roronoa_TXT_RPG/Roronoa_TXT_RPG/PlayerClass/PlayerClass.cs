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
        internal Player()
        {
           level = 1;
           // name
           // job
           // attackPower
           // defense
           maxHealthPoint = 100;
           curHealthPoint = 100;
           maxManaPoint = 50;
           curManaPoint = 50;
           gold = 0;
        }
            
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

        
        public override void PrintCharacterInfo()
        {
            Console.WriteLine("  [내정보]");
            Console.WriteLine();
            Console.WriteLine($"Lv.{level} {name} {job}");
            Console.WriteLine();
            Console.WriteLine($" HP  {curHealthPoint}/{maxHealthPoint}".PadRight(17) + $"MP  {curManaPoint}/{maxManaPoint}");
            Console.WriteLine($" ATK {attackPower}".PadRight(17) + $"DEF {defense}");
        }
       

        string[] battlePlayerSelectType = { "공격" };

       public void BattlePlayerSelect(Queue<int> selectQueue)
        {
            Console.WriteLine("무엇을 하시겠습니까?");
            Console.WriteLine("");
            for (int i = 0; i < battlePlayerSelectType.Length; i++)
            {
                int playerSelectNum = i + 1;
                Console.WriteLine($"{playerSelectNum}. {battlePlayerSelectType[i]}");
            }
            Console.WriteLine("");
            Console.WriteLine($"0. 도망");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            Program.KeyInputCheck(out int _selectPlayerAction, battlePlayerSelectType.Length, true);

            selectQueue.Enqueue(_selectPlayerAction);
        }

        
       public void BattlePlayerAction(Queue<int> selectQueue, List<Monster> monstersList)
        {
            PLAYER_ACTION_TYPE playerAction = (PLAYER_ACTION_TYPE)selectQueue.Dequeue();
            switch(playerAction)
            {
                case PLAYER_ACTION_TYPE.ATTACK:
                int selectMonster = selectQueue.Dequeue() - 1;//입력받은 선택지 - 1
                    AttackOpponent(monstersList[selectMonster], attackPower);
                    break;
            }
             

        }


        public void EquipItem(Item item)
        {
            
        }

    }
    internal class Warrior : Player
    {
        public Warrior()
        {
        }

        internal Warrior(string inputName)
        {
            job = "Warrior";
            name = inputName;
            attackPower = 20;
            defense = 10;
        }
        
        public void Skill()
        {
            Console.WriteLine("스킬 강타를 사용했습니다.");
        }

    }
    internal class Wizard : Player
    {
        internal Wizard(string inputName)
        {
            job = "Wizard";
            name = inputName;
            attackPower = 23;
            defense = 8;
        }
        public void Skill()
        {
            Console.WriteLine("스킬 파이어볼을 사용했습니다.");
        }
    }
    internal class Assassin : Player
    {
        internal Assassin(string inputName)
        {
            job = "Assassin";
            name = inputName;
            attackPower = 25;
            defense = 7;
        }
        public void Skill()
        {
            Console.WriteLine("스킬 수리던지기를 사용했습니다.");
        }
    }


}
