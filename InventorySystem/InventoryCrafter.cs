using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InventorySystem.Item;

namespace InventorySystem
{
    internal class InventoryCrafter
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string[,] Grid { get; set; }
        public List<Item> Items { get; set; }
        public decimal Balance { get; private set; }

        public InventoryCrafter(int row, int column) // Constructor that initializes the row, column, grid, and items list for the inventory system 
        {
            this.Row = row;
            this.Column = column;
            Grid = new string[row, column];
            Items = new List<Item>();
            Balance = 500000;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Grid[i, j] = "[ ]"; // Initialize the grid with empty slots
                }
            }
        }

        public void buyItem(Item item) // Method that buys an item and adds it to the inventory system
        {
            // only ammo is stackable when buying to wepaons or armor or consumables it will give a new id and a new slot

            if (item.Type == Item.ItemType.Ammo)
            {
                item.id = Items.Count + 1; // Assign a new ID to the item
                item.Price = item.PriceByType(item.Type) * item.quantity; // Calculate the price based on the quantity
            }
            else
            {
                item.id = Items.Count + 1; // Assign a new ID to the item
                item.Price = item.PriceByType(item.Type); // Calculate the price based on the type
            }

            // Buying an item
            if (Balance >= item.Price) // Check if the balance is sufficient
            {
                Balance -= item.Price; // Deduct the price from the balance
                Items.Add(item); // Add the item to the inventory lis
                if (PlaceItemInGrid(item)) // Place the item in the grid
                {
                    Console.WriteLine($"{item.Name} bought and added to inventory.");
                }
                else
                {
                    Console.WriteLine("Not enough space in inventory.");
                }
            }
            else
            {
                Console.WriteLine("Not enough balance to buy this item.");
            }

        }



        private bool PlaceItemInGrid(Item item)
        {
            for (int i = 0; i <= Row - item.itemRow; i++)
            {
                for (int j = 0; j <= Column - item.itemCol; j++)
                {
                    bool canPlace = true;

                    for (int k = 0; k < item.itemRow; k++)
                    {
                        for (int l = 0; l < item.itemCol; l++)
                        {
                            if (Grid[i + k, j + l] != "[ ]")
                            {
                                canPlace = false;
                                break;
                            }
                        }
                        if (!canPlace) break;
                    }

                    if (canPlace)
                    {
                        for (int k = 0; k < item.itemRow; k++)
                        {
                            for (int l = 0; l < item.itemCol; l++)
                            {
                                Grid[i + k, j + l] = $"[{item.id}]";
                            }
                        }
                        return true; // placed successfully
                    }
                }
            }
            return false; // no space found
        }

        public void createGrid() // Method that creates the grid for the inventory system 
        {
            for (int i = 0; i < Row; i++) // for loop that iterates through the rows and columns of the grid
            {
                for (int j = 0; j < Column; j++)
                {
                    Console.Write(Grid[i, j]); // Print out the grid
                }
                Console.WriteLine();
            }
        }

        public void remove(int itemId) // Method that removes an item from the inventory system
        {
            //Delte the item if you hate money
            Item item = Items.FirstOrDefault(i => i.id == itemId); // Find the item by its ID
            if (item != null)
            {
                for (int i = 0; i < Row; i++) // for loop that iterates through the rows and columns of the grid
                {
                    for (int j = 0; j < Column; j++)
                    {
                        if (Grid[i, j] == $"[{item.id}]") // If the item is found in the grid
                        {
                            for (int k = 0; k < item.itemRow; k++) // for loop that iterates through the rows and columns of the grid
                            {
                                for (int l = 0; l < item.itemCol; l++)
                                {
                                    Grid[i + k, j + l] = "[ ]"; // Remove the item from the grid
                                }
                            }
                        }
                    }
                }
                Items.Remove(item); // Remove the item from the list
                Console.WriteLine($"{item.Name} removed from inventory.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
        public void displayItems()
        {
            Console.WriteLine("Items List:");
            if (Items.Count == 0)
            {
                Console.WriteLine("No items in inventory yet.");
            }
            else
            {
                foreach (var item in Items) // displays all the items with the use of an foreach loop
                {
                    Console.WriteLine($"Name: {item.Name}, Type: {item.Type}, Size: {item.itemRow}x{item.itemCol}, ID: {item.id}, Amount: {item.quantity}"); // Print out the item name, type, size, id, and amount
                }

            }
        }
        public void sellItem(int itemId, int quantity)
        {
            Item item = Items.FirstOrDefault(i => i.id == itemId);
            if (item != null)
            {
                if (quantity > 0 && quantity <= item.quantity)
                {
                    // Calculate the selling price based on the quantity sold
                    decimal pricePerUnit = item.Price / item.quantity; // Price per unit
                    decimal sellingPrice = pricePerUnit * 0.95m * quantity; // 95% of the price per unit

                    item.quantity -= quantity; // Reduce the quantity of the item
                    Balance += sellingPrice; // Add the selling price to the balance
                    item.Price = pricePerUnit * item.quantity; // Update the item's price based on the remaining quantity
                    for (int i = 0; i < Row; i++) // for loop that iterates through the rows and columns of the grid
                    {
                        for (int j = 0; j < Column; j++)
                        {
                            if (Grid[i, j] == $"[{item.id}]") // If the item is found in the grid
                            {
                                for (int k = 0; k < item.itemRow; k++) // for loop that iterates through the rows and columns of the grid
                                {
                                    for (int l = 0; l < item.itemCol; l++)
                                    {
                                        Grid[i + k, j + l] = "[ ]"; // Remove the item from the grid
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine($"{quantity} x {item.Name} sold for {sellingPrice} rubles. Current balance: {Balance} rubles");

                    if (item.quantity == 0)
                    {
                        Items.Remove(item);
                        Console.WriteLine($"{item.Name} completely removed from inventory.");
                    }
                }

                else
                {
                    Console.WriteLine($"Invalid quantity. You can sell between 1 and {item.quantity}.");
                }
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
        public void moveItem(int itemId, int newRow, int newCol) // move the item through the grid
        {
            // Find the item by its ID
            Item item = Items.FirstOrDefault(i => i.id == itemId);
            

        }

    }
}
