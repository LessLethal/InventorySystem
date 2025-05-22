namespace InventorySystem
{
    using System;
    using static InventorySystem.Item;

    internal class MyProgram
    {
        internal void Run()
        {
            InventoryCrafter crafter = null;
            bool running = true; // Makes while loop go round
            int menyChoice;
            int innerMenyChoice;
            
            while (running) // While loop that runs the program until the user chooses to quit
            {
                Console.Clear();
                Console.WriteLine(
                    "Welcome to EFT, Start by creating your first stash!\n1. Create Stash\n2. Add an item\n3. Display and Manage your items\n4. Enter Raid(Still in progress)\n5. Quit"
                );

                if (int.TryParse(Console.ReadLine(), out menyChoice)) // Checks if the input is a number and if it is, it runs the code inside the if statement
                {
                    if (menyChoice == 1)
                    {
                        Console.WriteLine("Enter how mnay ROWS the grid will have?");
                        int row = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter how many COLUMNS the grid will have?");
                        int column = Convert.ToInt32(Console.ReadLine());

                        crafter = new InventoryCrafter(row, column); // Adds the row and colums and creates the grids in the INverntoryCrafter class
                        Console.WriteLine(
                            $"You have created a grid system with {row} rows and {column} columns"
                        );
                    }
                    else if (menyChoice == 2)
                    {
                        bool storeRunning = true;

                        if (crafter == null)
                        {
                            Console.WriteLine("Create an stash first!\nPress enter to Continue");
                            Console.ReadLine();
                        }
                        else
                        {
                            
                            while (storeRunning)
                            {
                                if (int.TryParse(Console.ReadLine(), out storeMenyChoice))
                                {
                                    if (storeManyChooice == 1)
                                    {
                                        
                                    }
                                }
                            }
                            Console.WriteLine("Enter the name of the item:");
                            string itemName = Console.ReadLine();

                            Console.WriteLine("Enter the item type (Armor, Weapon, Ammo, Consumable):");
                            ItemType itemType = (ItemType)Enum.Parse(typeof(ItemType), Console.ReadLine(), true);

                            int itemId = crafter.Items.Count + 1; 
                            Item item = new Item(itemName, itemType, itemId); //Creates the item with the input

                            crafter.addItem(item);
                            Console.WriteLine($"{itemName} added to the inventory");


                            Console.ReadLine();
                        }
                    }

                    else if (menyChoice == 3)
                    {
                        if (crafter == null)
                        {
                            Console.WriteLine("Create an Inventory first!\nPress enter to Continue");
                            Console.ReadLine();
                        }
                        else
                        {
                            bool innerRunning = true;
                            Console.Clear();
                            Console.WriteLine(
                                "What would you like to do?\n1. Sell\n2. Discard\n3. Equip\n4. Consume\n5. Exit Management"
                            );

                            crafter.displayItems();
                            crafter.createGrid();
                            while (innerRunning)
                            {
                                if (int.TryParse(Console.ReadLine(), out innerMenyChoice))
                                {
                                    if (innerMenyChoice == 1)
                                    {
                                        Console.WriteLine("Enter the ID of the item you want to sell:");
                                        int itemId = Convert.ToInt32(Console.ReadLine());
                                        crafter.sellItem(itemId);
                                    }
                                    if (innerMenyChoice == 2)
                                    {
                                       
                                    }
                                    if (innerMenyChoice == 3)
                                    {
                                        
                                    }
                                    if (innerMenyChoice == 4)
                                    {
                                        
                                    }
                                    if (innerMenyChoice == 5)
                                    {
                                        innerRunning = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a number.");
                                }
                            }
                        }
                    }
                    else if (menyChoice == 4)
                    {
                        //Not Implemented yes
                    }
                    else if (menyChoice == 5)
                    {
                        Console.WriteLine("Exiting Program");
                        running = false;
                    }
                    else
                    {
                        Console.WriteLine("invalid Choice");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}
