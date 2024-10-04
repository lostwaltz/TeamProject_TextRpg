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
enum SCENE_INFO_TYPE { WATCH, ITEM_USE, SELL}
namespace Roronoa_TXT_RPG
{
    
    internal class Player : Character
    {
        static int _inventoryMaxCount = 10;
        public List<Item> _inventoryItems { get; protected set; }
        public List<Item> _equippedItems { get; protected set; }
        public bool _isEquipArmor { get; protected set; }
        public bool _isEquipWeapon { get; protected set; }

        public SCENE_INFO_TYPE sceneInfoType { get; protected set; }
        
        static List<int> experiencePerLevel = new List<int> { 0, 6, 8, 15, 25, 40, 80, 140, 250, 400 };
        int maxLevel = experiencePerLevel.Count;

        internal Player()
        {
            level = 1;
            experience = 0;
            // name
            // job
            // attackPower
            // defense
            maxHealthPoint = 100;
            curHealthPoint = 100;
            maxManaPoint = 50;
            curManaPoint = 50;
            gold = 10;
            _isEquipArmor = false;
            _isEquipWeapon = false;
            _inventoryItems = new List<Item>();
            _equippedItems = new List<Item>() { new Item(ItemCategory.WEAPON) , new Item(ItemCategory.ARMOR) };
            sceneInfoType = SCENE_INFO_TYPE.WATCH;
        }
        public void CheckLevel()
        {
            int levelUp = 0;
            while (level + levelUp != maxLevel && experience >= experiencePerLevel[level+levelUp])
            {
                experience -= experiencePerLevel[level + levelUp];
                levelUp++;
            }
            if (levelUp > 0)
            {
                Console.Write($"Lv {level} -> {level += levelUp}");
            }
            
        }
        public void PrintExp()
        {
            if (level < maxLevel)
            {
                Console.Write($"EXP  " + $"{experience}/{experiencePerLevel[level]}".PadRight(9));
            }
            else
            {
                Console.Write("    Max Level");
            }
        }
        
        public void DisplayStatusAndItemInfo()
        {
            int inputSelectNum;
            Console.WriteLine($"Status & Belongings");
            PrintCharacterInfo();
            //>>아이템 장착
            PrintEquipedItemInfo();
            Console.WriteLine($"");
            PrintInventoryInfo();
            Console.WriteLine($"");
            switch (sceneInfoType)
            {
                case SCENE_INFO_TYPE.WATCH:
                    Console.WriteLine($"1. 아이템 사용");
                    Console.WriteLine($"");
                    Console.WriteLine($"0. 나가기");
                    Console.WriteLine($"");
                    Console.WriteLine($"원하시는 행동을 입력해주세요.");
                    Console.Write($">>");
                    Program.KeyInputCheck(out inputSelectNum, 1);
                    switch (inputSelectNum)
                    {
                        case 0:
                            SceneManager.instance?.SceneChange(SCENE_TYPE.SCENE_LOBY);
                            sceneInfoType = SCENE_INFO_TYPE.WATCH;
                            break;
                        case 1:
                            sceneInfoType = SCENE_INFO_TYPE.ITEM_USE;
                            break;
                    }
                    break;
                case SCENE_INFO_TYPE.ITEM_USE:
                    Console.WriteLine($"");
                    Console.WriteLine($"0. 뒤로가기");
                    Console.WriteLine($"");
                    Console.WriteLine($"아이템 사용하기!");
                    Console.WriteLine($"");
                    Console.WriteLine($"사용할 아이템을 골라주세요.");
                    Console.Write($">>");
                    if (Program.KeyInputCheck(out inputSelectNum, _inventoryItems.Count))
                    {
                        if (inputSelectNum == 0)
                        {
                            sceneInfoType = SCENE_INFO_TYPE.WATCH;
                        }
                        else
                        {
                            switch (_inventoryItems[inputSelectNum-1].ItemData.ItemCategory) 
                            {
                                case ItemCategory.WEAPON:
                                case ItemCategory.ARMOR:
                                    EquipItem(inputSelectNum-1);
                                    break;
                            }

                        }
                    }
                    break;
                case SCENE_INFO_TYPE.SELL:
                    Console.WriteLine("여기는 아이템 판매소가 아닙니다.");
                    Console.WriteLine("아이템 판매를 하시려면 상점으로 가십시오.");
                    Thread.Sleep(1000);
                    sceneInfoType = SCENE_INFO_TYPE.WATCH;
                    break;
            }



            

        }

