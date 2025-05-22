using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    internal class Meny
    {

        public void mainMeny()
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("         Welcome to EFT Inventory       ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. BUY items");
            Console.WriteLine("2. Display and Manage your items");
            Console.WriteLine("3. Enter Raid (Still in progress)");
            Console.WriteLine("4. Quit");
            Console.WriteLine("========================================");
            Console.Write("Enter your choice: ");
        }

        public void managinMeny()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("         Inventory Management Menu      ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Sell Item");
            Console.WriteLine("2. Move Item");
            Console.WriteLine("3. Discard Item");
            Console.WriteLine("4. Equip Item (Still in progress)");
            Console.WriteLine("5. Go Back");
            Console.WriteLine("========================================");
        }

        public void fleaMartket(InventoryCrafter crafter)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("              Flea Market               ");
            Console.WriteLine("========================================");
            Console.WriteLine($"Current Balance: {crafter.Balance} RUB");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Weapons");
            Console.WriteLine("2. Armor");
            Console.WriteLine("3. Ammo");
            Console.WriteLine("4. Consumables");
            Console.WriteLine("5. Go Back");
            Console.WriteLine("========================================");
            Console.Write("Enter your choice: ");
        }

        public void wepaonMeny()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("               Weapons                  ");
            Console.WriteLine("========================================");
            Console.WriteLine("ID   Name         Price      Description");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1    AK-74        50000   Standard rifle");
            Console.WriteLine("2    AKM          50000     Modern rifle");
            Console.WriteLine("3    AK-101       50000    Compact rifle");
            Console.WriteLine("4    SVD          50000   Marksman rifle");
            Console.WriteLine("========================================");
            Console.Write("Enter the ID of the weapon you want to buy: ");
        }

        public void armorMeny()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("                Armor                   ");
            Console.WriteLine("========================================");
            Console.WriteLine("ID   Name                     Price");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1         6B1-15 Armored Rig       35000");
            Console.WriteLine("2         6B3TM-01M Armored Rig    35000");
            Console.WriteLine("3         6B13 Assault Armor       35000");
            Console.WriteLine("4         6B23-1 Armor             35000");
            Console.WriteLine("========================================");
            Console.Write("Enter the ID of the armor you want to buy: ");
        }
        public void ammoMeny()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("                 Ammo                   ");
            Console.WriteLine("========================================");
            Console.WriteLine("ID   Name               Price (per unit)");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1    7.62 Ammo                       200");
            Console.WriteLine("2    5.45 Ammo                       200");
            Console.WriteLine("3    5.56 Ammo                       200");
            Console.WriteLine("4    7.62x51 Ammo                    200");
            Console.WriteLine("========================================");
            Console.Write("Enter the ID of the ammo you want to buy: ");
        }
        public void consumableMeny()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("             Consumables                ");
            Console.WriteLine("========================================");
            Console.WriteLine("ID   Name                          Price");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1    Trimadol                      20000");
            Console.WriteLine("2    Zagustin                      20000");
            Console.WriteLine("3    Propital                      20000");
            Console.WriteLine("4    Morphine                      20000");
            Console.WriteLine("========================================");
            Console.Write("Enter the ID of the consumable you want to buy: ");
        }
    }
}
