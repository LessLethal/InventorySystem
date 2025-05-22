using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{

    // Work in progress
    internal class Enemy
    {
        public int Health { get; set; }

        public int MaxHealth = 440;
        public string Name { get; set; }
        public string Weapon {  get; set; }
        public string Type { get; set; }
        public string[,] Weapons { get; set; }

        public Enemy(int health, int maxHealth, string name, string weapon, string type1)
        {
            this.Health = health;
            this.MaxHealth = maxHealth;
            this.Name = name;
            this.Weapon = weapon;
            this.Type = type1;
        }

        public void generateEnemy()
        {
            
        }
    }
}
