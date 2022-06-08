using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class Monster
    {
        public readonly string Name;
        public readonly int BaseHealth;
        public int Health;
        public int Strength;
        public int Defense;
        public int Speed;

        public Monster(string name, int health, int strength, int defence,  int speed)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            Strength = strength;
            Defense = defence;
            Speed = speed;

        }

        public void ResetStats()
        {
            Health = BaseHealth;
        }
    }
}
