using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    internal class Item
    {
        internal enum ItemType // Enum that contains the different types of items that can be created, A enum is a special class that represents a group of constants similar to a class 
        {
            Armor,
            Weapon,
            Ammo,
            Consumable
        }
        public string Name { get; set; }
        public int id { get; set; }
        public int itemRow { get; set; }
        public int itemCol { get; set; }
        public decimal Price { get; set; }
        public ItemType Type { get; set; }
        public int quantity { get; set; } 

        public Item(string Name, ItemType type, int id, int quantity = 1) // Constructor that initializes the name, type, row, column, and id of the item
        {
            this.Name = Name;
            this.Type = type;
            this.id = id;
            this.Price = PriceByType(type) * quantity;
            SetItemDimensions(type);
            this.quantity = quantity;
        }

        public decimal PriceByType(ItemType type) // A method that returns the price of an item based on its type
        {
            return type switch
            {
                ItemType.Weapon => 50000m,
                ItemType.Consumable => 20000m,
                ItemType.Ammo => 200m,
                ItemType.Armor => 35000m,
                _ => 0m,
            };
        }

        private void SetItemDimensions(ItemType type) // A method  that sets the item dimensions based on its type
        {
            switch (type)
            {
                case ItemType.Weapon:
                    itemRow = 2;
                    itemCol = 7;
                    break;
                case ItemType.Armor:
                    itemRow = 3;
                    itemCol = 3;
                    break;
                case ItemType.Ammo:
                case ItemType.Consumable:
                    itemRow = 1;
                    itemCol = 1;
                    break;
            }
        }
    }
}
