using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel.Design;
using System.Threading.Tasks.Dataflow;
using System.Reflection;

namespace InventorySystem
{
    /// BEWARE: LAZY CODING AHEAD 
    internal class MyProgram
    {
        internal void Run()
        {
            Meny meny = new Meny();
            InventoryCrafter crafter = new InventoryCrafter(10, 30);
            bool running = true; // Makes while loop go round

            while (running) // While loop that runs the program until the user chooses to quit
            {
                meny.mainMeny(); // Calls the MainMeny method from the Meny class to display the main menu

                if (int.TryParse(Console.ReadLine(), out int menyChoice)) // Checks if the input is a number and if it is, it runs the code inside the if statement 
                {
                    switch (menyChoice)
                    {
                        case 1:
                            HandleFleaMartket(meny, crafter); // Calls the HandleFleaMarket method to handle the flea market logic
                            break;
                        case 2:
                            HandleManagementMenu(meny, crafter); // Calls the HandleManagementMenu method to handle the inventory management logic
                            break;
                        case 3:
                            // Handle entering raid NOT WORKING RN IM LAZY
                            break;
                        case 4:
                            running = false; // Sets running to false to exit the while loop and quit the program
                            break;

                    }
                }
            }
        }

        private void HandleFleaMartket(Meny meny, InventoryCrafter crafter)
        {
            bool storeRunning = true;
            while (storeRunning)
            {
                meny.fleaMartket(crafter);
                if (int.TryParse(Console.ReadLine(), out int shopChoice))
                {

                    switch (shopChoice)
                    {
                        case 1:
                            meny.wepaonMeny(); // Wepaon purchasing
                            if (int.TryParse(Console.ReadLine(), out int weaponChoice))
                            {
                                Item? weapon = weaponChoice switch
                                {
                                    1 => new Item("AK-74", Item.ItemType.Weapon, weaponChoice),
                                    2 => new Item("AKM", Item.ItemType.Weapon, weaponChoice),
                                    3 => new Item("AK-101", Item.ItemType.Weapon, weaponChoice),
                                    4 => new Item("SVD", Item.ItemType.Weapon, weaponChoice),
                                    _ => null
                                };

                                if (weapon != null)
                                {
                                    crafter.buyItem(weapon);
                                    Console.WriteLine("Press enter to continue.");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid weapon choice.");
                                }
                            }
                            break;
                        case 2:
                            meny.armorMeny();
                            if (int.TryParse(Console.ReadLine(), out int armorChoice))
                            {
                                Item? armor = armorChoice switch
                                {
                                    1 => new Item("6B1-15 Armored Rig", Item.ItemType.Armor, armorChoice),
                                    2 => new Item("6B3TM-01M Armored Rig", Item.ItemType.Armor, armorChoice),
                                    3 => new Item("6B13 Assault Armor", Item.ItemType.Armor, armorChoice),
                                    4 => new Item("6B23-1 Armor", Item.ItemType.Armor, armorChoice),
                                    _ => null
                                };
                                if (armor != null)
                                {
                                    crafter.buyItem(armor);
                                    Console.WriteLine("Press enter to continue.");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid armor choice.");
                                }
                            }
                            break;
                        case 3:
                            meny.ammoMeny();
                            if (int.TryParse(Console.ReadLine(), out int ammoChoice))
                            {
                                Item? ammo = ammoChoice switch
                                {
                                    1 => new Item("5.45x39mm", Item.ItemType.Ammo, ammoChoice),
                                    2 => new Item("7.62x39mm", Item.ItemType.Ammo, ammoChoice),
                                    3 => new Item("5.56x45mm", Item.ItemType.Ammo, ammoChoice),
                                    4 => new Item("7.62x51mm", Item.ItemType.Ammo, ammoChoice),
                                    _ => null
                                };
                                if (ammo != null)
                                {
                                    crafter.buyItem(ammo);
                                    Console.WriteLine("Press enter to continue.");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ammo choice.");
                                }
                            }
                            break;
                        case 4:
                            meny.consumableMeny();
                            if (int.TryParse(Console.ReadLine(), out int consumableChoice))
                            {
                                Item? consumable = consumableChoice switch
                                {
                                    1 => new Item("Trimadol", Item.ItemType.Consumable, consumableChoice),
                                    2 => new Item("Zagustin", Item.ItemType.Consumable, consumableChoice),
                                    3 => new Item("Proptial", Item.ItemType.Consumable, consumableChoice),
                                    4 => new Item("Morphine", Item.ItemType.Consumable, consumableChoice),
                                    _ => null
                                };
                                if (consumable != null)
                                {
                                    crafter.buyItem(consumable);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid consumable choice.");
                                }
                            }
                            break;
                        case 5:
                            storeRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Press enter to continue.");
                            Console.ReadLine();
                            break;
                    }
                }
            }
        }

        private void HandleManagementMenu(Meny meny, InventoryCrafter crafter)
        {
            bool managementRunning = true;
            while (managementRunning)
            {
                meny.managinMeny();
                crafter.displayItems(); // Display the items in the inventory
                crafter.createGrid(); // Create the grid for the inventory system
                if (int.TryParse(Console.ReadLine(), out int managementChoice))
                {
                    switch (managementChoice)
                    {
                        case 1:
                            //Handle selling item
                            Console.WriteLine("Enter the ID of the item you want to sell:");
                            if (int.TryParse(Console.ReadLine(), out int itemId))
                            {
                                Console.WriteLine("Enter the quantity you want to sell:");
                                if (int.TryParse(Console.ReadLine(), out int quantity))
                                {
                                    crafter.sellItem(itemId, quantity);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid quantity.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid item ID.");
                            }
                            break;
                        case 2:
                            // Handle moving item
                            break;
                        case 3:
                            // Handle discarding item
                            break;
                        case 4:
                            // Handle equipping item IM LAZY
                            break;
                        case 5:
                            managementRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Press enter to continue.");
                            Console.ReadLine();
                            break;
                    }
                }
            }
        }


    }
}