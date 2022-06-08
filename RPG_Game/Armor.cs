using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class Armor
    {
        protected string Name;
        protected int Defense;
        protected int Weight;

        public virtual string GetName()
        {
            return Name;
        }

        public virtual int GetDefense()
        {
            return Defense;
        }

        public virtual int GetWeight()
        {
            return Weight;
        }

        public Armor() { }
        public Armor(string name, int defense, int weight)
        {
            Name = name;
            Defense = defense;
            Weight = weight;
        }
    }
}
