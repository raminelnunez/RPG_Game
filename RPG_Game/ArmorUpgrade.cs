using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal abstract class ArmorUpgrade : Armor
    {
        public string UpgradeName;
        public int UpgradeDefense;
        public int UpgradeWeight;
        public Armor Armor { get; set; }
        public abstract override string GetName();
        public abstract override int GetDefense();
        public abstract override int GetWeight();

        public ArmorUpgrade() { }
        public ArmorUpgrade(Armor armor)
        {
            Armor = armor;
        }
        public virtual Armor Upgrade(Armor selectedArmor)
        {
            return selectedArmor;
        }

    }
}