        public override void PrintCharacterInfo()
        {
            Console.WriteLine(Program.PadLeftForKorean("[내정보]", 18));
            Console.WriteLine($" Lv.{level, -3}" + Program.CenterAlign(name, 18) +$"({job})");
            Console.Write($" "); PrintExp();Console.WriteLine("");
            Console.WriteLine($" HP   " + $"{curHealthPoint}/{maxHealthPoint}".PadRight(11) + $"MP   {curManaPoint}/{maxManaPoint}");
            Console.WriteLine($" ATK  {attackPower}".PadRight(17) + $"DEF  {defense}");
            Console.WriteLine($" Gold {gold}G");
            Console.WriteLine($"");
        }
       
        public void PrintEquipedItemInfo()
        {
            Console.WriteLine(Program.PadLeftForKorean("[장착 아이템]", 21));
            for (int i = 0; i < _equippedItems.Count; i++)
            {
                Console.Write($"{_equippedItems[i].ItemData.ItemCategory,-8} |  ");
                ItemManager.instance?.PrintItemInfo(_equippedItems[i].ItemData);
                Console.WriteLine();
            }
        }

        public void PrintInventoryInfo()
        {
            Console.WriteLine(Program.PadLeftForKorean("[인벤토리]", 19));
            if (_inventoryItems.Count != 0)
            {
                switch (sceneInfoType)
                {
                    case SCENE_INFO_TYPE.WATCH:
                        for (int i = 0; i < _inventoryItems.Count; i++)
                        {
                            Console.Write($"{_inventoryItems[i].ItemData.ItemCategory,-8} |  ");
                            ItemManager.instance?.PrintItemInfo(_inventoryItems[i].ItemData);
                            Console.WriteLine();
                        }
                        break;
                    case SCENE_INFO_TYPE.ITEM_USE:
                    case SCENE_INFO_TYPE.SELL:
                        for (int i = 0; i < _inventoryItems.Count; i++)
                        {
                            Console.Write($"{i + 1}. {_inventoryItems[i].ItemData.ItemCategory,-8} |  ");
                            ItemManager.instance?.PrintItemInfo(_inventoryItems[i].ItemData);
                            Console.WriteLine();
                        }
                        break;
                }
                
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine(Program.PadLeftForKorean("비어 있음.", 19));
                Console.WriteLine("");
            }
        }

        public void GetExp(int getExp)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($" +{getExp}EXP  EXP {experience} -> ");
            experience += getExp;
            stringBuilder.Append($"{experience}");
            Console.Write(stringBuilder.ToString().PadRight(20));
        }
        public void GetGold(int getGold)
        {
            Console.Write($" +{getGold}G {gold}G -> ");
            gold += getGold;
            Console.Write($"{gold}G");
        }

        public void AddGold(int getGold)
        {
            gold += getGold;
        }
        public void EnterSell()
        {
            sceneInfoType = SCENE_INFO_TYPE.SELL;
        }
        public void ExitSell()
        {
            sceneInfoType = SCENE_INFO_TYPE.WATCH;
        }





        public bool GetItem(Item item)
        {
            if (_inventoryItems.Count < _inventoryMaxCount)
            {
                _inventoryItems.Add(item);
                return true;
            }
            else
            {
                Console.WriteLine("인벤토리가 가득찼습니다. 아이템을 추가할 수 없습니다.");
                Thread.Sleep(1200);
                return false;
            }
        }

