using System.Text;

namespace Roronoa_TXT_RPG
{
    public enum ItemCategory
    {
        WEAPON, ARMOR, END, NULL
    }
    public struct ItemStruct
    {
        public ItemStruct(ItemStruct itemData)
        {
            Name = new StringBuilder(itemData.Name.ToString());
            Description = new StringBuilder(itemData.Description.ToString());

            ItemCategory = itemData.ItemCategory;
            Stat = itemData.Stat;
            Price = itemData.Price;
        }
        public ItemStruct(string name, string description, ItemCategory itemCategory, int stat, int price)
        {
            Name = new StringBuilder(name);
            Description = new StringBuilder(description);
            ItemCategory = itemCategory;
            Stat = stat;
            Price = price;
        }

        public StringBuilder Name;
        public StringBuilder Description;
        public ItemCategory ItemCategory;
        public int Stat;
        public int Price;
    }
    public class Item
    {
        public ItemStruct ItemData { get; private set; }

        internal Item(ItemCategory itemCategory) 
        {
            ItemData = new ItemStruct("빈 아이템", "", itemCategory, 0, 0);
        }
        public Item(string itemName)
        {
            CreateItemPreset(itemName);
        }


        private void CreateItemPreset(string itemName)
        {
            ItemStruct? tempData = ItemManager.instance?.ItemList.Find(item => item.Name.ToString() == itemName);

            if (tempData == null)
            {
                ItemData = new ItemStruct("빈 아이템", "", ItemCategory.NULL, 0, 0);
            }
            else
            {
                ItemData = (ItemStruct)tempData;
            }

        }


    }

}