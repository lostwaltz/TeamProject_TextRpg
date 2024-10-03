using System.Text;

namespace Roronoa_TXT_RPG
{
    public class ItemManager
    {
        public static ItemManager? instance { get; private set; }

        List<ItemStruct> itemList = new List<ItemStruct>() {
        new ItemStruct("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", ItemCategory.ARMOR, 5, 1000),
        new ItemStruct("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", ItemCategory.ARMOR, 9, 2000),
        new ItemStruct("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", ItemCategory.ARMOR, 15, 3500),
        new ItemStruct("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", ItemCategory.WEAPON, 2, 600),
        new ItemStruct("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", ItemCategory.WEAPON, 5, 1500),
        new ItemStruct("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", ItemCategory.WEAPON, 7, 3000),
         new ItemStruct("취업의 돌", "소유한자를 취업시켜준다는 취업의 돌...열심히 하자", ItemCategory.WEAPON, 100, 9999)
        };

        public static void InitItemManager()
        {
            if (instance == null)
            {
                instance = new ItemManager();
            }
        }

        public void PrintItemInfo(ItemStruct ItemData)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int totalNameLenght = 20;
            int totalDescLenght = 30;

            totalNameLenght -= ItemData.Name.Length;
            totalDescLenght -= ItemData.Description.Length;

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

            stringBuilder.Append(Program.PadRightForKorean(ItemData.Description.ToString(), ItemData.Description.Length));

            Console.Write(stringBuilder);
        }

        public void PrintStore(STORE_ACTION_TYPE storeActionType)
        {
            int seletNum;
            Console.Clear();
            Console.WriteLine("Store!");
            Console.WriteLine("");
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
                    Console.WriteLine("무엇을 하시겠습니까?");
                    Console.WriteLine("");
                    Console.WriteLine("1. 구매");
                    Console.WriteLine("2. 판매");
                    Console.WriteLine("");
                    Console.WriteLine("0. 로비로 돌아가기");
                    Console.Write(">>");
                    Program.KeyInputCheck(out seletNum, 2);
                    break;
                case STORE_ACTION_TYPE.PURCHASE:
                    for (int i = 0; i < itemList.Count; i++)
                    {
                        Console.Write($"{i}. ");
                        PrintItemInfo(itemList[i]);
                        Console.WriteLine();
                    }
                    Console.WriteLine("");
                    Console.WriteLine("무엇을 하시겠습니까?");
                    Console.WriteLine("");
                    Console.WriteLine("0. 이전으로");
                    Console.Write(">>");
                    Program.KeyInputCheck(out seletNum, itemList.Count);
                    break;
                case STORE_ACTION_TYPE.SELL:

                    break;
            }


        }
    }

}