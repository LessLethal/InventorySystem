using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    internal class Item
    {
        internal enum ItemType // Enum that contains the different types of items that can be created
        {
            Armor,
            Weapon,
            Ammo,
            Consumable
        }
        public string Name { get; set; }
        public int itemRow { get; set; }
        public int itemCol { get; set; }
        public int id { get; set; }
        public decimal Price { get; set; }
        public ItemType Type { get; set; } 

        public Item(string Name, ItemType type, int id) // Constructor that initializes the name, type, row, column, and id of the item
        {
            this.Name = Name;
            this.Type = type;
            this.id = id;
            this.Price = PriceByType(type);
            SetItemDimensions(type);
        }

        public decimal PriceByType(ItemType type) // A method that returns the price of an item based on its type
        {
            decimal price = 0;
            switch (type)
            {
                case ItemType.Weapon:
                    price = 50000m;
                    break;
                case ItemType.Consumable:
                    price = 20000m;
                    break;
                case ItemType.Ammo:
                    price = 200m;
                    break;
                case ItemType.Armor:
                    price = 35000m;
                    break;
                default:
                    price = 0m;
                    break;
            }
            return price;
        }

        private void SetItemDimensions(ItemType type) // A method that sets the item dimensions based on its type
        {
            switch (type)
            {
                case ItemType.Weapon:
                    this.itemRow = 2;
                    this.itemCol = 7;
                    break;
                case ItemType.Armor:
                    this.itemRow = 3;
                    this.itemCol = 3;
                    break;
                case ItemType.Ammo:
                case ItemType.Consumable:
                    this.itemRow = 1;
                    this.itemCol = 1;
                    break;
                default:
                    this.itemRow = 0;
                    this.itemCol = 0;
                    break;
            }
        }
    }
}

