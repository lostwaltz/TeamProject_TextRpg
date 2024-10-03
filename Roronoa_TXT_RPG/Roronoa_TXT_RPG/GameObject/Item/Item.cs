using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG
{
    public enum ItemType
    {
        WEAPON, ARMOR, END
    }

    public struct ItemStruct
    {
        public ItemStruct(ItemStruct itemData)
        {
            Name = new StringBuilder(itemData.Name.ToString());
            Description = new StringBuilder(itemData.Description.ToString());

            ItemType = itemData.ItemType;
            Stat = itemData.Stat;
            Price = itemData.Price;
        }
        public StringBuilder Name;
        public StringBuilder Description;
        public ItemType ItemType;
        public int Stat;
        public int Price;
    }
    public class Item
    {
        public Item(string itemName)
        {
            CreateItemPreset(itemName);
        }

        public ItemStruct ItemData { get; private set; }

        public StringBuilder GetItemStringBuilder()
        {
            StringBuilder stringBuilder = new StringBuilder();

            int totalNameLenght = 20;
            int totalDescLenght = 30;

            totalNameLenght -= ItemData.Name.Length;
            totalDescLenght -= ItemData.Description.Length;

            stringBuilder.AppendFormat("{0, " + -totalNameLenght + "} |", ItemData.Name);

            switch (ItemData.ItemType)
            {
                case ItemType.WEAPON:
                    stringBuilder.AppendFormat(" {0, -5}", "공격력 + ");
                    break;
                case ItemType.ARMOR:
                    stringBuilder.AppendFormat(" {0, -5}", "방어력 + ");
                    break;
            }

            stringBuilder.AppendFormat("{0, -4} | ", ItemData.Stat);

            stringBuilder.Append(Program.PadRightForKorean(ItemData.Description.ToString(), ItemData.Description.Length));
            
            return stringBuilder;
        }

        private void CreateItemPreset(string itemName)
        {
            ItemStruct tempData = ItemData;

            switch (itemName)
            {
                case "수련자 갑옷":
                    tempData.Name = new StringBuilder(itemName);
                    tempData.Description = new StringBuilder("수련에 도움을 주는 갑옷입니다.                   ");
                    tempData.ItemType = ItemType.ARMOR;
                    tempData.Stat = 5;
                    tempData.Price = 1000;
                    break;
                case "무쇠 갑옷":
                    tempData.Name = new StringBuilder(itemName);
                    tempData.Description = new StringBuilder("무쇠로 만들어져 튼튼한 갑옷입니다.               ");
                    tempData.ItemType = ItemType.ARMOR;
                    tempData.Stat = 9;
                    tempData.Price = 2000;
                    break;
                case "스파르타의 갑옷":
                    tempData.Name = new StringBuilder(itemName);
                    tempData.Description = new StringBuilder("스파르타의 전사들이 사용했다는 전설의 갑옷입니다.");
                    tempData.ItemType = ItemType.ARMOR;
                    tempData.Stat = 15;
                    tempData.Price = 3500;
                    break;
                case "낡은 검":
                    tempData.Name = new StringBuilder(itemName);
                    tempData.Description = new StringBuilder("쉽게 볼 수 있는 낡은 검 입니다.                  ");
                    tempData.ItemType = ItemType.WEAPON;
                    tempData.Stat = 2;
                    tempData.Price = 600;
                    break;
                case "청동 도끼":
                    tempData.Name = new StringBuilder(itemName);
                    tempData.Description = new StringBuilder("어디선가 사용됐던거 같은 도끼입니다.             ");
                    tempData.ItemType = ItemType.WEAPON;
                    tempData.Stat = 5;
                    tempData.Price = 1500;
                    break;
                case "스파르타의 창":
                    tempData.Name = new StringBuilder(itemName);
                    tempData.Description = new StringBuilder("스파르타의 전사들이 사용했다는 전설의 창입니다.  ");
                    tempData.ItemType = ItemType.WEAPON;
                    tempData.Stat = 7;
                    tempData.Price = 3000;
                    break;
                case "취업의 돌":
                    tempData.Name = new StringBuilder(itemName);
                    tempData.Description = new StringBuilder("소유한자를 취업시켜준다는 취업의 돌...열심히 하자");
                    tempData.ItemType = ItemType.WEAPON;
                    tempData.Stat = 100;
                    tempData.Price = 9999;
                    break;
            }

            ItemData = tempData;
        }
    }
}