using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class Weapon
    {
        protected string Name;
        protected int Power;
        protected int Weight;
        public virtual string GetName()
        {
            return Name;
        }
        public virtual int GetPower()
        {
            return Power;
        }
        public virtual int GetWeight()
        {
            return Weight;
        }
       
        public Weapon() { }
        public Weapon(string name, int power, int weight) 
        {
            Name = name;
            Power = power;
            Weight = weight;
        }
    }
}
