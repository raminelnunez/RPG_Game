using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.ArmorUpgrades
{
    internal class LeatherWraps : ArmorUpgrade
    {
        public LeatherWraps(Armor armor) : base(armor)
        {
            UpgradeName = "Leather Wraps";
            UpgradeDefense = 5;
            UpgradeWeight = 2;
            Armor = armor;
        }

        public LeatherWraps()
        {
            UpgradeName = "Leather Wraps";
            UpgradeDefense = 5;
            UpgradeWeight = 2;
        }

        public override Armor Upgrade(Armor selectedArmor)
        {
            return new LeatherWraps(selectedArmor);
        }
        public override string GetName()
        {
            return Armor.GetName() + ", " + UpgradeName;
        }
        public override int GetDefense()
        {
            return Armor.GetDefense() + UpgradeDefense;
        }
        public override int GetWeight()
        {
            return Armor.GetWeight() + UpgradeWeight;
        }
    }
}
