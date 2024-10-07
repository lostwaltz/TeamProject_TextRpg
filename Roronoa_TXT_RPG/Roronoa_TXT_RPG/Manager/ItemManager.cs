using System.Runtime.CompilerServices;
using System.Text;

public enum STORE_ACTION_TYPE { GO_LOBY, PURCHASE, SELL, WATCH }
namespace Roronoa_TXT_RPG
{
    internal class ItemManager
    {
        public static ItemManager? instance { get; private set; }
        static public STORE_ACTION_TYPE storeActionType { get; private set; }
        
        //전체 아이템 리스트(상점에서 사용)
        static private List<ItemStruct> itemList = new List<ItemStruct>() {
        new ItemStruct("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", ItemCategory.ARMOR, 7, 100),
        new ItemStruct("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", ItemCategory.ARMOR, 21, 200),
        new ItemStruct("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", ItemCategory.ARMOR, 30, 350),
        new ItemStruct("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", ItemCategory.WEAPON, 5, 60),
        new ItemStruct("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", ItemCategory.WEAPON, 10, 150),
        new ItemStruct("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", ItemCategory.WEAPON, 30, 300),
         new ItemStruct("취업의 돌", "소유한자를 취업시켜준다는 취업의 돌...열심히 하자", ItemCategory.WEAPON, 100, 999)
        };
        public List<ItemStruct> ItemList
        {
            get { return itemList; }
            protected set { itemList = value; }
        }

        public static void InitItemManager()
        {
            if (instance == null)
            {
                instance = new ItemManager();
            }
            storeActionType = STORE_ACTION_TYPE.WATCH;
        }

        public void PrintItemInfo(ItemStruct ItemData)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int totalNameLenght = 20;
            int totalDescLenght = 50;

            totalNameLenght -= ItemData.Name.Length;

            stringBuilder.AppendFormat("{0, " + -totalNameLenght + "} |", ItemData.Name);

            switch (ItemData.ItemCategory)
            {
                case ItemCategory.WEAPON:
                    stringBuilder.AppendFormat(" {0, -5}", "공격력 + ");
                    break;
                case ItemCategory.ARMOR:
                    stringBuilder.AppendFormat(" {0, -5}", "방어력 + ");
                    break;
            }

            stringBuilder.AppendFormat("{0, -4} | ", ItemData.Stat);

            stringBuilder.Append(Program.PadRightForKorean(ItemData.Description.ToString(), totalDescLenght) + " | ");

            if (Program.player.sceneInfoType == SCENE_INFO_TYPE.SELL)
            {
                stringBuilder.Append($"{SellPrice(ItemData.Price), 4}G");
            }
            else
            {
                stringBuilder.Append($"{ItemData.Price,4}G");
            }

            Console.Write(stringBuilder);
        }

        public void PrintStore()
        {
            int seletNum;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Store!");
            Console.WriteLine("");
            switch (storeActionType)
            {
                case STORE_ACTION_TYPE.WATCH:
                    for (int i = 0; i < itemList.Count; i++)
                    {
                        PrintItemInfo(itemList[i]);
                        Console.WriteLine();

                    }
                    Console.WriteLine("");
                    Console.WriteLine(Program.PadRightForKorean("무엇을 하시겠습니까?", 30) + $"보유골드 {Program.player.gold}G");
                    Console.WriteLine("");
                    Console.WriteLine("1. 구매");
                    Console.WriteLine("2. 판매");
                    Console.WriteLine("");
                    Console.WriteLine("0. 로비로 돌아가기");
                    Console.Write(">>");
                    Program.KeyInputCheck(out seletNum, 2);
                    switch ((STORE_ACTION_TYPE)seletNum)
                    {
                        case STORE_ACTION_TYPE.PURCHASE:
                            storeActionType = STORE_ACTION_TYPE.PURCHASE;
                            break;
                        case STORE_ACTION_TYPE.SELL:
                            storeActionType = STORE_ACTION_TYPE.SELL;
                            break;
                        case STORE_ACTION_TYPE.GO_LOBY:
                            SceneManager.instance?.SceneChange(SCENE_TYPE.SCENE_LOBY);
                            break;
                    }
                    break;
                case STORE_ACTION_TYPE.PURCHASE:
                    for (int i = 0; i < itemList.Count; i++)
                    {
                        Console.Write($"{i + 1}. ");
                        PrintItemInfo(itemList[i]);
                        Console.WriteLine();
                    }
                    Console.WriteLine("");
                    Console.WriteLine(Program.PadRightForKorean("무엇을 구매시겠습니까?", 30) + $"보유골드 {Program.player.gold}G");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("0. 이전으로");
                    Console.Write(">>");
                    if(Program.KeyInputCheck(out seletNum, itemList.Count))
                    {
                        if (seletNum == 0)
                        {
                            storeActionType = STORE_ACTION_TYPE.WATCH;
                        }
                        else
                        {
                            Program.player.BuyItem(itemList[seletNum - 1]);
                        }
                    }
                    
                    break;
                case STORE_ACTION_TYPE.SELL:
                    Program.player.EnterSell();
                    Program.player.PrintInventoryInfo();
                    Console.WriteLine(Program.PadRightForKorean("무엇을 판매시겠습니까?", 30) + $"보유골드 {Program.player.gold}G");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("0. 이전으로");
                    Console.Write(">>");
                    if(Program.KeyInputCheck(out seletNum, Program.player._inventoryItems.Count))
                    {
                        if (seletNum == 0)
                        {
                            storeActionType = STORE_ACTION_TYPE.WATCH;
                        }
                        else
                        {
                            Program.player.SellItem(seletNum - 1);
                        }
                    }
                    Program.player.ExitSell();
                    break;
            }


        }

        public int SellPrice(int price)
        {
            return price * 7 / 10;
        }

    }

}