        public void ThrowItem(int itemIndex)
        {
            _inventoryItems.RemoveAt(itemIndex);
        }

        public void BuyItem(ItemStruct item)
        {
            if (gold >= item.Price)
            {
                if (GetItem(new Item(item.Name.ToString())))
                {
                    Console.Write($"{item.Name}을 구매하셨습니다! Gold {gold} -> ");
                    gold -= item.Price;
                    Console.WriteLine($"{gold}");
                }

            }
            else
            {
                Console.WriteLine("돈도 없는 주제에...");
            }
            Thread.Sleep(2000);
        }

        public void SellItem(int itemIndex)
        {
            Console.Write($"{_inventoryItems[itemIndex].ItemData.Name}을 판매하셨습니다! Gold {gold} -> ");
            gold += (int)ItemManager.instance?.SellPrice(_inventoryItems[itemIndex].ItemData.Price);
            ThrowItem(itemIndex);
            Console.WriteLine($"{gold}");
            Thread.Sleep(2000);
        }

        public void EquipItem(int itemIndex)
        {
            switch (_inventoryItems[itemIndex].ItemData.ItemCategory)
            {
                case ItemCategory.WEAPON:
                    if (_isEquipWeapon == false)
                    {
                        _equippedItems[(int)ItemCategory.WEAPON] = _inventoryItems[itemIndex];
                        ThrowItem(itemIndex);
                        _isEquipWeapon = true;
                        attackPower += _equippedItems[(int)ItemCategory.WEAPON].ItemData.Stat;
                    }
                    else
                    {
                        attackPower -= _equippedItems[(int)ItemCategory.WEAPON].ItemData.Stat;
                        _inventoryItems.Add(_equippedItems[(int)ItemCategory.WEAPON]);
                        _equippedItems[(int)ItemCategory.WEAPON] = _inventoryItems[itemIndex];
                        ThrowItem(itemIndex);
                        attackPower += _equippedItems[(int)ItemCategory.WEAPON].ItemData.Stat;
                    }
                    break;
                case ItemCategory.ARMOR:
                    if (_isEquipArmor == false)
                    {
                        _equippedItems[(int)ItemCategory.ARMOR] = _inventoryItems[itemIndex];
                        ThrowItem(itemIndex);
                        _isEquipArmor = true;
                        defense += _equippedItems[(int)ItemCategory.ARMOR].ItemData.Stat;
                    }
                    else
                    {
                        defense -= _equippedItems[(int)ItemCategory.ARMOR].ItemData.Stat;
                        _inventoryItems.Add(_equippedItems[(int)ItemCategory.ARMOR]);
                        _equippedItems[(int)ItemCategory.ARMOR] = _inventoryItems[itemIndex];
                        ThrowItem(itemIndex);
                        defense += _equippedItems[(int)ItemCategory.ARMOR].ItemData.Stat;
                    }
                    break;
            }
        }
        public void UnEquipItem(int itemIndex)
        {
            _inventoryItems.Add(_equippedItems[itemIndex]);
            switch (_equippedItems[itemIndex].ItemData.ItemCategory)
            {
                case ItemCategory.WEAPON:
                    attackPower -= _equippedItems[itemIndex].ItemData.Stat;
                    _isEquipWeapon = false;
                    break;
                case ItemCategory.ARMOR:
                    defense -= _equippedItems[itemIndex].ItemData.Stat;
                    _isEquipArmor = false;
                    break;
            }
            _equippedItems[itemIndex] = new Item(_equippedItems[itemIndex].ItemData.ItemCategory);
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


        public void Attack()
        {
            Console.WriteLine("공격했습니다.");
        }
        public void Skill()
        {
            Console.WriteLine("스킬을 사용했습니다.");
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
